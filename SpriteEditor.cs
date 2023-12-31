using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class SpriteEditor : Panel
    {
        public SpriteEditor() :base()
        {
            this.Paint += SpriteEditor_Paint;
            this.MouseDown += SpriteEditor_MouseDown;
            this.MouseUp += SpriteEditor_MouseUp;
            this.MouseMove += SpriteEditor_MouseMove;
            this.MouseLeave += SpriteEditor_MouseLeave;
            this.MouseClick += SpriteEditor_Click;
            PaperIdx = 15;
            InkIdx = 0;
        }
        bool mousedown = false;
        private void SpriteEditor_MouseLeave(object? sender, EventArgs e)
        {
            mousedown = false;
        }

        private void SpriteEditor_MouseMove(object? sender, MouseEventArgs e)
        {
            if (this.Sprite == null || ! mousedown)
                return;
            int val = 1;
            if (e.Button == MouseButtons.Left)
            {
                val = this.InkIdx;
            }
            else if (e.Button == MouseButtons.Right)
            {
                val = this.PaperIdx;
            }
            // get tile byte array that corresponds,
            int tx = (int)(e.X / (this.Width / 16));
            int ty = (int)(e.Y / (this.Height / 16));
            if (tx > 15)
                tx = 15;
            if (ty > 15)
                ty = 15;



            int byteNo = tx / 2 + ty * 8;
            if ((tx & 0b1) != 0) // are we odd?
            {
                this.Sprite.sprBytes[byteNo] = (byte)((this.Sprite.sprBytes[byteNo] & 0b11110000) + val);
            }
            else
            {   // we mus be even
                this.Sprite.sprBytes[byteNo] = (byte)((this.Sprite.sprBytes[byteNo] & 0b1111) + (val << 4));
            }

            Invalidate();
        }

        private void SpriteEditor_MouseUp(object? sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void SpriteEditor_MouseDown(object? sender, MouseEventArgs e)
        {
            mousedown=true;
        }

        public Palette9bit Palette
        {
            get;
            set;
        }

        public int PaperIdx
        {
            get;
            set;
        }
        public int InkIdx
        {
            get;
            set;
        }
        
        private void SpriteEditor_Click(object? sender, MouseEventArgs e)
        {
            
        }

        private void SpriteEditor_Paint(object? sender, PaintEventArgs e)
        {
            if (Sprite==null)
            {
                e.Graphics.Clear(Color.Black);
                return;
            }
            int tempheight = Height > 16 ? Height / 16 : 1;
            int tempwidth = Width > 16 ? Width / 16 : 1;
            int _x = 0, _y=0,idx = 0;
            for (int iy = 0; iy < 16; iy++)
            {

                for (int ix = 0; ix < 16; ix++)
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(Sprite.Palette.Palettearray[Sprite.sprNibbles[idx]+(Sprite.paletteOffsetFor4bit*16)].PalColor),
                        _x,
                        _y,
                        tempwidth,
                        tempheight
                        );
                    idx++;
                    _x += tempwidth;
                }
                _y += tempheight;_x = 0;
            }
        }

        public Sprite Sprite { get; set; }
    }
}
