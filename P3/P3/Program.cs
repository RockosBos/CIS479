using System;
using System.Collections.Generic;

namespace P3
{
    class Program
    {
        public static List<List<GridLocation>> grid = new List<List<GridLocation>>();
        static void Main(string[] args)
        {
            //Initialize Grid

            const int TRIALMAX = 50000;
            GridLocation[] array1 = { new GridLocation(-100), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0) };
            GridLocation[] array2 = { new GridLocation(-100), new GridLocation(), new GridLocation(0), new GridLocation(0), new GridLocation(), new GridLocation(0), new GridLocation(0) };
            GridLocation[] array3 = { new GridLocation(-100), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0) };
            GridLocation[] array4 = { new GridLocation(-100), new GridLocation(), new GridLocation(0), new GridLocation(0), new GridLocation(), new GridLocation(0), new GridLocation(0) };
            GridLocation[] array5 = { new GridLocation(-100), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(-100) };
            GridLocation[] array6 = { new GridLocation(-100), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(0), new GridLocation(100) };
            List<GridLocation> gridRow = new List<GridLocation>(array1);
            grid.Add(gridRow);
            gridRow = new List<GridLocation>(array2);
            grid.Add(gridRow);
            gridRow = new List<GridLocation>(array3);
            grid.Add(gridRow);
            gridRow = new List<GridLocation>(array4);
            grid.Add(gridRow);
            gridRow = new List<GridLocation>(array5);
            grid.Add(gridRow);
            gridRow = new List<GridLocation>(array6);
            grid.Add(gridRow);

            setGridIDs();

            var rand = new Random();

            //Loop for every trial
            for (int trial = 0; trial < TRIALMAX; trial++)
            {
                Trial currentTrial = new Trial();
                currentTrial.gridLocation = rand.Next(0, 41);
                currentTrial.updateXYLocationsFromGrid();
                while (!isValidLocation(currentTrial.gridLocation))
                {
                    currentTrial.gridLocation = rand.Next(0, 41);
                }
                currentTrial.updateXYLocationsFromGrid();

                //Once the initial location has been established we will run the trial from that point.

                while (!grid[currentTrial.locationY][currentTrial.locationX].terminalState)
                {
                    if(currentTrial.moves >= 100)
                    {
                        break;
                    }
                    int driftProbability;
                    driftProbability = rand.Next(0, 30);
                    char driftDirection = 'c';
                    if (driftProbability == 0)
                        driftDirection = 'b';
                    if (driftProbability == 1)
                        driftDirection = 'l';
                    if (driftProbability == 2)
                        driftDirection = 'r';

                    char bestDirection = grid[currentTrial.locationY][currentTrial.locationX].getBestDirection();
                    int windValue;
                    switch (bestDirection)
                    {
                        case 'n':
                            windValue = -2;
                            if(driftDirection == 'l')
                            {
                                bestDirection = 'w';
                            }
                            if(driftDirection == 'r')
                            {
                                bestDirection = 'e';
                            }
                            if (driftDirection == 'b')
                            {
                                bestDirection = 's';
                            }
                         
                            break;
                        case 'e':
                            if (driftDirection == 'l')
                            {
                                bestDirection = 'n';
                            }
                            if (driftDirection == 'r')
                            {
                                bestDirection = 's';
                            }
                            if (driftDirection == 'b')
                            {
                                bestDirection = 'w';
                            }
                            
                            break;
                        case 's':
                            if (driftDirection == 'l')
                            {
                                bestDirection = 'e';
                            }
                            if (driftDirection == 'r')
                            {
                                bestDirection = 'w';
                            }
                            if (driftDirection == 'b')
                            {
                                bestDirection = 'n';
                            }
                            
                            break;
                        case 'w':
                            if (driftDirection == 'l')
                            {
                                bestDirection = 's';
                            }
                            if (driftDirection == 'r')
                            {
                                bestDirection = 'n';
                            }
                            if (driftDirection == 'b')
                            {
                                bestDirection = 'e';
                            }
                           
                            break;
                    }
                    char nextMaxQDirection;
                    double nextmaxQValue = 0;
                    switch (bestDirection)
                    {
                        case 'n':
                            windValue = -2;


                            if (isValidLocation(currentTrial.gridLocation - 7) && isValidLocation(currentTrial.locationX, currentTrial.locationY - 1))
                            {
                                nextMaxQDirection = grid[currentTrial.locationY - 1][currentTrial.locationX].getBestDirection();
                                grid[currentTrial.locationY][currentTrial.locationX].northAccessFequency++;
                                if (grid[currentTrial.locationY][currentTrial.locationX].isBlocked)
                                {
                                    Console.WriteLine("Why");
                                }

                                switch (nextMaxQDirection)
                                {
                                    case 'n':
                                        nextmaxQValue = grid[currentTrial.locationY - 1][currentTrial.locationX].northQValue;
                                        break;
                                    case 'e':
                                        nextmaxQValue = grid[currentTrial.locationY - 1][currentTrial.locationX].eastQValue;
                                        break;
                                    case 's':
                                        nextmaxQValue = grid[currentTrial.locationY - 1][currentTrial.locationX].southQValue;
                                        break;
                                    case 'w':
                                        nextmaxQValue = grid[currentTrial.locationY - 1][currentTrial.locationX].westQValue;
                                        break;

                                }
                                grid[currentTrial.locationY][currentTrial.locationX].northQValue =
                                    grid[currentTrial.locationY][currentTrial.locationX].northQValue +
                                    (1 / grid[currentTrial.locationY][currentTrial.locationX].northAccessFequency)
                                    * (windValue + (0.9 * nextmaxQValue - grid[currentTrial.locationY][currentTrial.locationX].northQValue));
                                currentTrial.gridLocation = currentTrial.gridLocation - 7;
                                currentTrial.updateXYLocationsFromGrid();

                            }
                            break;
                        case 'e':
                            windValue = -3;

                            if (isValidLocation(currentTrial.gridLocation + 1) && isValidLocation(currentTrial.locationX + 1, currentTrial.locationY))
                            {
                                nextMaxQDirection = grid[currentTrial.locationY][currentTrial.locationX + 1].getBestDirection();

                                grid[currentTrial.locationY][currentTrial.locationX].eastAccessFequency++;
                                if (grid[currentTrial.locationY][currentTrial.locationX].isBlocked)
                                {
                                    Console.WriteLine("Why");
                                }

                                switch (nextMaxQDirection)
                                {
                                    case 'n':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX + 1].northQValue;
                                        break;
                                    case 'e':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX + 1].eastQValue;
                                        break;
                                    case 's':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX + 1].southQValue;
                                        break;
                                    case 'w':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX + 1].westQValue;
                                        break;

                                }

