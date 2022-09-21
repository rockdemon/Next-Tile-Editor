using KGySoft.Drawing;
using KGySoft.Drawing.Imaging;
using System.Drawing.Imaging;
using System.IO;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

namespace Next_tile_editor
{
    public partial class Form1 : Form
    {
        List<Image> spriteImages = new List<Image>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        int noFrames = 0;
        string curDir = Application.ExecutablePath;
        public static int TileSize = 24;
        public static int PixelSize = 3;

        public Form1()
        {
            this.Size = new System.Drawing.Size(1400, 800);

            InitializeComponent();
            DefaultTileBitmaps();
            
            this.pnlTileMap.Paint += Panel1_Paint;
            
            this.pnlPalettePicker.Paint += PnlPalettePicker_Paint;
            pnlTileMap.Invalidate();
            pnlPalettePicker.Invalidate();
            pnlPalettePicker.MouseClick += PnlPalettePicker_MouseClick;
            NextPalette.InkColoursChanged += NextPalette_SelectedColoursChanged;
            NextPalette.PaperColoursChanged += NextPalette_PaperColoursChanged;
            pnlTilePalette.Invalidate();
            pnlTileMap.MouseMove += PnlTileMap_MouseMove;
            pnlTileMap.MouseLeave += PnlTileMap_MouseLeave;
            pnlTileMap.MouseEnter += PnlTileMap_MouseEnter;
            pnlTileMap.MouseClick += PnlTileMap_MouseClick;
            NextPalette.InkColoursChanged += NextPalette_SelectedColoursChanged1;
        }

        private void NextPalette_SelectedColoursChanged1(object? sender, EventArgs e)
        {
            this.setInkForIdx(NextPalette.Ink9bit);
            
        }

        private void NextPalette_PaperColoursChanged(object? sender, EventArgs e)
        {
            
            this.setPaperForIdx(NextPalette.Paper9bit);

        }
        private void setInkForIdx(paletteValue9bit inkCol)
        {
            
            byte[] bs = inkCol.toSaveBytes();
            this.baTilePalette[InkIndex * 2] = bs[0];
            this.baTilePalette[InkIndex * 2  + 1] = bs[1];
            tileEditor1.palette = Palette9bit.FromByteArray(baTilePalette);
            UpdatePalettePicker();
            this.pnlPalettePicker.Invalidate();
            
        }

        private void setPaperForIdx(paletteValue9bit paperCol)
        {

            byte[] bs = paperCol.toSaveBytes();
            
            this.baTilePalette[PaperIndex * 2] = bs[0];
            this.baTilePalette[PaperIndex * 2 + 1] = bs[1];
            tileEditor1.palette = Palette9bit.FromByteArray(baTilePalette);
            UpdatePalettePicker();
            this.pnlPalettePicker.Invalidate();
        }

        private void PnlPalettePicker_MouseClick(object? sender, MouseEventArgs e)
        {
            Point pos  = new Point(e.X, e.Y);
            //pos = this.PointToClient(pos);
            int idx = ((int)(pos.X/Form1.TileSize))+((int)pos.Y/Form1.TileSize)*4;
            if (e.Button == MouseButtons.Left)
            {
                InkIndex = idx;
                tileEditor1.InkVal = idx;
                tileEditor1.Ink = paletteValue9bit.From2bytes(baTilePalette[idx * 2], baTilePalette[idx * 2 + 1]);
            }
            else
            {
                PaperIndex = idx;

                tileEditor1.PaperVal = idx;
            }
            
        }
        
        public int InkIndex
        { get; set; }

        public int PaperIndex { get; set; }

