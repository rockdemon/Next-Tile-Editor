using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Next_tile_editor;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using Image = System.Drawing.Image;

namespace Next_tile_editor
{
    public partial class tile32PixImport : UserControl
    {



        public void refreshFromObjs()
        {
            this.pct_OriginalTileBitmap.Image = tileMapObjs.GetInstance().imgOrigin;
            this.pnl_32x32_gauntletMap.Invalidate();
            this.pnl_32_32_TilePalette.Invalidate();
            this.numMapWidth.Value = tileMapObjs.GetInstance().ImportSettings.width_32tiles;
            this.numMapHeight.Value = tileMapObjs.GetInstance().ImportSettings.height_32tiles;
        }

        public tile32PixImport()
        {
            tileMapObjs.GetInstance().ImportSettings = new tileMapObjs.TileSettings();
            InitializeComponent();
            this.DropDown_SuperTileSize.SelectedIndex = 2;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                tileMapObjs.GetInstance().imgOrigin = new Bitmap(image);
                this.pct_OriginalTileBitmap.Image = tileMapObjs.GetInstance().imgOrigin;
                this.tabCutIntoSuperTiles.Select();
                btn_cutIntoTiles.BeginInvoke(btn_CutIntoTiles_Click, new object[] { this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) });
            }
        }
        List<List<Image>> InitialTileImages = new List<List<Image>>();

        /// <summary>
        /// Creates a list of 8x8 px images from the original image for each supertile (either 8x8, 16x16 or 32x32)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CutIntoTiles_Click(object sender, EventArgs e)
        {
            InitialTileImages.Clear();

            int width = tileMapObjs.GetInstance().imgOrigin.Width;
            int height = tileMapObjs.GetInstance().imgOrigin.Height;
            int BigTileIdx = 0;
            tileMapObjs.GetInstance().ImportSettings.tileWidth = width / 8;
            // Remove this line from tile32PixImport:
            // public TileSettingstileMapObjs.GetInstance().ImportSettings;
            tileMapObjs.GetInstance().ImportSettings.tileHeight = height / 8;

            tileMapObjs.GetInstance().ImportSettings.tileGroupWidth = tileMapObjs.GetInstance().ImportSettings.tileWidth / tileMapObjs.GetInstance().ImportSettings.superTileTileWidth;
            tileMapObjs.GetInstance().ImportSettings.tileGroupHeight = tileMapObjs.GetInstance().ImportSettings.tileHeight / tileMapObjs.GetInstance().ImportSettings.superTileTileHeight;

            for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
            {
                for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                {
                    int idx = 0;
                    List<System.Drawing.Image> imageList = new List<System.Drawing.Image>();

                    for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                        {
                            Bitmap imTemp = new Bitmap(8, 8);

                            Rectangle rect = new Rectangle((ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 8) + (x * 8)),
                                                           (iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 8) + (y * 8)),
                            8,
                            8);

                            using (Graphics g = Graphics.FromImage(imTemp))
                            {
                                g.DrawImage(tileMapObjs.GetInstance().imgOrigin, new Rectangle(0, 0, 8, 8),
                                    rect,
                                    GraphicsUnit.Pixel);
                            }
                            imageList.Add(imTemp);

                            idx++;
                        }
                    }
                    InitialTileImages.Add(imageList);
                    BigTileIdx++;
                }
            }
            pnl_32_32_tiles.Invalidate();
            btn_cutIntoTiles.BeginInvoke(btnQuantizeColours_Click, new object[] { this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) });
        }

        private void pnl_32_32_tiles_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            int iTile = 0;
            for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
            {
                for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth /*&& ix < images[iy].Count*/; ix++)
                {
                    for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                        {
                            try
                            {
                                e.Graphics.DrawImageUnscaled(
                                    InitialTileImages[iTile][y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x],
                                    ix * (8 * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth) + scaleFactor * ix + x * 8,
                                    iy * (8 * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight) + scaleFactor * iy + y * 8);
                            }
                            catch { }
                        }
                    }

                    iTile++;
                }
            }
        }

        List<List<paletteValue9bit[]>> NextQuantisedTiles = new List<List<paletteValue9bit[]>>();
        /// <summary>
        /// Goes through the 8x8 px images and quantises the colours to 9 bit colours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuantizeColours_Click(object sender, EventArgs e)
        {
            NextQuantisedTiles.Clear();
            foreach (List<Image> images in this.InitialTileImages)
            {
                List<paletteValue9bit[]> List9BitColours = new List<paletteValue9bit[]>();
                foreach (Image image in images)
                {
                    Bitmap bitmapImage = image as Bitmap;
                    if (bitmapImage == null)
                    {
                        throw new InvalidOperationException("Image is not a Bitmap.");
                    }

                    BitmapData bData = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadWrite, bitmapImage.PixelFormat);

                    byte bitsPerPixel = GetBitsPerPixel(bData.PixelFormat);
                    paletteValue9bit[] baImg = new paletteValue9bit[bitmapImage.Width * bitmapImage.Height];

                    unsafe
                    {
                        byte* scan0 = (byte*)bData.Scan0.ToPointer();

                        for (int y = 0; y < bData.Height; ++y)
                        {
                            for (int x = 0; x < bData.Width; ++x)
                            {
                                byte* data = scan0 + y * bData.Stride + x * bitsPerPixel / 8;

                                //data is a pointer to the first byte of the 3-byte color data  
                                //data[0] = blueComponent;  
                                //data[1] = greenComponent;  
                                //data[2] = redComponent;  
                                Color c = Color.FromArgb(data[2], data[1], data[0]); //BbitmapImage.GetPixel(x, y);
                                baImg[y * bitmapImage.Width + x] = paletteValue9bit.FromColor(c);
                            }
                        }
                    }

                    bitmapImage.UnlockBits(bData);
                    List9BitColours.Add(baImg);
                    //for (int y = 0; y < bitmapImage.Height; y++)
                    //{
                    //    for (int x = 0; x < bitmapImage.Width; x++)
                    //    {
                    //        Color c = bitmapImage.GetPixel(x, y);
                    //        baImg[y * bitmapImage.Width + x] = paletteValue9bit.FromColor(c);
                    //    }
                    //}
                    //List9BitColours.Add(baImg);
                }
                NextQuantisedTiles.Add(List9BitColours);
            }
            pnl_QuantizedColour.Invalidate();
            this.BeginInvoke(btn_CommonTileCheck_Click, new object[] { this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) });
        }

        private void pnl_QuantizedColour_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Green);
            int iTiles = 0;
            try
            {
                for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                    {

                        for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                        {


                            for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                            {
                                var paletteValue9Bits = NextQuantisedTiles[iTiles][y * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight + x];


                                Bitmap bmTemp = new Bitmap(8, 8);
                                IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                for (int ij = 0; ij < 8; ij++)
                                {
                                    for (int ik = 0; ik < 8; ik++)
                                    {
                                        bmwrite.SetPixel(ik, ij, paletteValue9Bits[ij * 8 + ik].PalColor);

                                    }
                                }
                                e.Graphics.DrawImageUnscaled(
                                       bmwrite.ToBitmap(),
                                       ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 8) + 2 * ix + x * 8,
                                       iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 8) + 2 * iy + y * 8);
                            }


                        }


                        iTiles++;
                    }
                }
            }
            catch
            (Exception ex)
            {
                int xxxx = 0;
            }
        }



        /// <summary>
        /// Builds a list of 8x8 px tiles using palette data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CommonTileCheck_Click(object sender, EventArgs e)
        {
            tileMapObjs.GetInstance().palette = new Palette9bit();
            int iPaletteIdx = 0;
            int iTiles = 0;
            tileMapObjs.GetInstance().TileList.Clear();
            for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++) // count through supertiles
            {
                for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++) // count through supertiles
                {
                    for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++) // count through 8x8 tiles within supertile
                    {
                        for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++) // count through 8x8 tiles within supertile
                        {
                            // get palette array for tile we've counted to
                            paletteValue9bit[] paletteValue9Bits = NextQuantisedTiles[iTiles][y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x];

                            foreach (paletteValue9bit pv in paletteValue9Bits)
                            {
                                bool contained = false;
                                for (int xx = 0; xx < iPaletteIdx; xx++)
                                {
                                    if (tileMapObjs.GetInstance().palette.Palettearray[xx].Equals(pv))
                                    {
                                        contained = true;
                                        break;
                                    }
                                }
                                if (contained)
                                    continue;

                                if (!tileMapObjs.GetInstance().palette.Palettearray.Contains(pv)) // add to palette array (A palette array is a palette based bitmap)
                                {
                                    tileMapObjs.GetInstance().palette.Palettearray[iPaletteIdx] = pv;
                                    iPaletteIdx++;
                                }
                            }
                        }
                    }
                    iTiles++; // go through the tile lists
                }
            }

            iTiles = 0;
            tileMapObjs.GetInstance().TileList.Clear();
            for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
            {
                for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                {
                    tileMapObjs.GetInstance().TileList.Add(new List<Tile8x8>()); // new super tile
                    for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                        {
                            var paletteValue9Bits = NextQuantisedTiles[iTiles][y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x];
                            tileMapObjs.GetInstance().TileList[iTiles].Add(Tile8x8.FromPalette9ValArray(paletteValue9Bits, tileMapObjs.GetInstance().palette));
                        }
                    }
                    iTiles++;
                }
            }

            pnl_CommonTiles.Invalidate();
            this.BeginInvoke(btnCreateTileToolboxandMap_Click, new object[] { this, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0) });

        }

        private void pnl_CommonTiles_Paint(object sender, PaintEventArgs e)
        {
            if (tileMapObjs.GetInstance().TileList.Count > 0)
            {
                e.Graphics.Clear(Color.Green);
                int iTiles = 0;
                try
                {
                    for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
                    {
                        for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                        {

                            for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                            {


                                for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                                {

                                    Bitmap bmTemp = new Bitmap(8, 8);
                                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                    for (int ij = 0; ij < 8; ij++)
                                    {
                                        for (int ik = 0; ik < 8; ik++)
                                        {
                                            nibble n = null;
                                            try
                                            {
                                                n = tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x].tileNibbles[ij * 8 + ik];



                                                bmwrite.SetPixel(ik, ij, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                            }
                                            catch (Exception ex)
                                            {
                                                int ififif = 888;
                                            }
                                        }
                                    }
                                    e.Graphics.DrawImageUnscaled(
                                           bmwrite.ToBitmap(),
                                           ix * (8 * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth) + 2 * ix + x * 8,
                                           iy * (8 * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight) + 2 * iy + y * 8);

                                }


                            }


                            iTiles++;
                        }
                    }
                }
                catch
                (Exception ex)
                {
                    int xxxx = 0;
                }
            }
        }
        ///
        /// Palette Offset 4-bit palette offset for this tile. This allows shifting colours to other 16-colour
        /// “banks” thus allowing us to reach the whole 256 colours from the palette.
        /// X Mirror
        /// Y Mirror
        /// Rotate
        /// If 1, this tile will be mirrored in X direction.
        /// If 1, this tile will be mirrored in Y direction.
        /// If 1, this tile will be rotated 90oclockwise.
        /// ULA Mode If1, this tile will be rendered on top, if 0 below ULA display. However in 512
        /// tile mode, this is the 9th bit of tile index.
        /// Tile8x8 Index
        /// 8-bit tile index within the tile definitions.



        private void btnCreateTileToolboxandMap_Click(object sender, EventArgs e)
        {
            int iTiles = 0;
            tileMapObjs.GetInstance().tile32_32_definition_Map.Clear();
            tileMapObjs.GetInstance().tiles.Clear();
            for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++) // height in supertiles
            {
                for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++) // width in supertiles
                {
                    tileMapObjs.GetInstance().TileList.Add(new List<Tile8x8>());
                    for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++) // height of supertile in 8x8 tiles
                    {
                        for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++) // width of supertile in 8x8 tiles
                        {

                            bool found = false;
                            for (int z = 0; z < tileMapObjs.GetInstance().tiles.Count; z++) //count through all 8x8 tiles
                            {
                                Tile8x8 tile8X8 = tileMapObjs.GetInstance().tiles[z];
                                if (!found &&
                                    tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][
                                        y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x].Equals(tile8X8, out bool rotated))
                                {
                                    found = true;
                                    byte iflags = (byte)((int)Modifier.None + (rotated ? (int)Modifier.Rotate : 0));
                                    if (z > 255 && z < 512)
                                    {
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)(1 + iflags), (byte)(z - 256)));

                                    }
                                    else
                                    {
                                        // tile8X8 less than 256
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef(iflags, (byte)z));
                                    }


                                    tile8X8.Index = z;
                                    //           tiles.Add(TileList[iy *tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][y *tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]);
                                    break;

                                }

                                if (!found &&
                                    tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][
                                            y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]
                                        .EqualsHorizontalMirror(tile8X8, out rotated))
                                {
                                    // byte 11 for x mirror
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)(1 + Modifier.XMirror), (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile8X8 less than 256
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)(Modifier.XMirror), (byte)(z - 256)));

                                    }


                                    tile8X8.Index = z;
                                    break;

                                }

                                if (!found &&
                                            tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][
                                            y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]
                                        .EqualsVerticalMirror(tile8X8, out rotated))
                                {
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)((int)Modifier.YMirror | 1), (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile8X8 less than 256
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)Modifier.YMirror, (byte)z));
                                    }

                                    tile8X8.Index = z;
                                    break;

                                }

                                if (!found &&
                                    tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][
                                            y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]
                                        .EqualsVerticalAndHorizontalMirror((tile8X8), out rotated))
                                {
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {

                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)(1 | (int)Modifier.XMirror | (int)Modifier.YMirror), (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile8X8 less than 256
                                        tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef((byte)((int)Modifier.XMirror | (int)Modifier.YMirror), (byte)(z - 256)));
                                    }


                                    tile8X8.Index = z;
                                    break;
                                }
                                //----------------------------------------------------------//
                            }
                            if (!found)
                            {
                                tileMapObjs.GetInstance().tiles.Add(tileMapObjs.GetInstance().TileList[iy * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][
                                    y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]);
                                if (tileMapObjs.GetInstance().tiles.Count <= 256)
                                {
                                    tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef(0, (byte)(tileMapObjs.GetInstance().tiles.Count - 1)));
                                }
                                else
                                {
                                    tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef(1, (byte)(tileMapObjs.GetInstance().tiles.Count - 257)));
                                }

                                Tile8x8 newtile = tileMapObjs.GetInstance().tiles[tileMapObjs.GetInstance().tiles.Count - 1];

                                newtile.Index = tileMapObjs.GetInstance().tiles.Count - 1;
                                //            tiles.Add(TileList[iy *tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + ix][y *tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + x]);
                            }
                        }
                        iTiles++;
                    }
                }
            }

            this.label3.Text = "8x8 Tiles : " + tileMapObjs.GetInstance().tiles.Count;
            pnl_32_32_TilePalette.Size =
                new Size(tileMapObjs.GetInstance().ImportSettings.tileGroupWidth * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 17,
                   tileMapObjs.GetInstance().ImportSettings.tileGroupHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 17);
            pnl_fromActualTilemap.Invalidate();
            pnl_32x32_gauntletMap.Invalidate();
            pnl_32_32_TilePalette.Invalidate();
        }

        private void pnl_fromActualTilemap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Azure);
            if (tileMapObjs.GetInstance().tile32_32_definition_Map.Count == 0 || tileMapObjs.GetInstance().tiles.Count == 0) { return; }
            int iBigTile = 0;
            try
            {
                for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                    {
                        for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                        {
                            for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                            {
                                TileRef tref = tileMapObjs.GetInstance().tile32_32_definition_Map[
                                    (iBigTile * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth)
                                     + (y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth) + x)];
                                int bTile = tref.tileIndex;

                                Tile8x8 t = tileMapObjs.GetInstance().tiles[bTile];
                                Bitmap bmTemp = new Bitmap(8, 8);
                                IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();



                                for (int ij = 0; ij < 8; ij++) // ycount
                                {
                                    for (int ik = 0; ik < 8; ik++) //xcount
                                    {

                                        int nibbleOffset = 0;
                                        if (((int)tref.flags & (int)Modifier.Rotate) == 0)
                                        {


                                            if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                            {
                                                nibbleOffset += (7 - ik);

                                            }
                                            else
                                            {
                                                nibbleOffset += ik;
                                            }

                                            if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                            {
                                                // flip vertically
                                                nibbleOffset += 56 - (ij * 8);
                                            }
                                            else
                                            {
                                                nibbleOffset += ij * 8;


                                            }
                                        }
                                        else
                                        {


                                            // rotate 90 degrees
                                            if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                            {
                                                nibbleOffset += (7 - ij);

                                            }
                                            else
                                            {
                                                nibbleOffset += ij;
                                            }

                                            if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                            {
                                                // flip vertically
                                                nibbleOffset += 56 - (ik * 8);
                                            }
                                            else
                                            {
                                                nibbleOffset += ik * 8;


                                            }
                                        }

                                        nibble n = t.tileNibbles[nibbleOffset];
                                        bmwrite.SetPixel(ik, ij, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                    }
                                }
                                e.Graphics.DrawImageUnscaled(
                                       bmwrite.ToBitmap(),
                                       ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 8) + 2 * ix + x * 8,
                                       iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 8) + 2 * iy + y * 8);
                                if (bShowNumbers)
                                    e.Graphics.DrawString("" + tref.tileIndex, SystemFonts.DialogFont, Brushes.Aqua, ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 8) + 2 * ix + x * 8, iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 8) + 2 * iy + y * 8);

                            }
                        }

                        iBigTile++;
                    }
                }
            }
            catch (Exception ex)
            {
                int ffff = 9;
            }
            this.btnExportTile_32_Tile_8.Enabled = true;
        }

        /// <summary>
        /// get_8_8_TileMapBytesForSaving returns a byte array for saving as a next l3 16 bit aligned tilemap.
        /// gauntletMap is the map of 32 x 32 tiles that we're saving. It's numwidth x numheight
        /// tile32_32_definition_Map is the list of tiles in the 32x32 supertiles. in 4x4 mode each is 16 tiles long. Each
        /// super tile runs in order so thats
        /// t1:x0y0 t1:x1:y0 t1:x2,y0 t1:x3,y0 t1 x0y1 x1y1 x2y1 x3y1 x0y2x1y2 x2y2 x3y2 x0y3 x1y3 x2y3 x3y3 t2:x0y0
        /// so you go 16 at a time to get to the right supertile then the 16tiles at that point should match the index from gauntletmap
        /// </summary>
        /// <returns></returns>

        public byte[] get_8_8_TileMapBytesForSaving()
        {
            List<byte> retList = new List<byte>();
            for (int iw = 0; iw < (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * numMapWidth.Value) * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * numMapHeight.Value) * 2; iw++)
            {
                retList.Add((byte)0);
            }

            int iBigTile = 0;
            //   for (int ij=0; ij <tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; ij++) // y (row)
            for (int ij = 0; ij < numMapHeight.Value; ij++) // y (row)
            {
                for (int ik = 0; ik < numMapWidth.Value; ik++) // x
                {
                    int bSuperTileIndex = tileMapObjs.GetInstance().gauntletMap[ij][ik];
                    for (int j = 0; j < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; j++)
                    {
                        for (int k = 0; k < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; k++)
                        {
                            TileRef tref = tileMapObjs.GetInstance().tile32_32_definition_Map[(bSuperTileIndex * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth)) //big tile ref
                                                                                                                                                                                                                                               // big tile left
                                                                + (j * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth) + k];

                            int rowChars = (int)numMapWidth.Value * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth;
                            int rety = ij * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight + j;
                            int retx = ik * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth + k;
                            int idx = rety * rowChars + retx;



                            retList[idx * 2 + 1] = tref.flags;
                            retList[idx * 2] = tref.index;


                        }
                    }

                    iBigTile++;
                }
            }

            return retList.ToArray();
        }

        private void btnExportTile_32_Tile_8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] linearFileMapBytes = get_8_8_TileMapBytesForSaving();
                File.WriteAllBytes(saveFileDialog.FileName + ".tileMap", linearFileMapBytes);
                //tile32_32_definition_Map
                //tile32_32_definition_Map[(iBigTile * 16) + (y * 4) + x];
                List<byte> outTileBytes = new List<byte>();
                foreach (Tile8x8 t in tileMapObjs.GetInstance().tiles)
                {
                    outTileBytes.AddRange(t.tileData);
                }
                File.WriteAllBytes(saveFileDialog.FileName + ".tileDefs", outTileBytes.ToArray());
                File.WriteAllBytes(saveFileDialog.FileName + ".tilePal", tileMapObjs.GetInstance().palette.SaveByteArray);

            }
        }

        private void pnl_32_32_TilePalette_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Azure);
            if (tileMapObjs.GetInstance().tile32_32_definition_Map.Count == 0 || tileMapObjs.GetInstance().tiles.Count == 0) { return; }
            int iBigTile = 0;
            try
            {
                for (int iy = 0; iy < tileMapObjs.GetInstance().ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0; ix < tileMapObjs.GetInstance().ImportSettings.tileGroupWidth; ix++)
                    {
                        if (e.Graphics.ClipBounds.IntersectsWith(new Rectangle(ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16))))
                        {


                            for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
                            {
                                for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                                {
                                    TileRef tref = tileMapObjs.GetInstance().tile32_32_definition_Map[
                                        (iBigTile * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth)
                                         + (y * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth) + x)];

                                    int bTile = tref.tileIndex;
                                    Tile8x8 t = tileMapObjs.GetInstance().tiles[bTile];
                                    Bitmap bmTemp = new Bitmap(16, 16);
                                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                    for (int ij = 0; ij < 8; ij++)
                                    {
                                        for (int ik = 0; ik < 8; ik++)
                                        {
                                            nibble n;
                                            int nibbleOffset = 0;//ij * 8 + ik;
                                            if (((int)tref.flags & (int)Modifier.Rotate) == 0)
                                            {
                                                if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                                {
                                                    nibbleOffset += (7 - ik);
                                                }
                                                else
                                                {
                                                    nibbleOffset += ik;
                                                }

                                                if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                                {
                                                    // flip vertically
                                                    nibbleOffset += 56 - (ij * 8);
                                                }
                                                else
                                                {
                                                    nibbleOffset += ij * 8;


                                                }
                                            }
                                            else
                                            {


                                                // rotate 90 degrees
                                                if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                                {
                                                    nibbleOffset += (7 - ij);

                                                }
                                                else
                                                {
                                                    nibbleOffset += ij;
                                                }

                                                if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                                {
                                                    // flip vertically
                                                    nibbleOffset += 56 - (ik * 8);
                                                }
                                                else
                                                {
                                                    nibbleOffset += ik * 8;


                                                }
                                            }

                                            try
                                            {
                                                n = t.tileNibbles[nibbleOffset];
                                                bmwrite.SetPixel(ik * 2, ij * 2, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                                bmwrite.SetPixel(ik * 2 + 1, ij * 2, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                                bmwrite.SetPixel(ik * 2, ij * 2 + 1, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                                bmwrite.SetPixel(ik * 2 + 1, ij * 2 + 1, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                                            }
                                            catch (Exception exception)
                                            {
                                                Console.WriteLine(exception);
                                                throw;
                                            }





                                        }
                                    }
                                    e.Graphics.DrawImageUnscaled(
                                           bmwrite.ToBitmap(),
                                           ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * ix + x * 16 + 1,
                                           iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * iy + y * 16 + 1);
                                    if (bShowNumbers)
                                    {
                                        e.Graphics.DrawString("" + tref.tileIndex, SystemFonts.DialogFont, Brushes.Aqua,
                                            ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * ix + x * 16 + 1,
                                            iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * iy + y * 16 + 1);
                                    }
                                    if (iBigTile == iSelectedIndex)
                                    {
                                        e.Graphics.DrawRectangle(Pens.Black,
                                                                ix * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * ix + x * 16 + 1,
                                                                iy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * iy + y * 16 + 1,
                                                                16, 16);
                                    }

                                }
                            }
                        }
                        iBigTile++;


                    }
                }
            }
            catch (Exception ex)
            {
                int x = 999999;
            }
        }

        private Bitmap get_32_32_TileBitMap(int iBigTile)
        {
            Bitmap retBm = new Bitmap(BigtilewidthInPx, BigtileheightInPx);
            for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.superTileTileHeight; y++)
            {
                for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.superTileTileWidth; x++)
                {
                    TileRef tref =
                        tileMapObjs.GetInstance().tile32_32_definition_Map[
                            (iBigTile * (tileMapObjs.GetInstance().ImportSettings.NumberOfTilesPerSuperTile)) +
                            (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * y) + x];
                    int bTile = tref.tileIndex;
                    Tile8x8 t = tileMapObjs.GetInstance().tiles[bTile];
                    nibble[] nib = t.tileNibbles;
                    if (((int)tref.flags & (int)Modifier.Rotate) > 0)
                    {
                        nib = t.Rotated;
                    }
                    Bitmap bmTemp = new Bitmap(8, 8);
                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                    for (int ij = 0; ij < 8; ij++)
                    {
                        for (int ik = 0; ik < 8; ik++)
                        {

                            int nibbleOffset = 0;//ij * 8 + ik;
                            if (((int)tref.flags & (int)Modifier.Rotate) == 0)
                            {
                                if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                {
                                    nibbleOffset += (7 - ik);
                                }
                                else
                                {
                                    nibbleOffset += ik;
                                }

                                if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                {
                                    // flip vertically
                                    nibbleOffset += 56 - (ij * 8);
                                }
                                else
                                {
                                    nibbleOffset += ij * 8;


                                }
                            }
                            else
                            {


                                // rotate 90 degrees
                                if (((int)tref.flags & (int)Modifier.YMirror) > 0)
                                {
                                    nibbleOffset += (7 - ij);

                                }
                                else
                                {
                                    nibbleOffset += ij;
                                }

                                if (((int)tref.flags & (int)Modifier.XMirror) > 0)
                                {
                                    // flip vertically
                                    nibbleOffset += 56 - (ik * 8);
                                }
                                else
                                {
                                    nibbleOffset += ik * 8;


                                }
                            }
                            nibble n = t.tileNibbles[nibbleOffset];
                            bmwrite.SetPixel(ik, ij, tileMapObjs.GetInstance().palette.Palettearray[n].PalColor);
                        }
                    }

                    Graphics.FromImage(retBm).DrawImageUnscaled(
                           bmwrite.ToBitmap(),
                           x * 8,
                           y * 8);
                }
            }
            return retBm;
        }

        int iSelectedIndex = 0;

        private void pnl_32_32_TilePalette_MouseDown(object sender, MouseEventArgs e)
        {


            int tileX = (e.Location.X + 1) / (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 17);

            int tileY = (e.Location.Y + 1) / (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 17);


            //this.textBox1.Text = "" + tileX + " " + tileY + " " + (tileY * 8 + tileX);

            int oldy = iSelectedIndex / tileMapObjs.GetInstance().ImportSettings.tileGroupWidth;
            int oldx = iSelectedIndex % tileMapObjs.GetInstance().ImportSettings.tileGroupWidth;
            //pnl_32_32_TilePalette.Invalidate(new Rectangle(oldx * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16)  /*+ 2 * oldx*/, oldy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + 2 * oldy, (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16)));
            pnl_32_32_TilePalette.Invalidate(new Rectangle(
                oldx * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * oldx + 1,
                oldy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * oldy + 1,
                (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16)));

            iSelectedIndex = tileY * tileMapObjs.GetInstance().ImportSettings.tileGroupWidth + tileX;

            int newy = iSelectedIndex / tileMapObjs.GetInstance().ImportSettings.tileGroupWidth;
            int newx = iSelectedIndex % tileMapObjs.GetInstance().ImportSettings.tileGroupWidth;
            //pnl_32_32_TilePalette.Invalidate(new Rectangle(newx * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) /*+ 2 * newx*/, newy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + 2 * newy, (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16)));
            pnl_32_32_TilePalette.Invalidate(new Rectangle(
                newx * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * newx + 1,
                newy * (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16) + tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * newy + 1,
                (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16), (tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * 16)));

        }
        // mouse.locationx = newx * (tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * 16) +tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * newx+1,
        // mouselocx +1 = newx * sup*16 + sup *newx
        // newx = mouselocx+1/((sup*16)+sup)


        private void pnl_gauntletMap_Paint(object sender, PaintEventArgs e)
        {
            if (tileMapObjs.GetInstance().gauntletMap.Count == 0)
            {
                for (int j = 0; j < numMapHeight.Value; j++)
                {


                    tileMapObjs.GetInstance().gauntletMap.Add(new byte[(int)numMapWidth.Value]);
                }
            }

            e.Graphics.FillRectangle(new SolidBrush(Color.Azure), e.Graphics.ClipBounds);
            if (tileMapObjs.GetInstance().tile32_32_definition_Map.Count == 0 || tileMapObjs.GetInstance().tiles.Count == 0) { return; }

            try
            {
                for (int iy = 0; iy < numMapHeight.Value; iy++)
                {
                    for (int ix = 0; ix < numMapWidth.Value; ix++)
                    {

                        RectangleF clipRect = new RectangleF(ix * (this.BigtilewidthInPx),
                            iy * (this.BigtileheightInPx),
                            (this.BigtilewidthInPx),
                            (this.BigtileheightInPx));
                        if (e.Graphics.ClipBounds.IntersectsWith(clipRect))
                        {
                            byte bTile = tileMapObjs.GetInstance().gauntletMap[iy][ix];
                            Bitmap bmTemp = get_32_32_TileBitMap(bTile);

                            IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                            e.Graphics.DrawImageUnscaled(
                                    bmwrite.ToBitmap(),
                                    ix * (scaleFactor * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth),
                                    iy * scaleFactor * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight);
                            if (this.ShowGridLines)
                                e.Graphics.DrawRectangle(Pens.Gray, clipRect.X, clipRect.Y, clipRect.Width, clipRect.Height);
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                int x = 0; int y = 0;
            }
        }


        void setLocationOn_32_MapEd(Point mouseLocation, bool invalidate, bool delete = false, bool MouseChanged=false)
        {
            try
            {
                int iy = (int)mouseLocation.Y / ((scaleFactor) * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight);
                int ix = (int)mouseLocation.X / ((scaleFactor) * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth);
                if (MouseChanged)
                {
                    _lastMouseX = ix;
                    _lastMouseY = iy;
                }
                if (!delete)
                {
                
                        tileMapObjs.GetInstance().gauntletMap[iy][ix] = (byte)iSelectedIndex;
                }
                else
                {
                    tileMapObjs.GetInstance().gauntletMap[iy][ix] = 0;
                }
                if (chkZingotMode.Checked)
                {


                    ZingotMode(_lastMouseX, _lastMouseY, ix, iy);
                 
                }
                invalidate = true;

                if (invalidate)
                {
                    Rectangle r = new Rectangle(
                        (ix - 1) * ((scaleFactor) * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth),
                        (iy - 1) * ((scaleFactor) * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight),
                        (3 * scaleFactor * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth * tileMapObjs.GetInstance().ImportSettings.superTileTileWidth),
                        (3 * scaleFactor * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight * tileMapObjs.GetInstance().ImportSettings.superTileTileHeight));
                    pnl_32x32_gauntletMap.Invalidate(r);
                }

         
            }
            catch (Exception ex) { }

        }

        bool mouseDown = false;
        private int _lastMouseX = -1;
        private int _lastMouseY = -1;
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.setLocationOn_32_MapEd(e.Location, true, e.Button == MouseButtons.Right, MouseChanged: true);
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;

        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown) { this.setLocationOn_32_MapEd(e.Location, true, e.Button == MouseButtons.Right); }
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            this.mouseDown = false;
            _lastMouseX = -1;
            _lastMouseY = -1;

        }

        private void btn_Save32_32px_tilemap(object sender, EventArgs e)
        {
            List<byte> bytesSaveMap = new List<byte>();
            foreach (var v in tileMapObjs.GetInstance().gauntletMap)
            {
                bytesSaveMap.AddRange(v);
            }
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(sfd.FileName, bytesSaveMap.ToArray());
            }


        }

        private void btnLoad_32_32_px_tilemap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] baBytes = File.ReadAllBytes(openFileDialog.FileName);
                tileMapObjs.GetInstance().gauntletMap.Clear();
                for (int iy = 0; iy < 64; iy++)
                {
                    byte[] baRow = new byte[64];
                    for (int ix = 0; ix < 64; ix++)
                    {
                        baRow[ix] = baBytes[iy * 64 + ix];
                    }
                    tileMapObjs.GetInstance().gauntletMap.Add(baRow);
                }

                //    tileMapObjs.GetInstance().gauntletMap = (List<byte[]>) baBytes.Chunk(64);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;
                if (FileName.EndsWith(".tile32_32_definition_Map") || FileName.EndsWith(".tileDefs") || FileName.EndsWith(".tilePal"))
                {
                    List<string> list = new List<string>(FileName.Split("."));
                    list.RemoveAt(list.Count - 1);
                    FileName = string.Join(".", list);
                }

                byte[] tempBytes = File.ReadAllBytes(FileName + ".tile32_32_definition_Map");
                for (int i = 0; i < tempBytes.Length / 2; i++)
                {
                    tileMapObjs.GetInstance().tile32_32_definition_Map.Add(new TileRef(tempBytes[i * 2], tempBytes[i * 2 + 1]));
                }

                tileMapObjs.GetInstance().palette = Palette9bit.FromByteArray(
                     File.ReadAllBytes(FileName + ".tilePal"));
                byte[] outTileBytes = File.ReadAllBytes(FileName + ".tileDefs");
                // now reverse park those bytes into tiles

                tileMapObjs.GetInstance().tiles = new List<Tile8x8>();
                for (int i = 0; i < outTileBytes.Length / 32; i++)
                {
                    byte[] baTemp = new byte[32];
                    for (int j = 0; j < 32; j++)
                    {
                        baTemp[j] = (byte)(outTileBytes[i * 32 + j]);
                    }
                    tileMapObjs.GetInstance().tiles.Add(new Tile8x8(tileMapObjs.GetInstance().palette, 0, baTemp));
                }

            }
        }

        private void btnTileLeft_Click(object sender, EventArgs e)
        {
            if (iSelectedIndex > 0)
            {
                List<Image> itemp = InitialTileImages[iSelectedIndex]; // from

                //    int idx2 = Math.DivRem(iSelectedIndex-1,8, out int rem2);
                InitialTileImages[iSelectedIndex] = InitialTileImages[iSelectedIndex - 1];
                InitialTileImages[iSelectedIndex - 1] = itemp;
                btnQuantizeColours_Click(null, null);


                pnl_32_32_tiles.Invalidate();
            }
        }

        private void btnRightTile_Click(object sender, EventArgs e)
        {
            if (iSelectedIndex < InitialTileImages.Count - 1)
            {
                List<Image> itemp = InitialTileImages[iSelectedIndex]; // from

                //    int idx2 = Math.DivRem(iSelectedIndex-1,8, out int rem2);
                InitialTileImages[iSelectedIndex] = InitialTileImages[iSelectedIndex + 1];
                InitialTileImages[iSelectedIndex + 1] = itemp;
                btnQuantizeColours_Click(null, null);


                pnl_32_32_tiles.Invalidate();
            }
        }

        private int scaleFactor = 2;
        private int BigtilewidthInPx = 32;
        private int BigtileheightInPx = 32;

        private void DropDown_SuperTileSize_ValueChanged(object sender, EventArgs e)
        {
            switch (DropDown_SuperTileSize.SelectedIndex)
            {
                case 0:     //1x1
                    tileMapObjs.GetInstance().ImportSettings.NumberOfTilesPerSuperTile = 1;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileHeight = 1;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileWidth = 1;
                    this.scaleFactor = 8;
                    this.BigtilewidthInPx = 8;
                    this.BigtileheightInPx = 8;

                    break;

                case 1:     //2x2
                    tileMapObjs.GetInstance().ImportSettings.NumberOfTilesPerSuperTile = 4;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileHeight = 2;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileWidth = 2;
                    this.scaleFactor = 4;
                    this.BigtilewidthInPx = 16;
                    this.BigtileheightInPx = 16;

                    break;
                case 2:     //3x3
                    tileMapObjs.GetInstance().ImportSettings.NumberOfTilesPerSuperTile = 16;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileHeight = 4;
                    tileMapObjs.GetInstance().ImportSettings.superTileTileWidth = 4;
                    this.scaleFactor = 2;
                    this.BigtilewidthInPx = 32;
                    this.BigtileheightInPx = 32;

                    break;

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ShowGridLines = checkBox1.Checked;
            pnl_32x32_gauntletMap.Invalidate();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        bool bShowNumbers = true;

        private void chknumbers_CheckedChanged(object sender, EventArgs e)
        {
            bShowNumbers = this.chknumbers.Checked;
        }

        private byte GetBitsPerPixel(PixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case PixelFormat.Format1bppIndexed:
                    return 1;
                case PixelFormat.Format4bppIndexed:
                    return 4;
                case PixelFormat.Format8bppIndexed:
                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                    return 16;
                case PixelFormat.Format24bppRgb:
                    return 24;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    return 32;
                case PixelFormat.Format48bppRgb:
                    return 48;
                case PixelFormat.Format64bppArgb:
                case PixelFormat.Format64bppPArgb:
                    return 64;
                default:
                    throw new ArgumentException("Unsupported pixel format: " + pixelFormat);
            }
        }

        private void numMapWidth_ValueChanged(object sender, EventArgs e)
        {
            tileMapObjs.GetInstance().ImportSettings.width_32tiles = (int)numMapWidth.Value;
        }

        private void numMapHeight_ValueChanged(object sender, EventArgs e)
        {
            tileMapObjs.GetInstance().ImportSettings.height_32tiles = (int)numMapHeight.Value;
        }

        public bool ShowGridLines
        {
            get;
            set;
        }

        private bool place_meeting(int x, int y, int tilenumber)
        {
            if (x <1 ||y < 1 || x >= tileMapObjs.GetInstance().gauntletMap[0].Length || y >= tileMapObjs.GetInstance().gauntletMap.Count)
                return false; // out of bounds check
            if (tileMapObjs.GetInstance().gauntletMap[y][x] == tilenumber)
                return true;
            else return false;

        }
        /// <summary>
        /// In Gamemaker I use a generic wall tile (object_index) and my code scans the room (x,y) and when it finds object_index it checks around it to determine the correct wall tile that needs to be placed at that position. 
        /// Then the loop continues.
        /// </summary>
        /// <param name="tile_x"></param>
        /// <param name="tile_y"></param>
        /// <param name="tile_size"></param>
        //tile_x      = argument0;	// current x tile position in the map
        //tile_y      = argument1;	// current y tile position in the map
        //tile_size   = argument2;	// added to this function for usage elsewhere (can be hardcoded)
        public void ZingotMode(int old_x, int old_y, int new_x, int new_y)
        {
            var map = tileMapObjs.GetInstance().gauntletMap;
            //map[new_y][new_x] = (byte)basetile; // no change
            for (int gy = 0; gy < numMapHeight.Value; gy += 1)
            {
                for (int gx = 0; gx < numMapWidth.Value; gx += 1)
                {
                    if (map[gy] [gx] != 0)
                    {
                        map[gy][gx] = (byte)zingotSub(gx, gy);
                    }
                }
            }
            ///// Check Mouse Input & Perform Autotile Logic

            //// Grab Mouse X,Y snapped to tile grid
            //mx = clamp(floor(device_mouse_x(0) / 16), 0, 15);
            //my = clamp(floor(device_mouse_y(0) / 16), 0, 11);

            //// Draw Tile
            //if device_mouse_check_button(0, mb_left) {
            //    global.grid_array[mx, my] = 45;
            //    for (gy = 0; gy < 12; gy += 1)
            //    {
            //        for (gx = 0; gx < 16; gx += 1)
            //        {
            //            if (global.grid_array[gx, gy] <> 0)
            //            {
            //                global.grid_array[gx, gy] = autotile(gx, gy);
            //            }
            //        }
            //    }
            //}

            //// Erase Tile
            //if device_mouse_check_button(0, mb_right) {
            //    global.grid_array[mx, my] = 0;
            //    for (gy = 0; gy < 12; gy += 1)
            //    {
            //        for (gx = 0; gx < 16; gx += 1)
            //        {
            //            if (global.grid_array[gx, gy] <> 0)
            //            {
            //                global.grid_array[gx, gy] = autotile(gx, gy);
            //            }
            //        }
            //    }
            //
        }

        public int zingotSub(int tile_x, int tile_y) //, int tile_size=1, int object_index=45 )
        {

            //int iw = tile_size;

            // Autotile(tx, ty)

            // current tile
            int tx = tile_x; // current x tile position in the map
            int ty = tile_y; // current y tile position in the map

            // surrounding tiles
            int tile, w_left, w_right, w_up, w_down, w_upleft, w_downleft, w_upright, w_downright;
            tile = 45;
            w_left = 0;
            w_right = 0;
            w_up = 0;
            w_down = 0;
            w_upleft = 0;
            w_downleft = 0;
            w_upright = 0;
            w_downright = 0;
            try
            {


                var map = tileMapObjs.GetInstance().gauntletMap;
                // array boundary checks (determine vars as true/false)
                w_left = (tx > 0 && map[ty][tx - 1] != 0) ? 1 : 0;
                //if tx > 0  { if global.grid_array[tx - 1, ty] <> 0 { w_left = 1; } else { w_left = 0; } }

                //if tx < 16 { if global.grid_array[tx + 1, ty] <> 0 { w_right = 1; } else { w_right = 0; } }
                w_right = (tx < numMapWidth.Value && map[ty][tx + 1] != 0) ? 1 : 0;

                //if ty > 0  { if global.grid_array[tx, ty - 1] <> 0 { w_up = 1; } else { w_up = 0; } }
                w_up = (ty > 0 && map[ty - 1][tx] != 0) ? 1 : 0;

                //if ty < 12 { if global.grid_array[tx, ty + 1] <> 0 { w_down = 1; } else { w_down = 0; } }
                w_down = (ty < numMapHeight.Value && map[ty + 1][tx] != 0) ? 1 : 0;

                //if (tx > 0) && (ty > 0) { if global.grid_array[tx - 1, ty - 1] <> 0 { w_upleft = 1; } else { w_upleft = 0; } }
                w_upleft = (tx > 0 && ty > 0 && map[ty - 1][tx - 1] != 0) ? 1 : 0;

                //if (tx > 0) && (ty < 12) { if global.grid_array[tx - 1, ty + 1] <> 0 { w_downleft = 1; } else { w_downleft = 0; } }
                w_downleft = (tx > 0 && ty < numMapHeight.Value && map[ty + 1][tx - 1] != 0) ? 1 : 0;

                //if (tx < 16) && (ty > 0) { if global.grid_array[tx + 1, ty - 1] <> 0 { w_upright = 1; } else { w_upright = 0; } }
                w_upright = (tx < numMapWidth.Value && ty > 0 && map[ty - 1][tx + 1] != 0) ? 1 : 0;

                //if (tx < 16) && (ty < 12) { if global.grid_array[tx + 1, ty + 1] <> 0 { w_downright = 1; } else { w_downright = 0; } }
                w_downright = (tx < numMapWidth.Value && ty < numMapHeight.Value && map[ty + 1][tx + 1] != 0) ? 1 : 0;

                // dictate the tile to replace at tx,ty position
                if (w_up > 0)
                {
                    tile = 1;
                    if (w_right > 0)
                    {
                        tile = 5;
                        if (w_down > 0)
                        {
                            tile = 13;
                            if (w_left > 0)
                            {
                                tile = 29;
                                if (w_upright > 0)
                                {
                                    tile = 30;
                                    if (w_downright > 0)
                                    {
                                        tile = 34;
                                        if (w_downleft > 0)
                                        {
                                            tile = 40;
                                            if (w_upleft > 0)
                                            {
                                                tile = 44;
                                            }
                                        }
                                        else if (w_upleft > 0)
                                        {
                                            tile = 41;
                                        }
                                    }
                                    else if (w_downleft > 0)
                                    {
                                        tile = 38;
                                        if (w_upleft > 0)
                                        {
                                            tile = 42;
                                        }
                                    }
                                    else if (w_upleft > 0)
                                    {
                                        tile = 37;
                                    }
                                }
                                else if (w_downright > 0)
                                {
                                    tile = 31;
                                    if (w_downleft > 0)
                                    {
                                        tile = 35;
                                        if (w_upleft > 0)
                                        {
                                            tile = 43;
                                        }
                                    }
                                    else if (w_upleft > 0)
                                    {
                                        tile = 39;
                                    }
                                }
                                else if (w_downleft > 0)
                                {
                                    tile = 32;
                                    if (w_upleft > 0) tile = 36;
                                }
                                else if (w_upleft > 0)
                                {
                                    tile = 33;
                                }
                            }
                            else if (w_upright > 0)
                            {
                                tile = 17;
                                if (w_downright > 0)
                                {
                                    tile = 19;
                                }
                            }
                            else if (w_downright > 0)
                            {
                                tile = 18;
                            }
                        }
                        else if (w_left > 0)
                        {
                            tile = 16;
                            if (w_upright > 0)
                            {
                                tile = 26;
                                if (w_upleft > 0)
                                {
                                    tile = 28;
                                }
                            }
                            else if (w_upleft > 0)
                            {
                                tile = 27;
                            }
                        }
                        else if (w_upright > 0)
                        {
                            tile = 9;
                        }
                    }
                    else if (w_down > 0)
                    {
                        tile = 46;
                        if (w_left > 0)
                        {
                            tile = 15;
                            if (w_downleft > 0)
                            {
                                tile = 23;
                                if (w_upleft > 0)
                                {
                                    tile = 25;
                                }
                            }
                            else if (w_upleft > 0)
                            {
                                tile = 24;
                            }
                        }
                    }
                    else if (w_left > 0)
                    {
                        tile = 8;
                        if (w_upleft > 0)
                        {
                            tile = 12;
                        }
                    }
                }


                else if (w_right > 0)
                {
                    tile = 2;
                    if (w_down > 0)
                    {
                        tile = 6;
                        if (w_left > 0)
                        {
                            tile = 14;
                            if (w_downright > 0)
                            {
                                tile = 20;
                                if (w_downleft > 0)
                                {
                                    tile = 22;
                                }
                            }
                            else if (w_downleft > 0)
                            {
                                tile = 21;
                            }
                        }
                        else if (w_downright > 0)
                        {
                            tile = 10;
                        }
                    }
                    else if (w_left > 0)
                    {
                        tile = 47;
                    }
                }


                else if (w_down > 0)
                {
                    tile = 3;
                    if (w_left > 0)
                    {
                        tile = 7;
                        if (w_downleft > 0)
                        {
                            tile = 11;
                        }
                    }
                }


                else if (w_left > 0)
                {
                    tile = 4;
                }
            }
            catch (Exception ex)
            {
                tile = 45;
            }

            return tile;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < tileMapObjs.GetInstance().ImportSettings.width_32tiles; x++)
            {
                for (int y = 0; y < tileMapObjs.GetInstance().ImportSettings.height_32tiles; y++)
                {
                    ZingotMode(x, y,1,44);
                }
            }
            
        }
    }
    class DBPanel : Panel
    {
        public DBPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