                                grid[currentTrial.locationY][currentTrial.locationX].eastQValue =
                                    grid[currentTrial.locationY][currentTrial.locationX].eastQValue +
                                    (1 / grid[currentTrial.locationY][currentTrial.locationX].eastAccessFequency)
                                    * (windValue + (0.9 * nextmaxQValue - grid[currentTrial.locationY][currentTrial.locationX].eastQValue));
                                currentTrial.gridLocation = currentTrial.gridLocation + 1;
                                currentTrial.updateXYLocationsFromGrid();

                            }
                            break;
                        case 's':
                            windValue = -1;

                            if (isValidLocation(currentTrial.gridLocation + 7) && isValidLocation(currentTrial.locationX, currentTrial.locationY + 1))
                            {
                                nextMaxQDirection = grid[currentTrial.locationY + 1][currentTrial.locationX].getBestDirection();

                                grid[currentTrial.locationY][currentTrial.locationX].southAccessFequency++;
                                if (grid[currentTrial.locationY][currentTrial.locationX].isBlocked)
                                {
                                    Console.WriteLine("Why");
                                }

                                switch (nextMaxQDirection)
                                {
                                    case 'n':
                                        nextmaxQValue = grid[currentTrial.locationY + 1][currentTrial.locationX].northQValue;
                                        break;
                                    case 'e':
                                        nextmaxQValue = grid[currentTrial.locationY + 1][currentTrial.locationX].eastQValue;
                                        break;
                                    case 's':
                                        nextmaxQValue = grid[currentTrial.locationY + 1][currentTrial.locationX].southQValue;
                                        break;
                                    case 'w':
                                        nextmaxQValue = grid[currentTrial.locationY + 1][currentTrial.locationX].westQValue;
                                        break;

                                }

                                grid[currentTrial.locationY][currentTrial.locationX].southQValue =
                                    grid[currentTrial.locationY][currentTrial.locationX].southQValue +
                                    (1 / grid[currentTrial.locationY][currentTrial.locationX].southAccessFequency)
                                    * (windValue + (0.9 * nextmaxQValue - grid[currentTrial.locationY][currentTrial.locationX].southQValue));
                                currentTrial.gridLocation = currentTrial.gridLocation + 7;
                                currentTrial.updateXYLocationsFromGrid();

                            }
                            break;
                        case 'w':
                            windValue = -1;
                            if(isValidLocation(currentTrial.gridLocation - 1) && isValidLocation(currentTrial.locationX - 1, currentTrial.locationY))
                            {
                                nextMaxQDirection = grid[currentTrial.locationY][currentTrial.locationX - 1].getBestDirection();

                                grid[currentTrial.locationY][currentTrial.locationX].westAccessFequency++;
                                if (grid[currentTrial.locationY][currentTrial.locationX].isBlocked)
                                {
                                    Console.WriteLine("Why");
                                }
                                

                                switch (nextMaxQDirection)
                                {
                                    case 'n':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX - 1].northQValue;
                                        break;
                                    case 'e':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX - 1].eastQValue;
                                        break;
                                    case 's':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX - 1].southQValue;
                                        break;
                                    case 'w':
                                        nextmaxQValue = grid[currentTrial.locationY][currentTrial.locationX - 1].westQValue;
                                        break;

                                }

                                grid[currentTrial.locationY][currentTrial.locationX].westQValue = grid[currentTrial.locationY][currentTrial.locationX].westQValue + (1 / grid[currentTrial.locationY][currentTrial.locationX].westAccessFequency) * (windValue + (0.9 * nextmaxQValue) - grid[currentTrial.locationY][currentTrial.locationX].westQValue);
                                currentTrial.gridLocation = currentTrial.gridLocation - 1;
                                currentTrial.updateXYLocationsFromGrid();

                            }
                            break;

                    }
                    currentTrial.moves++;

                }
                
            }
            PrintAccesses();
            PrintQValues();
            PrintOptimalPolicy();

        }
        public static bool isValidLocation(int gridlocation)
        {

            if ( gridlocation == 8 || gridlocation == 11 || gridlocation == 22 || gridlocation == 25 || gridlocation < 0 || gridlocation > 41)
            {
                return false;
            }
            return true;
        }
        public static bool isValidLocation(int locationX, int locationY)
        {

            if (locationX < 0 || locationX > 6 || locationY < 0 || locationX > 5) 
            {
                return false;
            }
            return true;
        }
        public static void setGridIDs()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grid[i][j].gridID = (i) * 7 + j;
                }
            }
        }
        public static void PrintBlockedTable()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(grid[i][j].isBlocked + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintGridIDs()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(grid[i][j].gridID + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintAccesses()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(Math.Round(grid[i][j].northAccessFequency, 2) + "/" + Math.Round(grid[i][j].eastAccessFequency, 2) + "/" + Math.Round(grid[i][j].southAccessFequency, 2) + "/" + Math.Round(grid[i][j].westAccessFequency, 2) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintQValues()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(Math.Round(grid[i][j].northQValue, 2) + "/" + Math.Round(grid[i][j].eastQValue, 2) + "/" + Math.Round(grid[i][j].southQValue, 2) + "/" + Math.Round(grid[i][j].westQValue, 2) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintOptimalPolicy()
        {
            string arrows = "";
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (!grid[i][j].isBlocked)
                    {
                        if(grid[i][j].northQValue == 100 || grid[i][j].northQValue == -100)
                        {
                            arrows = grid[i][j].northQValue.ToString();
                        }
                        else{
                            char bestDir = grid[i][j].getBestDirection();

                            switch (bestDir)
                            {
                                case 'n':
                                    arrows = "^^^^";
                                    break;
                                case 'e':
                                    arrows = ">>>>";
                                    break;
                                case 's':
                                    arrows = "vvvv";
                                    break;
                                case 'w':
                                    arrows = "<<<<";
                                    break;
                            }
                        }
                     
                    }
                    else
                    {
                        arrows = "####";
                    }
                    Console.Write(arrows + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
