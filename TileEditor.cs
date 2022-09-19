using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class TileEditor :Panel
    {
        NumericUpDown _numericPaletteOffset;
        private Bitmap _Bitmap = null;
        public TileEditor() :base()
        {
            
            Size size = new Size(256, 320);
            
            

            MouseClick += TileEditor_MouseClick;
        }

        private void TileEditor_MouseClick(object? sender, MouseEventArgs e)
        {
            paletteValue9bit paletteValue9BitPaint = null;
            int val = 1;
            if (e.Button == MouseButtons.Left)
            {
                //get ink colour
                paletteValue9BitPaint = this.Ink;
                val = this.InkVal;
            }
            else if (e.Button == MouseButtons.Right)
            {
                // get paper colour
                paletteValue9BitPaint = this.Paper;
                val = this.PaperVal;
            }
            // get tile byte array that corresponds,
            int tx = (int)(e.X / 32);
            int ty = (int)(e.Y / 32);

            int byteNo = tx / 2 + ty * 4;
            if ((tx & 0b1 )!= 0) // are we odd?
            {
                Tile[byteNo] = (byte)((Tile[byteNo] & 0b11110000)+ val);
            }
            else
            {   // we mus be even
                Tile[byteNo] = (byte)((Tile[byteNo] & 0b1111) + (val<<4));

            }
            UpdateBmp();
            Invalidate();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_Bitmap != null)
                e.Graphics.DrawImage(_Bitmap, 0, 0);
        }

 

        public bool Mode8x8
        {
            get { return true; }
        }
        private byte[] _Tile = null;
        public byte[] Tile
        {
            get
            {
                return _Tile;
            }
            set
            { 
                _Tile = value;
                UpdateBmp();
                this.Invalidate();
            }

        }

        public Palette9bit palette
        {
            get;
            set;
        }
        public paletteValue9bit Ink
        {
            get;
            set;
        }
        public int InkVal
        {
            get;
            set;
        }
        public int PaperVal
        {
            get;
            set;
        }
        public paletteValue9bit Paper
        {
            get;
            set;
        }

        int _paletteOffset = 0;
        public int PaletteOffset
        {
            get { return _paletteOffset; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 15)
                    value = 15;

                _paletteOffset = value;
                UpdateBmp();
                Invalidate();
            }
        }

        private void UpdateBmp()
        {
            if (_Bitmap == null)
                _Bitmap = new Bitmap(256, 256);
            int pixelWidth = _Bitmap.Width / 8;
            int pixelHeight = _Bitmap.Height / 8;
            int iX = 0, iY = 0;
            int iByte = 0;
            if (Tile != null)
            {
                using (Graphics g = Graphics.FromImage(_Bitmap))
                {
                    while (iY < _Bitmap.Height && iByte <Tile.Length)
                    {
                        byte ourByte = (byte)(Tile[iByte]);
                        byte p1 = (byte)(( ourByte & 0b11110000)>>4);
                        byte p2 = (byte)(ourByte & 0b00001111);
                        iByte++;
                        g.FillRectangle(
                            new SolidBrush(palette.Palettearray[p1+_paletteOffset].PalColor), new Rectangle(iX, iY, pixelWidth, pixelHeight));
                        g.FillRectangle(
                            new SolidBrush(palette.Palettearray[p2+_paletteOffset].PalColor), new Rectangle(iX+pixelWidth, iY, pixelWidth, pixelHeight));
                        iX = iX + 2*pixelWidth;
                        if (iX >= _Bitmap.Width)
                        {
                            iX = 0;
                            iY = iY + pixelHeight;
                        }    
                        
                    }
                }
                this.Invalidate();
            }

        }
    }
}
