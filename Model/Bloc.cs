using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Model
{
    internal class Bloc
    {
        private (int x, int y)[] initialCoords = new (int, int)[] { (0, 0), (0, 1), (0, 2), (0, 3) };
        public (int x, int y)[] coords = new (int, int)[] { (0, 0), (0, 1), (0, 2), (0, 3) };
        public void DownBlock ()
        {
            for (int i = 0; i < coords.Length; i++)
            {
                coords[i] = (coords[i].x + 1, coords[i].y);
            }
        }

        public void Reset ()
        {
            coords = initialCoords;
        }
    }
}
