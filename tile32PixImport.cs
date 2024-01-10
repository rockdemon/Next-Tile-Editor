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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Next_tile_editor
{
    public partial class tile32PixImport : UserControl
    {
        Image imgOrigin = null;
        public tile32PixImport()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image image = new Bitmap(ofd.FileName);
                imgOrigin = new Bitmap(image);
                this.pct_OriginalTileBitmap.Image = imgOrigin;
            }
        }
        List<List<int>> TileIndexes = new List<List<int>>();
        List<List<Image>> images = new List<List<Image>>();
        private void button1_Click(object sender, EventArgs e)
        {
            images.Clear();
            TileIndexes.Clear();

            int width = imgOrigin.Width;
            int height = imgOrigin.Height;
            int BigTileIdx = 0;
            int tileWidth = width / 8;
            int tileHeight = height / 8;

            int tileGroupWidth = tileWidth / 4;
            int tileGroupHeight = tileHeight / 4;

            for (int iy = 0; iy < tileGroupWidth && iy < 5; iy++)
            {
                for (int ix = 0; ix < tileGroupHeight; ix++)
                {

                    int idx = 0;
                    List<Image> imageList = new List<Image>();
                    TileIndexes.Add(new List<int>());
                    for (int y = 0; y < 4; y++)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            //Image  = imgOrigin.
                            Bitmap imTemp = new Bitmap(8, 8);
                            {
                                using (Graphics g = Graphics.FromImage(imTemp))
                                {
                                    g.DrawImage(imgOrigin, new Rectangle(0, 0, 8, 8),
                                        new Rectangle((ix * 32 + x * 8), (iy * 32 + y * 8), 8, 8),
                                        GraphicsUnit.Pixel);
                                }
                            }
                            imageList.Add(imTemp);

                            TileIndexes[BigTileIdx].Add(idx);
                            idx++;
                        }
                    }
                    images.Add(imageList);
                    BigTileIdx++;
                }
            }

            pnl_32_32_tiles.Invalidate();

        }

        private void pnl_32_32_tiles_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            int iTile = 0;
            for (int iy = 0; iy < 4 && iy < images.Count; iy++)
            {
                for (int ix = 0; ix < 8 && ix < images[iy].Count; ix++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            try
                            {
                                e.Graphics.DrawImageUnscaled(
                                    images[iTile][y * 4 + x],
                                    ix * 32 + 2 * ix + x * 8,
                                    iy * 32 + 2 * iy + y * 8);
                            }
                            catch { }
                        }
                    }

                    iTile++;
                }
            }
        }

        List<List<paletteValue9bit[]>> Lists9BitColours = new List<List<paletteValue9bit[]>>();

        private void btnQuantizeColours_Click(object sender, EventArgs e)
        {
            Lists9BitColours.Clear();
            foreach (List<Image> images in images)
            {
                List<paletteValue9bit[]> List9BitColours = new List<paletteValue9bit[]>();
                foreach (Image image in images)
                {
                    paletteValue9bit[] baImg = new paletteValue9bit[image.Width * image.Height];
                    for (int y = 0; y < 8; y++)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            Color c = (image as Bitmap).GetPixel(x, y);
                            baImg[y * 8 + x] = paletteValue9bit.FromColor(c);
                        }
                    }
                    List9BitColours.Add(baImg);

                }
                Lists9BitColours.Add(List9BitColours);
            }
            pnl_QuantizedColour.Invalidate();
        }

        private void pnl_QuantizedColour_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Green);
            int iTiles = 0;
            try
            {
                for (int iy = 0; iy < 4; iy++)
                {
                    for (int ix = 0; ix < 8; ix++)
                    {

                        for (int y = 0; y < 4; y++)
                        {


                            for (int x = 0; x < 4; x++)
                            {
                                var paletteValue9Bits = Lists9BitColours[iTiles][y * 4 + x];


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
                                       ix * 32 + 2 * ix + x * 8,
                                       iy * 32 + 2 * iy + y * 8);
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

        List<List<List<byte>>> hashes = new List<List<List<byte>>>();
        List<List<Tile>> TileList = new List<List<Tile>>();
        Palette9bit palette = new Palette9bit();
        private void btn_CommonTileCheck_Click(object sender, EventArgs e)
        {
            palette = new Palette9bit();
            int iPaletteIdx = 0;
            int iTiles = 0;
            for (int iy = 0; iy < 4; iy++)
            {
                for (int ix = 0; ix < 8; ix++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            paletteValue9bit[] paletteValue9Bits = Lists9BitColours[iTiles][y * 4 + x];
                            foreach (paletteValue9bit pv in paletteValue9Bits)
                            {
                                bool contained = false;
                                for (int xx = 0; xx < iPaletteIdx; xx++)
                                {
                                    if (palette.Palettearray[xx].Red == pv.Red &&
                                        palette.Palettearray[xx].Green == pv.Green &&
                                        palette.Palettearray[xx].Blue == pv.Blue
                                        )
                                    {
                                        contained = true;
                                        break;
                                    }
                                }
                                if (contained)
                                    continue;

                                if (!palette.Palettearray.Contains(pv))
                                {
                                    palette.Palettearray[iPaletteIdx] = pv;

                                    iPaletteIdx++;
                                }


                            }
                        }

                    }

                    iTiles++;
                }
            }

            iTiles = 0;
            TileList.Clear();
            for (int iy = 0; iy < 4; iy++)
            {
                for (int ix = 0; ix < 8; ix++)
                {
                    TileList.Add(new List<Tile>());
                    for (int y = 0; y < 4; y++)
                    {
                        for (int x = 0; x < 4; x++)
                        {
                            var paletteValue9Bits = Lists9BitColours[iTiles][y * 4 + x];


                            TileList[iTiles].Add(Tile.FromPalette9ValArray(paletteValue9Bits, palette));
                        }

                    }

                    iTiles++;
                }
            }
            pnl_CommonTiles.Invalidate();
        }

        private void pnl_CommonTiles_Paint(object sender, PaintEventArgs e)
        {
            if (TileList.Count > 0)
            {
                e.Graphics.Clear(Color.Green);
                int iTiles = 0;
                try
                {
                    for (int iy = 0; iy < 4; iy++)
                    {
                        for (int ix = 0; ix < 8; ix++)
                        {

                            for (int y = 0; y < 4; y++)
                            {


                                for (int x = 0; x < 4; x++)
                                {

                                    Bitmap bmTemp = new Bitmap(8, 8);
                                    IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();
                                    for (int ij = 0; ij < 8; ij++)
                                    {
                                        for (int ik = 0; ik < 8; ik++)
                                        {
                                            nibble n = TileList[iy * 8 + ix][y * 4 + x].tileNibbles[ij * 8 + ik];


                                            bmwrite.SetPixel(ik, ij, palette.Palettearray[n].PalColor);

                                        }
                                    }
                                    e.Graphics.DrawImageUnscaled(
                                           bmwrite.ToBitmap(),
                                           ix * 32 + 2 * ix + x * 8,
                                           iy * 32 + 2 * iy + y * 8);
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

        List<byte> tileMap = new List<byte>();
        List<Tile> tiles = new List<Tile>();

        private void button4_Click(object sender, EventArgs e)
        {
            int iTiles = 0;
            tileMap.Clear();
            tiles.Clear();
            for (int iy = 0; iy < 4; iy++)
            {
                for (int ix = 0; ix < 8; ix++)
                {
                    TileList.Add(new List<Tile>());
                    for (int y = 0; y < 4; y++)
                    {
                        for (int x = 0; x < 4; x++)
                        {

                            bool found = false;
                            for (int z = 0; z < tiles.Count; z++)
                            {
                                Tile tile = tiles[z];
                                if (!found && TileList[iy * 8 + ix][y * 4 + x].Equals(tile))
                                {
                                    found = true;
                                    tileMap.Add((byte)z);
                                }
                            }
                            if (!found)
                            {
                                tiles.Add(TileList[iy * 8 + ix][y * 4 + x]);
                                tileMap.Add((byte)(tiles.Count - 1));
                            }
                            //            var paletteValue9Bits = Lists9BitColours[iTiles][y * 4 + x];


                            ///          TileList[iTiles].Add(Tile.FromPalette9ValArray(paletteValue9Bits, palette));
                        }

                    }

                    iTiles++;
                }
            }
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
                for (int iy = 0; iy < 4; iy++)
                {
                    for (int ix = 0; ix < 8; ix++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            for (int x = 0; x < 4; x++)
                            {
                                byte bTile = tileMap[(iBigTile * 16) + (y * 4) + x];
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
                                       ix * 32 + 2 * ix + x * 8,
                                       iy * 32 + 2 * iy + y * 8);


                            }
                        }

                        iBigTile++;


                    }
                }
            }
            catch (Exception ex)
            {

            }
            this.btnExportTile_32_Tile_8.Enabled = true;
        }

        private void btnExportTile_32_Tile_8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName + ".tileMap", tileMap.ToArray());
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
                for (int iy = 0; iy < 4; iy++)
                {
                    for (int ix = 0; ix < 8; ix++)
                    {
                        if (e.Graphics.ClipBounds.IntersectsWith(new Rectangle(ix * 64, iy * 64, 64, 64)))
                        {


                            for (int y = 0; y < 4; y++)
                            {
                                for (int x = 0; x < 4; x++)
                                {
                                    byte bTile = tileMap[(iBigTile * 16) + (y * 4) + x];
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
                                           ix * 64 + 4 * ix + x * 16 + 1,
                                           iy * 64 + 4 * iy + y * 16 + 1);
                                    if (iBigTile == iSelectedIndex)
                                    {
                                        e.Graphics.DrawRectangle(Pens.Black,
                                                                ix * 64 + 4 * ix + x * 16,
                                                                iy * 64 + 4 * iy + y * 16 + 1,
                                                                18, 18);
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
            Bitmap retBm = new Bitmap(32, 32);
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    byte bTile = tileMap[(iBigTile * 16) + (y * 4) + x];
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


            int tileX = e.Location.X / 64;

            int tileY = e.Location.Y / 64;


            //this.textBox1.Text = "" + tileX + " " + tileY + " " + (tileY * 8 + tileX);

            int oldy = iSelectedIndex / 8;
            int oldx = iSelectedIndex % 8;
            pnl_32_32_TilePalette.Invalidate(new Rectangle(oldx * 64 + 1, oldy * 64 + 1, 64, 64));
            iSelectedIndex = tileY * 8 + tileX;

            int newy = iSelectedIndex / 8;
            int newx = iSelectedIndex % 8;
            pnl_32_32_TilePalette.Invalidate(new Rectangle(newx * 64 + 1, newy * 64 + 1, 64, 64));
        }

        List<byte[]> gauntletMap = new List<byte[]>();
        private void pnl_32x32_gauntletMap_Paint(object sender, PaintEventArgs e)
        {

            if (gauntletMap.Count == 0)
            {
                for (int j = 0; j < 64; j++)
                {
                    gauntletMap.Add(new byte[64]);

                }
            }

            e.Graphics.FillRectangle(new SolidBrush(Color.Azure), e.Graphics.ClipBounds);
            if (tileMap.Count == 0 || tiles.Count == 0) { return; }
            int iBigTile = 0;
            try
            {
                for (int iy = 0; iy < 64; iy++)
                {
                    for (int ix = 0; ix < 64; ix++)
                    {
                        if (e.Graphics.ClipBounds.IntersectsWith(new RectangleF(ix * 32, iy * 32, 32, 32)))
                        {
                            byte bTile = gauntletMap[iy][ix];
                            Bitmap bmTemp = get_32_32_TileBitMap(bTile);

                            IReadWriteBitmapData bmwrite = bmTemp.GetReadWriteBitmapData();

                            e.Graphics.DrawImageUnscaled(
                                    bmwrite.ToBitmap(),
                                    ix * 32,
                                    iy * 32);


                        }

                        iBigTile++;


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
                this.gauntletMap[(int)mouseLocation.Y / 32][(int)mouseLocation.X / 32] = (byte)iSelectedIndex;
                if (invalidate)
                {
                    Rectangle r = new Rectangle(((int)mouseLocation.X / 32) * 32, ((int)mouseLocation.Y / 32) * 32, 32, 32);
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
                tileMap = new List<byte>(File.ReadAllBytes(FileName + ".tileMap"));
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
                List<Image> itemp = images[iSelectedIndex]; // from

            //    int idx2 = Math.DivRem(iSelectedIndex-1,8, out int rem2);
                images[iSelectedIndex] = images[iSelectedIndex-1];
                images[iSelectedIndex-1] = itemp;
                btnQuantizeColours_Click(null, null);


                pnl_32_32_tiles.Invalidate();
            }
        }

        private void btnRightTile_Click(object sender, EventArgs e)
        {
            if (iSelectedIndex < tiles.Count-1 )
            {
                Tile temp = tiles[iSelectedIndex+1];
                tiles[iSelectedIndex+1] = tiles[iSelectedIndex];
                tiles[iSelectedIndex] = temp;
                this.pnl_32_32_TilePalette.Invalidate();
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
