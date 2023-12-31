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
                this.pictureBox1.Image = imgOrigin;
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

            panel3.Invalidate();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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
            panel4.Invalidate();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
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
            panel5.Invalidate();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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
            panel6.Invalidate();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
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
                List <byte> outTileBytes = new List<byte>();
                foreach (Tile t in tiles)
                {
                    outTileBytes.AddRange(t.tileBytes);
                }
                File.WriteAllBytes(saveFileDialog.FileName + ".tileDefs", outTileBytes.ToArray());
                File.WriteAllBytes(saveFileDialog.FileName + ".tilePal", palette.SaveByteArray);
                
            }
        }
    }
}
