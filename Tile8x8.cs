using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    /***
     *bits 15-12 : palette offset
       bit 11 : x mirror
       bit 10 : y mirror
       bit 9 : rotate
       bit 8 : ULA over tilemap (in 512 tile mode, bit 8 of the tile number)
       bits 7-0 : tile number
     */
    public enum Modifier :int
    {
        None = 0,
        XMirror = 8,
        YMirror = 4,
        Rotate = 2
        
    }

    public class Tile8x8 : ICloneable
    {
        /// <summary>
        /// 
        /// Palette Offset 4-bit palette offset for this tile. This allows shifting colours to other 16-colour
        /// “banks” thus allowing us to reach the whole 256 colours from the palette.
        /// X Mirror
        /// Y Mirror
        /// Rotate
        /// If 1, this tile will be mirrored in X direction.
        /// If 1, this tile will be mirrored in Y direction.
        /// If 1, this tile will be rotated 90oclockwise.
        /// ULA Mode If1, this tile will be rendered on top, if 0 below ULA display. However in 512
        /// tile mode, this is the 8th bit of tile index.
        /// Tile8x8 Index
        /// 8-bit tile index within the tile definitions.
        /// </summary>
        /// <param name="palette"></param>
        /// <param name="paletteOffsetFor4bit"></param>
        /// <param name="mTileData"></param>
        /// <param name="spriteNibbles"></param>
        [JsonConstructor]
        public Tile8x8(Palette9bit palette, int paletteOffsetFor4bit, byte[] TileData)
        {
            Palette = palette;
            this.paletteOffsetFor4bit = paletteOffsetFor4bit;
            this.tileData = TileData;
        }

        private Tile8x8()
        {
        }
        
        public static Tile8x8 FromPalette9ValArray(paletteValue9bit[] tileInNextColours, Palette9bit palette)
        {
            return new Tile8x8 { Palette = palette, TileFromNextColours = tileInNextColours };
        }


        [JsonIgnore]
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
                            break; // palette value found so stop comparison otherwise we will have duplicates
                        }
                    }
                }

                tileData = new byte[nibbles.Count / 2];
                List<byte> bytes = new List<byte>();

                for (int i = 0; i < nibbles.Count; i += 2)
                {
                    if (i < nibbles.Count - 1)
                        bytes.Add((byte)(nibbles[i] << 4 | nibbles[i + 1]));
                }

                tileData = bytes.ToArray();
            }
        }

        public Palette9bit Palette { get; set; }
        public int paletteOffsetFor4bit { get; set; }

        public int Index { get; set; }

        [JsonIgnore]
        public nibble[] tileNibbles
        {
            get
            {
                List<nibble> result = new List<nibble>();
                if (tileData == null || tileData.Length == 0)
                {
                    tileData = new byte[32]
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };
                }
                    
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

        //public byte[] tileData
        //{
        //    get { return m_tileData; }
        //    set { m_tileData = value; }
        //}

        [JsonIgnore]
        public byte[] tileData { get; set; }

        [JsonIgnore]
        private Bitmap _bitmapData = null;

        [JsonIgnore]
        public Bitmap bitmapData
        {
            get
            {
                int idx = 0;
                if (_bitmapData == null)
                    _bitmapData = new Bitmap(8, 8);
                using (Graphics g = Graphics.FromImage(_bitmapData))
                {
                    for (int iy = 0; iy < 8; iy++)
                    {
                        for (int ix = 0; ix < 8; ix++)
                        {
                            g.FillRectangle(
                                new SolidBrush(Palette.Palettearray[tileNibbles[idx] + this.paletteOffsetFor4bit * 16]
                                    .PalColor), ix, iy, 1, 1);
                            idx++;
                        }
                    }
                }

                return _bitmapData;
            }
            set { _bitmapData = value; }
        }

        public object Clone()
        {
            return (new Tile8x8(this.Palette, this.paletteOffsetFor4bit, this.tileData) as object);
        }

        //public  byte[] getHash()
        //{
        //    return MD5.HashData(this.m_tileData);
        //}


        public bool Equals(Tile8x8? other, out bool rotated)
        {
            rotated = false;
            if (other == null) return false;
            bool retval = true;
            if (this.tileData.Length != other.tileData.Length) return false;
            for (int i = 0; i < this.tileData.Length; i++)
            {
                if (this.tileData[i] != other.tileData[i])
                {
                    retval = false;
                    break;
                }
            }

            if (retval) return retval;
            nibble[] rotatedNibbles = other.Rotated;
            for (int i = 0; i < this.tileNibbles.Length; i++)
            {
                if (this.tileNibbles[i] != rotatedNibbles[i]) return false;
            }

            rotated = true;
            return true;
        }
        //public override bool Equals(object? obj)
        //{

        //    if (obj is Palette9bit otherPalette)
        //    {
        //        return this.Palettearray.SequenceEqual(otherPalette.Palettearray);
        //    }
        //    return false;
        //}

        public bool EqualsVerticalMirror(Tile8x8? other, out bool rotated)
        {
            rotated = false;
            if (other == null) return false;
            bool retval = true;
            if (this.tileData.Length != other.tileData.Length) return false;
            for (int i = 0; i < this.tileData.Length; i += 4)
            {
                for (int ik = 0; ik < 4; ik++)
                {
                    int TileBytethis = i + ik;
                    int TileByteother = (tileData.Length - i - 4) + ik;
                    if (this.tileData[TileBytethis] != other.tileData[TileByteother])
                    {
                        retval = false;
                        break;
                    }
                }

            }
            if (retval)
                return retval;
            nibble[] rotatedNibbles = other.Rotated;
            for (int i = 0; i < this.tileNibbles.Length; i += 8)
            {
                for (int ik = 0; ik < 8; ik++)
                {
                    int TileNibblesthis = i + ik;
                    int TileNibblesother = (tileNibbles.Length - i - 8) + ik;
                    if (this.tileNibbles[TileNibblesthis] != rotatedNibbles[TileNibblesother])
                    {
                        return false;
                    }
                }
            }


            rotated = true;
            return true;
        }

        public bool EqualsHorizontalMirror(Tile8x8? other, out bool rotated)
        {
            rotated = false;
            if (other == null) return false;
            if (this.tileNibbles.Length != other.tileNibbles.Length) return false;
            bool retval = true;
            for (int i = 0; i < this.tileNibbles.Length; i += 8)
            {
                for (int ik = 0; ik < 8; ik++)
                {
                    int TileNibblethis = i + ik;
                    int TileNibblesother = i + 7 - ik;
                    if (this.tileNibbles[TileNibblethis] != other.tileNibbles[TileNibblesother]) return false;
                }

            }

            if (retval) return retval;

            for (int i = 0; i < this.tileNibbles.Length; i += 8)
            {
                for (int ik = 0; ik < 8; ik++)
                {
                    int TileNibblethis = i + ik;
                    int TileNibblesother = i + 7 - ik;

                    nibble[] rot = other.Rotated;
                    if (this.tileNibbles[TileNibblethis] != rot[TileNibblesother]) return false;
                }
            }

            rotated = true;
            return true;
        }

        public bool EqualsVerticalAndHorizontalMirror(Tile8x8? other, out bool rotated)
        {
            rotated = false;
            if (other == null) return false;
            if (this.tileNibbles.Length != other.tileNibbles.Length) return false;
            bool retval = true;
            for (int i = 0; i < this.tileNibbles.Length; i += 8)
            {
                for (int ik = 0; ik < 8; ik++)
                {
                    int TileBytethis = i + ik;
                    int TileByteother = (tileNibbles.Length - i) - ik - 1;
                    if (this.tileNibbles[TileBytethis] != other.tileNibbles[TileByteother])
                    {
                        retval = false;
                        break;
                    }

                }

            }

            if (retval) return retval;
            nibble[] rotatedNibbles = other.Rotated;
            for (int i = 0; i < this.tileNibbles.Length; i += 8)
            {
                for (int ik = 0; ik < 8; ik++)
                {
                    int TileBytethis = i + ik;
                    int TileByteother = (tileNibbles.Length - i) - ik - 1;
                    if (this.tileNibbles[TileBytethis] != rotatedNibbles[TileByteother])
                    {
                        return false;
                    }

                }

            }

            rotated = true;
            return true;
        }

        [JsonIgnore]
        public nibble[] Rotated
        {
            get
            {
                nibble[] result = new nibble[64];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        result[j * 8 + i] = tileNibbles[i * 8 + j];
                    }
                }

                return result;
            }
        }
    }

}
