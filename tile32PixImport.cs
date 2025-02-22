using KGySoft.CoreLibraries;
using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Next_tile_editor
{
    public partial class tile32PixImport : UserControl
    {
        public class TileSettings
        {
            /// <summary>
            /// Number of 8x8 px tiles in each supertile
            /// </summary>
            public int NumberOfTilesPerSuperTile { get; set; } = 16;
            /// <summary>
            /// How many super tiles in the import horizontally
            /// </summary>
            public int ImportTilesInX { get; set; } = 8;
            /// <summary>
            /// How many super tiles in the import vertically
            /// </summary>
            public int ImportTilesInY { get; set; } = 8;

            /// <summary>
            /// How many 8px squares are there horizontally in one super tile
            /// </summary>
            public int superTileTileWidth { get; set; } = 4;
            /// <summary>
            /// How many 8px squares are there vertically in one super tile
            /// </summary>
            public int superTileTileHeight { get; set; } = 4;
            /// <summary>
            /// How manage 8 px squares in the import horizontally
            /// </summary>
            public int tileWidth {get;set; }
            /// How manage 8 px squares in the import vertically
            public int tileHeight { get;set; }

            /// <summary>
            /// /  how many groups of 1,2 or 4 tiles left to right
            /// </summary>
            public int tileGroupWidth { get; set; }
            /// <summary>
            /// //  how many groups of 1,2 or 4 tiles top to bottom
            /// </summary>
            public int tileGroupHeight { get; set; } //  how many groups of 1,2 or 4 tiles top to bottom

        }

        public TileSettings ImportSettings { get; set; }
        Image imgOrigin = null;
        public tile32PixImport()
        {
            this.ImportSettings = new TileSettings();
            InitializeComponent();
            this.DropDown_SuperTileSize.SelectedIndex = 2;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                imgOrigin = new Bitmap(image);
                this.pct_OriginalTileBitmap.Image = imgOrigin;
                this.tabCutIntoSuperTiles.Select();
                btn_cutIntoTiles.BeginInvoke(btn_CutIntoTiles_Click, new object[] { this, new MouseEventArgs(MouseButtons.Left,1,0,0,0)});
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
     
            int width = imgOrigin.Width;
            int height = imgOrigin.Height;
            int BigTileIdx = 0;
            ImportSettings.tileWidth = width / 8;
            ImportSettings.tileHeight = height / 8;

            ImportSettings.tileGroupWidth = ImportSettings.tileWidth / this.ImportSettings.superTileTileWidth;
            ImportSettings.tileGroupHeight = ImportSettings.tileHeight / this.ImportSettings.superTileTileHeight;
            
            for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
            {
                for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++)
                {
                    int idx = 0;
                    List<Image> imageList = new List<Image>();
       
                    for (int y = 0; y < this.ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < this.ImportSettings.superTileTileWidth ; x++)
                        {
                            Bitmap imTemp = new Bitmap(8, 8);
                            
                            Rectangle rect = new Rectangle((ix * (this.ImportSettings.superTileTileWidth * 8) + (x * 8)), 
                                                           (iy * (this.ImportSettings.superTileTileHeight * 8) + (y * 8)), 
                                                            8, 
                                                            8);
                            using (Graphics g = Graphics.FromImage(imTemp))
                            {
                                g.DrawImage(imgOrigin, new Rectangle(0, 0, 8, 8),
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
            for (int iy = 0; iy < ImportSettings.tileGroupHeight ; iy++)
            {
                for (int ix = 0; ix < ImportSettings.tileGroupWidth /*&& ix < images[iy].Count*/; ix++)
                {
                    for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                        {
                            try
                            {
                                e.Graphics.DrawImageUnscaled(
                                    InitialTileImages[iTile][y * ImportSettings.superTileTileWidth + x],
                                    ix * (8 * ImportSettings.superTileTileWidth) + scaleFactor * ix + x * 8,
                                    iy * (8 * ImportSettings.superTileTileHeight) + scaleFactor * iy + y * 8);
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
                    paletteValue9bit[] baImg = new paletteValue9bit[image.Width * image.Height];
                    for (int y = 0; y < image.Height; y++)
                    {
                        for (int x = 0; x < image.Width; x++)
                        {
                            Color c = (image as Bitmap).GetPixel(x, y);
                            baImg[y * image.Width + x] = paletteValue9bit.FromColor(c);
                        }
                    }
                    List9BitColours.Add(baImg);

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
                for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++)
                    {

                        for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                        {


                            for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                            {
                                var paletteValue9Bits = NextQuantisedTiles[iTiles][y * ImportSettings.superTileTileHeight + x];


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
                                       ix * (ImportSettings.superTileTileWidth*8) + 2 * ix + x * 8,
                                       iy * (ImportSettings.superTileTileHeight*8)  + 2 * iy + y * 8);
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

        
        List<List<Tile>> TileList = new List<List<Tile>>();
        Palette9bit palette = new Palette9bit();
        /// <summary>
        /// Builds a list of 8x8 px tiles using palette data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CommonTileCheck_Click(object sender, EventArgs e)
        {
            palette = new Palette9bit();
            int iPaletteIdx = 0;
            int iTiles = 0;
            TileList.Clear();
            for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++) // count through supertiles
            {
                for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++) // count through supertiles
                {
                    for (int y = 0; y < ImportSettings.superTileTileHeight; y++) // count through 8x8 tiles within supertile
                    {
                        for (int x = 0; x < ImportSettings.superTileTileWidth; x++) // count through 8x8 tiles within supertile
                        {
                            // get palette array for tile we've counted to
                            paletteValue9bit[] paletteValue9Bits = NextQuantisedTiles[iTiles][y * ImportSettings.superTileTileWidth + x];
                            
                            //if (palette.Palettearray[0].Equals(paletteValue9Bits[]))
                            //{

                            //}
                            //else if(palette.Palettearray[iPaletteIdx - 1].Equals(paletteValue9Bits[]))
                            //{
                                
                            //}
                            //else
                            //{
                            //}


                            foreach (paletteValue9bit pv in paletteValue9Bits)
                            {
                                bool contained = false;
                                for (int xx = 0; xx < iPaletteIdx; xx++)
                                {
                                    if (palette.Palettearray[xx].Equals(pv))
                                    {
                                        contained = true;
                                        break;
                                    }
                                }
                                if (contained)
                                    continue;

                                if (!palette.Palettearray.Contains(pv)) // add to palette array (A palette array is a palette based bitmap)
                                {
                                    palette.Palettearray[iPaletteIdx] = pv;

                                    iPaletteIdx++;
                                }


                            }
                        }

                    }

                    iTiles++; // go through the tile lists
                }
            }

            iTiles = 0;
            TileList.Clear();
            for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
            {
                for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++)
                {
                    TileList.Add(new List<Tile>()); // new super tile
                    for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                    {
                        for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                        {
                            var paletteValue9Bits = NextQuantisedTiles[iTiles][y * ImportSettings.superTileTileWidth + x];


                            TileList[iTiles].Add(Tile.FromPalette9ValArray(paletteValue9Bits, palette));
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
            if (TileList.Count > 0)
            {
                e.Graphics.Clear(Color.Green);
                int iTiles = 0;
                try
                {
                    for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
                    {
                        for (int ix = 0; ix < ImportSettings.tileGroupWidth ; ix++)
                        {

                            for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                            {


                                for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
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
                                                n     = TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x].tileNibbles[ij * 8 + ik];



                                                bmwrite.SetPixel(ik, ij, palette.Palettearray[n].PalColor);
                                            }
                                            catch (Exception ex)
                                            {
                                                int ififif = 888;
                                            }
                                        }
                                    }
                                    e.Graphics.DrawImageUnscaled(
                                           bmwrite.ToBitmap(),
                                           ix * (8 * ImportSettings.superTileTileWidth) + 2 * ix + x * 8,
                                           iy * (8* ImportSettings.superTileTileHeight) + 2 * iy + y * 8);
                                    
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
        /// Tile Index
        /// 8-bit tile index within the tile definitions.
        List<Tuple<byte,byte>> tileMap = new List<Tuple<byte, byte>>();

        public byte[] tileMapBytes
        {
            get
            {
                byte[] ret = new byte[tileMap.Count * 2];
                foreach (var tile in tileMap)
                {
                    ret.AddRange(new byte[]{
                        tile.Item1,tile.Item2
                    });
                }
                return ret;
            }
        }
        List<Tile> tiles = new List<Tile>();

        private void btnCreateTileToolboxandMap_Click(object sender, EventArgs e)
        {
            int iTiles = 0;
            tileMap.Clear();
            tiles.Clear();
            for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++) // height in supertiles
            {
                for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++) // width in supertiles
                {
                    TileList.Add(new List<Tile>());
                    for (int y = 0; y < ImportSettings.superTileTileHeight; y++) // height of supertile in 8x8 tiles
                    {
                        for (int x = 0; x < ImportSettings.superTileTileWidth; x++) // width of supertile in 8x8 tiles
                        {

                            bool found = false;
                            for (int z = 0; z < tiles.Count; z++) //count through all 8x8 tiles
                            {
                                Tile tile = tiles[z];
                                if (!found &&
                                    TileList[iy * ImportSettings.tileGroupWidth + ix][
                                        y * ImportSettings.superTileTileWidth + x].Equals(tile, out bool rotated))
                                {
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(1, (byte)(z - 256)));

                                    }
                                    else
                                    {
                                        // tile less than 256
                                        tileMap.Add(new Tuple<byte, byte>(0, (byte)z));
                                    }

                                    tile.flags = (int)Modifier.None + (rotated?(int)Modifier.Rotate:0) ;
                                    tile.Index = z;
                                    //           tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x]);


                                }

                                if (!found &&
                                    TileList[iy * ImportSettings.tileGroupWidth + ix][
                                            y * ImportSettings.superTileTileWidth + x]
                                        .EqualsHorizontalMirror(tile, out rotated))
                                {
                                    // byte 11 for x mirror
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(0b1001, (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile less than 256
                                        tileMap.Add(new Tuple<byte, byte>(0b1000, (byte)z));
                                    }

                                    tile.flags = (int)Modifier.XMirror +(rotated? (int)Modifier.Rotate : 0);
                                    tile.Index = z;
                                    //           tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x]);

                                }

                                if (!found &&
                                    TileList[iy * ImportSettings.tileGroupWidth + ix][
                                            y * ImportSettings.superTileTileWidth + x]
                                        .EqualsVerticalMirror(tile, out rotated))
                                {
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(0b0101, (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile less than 256
                                        tileMap.Add(new Tuple<byte, byte>(0b0100, (byte)z));
                                    }

                                    tile.flags = (int)Modifier.YMirror + (rotated ? (int)Modifier.Rotate : 0); ;
                                    tile.Index = z;
                                    //        tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x]);

                                }

                                if (!found &&
                                    TileList[iy * ImportSettings.tileGroupWidth + ix][
                                            y * ImportSettings.superTileTileWidth + x]
                                        .EqualsVerticalAndHorizontalMirror((tile), out rotated))
                                {
                                    found = true;
                                    if (z > 255 && z < 512)
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(0b1101, (byte)(z - 256)));
                                    }
                                    else
                                    {
                                        // tile less than 256
                                        tileMap.Add(new Tuple<byte, byte>(0b1100, (byte)z));
                                    }

                                    tile.flags = (int)Modifier.XMirror + (int)Modifier.YMirror +( ( rotated )?(int)Modifier.Rotate:0);
                                    tile.Index = z;
                                    //                tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x]);
                                }



                                //----------------------------------------------------------//

                                if (!found)
                                {
                                    tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][
                                        y * ImportSettings.superTileTileWidth + x]);
                                    if (tiles.Count <= 256)
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(0, (byte)(tiles.Count - 1)));
                                    }
                                    else
                                    {
                                        tileMap.Add(new Tuple<byte, byte>(1, (byte)(tiles.Count - 257)));
                                    }

                                    Tile newtile = tiles[tiles.Count - 1];
                                    newtile.flags = (int)Modifier.None;
                                    newtile.Index = tiles.Count - 1;
                                    //            tiles.Add(TileList[iy * ImportSettings.tileGroupWidth + ix][y * ImportSettings.superTileTileWidth + x]);
                                }

                            }

                        }

                        iTiles++;
                    }
                }
            }

            this.label3.Text = "8x8 Tiles : " + tiles.Count;
            pnl_32_32_TilePalette.Size =
                new Size(ImportSettings.tileGroupWidth * ImportSettings.superTileTileWidth * 17,
                    ImportSettings.tileGroupHeight * ImportSettings.superTileTileHeight * 17);
            pnl_fromActualTilemap.Invalidate();
            pnl_32x32_gauntletMap.Invalidate();
            pnl_32_32_TilePalette.Invalidate();
        }

        private void pnl_fromActualTilemap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Azure);
            if (tileMap.Count == 0 || tiles.Count == 0) { return; }
            int iBigTile = 0;
            try
            {
                for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0;ix < ImportSettings.tileGroupWidth ; ix++)
                    {
                        for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                        {
                            for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                            {
                                byte bTile = tileMap[(iBigTile * (ImportSettings.superTileTileHeight*ImportSettings.superTileTileWidth) 
                                        + (y*ImportSettings.superTileTileWidth ) + x)].Item2;
                                Tile t = tiles[bTile];
                                Bitmap bmTemp = new Bitmap(8, 8);
                                IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                for (int ij = 0; ij < 8; ij++)
                                {
                                    for (int ik = 0; ik < 8; ik++)
                                    {
                                        nibble n = t.tileNibbles[ij * 8 + ik];
                                        bmwrite.SetPixel(ik, ij, palette.Palettearray[n].PalColor);
                                    }
                                }
                                e.Graphics.DrawImageUnscaled(
                                       bmwrite.ToBitmap(),
                                       ix * (ImportSettings.superTileTileWidth*8) + 2 * ix + x * 8,
                                       iy * (ImportSettings.superTileTileHeight*8) + 2 * iy + y * 8);


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

        private void btnExportTile_32_Tile_8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName + ".tileMap", tileMapBytes);
                //tileMap
                //tileMap[(iBigTile * 16) + (y * 4) + x];
                List<byte> outTileBytes = new List<byte>();
                foreach (Tile t in tiles)
                {
                    outTileBytes.AddRange(t.tileBytes);
                }
                File.WriteAllBytes(saveFileDialog.FileName + ".tileDefs", outTileBytes.ToArray());
                File.WriteAllBytes(saveFileDialog.FileName + ".tilePal", palette.SaveByteArray);

            }
        }

        private void pnl_32_32_TilePalette_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Azure);
            if (tileMap.Count == 0 || tiles.Count == 0) { return; }
            int iBigTile = 0;
            try
            {
                for (int iy = 0; iy < ImportSettings.tileGroupHeight; iy++)
                {
                    for (int ix = 0; ix < ImportSettings.tileGroupWidth; ix++)
                    {
                        if (e.Graphics.ClipBounds.IntersectsWith(new Rectangle(ix * (ImportSettings.superTileTileWidth * 16), iy *(ImportSettings.superTileTileHeight *16), (ImportSettings.superTileTileWidth * 16), (ImportSettings.superTileTileHeight * 16))))
                        {


                            for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
                            {
                                for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                                {
                                    byte bTile = tileMap[(iBigTile * (ImportSettings.superTileTileWidth*ImportSettings.superTileTileHeight)) + (y * ImportSettings.superTileTileWidth) + x].Item2;
                                    Tile t = tiles[bTile];
                                    Bitmap bmTemp = new Bitmap(16, 16);
                                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                    for (int ij = 0; ij < 8; ij++)
                                    {
                                        for (int ik = 0; ik < 8; ik++)
                                        {


                                            nibble n = t.tileNibbles[ij * 8 + ik];


                                            bmwrite.SetPixel(ik * 2, ij * 2, palette.Palettearray[n].PalColor);
                                            bmwrite.SetPixel(ik * 2 + 1, ij * 2, palette.Palettearray[n].PalColor);
                                            bmwrite.SetPixel(ik * 2, ij * 2 + 1, palette.Palettearray[n].PalColor);
                                            bmwrite.SetPixel(ik * 2 + 1, ij * 2 + 1, palette.Palettearray[n].PalColor);

                                        }
                                    }
                                    e.Graphics.DrawImageUnscaled(
                                           bmwrite.ToBitmap(),
                                           ix * (ImportSettings.superTileTileWidth * 16) + ImportSettings.superTileTileWidth * ix + x * 16 + 1,
                                           iy * (ImportSettings.superTileTileHeight * 16) + ImportSettings.superTileTileHeight * iy + y * 16 + 1);
                                    if (iBigTile == iSelectedIndex)
                                    {
                                        e.Graphics.DrawRectangle(Pens.Black,
                                                                ix * (ImportSettings.superTileTileWidth * 16) + ImportSettings.superTileTileWidth * ix + x * 16 +1 ,
                                                                iy * (ImportSettings.superTileTileHeight * 16) + ImportSettings.superTileTileHeight * iy + y * 16 +1,
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

            }
        }

        private Bitmap get_32_32_TileBitMap(int iBigTile)
        {
            Bitmap retBm = new Bitmap(BigtilewidthInPx,BigtileheightInPx);
            for (int y = 0; y < ImportSettings.superTileTileHeight; y++)
            {
                for (int x = 0; x < ImportSettings.superTileTileWidth; x++)
                {
                    byte bTile = tileMap[(iBigTile * (ImportSettings.NumberOfTilesPerSuperTile)) + (ImportSettings.superTileTileWidth * y) + x].Item2;
                    Tile t = tiles[bTile];
                    Bitmap bmTemp = new Bitmap(8, 8);
                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                    for (int ij = 0; ij < 8; ij++)
                    {
                        for (int ik = 0; ik < 8; ik++)
                        {
                            nibble n = t.tileNibbles[ij * 8 + ik];
                            bmwrite.SetPixel(ik, ij, palette.Palettearray[n].PalColor);
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


            int tileX = (e.Location.X+1) / (ImportSettings.superTileTileWidth * 17 );

            int tileY = (e.Location.Y+1) / (ImportSettings.superTileTileHeight * 17  );


            //this.textBox1.Text = "" + tileX + " " + tileY + " " + (tileY * 8 + tileX);

            int oldy = iSelectedIndex / ImportSettings.tileGroupWidth;
            int oldx = iSelectedIndex % ImportSettings.tileGroupWidth;
            //pnl_32_32_TilePalette.Invalidate(new Rectangle(oldx * (ImportSettings.superTileTileWidth * 16)  /*+ 2 * oldx*/, oldy * (ImportSettings.superTileTileHeight * 16) + 2 * oldy, (ImportSettings.superTileTileWidth * 16), (ImportSettings.superTileTileHeight * 16)));
            pnl_32_32_TilePalette.Invalidate(new Rectangle(
                oldx * (ImportSettings.superTileTileWidth * 16) + ImportSettings.superTileTileWidth * oldx + 1,
                oldy * (ImportSettings.superTileTileHeight * 16) + ImportSettings.superTileTileHeight * oldy + 1,
                (ImportSettings.superTileTileWidth * 16), (ImportSettings.superTileTileHeight * 16)));

            iSelectedIndex = tileY * ImportSettings.tileGroupWidth + tileX;

            int newy = iSelectedIndex / ImportSettings.tileGroupWidth;
            int newx = iSelectedIndex % ImportSettings.tileGroupWidth;
            //pnl_32_32_TilePalette.Invalidate(new Rectangle(newx * (ImportSettings.superTileTileWidth * 16) /*+ 2 * newx*/, newy * (ImportSettings.superTileTileHeight * 16) + 2 * newy, (ImportSettings.superTileTileWidth * 16), (ImportSettings.superTileTileHeight * 16)));
            pnl_32_32_TilePalette.Invalidate(new Rectangle(
                newx * (ImportSettings.superTileTileWidth * 16) + ImportSettings.superTileTileWidth * newx+1,
                newy * (ImportSettings.superTileTileHeight * 16) + ImportSettings.superTileTileHeight * newy + 1,
                (ImportSettings.superTileTileWidth * 16), (ImportSettings.superTileTileHeight * 16)));

        }
        // mouse.locationx = newx * (ImportSettings.superTileTileWidth * 16) + ImportSettings.superTileTileWidth * newx+1,
        // mouselocx +1 = newx * sup*16 + sup *newx
        // newx = mouselocx+1/((sup*16)+sup)

        List<byte[]> gauntletMap = new List<byte[]>();
        private void pnl_gauntletMap_Paint(object sender, PaintEventArgs e)
        {
            if (gauntletMap.Count == 0)
            {
                for (int j = 0; j < numMapHeight.Value; j++)
                {
                    gauntletMap.Add(new byte[(int)numMapWidth.Value]);
                }
            }

            e.Graphics.FillRectangle(new SolidBrush(Color.Azure), e.Graphics.ClipBounds);
            if (tileMap.Count == 0 || tiles.Count == 0) { return; }
            
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
                            byte bTile = gauntletMap[iy][ix];
                            Bitmap bmTemp = get_32_32_TileBitMap(bTile);

                            IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                            e.Graphics.DrawImageUnscaled(
                                    bmwrite.ToBitmap(),
                                    ix * (scaleFactor * ImportSettings.superTileTileWidth * ImportSettings.superTileTileWidth),
                                    iy *  scaleFactor * ImportSettings.superTileTileHeight * ImportSettings.superTileTileHeight);

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                int x = 0; int y = 0;
            }
        }


        void setLocationOn_32_MapEd(Point mouseLocation, bool invalidate)
        {
            try
            {
                int iy = (int)mouseLocation.Y / (( scaleFactor) * ImportSettings.superTileTileHeight*ImportSettings.superTileTileHeight);
                int ix = (int)mouseLocation.X / (( scaleFactor) * ImportSettings.superTileTileWidth* ImportSettings.superTileTileWidth);
                this.gauntletMap[iy][ix] = (byte)iSelectedIndex;
                if (invalidate)
                {
                    Rectangle r = new Rectangle(
                        (ix-1) * ((scaleFactor) * ImportSettings.superTileTileWidth * ImportSettings.superTileTileWidth), 
                        (iy-1) * (( scaleFactor) * ImportSettings.superTileTileHeight * ImportSettings.superTileTileHeight), 
                        (3* scaleFactor * ImportSettings.superTileTileWidth * ImportSettings.superTileTileWidth),
                        (3* scaleFactor * ImportSettings.superTileTileHeight * ImportSettings.superTileTileHeight));
                    pnl_32x32_gauntletMap.Invalidate(r);
                }
            }
            catch (Exception ex) { }

        }

        bool mouseDown = false;
        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = true;
            this.setLocationOn_32_MapEd(e.Location, true);
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDown = false;

        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDown) { this.setLocationOn_32_MapEd(e.Location, true); }
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            this.mouseDown = false;

        }

        private void btn_Save32_32px_tilemap(object sender, EventArgs e)
        {
            List<byte> bytesSaveMap = new List<byte>();
            foreach (var v in gauntletMap)
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
                this.gauntletMap.Clear();
                for (int iy = 0; iy < 64; iy++)
                {
                    byte[] baRow = new byte[64];
                    for (int ix = 0; ix < 64; ix++)
                    {
                        baRow[ix] = baBytes[iy * 64 + ix];
                    }
                    gauntletMap.Add(baRow);
                }

                //    this.gauntletMap = (List<byte[]>) baBytes.Chunk(64);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string FileName = ofd.FileName;
                if (FileName.EndsWith(".tileMap") || FileName.EndsWith(".tileDefs") || FileName.EndsWith(".tilePal"))
                {
                    List<string> list = new List<string>(FileName.Split("."));
                    list.RemoveAt(list.Count - 1);
                    FileName = string.Join(".", list);
                }

                byte[] tempBytes = File.ReadAllBytes(FileName + ".tileMap");
                for (int i = 0; i < tempBytes.Length / 2; i++)
                {
                    tileMap.Add(new Tuple<byte, byte>(tempBytes[i * 2], tempBytes[i * 2 + 1]));
                }
                
                palette = Palette9bit.FromByteArray(
                     File.ReadAllBytes(FileName + ".tilePal"));
                byte[] outTileBytes = File.ReadAllBytes(FileName + ".tileDefs");
                // now reverse park those bytes into tiles

                tiles = new List<Tile>();
                for (int i = 0; i < outTileBytes.Length / 32; i++)
                {
                    byte[] baTemp = new byte[32];
                    for (int j = 0; j < 32; j++)
                    {
                        baTemp[j] = (byte)(outTileBytes[i * 32 + j]);
                    }
                    tiles.Add(new Tile(palette, 0, null, baTemp));
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
                    this.ImportSettings.NumberOfTilesPerSuperTile = 1;
                    this.ImportSettings.superTileTileHeight = 1;
                    this.ImportSettings.superTileTileWidth = 1;
                    this.scaleFactor = 8;
                    this.BigtilewidthInPx = 8;
                    this.BigtileheightInPx = 8;

                    break;

                case 1:     //2x2
                    this.ImportSettings.NumberOfTilesPerSuperTile = 4;
                    this.ImportSettings.superTileTileHeight = 2;
                    this.ImportSettings.superTileTileWidth = 2;
                    this.scaleFactor = 4;
                    this.BigtilewidthInPx = 16;
                    this.BigtileheightInPx = 16;

                    break;
                case 2:     //3x3
                    this.ImportSettings.NumberOfTilesPerSuperTile = 16;
                    this.ImportSettings.superTileTileHeight = 4;
                    this.ImportSettings.superTileTileWidth = 4;
                    this.scaleFactor = 2;
                    this.BigtilewidthInPx = 32;
                    this.BigtileheightInPx = 32;

                    break;

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

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