        private void PnlPalettePicker_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmPalettePicker, 0, 0);
        }

        private void PnlTileMap_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePos.Value != null)
            {
                int tmX = mousePos.Value.X / Form1.TileSize;
                int tmY = mousePos.Value.Y / Form1.TileSize;
                baMap[tmX + tmY * 40] = (byte)iSourceIndex;
                UpdateTileMap();
                pnlTileMap.Invalidate();

            }
        }

        Point? mousePos = null;
        private void PnlTileMap_MouseEnter(object? sender, EventArgs e)
        {
                Point ptemp = (sender as Control).PointToClient(Cursor.Position);
            int mX = ((int)(ptemp.X / Form1.TileSize) * Form1.TileSize);
            int mY = ((int)(ptemp.Y / Form1.TileSize) * Form1.TileSize);

            mousePos = new Point(mX, mY);
            pnlTileMap.Invalidate();
        }

        private void PnlTileMap_MouseLeave(object? sender, EventArgs e)
        {
            mousePos = null;
            pnlTileMap.Invalidate();
        }

        private void PnlTileMap_MouseMove(object? sender, MouseEventArgs e)
        {
            if (mousePos != null)
            {
                Point ptemp = (sender as Control).PointToClient(Cursor.Position);
                int mX = ((int)(ptemp.X / Form1.TileSize) * Form1.TileSize);
                int mY = ((int)(ptemp.Y / Form1.TileSize) * Form1.TileSize);
                if (mX != mousePos.Value.X || mY != mousePos.Value.Y)
                {
                    mousePos = new Point(mX, mY);
                    pnlTileMap.Invalidate();
                }
            }
        }


        Bitmap bmTileBuffer = null;
        private void Panel1_Paint(object? sender, PaintEventArgs e)
        {
            if (bmTileBuffer == null)
                bmTileBuffer = new Bitmap(40 * Form1.TileSize, 256 * Form1.TileSize);
            pnlTileMap.Size = bmTileBuffer.Size;
            e.Graphics.DrawImage(bmTileBuffer, 0, 0);
            if (mousePos != null && SourceImage != null)
                e.Graphics.DrawImage(SourceImage, mousePos.Value);
        }

        private void btnImportFromPNG_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png";
            openFileDialog.Title = "Select Pngs";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = curDir;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> listFileNames = new List<string>();
                listFileNames.AddRange(openFileDialog.FileNames);
                UpdateSprites(listFileNames);
            }

        }

        public void UpdateSprites(List<string> listFileNames)
        {
            noFrames = listFileNames.Count;
            for (int i = 0; i < listFileNames.Count; i++)
            {
                Image tempImage = LockUnlockBitsLowLevelUpdate((Bitmap)Bitmap.FromFile(listFileNames[i]));

                spriteImages.Add(tempImage);
                if (i >= pictureBoxes.Count)
                {
                    pictureBoxes.Add(new PictureBox());

                };

                pictureBoxes[i].Image = tempImage;

            }
            UpdatePictureBoxes();
        }

        public void UpdatePictureBoxes()
        {
            this.panelParent.Controls.Clear();
            int tempx = 0; int tempy = 0;
            for (int i = 0; i < noFrames; i++)
            {
                pictureBoxes[i].Size = new Size(pictureBoxes[i].Image.Width, pictureBoxes[i].Image.Height);
                this.panelParent.Controls.Add(pictureBoxes[i]);
                this.pictureBoxes[i].Location = new Point(tempx, tempy);
                this.pictureBoxes[i].Visible = true;
                tempx = tempx + 64;
                if (tempx + 64 > pnlTileMap.Width)
                {
                    tempy = tempy + 64;
                    tempx = 0;
                }
                this.label1.Text = String.Format("width {0} height {1}", pictureBoxes[i].Image.Width, pictureBoxes[i].Image.Height);

            }
        }
        
        //public Image Get9Bit(Image im)
        //{
        //    if (im == null)
        //        return null;

        //    using (Graphics tempWorking = Graphics.FromImage(im))
        //    {

        //        Bitmap bitmap = new Bitmap(im.Width,im.Height,16,1, PixelFormat.,);
        //        im.Con = 256;

        //    }

        //}

        private Bitmap LockUnlockBitsLowLevelUpdate(Bitmap bmp)
        {

            // Create a new bitmap.
            //Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int counter = 0; counter < rgbValues.Length; counter++)
                rgbValues[counter] = (byte)(rgbValues[counter] & (byte)208); // 11100000

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            return bmp;
        }

        private void btnSaveAsNextFormat_Click(object sender, EventArgs e)
        {
            if (pictureBoxes.Count > 0)
            {
                foreach (Image im in spriteImages)
                {
                    List<byte> lstBytes = new List<byte>();

                }
            }
        }

        private byte[] Get16x16ByteArrForBmp(Bitmap bmp)
        {
            byte[] bytesRet = new byte[256];
            // Create a new bitmap.
            //Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int counter = 0; counter < rgbValues.Length; counter++)
                rgbValues[counter] = (byte)(rgbValues[counter] & (byte)208); // 11100000

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            return bytesRet;
        }

        private void btnQuantizeImages_Click(object sender, EventArgs e)
        {
            var customPixelFormat = new PixelFormatInfo { BitsPerPixel = 8, Grayscale = false, HasAlpha=false,  };

            var targetFormat = System.Drawing.Imaging.PixelFormat.Format4bppIndexed; // feel free to try other formats as well
            using (Bitmap? bmpSrc = Icons.Shield.ExtractBitmap(new Size(256, 256)))
            using (Bitmap bmpDst = new Bitmap(16, 16, targetFormat))
            {
                using (IReadableBitmapData? dataSrc = bmpSrc.GetReadableBitmapData())
                using (IWritableBitmapData dataDst = bmpDst.GetWritableBitmapData())
                {
                    IReadableBitmapDataRow rowSrc = dataSrc.FirstRow;
                    IWritableBitmapDataRow rowDst = dataDst.FirstRow;
                    do
                    {
                        for (int x = 0; x < dataSrc.Width; x++)
                            rowDst[x] = rowSrc[x]; // works also between different pixel formats

                    } while (rowSrc.MoveNextRow() && rowDst.MoveNextRow());
                }

                bmpSrc.SaveAsPng(@"c:\temp\bmpSrc.png");
                bmpDst.SaveAsPng(@"c:\temp\bmpDst.png"); // or saveAsGif/SaveAsTiff to preserve the indexed format
            }
        }
        //private IReadWriteBitmapData Get4BitBitmap()// 16 x 16 x4 bit. Colours are 9 bit
        //{
        //    // Gray8 format has no built-in support
        //    var bitmap = new WriteableBitmap(16, 16, Form1.TileSize, Form1.TileSize, PixelFormats.Indexed4, null);

        //    // But we can specify how to use it
        //    var customPixelFormat = new PixelFormatInfo { BitsPerPixel = 4, Grayscale = false };
        //    Func<ICustomBitmapDataRow, int, ColorForm1.TileSize> getPixel =
        //        (row, x) => ColorForm1.TileSize.FromRgb(row.UnsafeGetRefAs<byte>(x));// byte will be 2 pixels?
        //    Action<ICustomBitmapDataRow, int, ColorForm1.TileSize> setPixel =
        //        (row, x, c) => row.UnsafeGetRefAs<byte>(x) = c.Blend(row.BitmapData.BackColor).GetBrightness();

        //    // Now we specify also a dispose callback to be executed when the returned instance is disposed:
        //    return BitmapDataFactory.CreateBitmapData(
        //        bitmap.BackBuffer, new Size(bitmap.PixelWidth, bitmap.PixelHeight), bitmap.BackBufferStride,
        //        customPixelFormat, getPixel, setPixel,
        //        disposeCallback: () =>
        //        {
        //            bitmap.AddDirtyRect(new System.Windows.IntForm1.TileSizeRect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
        //            bitmap.Unlock();
        //        });
        //}

        private void btnImportFromNext_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            var res = ofd.ShowDialog();
            byte[] bin = File.ReadAllBytes(ofd.FileName);

        }

        byte[] baMap = null;

        private void btnLoadTileMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            ofd.Filter = "map files (*.map)|*.map";
   //         ofd.DefaultExt = "*.map";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            { 
                baMap = File.ReadAllBytes(ofd.FileName);
                UpdateTileMap();
                
            }

        }
        byte[] baTiles = null;
        Bitmap[] Tiles = new Bitmap[256]; 
        
        private void btnLoadTiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;

            ofd.Filter = "spr files (*.spr)|*.spr|tile file|*.til";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                baTiles = File.ReadAllBytes(ofd.FileName);
                Tiles = new Bitmap[256];

                Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
                int offset = 0;
                int iTile = 0;
                int iPaletteX = 0; int iPaletteY = 0;
                for (int i = 0; i< baTiles.Length/32 && iTile<128; i++)
                {
                    Tiles[iTile] = new Bitmap(32, 32);
                    using (Graphics g = Graphics.FromImage(Tiles[iTile]))
                    {
                        int ix = 0; int iy = 0;
                        for (int j = 0; j < 32; j++)
                        {
                            byte firstNibble = (byte)((baTiles[offset] & 0b11110000) >> 4);
                            byte secondNibble = (byte)(baTiles[offset] & 0b00001111);
                            Rectangle R1 = new Rectangle(ix * PixelSize, iy * PixelSize, PixelSize, PixelSize);
                            g.FillRectangle(new System.Drawing.SolidBrush(
                                    pal.Palettearray[firstNibble].PalColor),    R1);
                            g.FillRectangle(new System.Drawing.SolidBrush(
                                    pal.Palettearray[secondNibble].PalColor), 
                                        (ix+1) * PixelSize, iy * PixelSize, PixelSize, PixelSize);
                            ix += 2;
                            offset++;
                            if (ix > 7)
                            {
                                ix = 0;
                                iy++;
                            }    

                        }
                        PictureBox tilePB = new PictureBox { Location = new Point(iPaletteX, iPaletteY), Image = Tiles[iTile], Visible = true, Size = new Size(32, 32), Name = "Tile_"+iTile };
                        
                        tilePB.Click += TilePB_Click;
                        pnlTilePalette.Controls.Add(tilePB);
                        iPaletteX += 32;
                        if (iPaletteX==128)
                        {
                            iPaletteY += 32;
                            iPaletteX = 0;
                        }
                        iTile++;
                    }
                    

                }
                UpdateTileMap();
            }

        }

        Image SourceImage = null;
        int iSourceIndex = -1;
        private void TilePB_Click(object? sender, EventArgs e)
        {
            try
            {
                SourceImage = (sender as PictureBox).Image;
                iSourceIndex = (Convert.ToInt32((sender as PictureBox).Name.Substring(5)));
                tileEditor1.palette = Palette9bit.FromByteArray(baTilePalette);

                List<byte> list = new List<byte>();
                for (int i = (iSourceIndex * 32); i < iSourceIndex * 32 + 32; i++)
                    list.Add(baTiles[i]);
                this.tileEditor1.Tile = list.ToArray<byte>();
                
            }
            catch (Exception exc)
            {
                SourceImage = null;
            }
        }

        private void DefaultTileBitmaps()
        {
            for( int i = 0; i<256; i++ )
            {
                Bitmap bmTemp = new Bitmap(Form1.TileSize, Form1.TileSize);
                Graphics g = Graphics.FromImage(bmTemp);
                g.DrawString("" + i, new Font("Arial", 8), System.Drawing.Brushes.Black, 0, 0);
                Tiles[i] = bmTemp;

            }
        }
        public void UpdateTileMap()
        {
            int arrLength = baMap.Length;
            int height = arrLength / 40 +1;
            if (bmTileBuffer != null && bmTileBuffer.Height != height * TileSize)
            {
                bmTileBuffer.Dispose();
                bmTileBuffer = null;
            }
                
            if (bmTileBuffer == null)
                bmTileBuffer = new Bitmap(40 * Form1.TileSize, 256 * TileSize);

            using (Graphics g = Graphics.FromImage(bmTileBuffer))
            {
                if (Tiles != null)
                {
                    int y = 0;
                    do
                    {
                        for (int x = 0; x < 40; x++)
                        {
                         if ((Tiles[baMap[x + (y * 40)]]) == null)
                            Tiles[baMap[x + (y * 40)]] = new Bitmap(TileSize,TileSize);
                        if (this.baMap[x + (y * 40)]<128)
                                g.DrawImage(Tiles[this.baMap[x+(y*40)]], (x * TileSize), y * TileSize);
                            
                        }
                        y++;
                    }
                    while ((y * 40)+39 < baMap.Length);

                }
                else
                {
                    g.Clear(System.Drawing.Color.Magenta);
                }
            }
            pnlTileMap.Invalidate();
            pnlPalettePicker.Invalidate();
            pnlTilePalette.Invalidate();

        }

        Bitmap bmPalettePicker = new Bitmap(128, 1024);
        byte[] baTilePalette = null;
        private void btnLoadPalette_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                baTilePalette = File.ReadAllBytes(ofd.FileName);
                Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
                int px = 0; int py = 0;
                foreach (paletteValue9bit v in pal.Palettearray)
                {
                    Graphics.FromImage(bmPalettePicker).FillRectangle(new SolidBrush(v.PalColor), px, py, 32, 32);
                    px += 32;
                    if (px == 128)
                    {
                        px = 0; py += 32;
                    }
                }
                NextPalette.Palette = pal;

                pnlPalettePicker.Location = new Point (132,0);
                pnlTilePalette.Location = new Point (0,0);
                
                
                pnlTileMap.Invalidate();
                pnlPalettePicker.Invalidate();
                pnlTilePalette.Invalidate();

            }
        }

        private void UpdatePalettePicker()
        {
            Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
            int px = 0; int py = 0;
            foreach (paletteValue9bit v in pal.Palettearray)
            {
                Graphics.FromImage(bmPalettePicker).FillRectangle(new SolidBrush(v.PalColor), px, py, 32,32);
                px += 32;
                if (px == 128)
                {
                    px = 0; py += 32;
                }
            }
            NextPalette.Palette = pal;
        }

        private void NextPalette_SelectedColoursChanged(object? sender, EventArgs e)
        {
            
            this.tileEditor1.Ink = NextPalette.Ink9bit;
            tileEditor1.InkVal = NextPalette.InkIndex;

            this.tileEditor1.Paper = NextPalette.Paper9bit;
            tileEditor1.PaperVal = NextPalette.PaperIndex;

        }

        private void btnSaveTileMap_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, baMap);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {   int val= (int)(sender as NumericUpDown).Value;
                tileEditor1.PaletteOffset = val;
            
        }

        /// <summary>
        /// Save tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            for ( int ix = 0; ix<Form1.TileSize ; ix++)
            {
                baTiles[ix + (iSourceIndex * 32)] = tileEditor1.Tile[ix];
            }
            foreach (Control c in pnlTilePalette.Controls)
            {
                if ((PictureBox)c != null)
                {
                    ((PictureBox)c).Click -= TilePB_Click;
                    c.Visible = false;
                    pnlTilePalette.Controls.Remove(c);
                    c.Dispose();
                }
            }


            Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
            int offset = 0;
            int iTile = 0;
            int iPaletteX = 0; int iPaletteY = 0;
            for (int i = 0; i < baTiles.Length / 32 && iTile < 128; i++)
            {
          
                Tiles[iTile] = new Bitmap(32,32);
                using (Graphics g = Graphics.FromImage(Tiles[iTile]))
                {
                    int ix = 0; int iy = 0;
                    for (int j = 0; j < 32; j++)
                    {
                        byte firstNibble = (byte)((baTiles[offset] & 0b11110000) >> 4);
                        byte secondNibble = (byte)(baTiles[offset] & 0b00001111);
                        Rectangle R1 = new Rectangle(ix * 4, iy * 4, 4, 4);
                        g.FillRectangle(new System.Drawing.SolidBrush(
                                pal.Palettearray[firstNibble].PalColor), R1);
                        g.FillRectangle(new System.Drawing.SolidBrush(
                                pal.Palettearray[secondNibble].PalColor),
                                    (ix + 1) * PixelSize, iy * 4, 4, 4);
                        ix += 2;
                        offset++;
                        if (ix > 7)
                        {
                            ix = 0;
                            iy++;
                        }

                    }
                    PictureBox tilePB = new PictureBox { Location = new Point(iPaletteX, iPaletteY), Image = Tiles[iTile], Visible = true, Size = new Size(32, 32), Name = "Tile_" + iTile };
                    tilePB.Click += TilePB_Click;
                    pnlTilePalette.Controls.Add(tilePB);
                    iPaletteX += 32;
                    if (iPaletteX >= 128)
                    {
                        iPaletteY += 32;
                        iPaletteX = 0;
                    }
                    iTile++;
                }


            }
            pnlTilePalette.Invalidate();
            UpdateTileMap();
        }

        private void btnSavePalette_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllBytes(ofd.FileName,baTilePalette);
                
            }
        }

        private void btnSaveTiles_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllBytes(ofd.FileName, baTiles);

            }
        }

        private void btnLoadTileMap_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlTileMap_Paint(object sender, PaintEventArgs e)
        {

        }


        //private IReadWriteBitmapData Get8BitBitmap()// 16 x 16 x4 bit. Colours are 9 bit
        //{
        //    // Gray8 format has no built-in support
        //    var bitmap = new WriteableBitmap(16, 16, Form1.TileSize, Form1.TileSize, PixelFormats., null);

        //    // But we can specify how to use it
        //    var customPixelFormat = new PixelFormatInfo { BitsPerPixel = 4, Grayscale = false };
        //    Func<ICustomBitmapDataRow, int, ColorForm1.TileSize> getPixel =
        //        (row, x) => ColorForm1.TileSize.FromRgb(row.UnsafeGetRefAs<byte>(x));// byte will be 2 pixels?
        //    Action<ICustomBitmapDataRow, int, ColorForm1.TileSize> setPixel =
        //        (row, x, c) => row.UnsafeGetRefAs<byte>(x) = c.Blend(row.BitmapData.BackColor).GetBrightness();

        //    // Now we specify also a dispose callback to be executed when the returned instance is disposed:
        //    return BitmapDataFactory.CreateBitmapData(
        //        bitmap.BackBuffer, new Size(bitmap.PixelWidth, bitmap.PixelHeight), bitmap.BackBufferStride,
        //        customPixelFormat, getPixel, setPixel,
        //        disposeCallback: () =>
        //        {
        //            bitmap.AddDirtyRect(new System.Windows.IntForm1.TileSizeRect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
        //            bitmap.Unlock();
        //        });
        //}
    }
}