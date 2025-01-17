using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class Tile :ICloneable
    {
        public Tile   (Palette9bit palette, int paletteOffsetFor4bit, nibble[] spriteNibbles, byte[] tileData)
        {
            Palette = palette;
            this.paletteOffsetFor4bit = paletteOffsetFor4bit;
            this.tileData = tileData;
        }

        private Tile()
        {
        }

        public static Tile FromPalette9ValArray( paletteValue9bit[] tileInNextColours,Palette9bit palette)
        {
            return new Tile { Palette = palette, TileFromNextColours = tileInNextColours };
        }

        private paletteValue9bit[] TileFromNextColours
        {
            set
            {
                List<nibble> nibbles = new List<nibble>();
                foreach (paletteValue9bit p in value)
                {
                    for (int i = 0; i < Palette.Palettearray.Length; i++)
                    {
                        if (Palette.Palettearray[i].Red == p.Red &&
                            Palette.Palettearray[i].Green == p.Green &&
                            Palette.Palettearray[i].Blue == p.Blue
                           )
                        {
                            nibbles.Add(i);
                            break;
                        }
                    }
                }   
                tileBytes = new byte[nibbles.Count/2];
                List<byte> bytes = new List<byte>();
                
                for (int i = 0;i < nibbles.Count;i+=2)
                {
                    if (i < nibbles.Count-1)
                    bytes.Add((byte)(nibbles[i] << 4 | nibbles[i+1]));
                }
                tileBytes = bytes.ToArray();
            }
        }
        
        public Palette9bit Palette { get; set; }
        public int paletteOffsetFor4bit { get; set; }

        public nibble[] tileNibbles
        {
            get
            {
                List<nibble> result = new List<nibble>();
                for (int i = 0; i < tileData.Length; i++)
                {
                    nibble a = (tileData[i] & 240) >> 4;
                    nibble b = (tileData[i] & 15);
                    result.Add(a);
                    result.Add(b);

                }
                return result.ToArray();
            }
        }
        public byte[] tileBytes { 
            get
            { 
                return tileData; 
            }
            set 
            { 
                tileData = value; 
            }
        }
        private byte [] tileData { get; set; }
        private Bitmap _bitmapData = null;
        public Bitmap bitmapData
        {
            get
            {
                int idx = 0;
                if (_bitmapData == null )
                    _bitmapData = new Bitmap(8, 8);
                using(Graphics g = Graphics.FromImage(_bitmapData))
                {
                    for (int iy = 0; iy < 8; iy++)
                    {
                        for (int ix = 0; ix < 8; ix++)
                        {
                            g.FillRectangle(new SolidBrush(Palette.Palettearray[tileNibbles[idx]+this.paletteOffsetFor4bit*16].PalColor), ix, iy, 1, 1);
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
            return (new Tile (this.Palette, this.paletteOffsetFor4bit,null, this.tileData ) as object);
        }

        public  byte[] getHash()
        {
            return MD5.HashData(this.tileData);
        }
            

        public bool Equals( Tile other )
        {
            if ( other == null ) return false;
            if ( this.tileBytes.Length != other.tileBytes.Length ) return false;
            for(int i = 0;i < this.tileBytes.Length;i++)
            {
                if (this.tileBytes[i] != other.tileBytes[i]) return false;
            }
            
            return true;
        }
    }
    
    
}
