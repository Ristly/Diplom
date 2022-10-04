using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class MazeGeneratorCell
    {
            public int X;
            public int Y;

            public bool WallLeft = true;
            public bool WallBottom = true;

            public bool used = false;
            public int Distance;

            public int? ExitX = null;
            public int? ExitY = null;
   
    }
}
