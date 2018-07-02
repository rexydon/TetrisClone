using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameClasses
{
    public class TetrisGameGrid
    {
        public Block[,] gridSpaces;

        public int height;
        public int width;

        //Constructor
        public TetrisGameGrid(int wantedWidth, int wantedHeight)
        {
            this.width = wantedWidth;
            this.height = wantedHeight;
            Initialize();
        }

        private void Initialize()
        {
            gridSpaces = new Block[width, height];
        }
    }
}
