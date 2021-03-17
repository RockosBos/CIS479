using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CIS479_P2
{
    class Robot
    {
        private double[,] probabilityMatrix;
        private const int maxHorizontal = 7;
        private const int maxVertical = 6;

        public Robot(double[,] matrix)
        {
            this.probabilityMatrix = matrix;
        }

        public void sensing(int west, int north, int east, int south)
        {
            int isObstructed;
            double listSum = 0.0;
            double westProbability = 0, northProbability = 0, eastProbability = 0, southProbability = 0;
            double[,] probabilityList = new double[maxVertical, maxHorizontal];

            for(int j = 0; j < maxVertical; j++)
            {
                for(int i = 0; i < maxHorizontal; i++)
                {
                    //WEST

                    if (probabilityMatrix[j, i] >= 0)
                    {

                        if (i != 0)
                        {
                            if (probabilityMatrix[j, i - 1] > -1)
                            {
                                isObstructed = 0;
                            }
                            else
                            {
                                isObstructed = 1;
                            }
                        }
                        else
                        {
                            isObstructed = 1;
                        }
                        if (isObstructed == 1 && west == 1)
                        {
                            westProbability = 0.8;
                        }
                        if (isObstructed == 1 && west == 0)
                        {
                            westProbability = 0.2;
                        }
                        if (isObstructed == 0 && west == 1)
                        {
                            westProbability = 0.15;
                        }
                        if (isObstructed == 0 && west == 0)
                        {
                            westProbability = 0.85;
                        }

                        //NORTH


                        if (j != 0)
                        {
                            if (probabilityMatrix[j - 1, i] > -1)
                            {
                                isObstructed = 0;
                            }
                            else
                            {
                                isObstructed = 1;
                            }
                        }
                        else
                        {
                            isObstructed = 1;
                        }
                        if (isObstructed == 1 && north == 1)
                        {
                            northProbability = 0.8;
                        }
                        if (isObstructed == 1 && north == 0)
                        {
                            northProbability = 0.2;
                        }
                        if (isObstructed == 0 && north == 1)
                        {
                            northProbability = 0.15;
                        }
                        if (isObstructed == 0 && north == 0)
                        {
                            northProbability = 0.85;
                        }

                        //EAST

                        if (i != maxHorizontal - 1)
                        {
                            if (probabilityMatrix[j, i + 1] > -1)
                            {
                                isObstructed = 0;
                            }
                            else
                            {
                                isObstructed = 1;
                            }
                        }
                        else
                        {
                            isObstructed = 1;
                        }
                        if (isObstructed == 1 && east == 1)
                        {
                            eastProbability = 0.8;
                        }
                        if (isObstructed == 1 && east == 0)
                        {
                            eastProbability = 0.2;
                        }
                        if (isObstructed == 0 && east == 1)
                        {
                            eastProbability = 0.15;
                        }
                        if (isObstructed == 0 && east == 0)
                        {
                            eastProbability = 0.85;
                        }

                        //SOUTH

                        if (j != maxVertical - 1)
                        {
                            if (probabilityMatrix[j + 1, i] > -1)
                            {
                                isObstructed = 0;
                            }
                            else
                            {
                                isObstructed = 1;
                            }
                        }
                        else
                        {
                            isObstructed = 1;
                        }
                        if (isObstructed == 1 && south == 1)
                        {
                            southProbability = 0.8;
                        }
                        if (isObstructed == 1 && south == 0)
                        {
                            southProbability = 0.2;
                        }
                        if (isObstructed == 0 && south == 1)
                        {
                            southProbability = 0.15;
                        }
                        if (isObstructed == 0 && south == 0)
                        {
                            southProbability = 0.85;
                        }

                        probabilityList[j,i] = westProbability * northProbability * eastProbability * southProbability * probabilityMatrix[j,i];
                    }
                    else
                    {
                        probabilityList[j, i] = 0;
                    }

                }
            }

            for (int i = 0; i < maxHorizontal; i++)
            {
                for (int j = 0; j < maxVertical; j++)
                {
                    listSum = listSum + probabilityList[j, i];
                }
            }
            for(int i = 0; i < maxHorizontal; i++)
            {
                for (int j = 0; j < maxVertical; j++)
                {
                    if (probabilityMatrix[j, i] >= 0)
                    {
                        probabilityMatrix[j, i] = probabilityList[j, i] / listSum;

                    }
                }
            }


        }
        public void moving(char direction)
        {
            double[,] newProbabilityMatrix = new double[maxVertical, maxHorizontal];
            double westProbability = 0, northProbability = 0, eastProbability = 0, southProbability = 0;
            double probabilitySum = 0;
            double tempProbability = 0;

            for (int j = 0; j < maxVertical; j++)
            {
                for (int i = 0; i < maxHorizontal; i++)
                {
                    if (probabilityMatrix[j, i] != -1)
                    {
                        switch (direction)
                        {
                            case 'W':
                                westProbability = 0.8;
                                southProbability = 0.1;
                                northProbability = 0.1;
                                eastProbability = 0.0;
                                break;
                            case 'N':
                                northProbability = 0.8;
                                westProbability = 0.1;
                                eastProbability = 0.1;
                                southProbability = 0.0;
                                break;
                            case 'E':
                                eastProbability = 0.8;
                                southProbability = 0.1;
                                northProbability = 0.1;
                                westProbability = 0.0;
                                break;
                            case 'S':
                                southProbability = 0.8;
                                westProbability = 0.1;
                                eastProbability = 0.1;
                                northProbability = 0.0;
                                break;
                            default:
                                Console.WriteLine("Bad input: " + direction + ". Please enter a valid direction (W,N,E,S).");
                                break;
                        }

                        //Logic for Western Probability

                        if (i == 0) //Current Location is on the left side Western movement. Probability includes current location and location to right.
                        {
                            tempProbability = westProbability;
                            westProbability *= probabilityMatrix[j, i];
                            if (probabilityMatrix[j, i + 1] != -1)
                            {
                                westProbability += (tempProbability * probabilityMatrix[j, i + 1]);
                            }
                        }
                        else if (i == maxHorizontal - 1) //current location is on right side. No western pobability will result here.
                        {
                            westProbability = 0;
                        }
                        else  // current location is unabstructed from sides. Normal calculation.
                        {
                            if (probabilityMatrix[j, i - 1] == -1) //current location is obstructed from left side. Probability includes current location and location to right. 
                            {
                                tempProbability = westProbability;
                                westProbability *= probabilityMatrix[j, i];
                                    if (probabilityMatrix[j, i + 1] != -1)
                                    {
                                        westProbability += (tempProbability * probabilityMatrix[j, i + 1]);
                                    }
                            }
                            else if (probabilityMatrix[j, i + 1] == -1)//current location is obstructed from right side. No western probability will result here
                            {
                                westProbability = 0;
                            }
                            else // current location is unabstructed from sides. Normal calculation.
                            {
                                westProbability *= probabilityMatrix[j, i + 1];
                            }
                        }

                        //Logic for Northern Probability

                        if (j == 0) 
                        {
                            tempProbability = northProbability;
                            northProbability *= probabilityMatrix[j, i];
                            if(probabilityMatrix[j + 1, i] != -1)
                            {
                                northProbability += (tempProbability * probabilityMatrix[j + 1, i]);
                            }
                            
                        }
                        else if (j == maxVertical - 1) 
                        {
                            northProbability = 0;
                        }
                        else  
                        {
                            if (probabilityMatrix[j - 1, i] == -1)
                            {
                                tempProbability = northProbability;
                                northProbability *= probabilityMatrix[j, i];
                                if (probabilityMatrix[j + 1, i] != -1)
                                {
                                    northProbability += (tempProbability * probabilityMatrix[j + 1, i]);
                                }
                            }
                            else if (probabilityMatrix[j + 1, i] == -1)
                            {
                                northProbability = 0;
                            }
                            else 
                            {
                                northProbability *= probabilityMatrix[j + 1, i];
                            }
                        }

                        //Logic for Eastern Probability

                        if (i == maxHorizontal - 1)
                        {
                            tempProbability = eastProbability;
                            eastProbability *= probabilityMatrix[j, i];
                            if (probabilityMatrix[j, i - 1] != -1)
                            {
                                eastProbability += (tempProbability * probabilityMatrix[j, i - 1]);
                            }
                        }
                        else if (i == 0) 
                        {
                            eastProbability = 0;
                        }
                        else  
                        {
                            if (probabilityMatrix[j, i + 1] == -1) 
                            {
                                tempProbability = eastProbability;
                                eastProbability *= probabilityMatrix[j, i];
                                if (probabilityMatrix[j, i - 1] != -1)
                                {
                                    eastProbability += (tempProbability * probabilityMatrix[j, i - 1]);
                                }
                            }
                            else if (probabilityMatrix[j, i - 1] == -1)
                            {
                                eastProbability = 0;
                            }
                            else 
                            {
                                eastProbability *= probabilityMatrix[j, i - 1];
                            }
                        }

                        //Logic for southern Probability

                        if (j == maxVertical - 1)
                        {
                            tempProbability = southProbability;
                            southProbability *= probabilityMatrix[j, i];
                            if (probabilityMatrix[j - 1, i] != -1)
                            {
                                southProbability += (tempProbability * probabilityMatrix[j - 1, i]);
                            }
                        }
                        else if (j == 0)
                        {
                            southProbability = 0;
                        }
                        else
                        {
                            if (probabilityMatrix[j + 1, i] == -1)
                            {
                                tempProbability = southProbability;
                                southProbability *= probabilityMatrix[j, i];
                                if (probabilityMatrix[j - 1, i] != -1)
                                {
                                    southProbability += (tempProbability * probabilityMatrix[j - 1, i]);
                                }
                            }
                            else if (probabilityMatrix[j - 1, i] == -1)
                            {
                                southProbability = 0;
                            }
                            else
                            {
                                southProbability *= probabilityMatrix[j - 1, i];
                            }
                        }
                        //Add up all subprobabilities except obstructed spaces
                        newProbabilityMatrix[j, i] = westProbability + northProbability + eastProbability + southProbability;

                    }
                    else
                    {
                        newProbabilityMatrix[j, i] = -1;
                    }

                }
            }
            for (int j = 0; j < maxVertical; j++)
            {
                for (int i = 0; i < maxHorizontal; i++)
                {
                    if (newProbabilityMatrix[j, i] != -1)
                    {
                        //Add up all probabilities for denominator
                        probabilitySum += newProbabilityMatrix[j, i];
                    }
                }
            }
            for (int j = 0; j < maxVertical; j++)
            {
                for (int i = 0; i < maxHorizontal; i++)
                {
                    if (newProbabilityMatrix[j, i] >= 0)
                    {
                        //Calculate new matrix probabilities
                        probabilityMatrix[j, i] = newProbabilityMatrix[j, i] / probabilitySum;
                    }
                }
            }
        }

        public void outputMatrix()
        {
            for (int j = 0; j < maxVertical; j++)
            {
                for(int i = 0; i < maxHorizontal; i++)
                {
                    //Console.Write(Math.Round(probabilityMatrix[j, i] * 100, 2).ToString("F") + " ");
                    if (probabilityMatrix[j, i] >= 0)
                    {
                        Console.Write(Math.Round(probabilityMatrix[j, i] * 100, 2).ToString("F") + " ");
                    }
                    else
                    {
                        Console.Write("#### ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
