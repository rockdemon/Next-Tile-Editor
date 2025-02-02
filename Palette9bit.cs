using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    
        public class Palette9bit
        {
            public paletteValue9bit[] Palettearray;
            public static Palette9bit FromByteArray(byte[] baLoadedNextPalette)
            {
                Palette9bit ret = new Palette9bit();
                List<paletteValue9bit> lstPaletteEntries = new List<paletteValue9bit>();
                int lengthOfArray = baLoadedNextPalette.Length;
                for (int i = 0; i < lengthOfArray; i += 2)
                {
                    lstPaletteEntries.Add(paletteValue9bit.From2bytes(baLoadedNextPalette[i], baLoadedNextPalette[i + 1]));
                }
                ret.Palettearray = lstPaletteEntries.ToArray();
                return ret;
            }

            public Palette9bit()
            {
                List<paletteValue9bit> lstPaletteEntries = new List<paletteValue9bit>();


                for (int i = 0; i < 255; i ++)
                {
                    lstPaletteEntries.Add(paletteValue9bit.FromColor(Color.FromArgb(i & 0b11100000, i & 0b00011100, i& 0b00000011)));
                }
                this.Palettearray = lstPaletteEntries.ToArray();

        }
        public byte[] SaveByteArray
        {
            get
            {
                List<byte> ret = new List<byte>();
                foreach (paletteValue9bit pv in  this.Palettearray)
                {
                    ret.AddRange(pv.toSaveBytes());
                }
                return ret.ToArray();
            }
        }
        public byte[] FromSaveByteArray
        {
            set
            {
                this.Palettearray = new paletteValue9bit[256];
                int idx = 0;
                for (int i = 0; i < value.Length; i ++)
                {
                    byte byte1 = value[i];
                    if (i + 1 == value.Length)
                        throw new Exception("invalid 9 bit palette");
                    byte byte2 = value[i + 1];
                    i++;
                    Palettearray[i] = paletteValue9bit.From2bytes(byte1, byte2);
                    idx++;
                }

            }
        }

    }

        public class paletteValue9bit
        {
            public int Value
            {
                get
                {
                    return Red << 6 + Green << 3 + Blue;
                }
            }

            public override bool Equals(object? obj)
            {
                if (obj != null && obj as paletteValue9bit != null)
                {
                    paletteValue9bit compare = (paletteValue9bit)obj;
                    return this.Red == compare.Red&& this.Green == compare.Green && this.Blue == compare.Blue;
                }
                return false;
                
            }

            public byte Red { get; set; }
            public byte Green { get; set; }
            public byte Blue { get; set; }
            public static paletteValue9bit FromColor(System.Drawing.Color color)
            {
                paletteValue9bit ret = new paletteValue9bit();
                ret.Red = (byte)(((color.R) & 0b11100000) >> 5);
                ret.Green = (byte)(((color.G) & 0b11100000) >> 5);
                ret.Blue = (byte)(((color.B) & 0b11100000) >> 5);
                return ret;

            }
            public static paletteValue9bit From2bytes(byte b1, byte b2)
            {
                paletteValue9bit ret = new paletteValue9bit();
                ret.Blue = (byte)(((b1 & 0b11) << 1) + (b2 & 0b1));
                ret.Green = (byte)((b1 & 0b11100) >> 2);
                ret.Red = (byte)((byte)((int)((int)b1) & 0b11100000) >> 5);
                return ret;
            }
            public System.Drawing.Color PalColor
            {
                get
                {

                    return System.Drawing.Color.FromArgb(
                                        (Red << 5) + (Red << 2) + ((Red & 110) >> 1),
                                        (Green << 5) + (Green << 2) + ((Green & 110) >> 1),
                                        (Blue << 5) + (Blue << 2) + ((Blue & 110) >> 1)
                                        );
                    //   (pal.Palettearray[secondNibble].Red << 5) + (pal.Palettearray[secondNibble].Red << 2) + ((pal.Palettearray[secondNibble].Red & 110) >> 1)
                }
            }
            public byte[] toSaveBytes()
            {
                byte b2 = (byte)(Blue & 1);
                byte b1 = (byte)((Red << 5) + (Green << 2) + ((Blue & 0b110) >> 1));
                return new byte[] { b1, b2 };
            }

        }
    }

