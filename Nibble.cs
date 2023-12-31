using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_tile_editor
{
    public class nibble
    {
        private int _Value;

        public static implicit operator nibble(int value)
        {
            return new nibble { _Value = ((value > 15) ? 15 : (value < 0 ? 0 : value)) };
        }

        public static implicit operator int(nibble value)
        {
            return value._Value;
        }
    }
}
