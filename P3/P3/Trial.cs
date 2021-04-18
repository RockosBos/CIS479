using System;
using System.Collections.Generic;
using System.Text;

namespace P3
{
    class Trial
    {
        public int gridLocation;
        public int locationX;
        public int locationY;
        public int moves;

        public Trial() {
            
        }

        public void updateGridLocationFromXY()
        {
            gridLocation = locationY * 7 + locationX;
        }

        public void updateXYLocationsFromGrid()
        {
            locationX = gridLocation % 7;
            locationY = gridLocation / 7;
        }

    }
}
