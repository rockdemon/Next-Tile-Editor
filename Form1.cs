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
        public static int PixelSize = 4;

        public Form1()
        {
            this.Size = new System.Drawing.Size(1400, 800);
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            DefaultTileBitmaps();

            this.pnlTileMap.Paint += Panel1_Paint;
            this.TilemapPaletteInkAndPaperPicker.InkColourChanged += PnlPalettePicker_InkColourChanged;
            this.TilemapPaletteInkAndPaperPicker.PaperColourChanged += PnlPalettePicker_PaperColourChanged;

            pnlTileMap.Invalidate();

            NextPalette.InkColoursChanged += NextPalette_SelectedColoursChanged;
            NextPalette.PaperColoursChanged += NextPalette_PaperColoursChanged;
            pnlTilePalette.Invalidate();
            pnlTileMap.MouseMove += PnlTileMap_MouseMove;
            pnlTileMap.MouseLeave += PnlTileMap_MouseLeave;
            pnlTileMap.MouseEnter += PnlTileMap_MouseEnter;
            pnlTileMap.MouseClick += PnlTileMap_MouseClick;
            NextPalette.InkColoursChanged += NextPalette_SelectedColoursChanged1;
        }

        private void PnlPalettePicker_PaperColourChanged(object sender, ColourChangedEventArgs e)
        {


            tileEditor1.PaperVal = e.colourIdx;

            tileEditor1.Invalidate();
        }

        private void PnlPalettePicker_InkColourChanged(object sender, ColourChangedEventArgs e)
        {


            tileEditor1.InkVal = e.colourIdx;

            tileEditor1.Invalidate();
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
            this.baTilePalette[InkIndex * 2 + 1] = bs[1];
            tileEditor1.palette = Palette9bit.FromByteArray(baTilePalette);
            UpdatePalettePicker();
            this.TilemapPaletteInkAndPaperPicker.Invalidate();

        }

        private void setPaperForIdx(paletteValue9bit paperCol)
        {

            byte[] bs = paperCol.toSaveBytes();

            this.baTilePalette[PaperIndex * 2] = bs[0];
            this.baTilePalette[PaperIndex * 2 + 1] = bs[1];
            tileEditor1.palette = Palette9bit.FromByteArray(baTilePalette);
            UpdatePalettePicker();
            this.TilemapPaletteInkAndPaperPicker.Invalidate();
        }



        public int InkIndex
        { get; set; }

        public int PaperIndex { get; set; }



        private void PnlTileMap_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePos != null && mousePos.Value != null)
            {
                if (baMap != null)
                {
                    int tmX = mousePos.Value.X / Form1.TileSize;
                    int tmY = mousePos.Value.Y / Form1.TileSize;
                    baMap[tmX + tmY * 40 + 1].tileIndex = (byte)iSourceIndex;
                    UpdateTileMap();
                    pnlTileMap.Invalidate();
                }
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
            //noFrames = listFileNames.Count;
            noFrames = 0;
            List<Image> tempImages = new List<Image>();
            for (int i = 0; i < listFileNames.Count; i++)
            {
                Bitmap tempImage = (Bitmap)Bitmap.FromFile(listFileNames[i]);

                if (tempImage.Height != tempImage.Width)
                {
                    if (tempImage.Height > tempImage.Width)
                    {
                        // slice it the right way
                        ;
                        for (int iy = 0; iy < tempImage.Height; iy += tempImage.Width)
                        {
                            Bitmap bmTemp = new Bitmap(16, 16);
                      
                            BitmapUtils.CopyBitmap(tempImage, bmTemp, new Rectangle(0, 0, 16, 16), new Rectangle( 0,iy , tempImage.Width, tempImage.Width));

                            spriteImages.Add(bmTemp);
                            noFrames++;
                        }
                    }

                    else
                    {
                        //slice it the other way
                        for (int ix = 0; ix < tempImage.Width; ix += tempImage.Height)
                        {
                            Bitmap bmTemp = new Bitmap(16, 16);
                            using (Graphics g = Graphics.FromImage((Image)bmTemp))
                            {
                                g.DrawImage((Image)tempImage, new Point[] { new Point(0, 0),new Point(0,16), new Point(16,0)},
                                    new Rectangle(ix, 0, tempImage.Height, tempImage.Height), GraphicsUnit.Pixel);
                            }


                            spriteImages.Add(bmTemp);
                            byte[] baCurSpr = Get4x8ByteArrForBmp(bmTemp);
                            
                            Sprite spr = new Sprite(palette: get9bitPaletteFromImage(bmTemp), (int)numericUpDown1.Value, spriteNibbles: null, spriteData: baCurSpr);

                            lstSprites.Add(spr);
                            noFrames++;
                        }

                    }

                }
                else

                {
                    spriteImages.Add(tempImage);
                    Sprite spr = new Sprite(palette: Palette9bit.FromByteArray(baSpritePalette), (int)numericUpDown1.Value, spriteNibbles: null, spriteData: Get4x8ByteArrForBmp(tempImage));

                    lstSprites.Add(spr);
                    noFrames++;
                }
        }
            for (int i = 0; i<noFrames; i++)
            {
            

            if (i >= pictureBoxes.Count)
                {
                    pictureBoxes.Add(new PictureBox());

                };

                pictureBoxes[i].Image = spriteImages[i];

            }

            UpdatePictureBoxes();
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
        private Palette9bit get9bitPaletteFromImage(Image img)
        {
                Palette9bit List9BitColours = new Palette9bit();
                List<paletteValue9bit> Palette = new List<paletteValue9bit>();
            List9BitColours.Palettearray= new paletteValue9bit[512]; // 256 colours, 2 bytes each
                int ix = 0;
                Bitmap bitmapImage = img as Bitmap;
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
                            if (!Palette.Contains(paletteValue9bit.FromColor(c))
                                && Palette.Count < 256)
                            {
                                Palette.Add(paletteValue9bit.FromColor(c));
                                List9BitColours.Palettearray[ix] = paletteValue9bit.FromColor(c);
                                ix++;
                            }
                            else if (Palette.Count >= 256)
                            {
                                // we have enough colours
                                break;
                            }
                        }
                    }
                }

                bitmapImage.UnlockBits(bData);
                
                //for (int y = 0; y < bitmapImage.Height; y++)
                //{
                //    for (int x = 0; x < bitmapImage.Width; x++)
                //    {
                //        Color c = bitmapImage.GetPixel(x, y);
                //        baImg[y * bitmapImage.Width + x] = paletteValue9bit.FromColor(c);
                //    }
                //}
                //List9BitColours.Add(baImg);
                return List9BitColours;

        }
        List<Sprite> lstSprites = new List<Sprite>();
        public void UpdateSprites(byte[] SpriteList, bool b4bit = true)
        {
            if (SpriteList == null)
            {
                return;
            }
            if (SpriteList.Length != 0)
            {
                lstSprites.Clear();
                //2 pixels per byte 16x16. 16 * 8 = 128 bytes
                int noblocks = SpriteList.Length / 128;// .Count;
                for (int i = 0; i < noblocks; i++)
                {
                    byte[] baCurSpr = new byte[128];
                    Array.Copy(SpriteList, i * 128, baCurSpr, 0, 128);
                    Sprite spr = new Sprite(palette: Palette9bit.FromByteArray(baSpritePalette), (int)numericUpDown1.Value, spriteNibbles: null, spriteData: baCurSpr);
                    // Image tempImage = LockUnlockBitsLowLevelUpdate((Bitmap)Bitmap.FromFile(listFileNames[i]));
                    spriteImages.Add(spr.bitmapData);
                    lstSprites.Add(spr);
                    if (i >= pictureBoxes.Count)
                    {
                        PictureBox pb = new PictureBox();
                        pb.Name = "" + i;
                        pb.Click += Pb_Click;
                        pictureBoxes.Add(pb);

                    };

                    pictureBoxes[i].Image = spr.bitmapData;
                    pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                }


                UpdatePictureBoxes();
            }

        }

        /// <summary>
        /// Sprite selected for editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pb_Click(object? sender, EventArgs e)
        {
            if (int.TryParse(((sender) as PictureBox).Name, out int idx))
            {
                spriteEditor1.Sprite = (Sprite)lstSprites[idx].Clone();
                spriteEditor1.Invalidate();
            }
            else
            {
                spriteEditor1.Sprite = null;
            }
        }

        public void UpdatePictureBoxes()
        {
            //      _quantizeImages();
            this.pnlSprites.Controls.Clear();
            if (pictureBoxes.Count > 0)
            {
                int tempx = 0; int tempy = 0;
                for (int i = 0; i < ((noFrames == 0) ? (128) : noFrames); i++)
                {
                    pictureBoxes[i].Size = new Size(64, 64);

                    spriteImages[i] = lstSprites[i].bitmapData;
                    pictureBoxes[i].Image = spriteImages[i] as Bitmap;
                    this.pnlSprites.Controls.Add(pictureBoxes[i]);
                    this.pictureBoxes[i].Location = new Point(tempx, tempy);

                    this.pictureBoxes[i].Visible = true;
                    tempx = tempx + 64;
                    if (tempx + 64 > pnlSprites.Width)
                    {
                        tempy = tempy + 64;
                        tempx = 0;
                    }
                    this.label1.Text = String.Format("width {0} height {1}", pictureBoxes[i].Image.Width, pictureBoxes[i].Image.Height);
                }
            }
        }

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

        private byte[] Get4x8ByteArrForBmp(Bitmap bmp)
        {
            byte[] bytesRet = new byte[128];
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
            _quantizeImages();
        }
        private void _quantizeImages()
        {

            var customPixelFormat = new PixelFormatInfo { BitsPerPixel = 8, Grayscale = false, HasAlpha = false, };

            var targetFormat = System.Drawing.Imaging.PixelFormat.Format4bppIndexed; // feel free to try other formats as well
            for (int ix = 0; ix < this.spriteImages.Count; ix++)
            {
                using (Bitmap bmpSrc = (Bitmap)this.spriteImages[ix])
                using (Bitmap bmpDst = new Bitmap(bmpSrc.Width, bmpSrc.Height, targetFormat))
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

                    //bmpSrc.SaveAsPng(@"c:\temp\bmpSrc.png");
                    bmpDst.SaveAsPng(@"c:\temp\bmpDst" + ix + ".png"); // or saveAsGif/SaveAsTiff to preserve the indexed format
                                                                       //      bmpDst.Palette.#
                    Palette9bit pal = new Palette9bit();

                    lstSprites.Add(new Sprite(pal, 0, null, Get16x16ByteArrForBmp(bmpDst)));
                }
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
            if (res == DialogResult.OK)
            {
                byte[] bin = File.ReadAllBytes(ofd.FileName);
                baSprites = bin;
                UpdateSprites(baSprites);
            }
        }

        byte[] baSprites = null;


        TileRef[] baMap = null;

        private void btnLoadTileMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            ofd.Filter = "map files (*.map)|*.map|(*.tileMap)|*.tileMap";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                byte[] tempMap = File.ReadAllBytes(ofd.FileName);
                baMap = new TileRef[tempMap.Length / 2];
                for (int i = 0; i < tempMap.Length / 2; i++)
                {
                    baMap[i] = new TileRef(tempMap[i * 2 + 1], tempMap[i * 2]);
                }
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

                Palette9bit pal = baTilePalette != null ? Palette9bit.FromByteArray(baTilePalette) : new Palette9bit();
                int offset = 0;
                int iTile = 0;
                int iPaletteX = 0; int iPaletteY = 0;
                for (int i = 0; i < baTiles.Length / 32 && iTile < 128; i++)
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
                                    pal.Palettearray[firstNibble].PalColor), R1);
                            g.FillRectangle(new System.Drawing.SolidBrush(
                                    pal.Palettearray[secondNibble].PalColor),
                                        (ix + 1) * PixelSize, iy * PixelSize, PixelSize, PixelSize);
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
                        if (iPaletteX == 128)
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
            for (int i = 0; i < 256; i++)
            {
                Bitmap bmTemp = new Bitmap(Form1.TileSize, Form1.TileSize);
                Graphics g = Graphics.FromImage(bmTemp);
                g.DrawString("" + i, new Font("Arial", 8), System.Drawing.Brushes.Black, 0, 0);
                Tiles[i] = bmTemp;

            }
        }

        private bool _b2byteMap = true;
        public void UpdateTileMap()
        {
            int arrLength = baMap.Length;

            int height = arrLength / 40 + 1;
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
                            int index = x + (y * 40);
                            if ((Tiles[baMap[index].index]) == null)
                                Tiles[baMap[index].index] = new Bitmap(TileSize, TileSize);
                            if (this.baMap[index].index < 128)
                            {
                                Color color;
                                g.DrawImage(Tiles[this.baMap[index].index], (x * TileSize), y * TileSize);
                                if (((x & 1) ^ (y & 1)) == 0) //even?
                                {
                                    color = Color.FromArgb(50, 255, 255, 255);
                                }
                                else
                                {
                                    color = Color.FromArgb(0, 0, 0, 0);
                                }
                                g.FillRectangle(new SolidBrush(color), x * TileSize, y * TileSize, TileSize, TileSize);
                            }

                        }
                        y++;
                    }
                    while ((y * 40) + 39 < baMap.Length);

                }
                else
                {
                    g.Clear(System.Drawing.Color.Magenta);
                }
            }
            pnlTileMap.Invalidate();
            TilemapPaletteInkAndPaperPicker.Invalidate();
            pnlTilePalette.Invalidate();

        }

        byte[] baTilePalette = null;
        private void btnLoadPalette_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;

            ofd.Filter = "map files (*.pal)|*.pal";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                baTilePalette = File.ReadAllBytes(ofd.FileName);
                Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
                this.TilemapPaletteInkAndPaperPicker.pal = pal;

                NextPalette.Palette = pal;

                TilemapPaletteInkAndPaperPicker.Location = new Point(132, 0);
                pnlTilePalette.Location = new Point(0, 0);


                pnlTileMap.Invalidate();
                TilemapPaletteInkAndPaperPicker.Invalidate();
                pnlTilePalette.Invalidate();

            }
        }
        private void UpdatePalettePicker()
        {
            Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);

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
                //     File.WriteAllBytes(saveFileDialog.FileName, baMap);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)(sender as NumericUpDown).Value;
            tileEditor1.PaletteOffset = val;

        }

        /// <summary>
        /// Save tile back into 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveTileDef(object sender, EventArgs e)
        {

            for (int ix = 0; ix < Form1.TileSize; ix++)
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

                Tiles[iTile] = new Bitmap(32, 32);
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
                File.WriteAllBytes(ofd.FileName, baTilePalette);

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


        private void button3_Click(object sender, EventArgs e)
        {
            List<byte> listByes = new List<byte>();
            for (int ix = 0; ix <= 255; ix++)
                listByes.Add((byte)ix);

            baTilePalette = listByes.ToArray();
            Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
            this.TilemapPaletteInkAndPaperPicker.pal = pal;
            int offset = 0, iPaletteX = 0, iPaletteY = 0;
            NextPalette.Palette = pal;

            for (int iTile = 0; iTile <= 255; iTile++)
            {
                Tiles[iTile] = new Bitmap(32, 32);
                baTiles = new byte[8192];
                using (Graphics g = Graphics.FromImage(Tiles[iTile]))
                {
                    int ix = 0;
                    int iy = 0;
                    for (int j = 0; j < 32; j++)
                    {
                        byte firstNibble = (byte)((baTiles[offset] & 0b11110000) >> 4);
                        byte secondNibble = (byte)(baTiles[offset] & 0b00001111);
                        Rectangle R1 = new Rectangle(ix * PixelSize, iy * PixelSize, PixelSize, PixelSize);
                        g.FillRectangle(new System.Drawing.SolidBrush(
                            pal.Palettearray[firstNibble].PalColor), R1);
                        g.FillRectangle(new System.Drawing.SolidBrush(
                                pal.Palettearray[secondNibble].PalColor),
                            (ix + 1) * PixelSize, iy * PixelSize, PixelSize, PixelSize);
                        ix += 2;
                        offset++;
                        if (ix > 7)
                        {
                            ix = 0;
                            iy++;
                        }

                    }

                    PictureBox tilePB = new PictureBox
                    {
                        Location = new Point(iPaletteX, iPaletteY),
                        Image = Tiles[iTile],
                        Visible = true,
                        Size = new Size(32, 32),
                        Name = "Tile_" + iTile
                    };

                    tilePB.Click += TilePB_Click;
                    pnlTilePalette.Controls.Add(tilePB);
                    iPaletteX += 32;
                    if (iPaletteX == 128)
                    {
                        iPaletteY += 32;
                        iPaletteX = 0;
                    }

                    iTile++;
                }
            }

            this.baMap = new TileRef[(int)numWidth.Value * (int)numHeight.Value];

            UpdateTileMap();

        }

        private void btnSaveAsPNG_Click(object sender, EventArgs e)
        {

        }

        byte[] baSpritePalette = null;
        private void btnLoadSpritePalette_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            ofd.Filter = "map files (*.pal)|*.pal";
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                baSpritePalette = File.ReadAllBytes(ofd.FileName);
                Palette9bit pal = Palette9bit.FromByteArray(baSpritePalette);
                this.SpritePaletteInkAndPaperPicker.pal = pal;
                this.SpritePaletteInkAndPaperPicker.Invalidate();

            }
        }

        private void SpritePaletteInkAndPaperPicker_InkColourChanged(object sender, ColourChangedEventArgs e)
        {
            this.spriteEditor1.InkIdx = e.colourIdx;
        }

        private void SpritePaletteInkAndPaperPicker_PaperColourChanged(object sender, ColourChangedEventArgs e)
        {
            this.spriteEditor1.PaperIdx = e.colourIdx;
        }

        private void btnWriteToSprite_Click(object sender, EventArgs e)
        {
            int sprNum = (int)numSpriteNum.Value;
            PictureBox pb = pnlSprites.Controls[sprNum] as PictureBox;
            if (pb != null)
                pb.Image = spriteEditor1.Sprite.bitmapData;
            spriteImages[sprNum] = spriteEditor1.Sprite.bitmapData;
            lstSprites[sprNum] = (Sprite)this.spriteEditor1.Sprite.Clone();
        }

        private void numSpritePaletteOffset_ValueChanged(object sender, EventArgs e)
        {
            int offset = (int)((sender as NumericUpDown).Value);
            foreach (Sprite sprite in lstSprites)
            {
                sprite.paletteOffsetFor4bit = offset;

            }
            UpdatePictureBoxes();
            if (spriteEditor1.Sprite != null)
            {
                this.spriteEditor1.Sprite.paletteOffsetFor4bit = offset;
                this.spriteEditor1.Invalidate();
            }
        }

        private void btn_ImportImageAndCreateTiles(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image im = Image.FromFile(ofd.FileName);
                List<Bitmap> images = new List<Bitmap>();
                if (im != null)
                {
                    for (int ix = 0; ix < im.Width; ix += 8)
                    {
                        for (int iy = 0; iy < im.Height; iy += 8)
                        {
                            Bitmap bmTemp = new Bitmap(8, 8);
                            bmTemp.Clone(new Rectangle(ix, iy, 8, 8), PixelFormat.Format32bppRgb);

                            images.Add((Bitmap)bmTemp);
                        }
                    }
                }
            }
        }

        private void tile32PixImport1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = curDir;
            sfd.Filter = "project files (*.proj)|*.proj";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tileMapObjs.GetInstance().Save(sfd.FileName);
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = curDir;
            ofd.Filter = "project files (*.proj)|*.proj";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tileMapObjs.GetInstance().Load(ofd.FileName);
            }
            this.Invalidate();
            this.tile32PixImport1.refreshFromObjs();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tileMapObjs.GetInstance().Clear();
            this.Invalidate();
        }
    }
}