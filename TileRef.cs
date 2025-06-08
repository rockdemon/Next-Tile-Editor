using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class TileRef
    {
        private byte _flags = 0;
        private byte _index = 0;
        public byte flags { get; set; }
        public byte index { get; set; }
        public TileRef(byte flags, byte index)
        {
            this.flags = flags;
            this.index = index;
        }

        public int tileIndex
        {
            get
            {
                return (int)index + ((int)flags & 0b00000001 * 256);
            }
            set
            {
                this.flags = (byte)(value > 255 ? flags | 1 : flags);
                this.index = (byte)(value & 0b11111111);
            }

        }
    }

}
