using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class ColourChangedEventArgs: EventArgs
    {
        public int colourIdx { get; set; }
        public paletteValue9bit PaletteValue9Bit { get; set; }
    }
    public class PalettePicker : Panel
    {

        public PalettePicker ()
            {
            this.Invalidate();
            this.MouseClick += PnlPalettePicker_MouseClick;
            }
   
        private Palette9bit _palette9Bit = null;

        public Palette9bit pal
        {
            get
            {
                return _palette9Bit;
            }
            set
            {
                _palette9Bit = value;
                if (_palette9Bit != null)
                {
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
                }
                else
                    Graphics.FromImage(bmPalettePicker).Clear(DefaultBackColor);

            }
        }

        Bitmap bmPalettePicker = new Bitmap(128, 1024);


        private void PnlPalettePicker_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmPalettePicker, 0, 0);
        }
        private void PnlPalettePicker_MouseClick(object? sender, MouseEventArgs e)
        {
            Point pos = new Point(e.X, e.Y);
            //pos = this.PointToClient(pos);
            int idx = ((int)(pos.X / 32)) + ((int)pos.Y / 32) * 4;
            if (e.Button == MouseButtons.Left)
            {
                InkColourChanged?.Invoke(this, new ColourChangedEventArgs { colourIdx = idx, PaletteValue9Bit = this._palette9Bit.Palettearray[idx] });
                //InkIndex = idx;
            }
            else
            {
                PaperColourChanged?.Invoke(this, new ColourChangedEventArgs { colourIdx = idx, PaletteValue9Bit = this._palette9Bit.Palettearray[idx] });

                
            }
            

        }
        public event InkColourChangedEventHandler InkColourChanged;
        public delegate void InkColourChangedEventHandler (object sender, ColourChangedEventArgs e);
        public event PaperColourChangedEventHandler PaperColourChanged;
        public delegate void PaperColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        private void UpdatePalettePicker()
        {
           // ; Palette9bit pal = Palette9bit.FromByteArray(baTilePalette);
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
//         ;   NextPalette.Palette = pal;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImageUnscaled(bmPalettePicker, 0, 0);
        }

    }
}
