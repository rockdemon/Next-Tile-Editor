using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class Sprite :ICloneable
    {
        public Sprite   (Palette9bit palette, int paletteOffsetFor4bit, nibble[] spriteNibbles, byte[] spriteData)
        {
            Palette = palette;
            this.paletteOffsetFor4bit = paletteOffsetFor4bit;
            this.sprData = spriteData;
        }

        public Palette9bit Palette { get; set; }
        public int paletteOffsetFor4bit { get; set; }

        public nibble[] sprNibbles
        {
            get
            {
                List<nibble> result = new List<nibble>();
                for (int i = 0; i < sprData.Length; i++)
                {
                    nibble a = (sprData[i] & 240) >> 4;
                    nibble b = (sprData[i] & 15);
                    result.Add(a);
                    result.Add(b);

                }
                return result.ToArray();
            }
        }
        public byte[] sprBytes { 
            get
            { 
                return sprData; 
            }
            set 
            { 
                sprData = value; 
            }
        }
        private byte [] sprData { get; set; }
        private Bitmap _bitmapData = null;
        public Bitmap bitmapData
        {
            get
            {
                int idx = 0;
                if (_bitmapData == null )
                    _bitmapData = new Bitmap(16, 16);
                using(Graphics g = Graphics.FromImage(_bitmapData))
                {
                    for (int iy = 0; iy < 16; iy++)
                    {
                        for (int ix = 0; ix < 16; ix++)
                        {
                            g.FillRectangle(new SolidBrush(Palette.Palettearray[sprNibbles[idx]].PalColor), ix, iy, 1, 1);
                            idx++;
                        }
                    }
                }
                return _bitmapData;
            }
            set
            {
                _bitmapData = value;
            }
        }

        public object Clone()
        {
            return (new Sprite (this.Palette, this.paletteOffsetFor4bit,null, this.sprData ) as object);
        }
    }
    
    public class nibble
    {
        private int _Value;

        public static implicit operator nibble(int value)
        {
            return new nibble { _Value = ((value >15) ? 15: (value<0?0:value    ))};
        }

        public static implicit operator int(nibble value)
        {
            return value._Value;
        }
    }
}
