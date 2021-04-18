using System;
using System.Collections.Generic;
using System.Text;

namespace P3
{
    class GridLocation
    {
        public double northAccessFequency = 0;
        public double eastAccessFequency = 0;
        public double southAccessFequency = 0;
        public double westAccessFequency = 0;

        public double northQValue = 0;
        public double eastQValue = 0;
        public double southQValue = 0;
        public double westQValue = 0;

        public bool isBlocked = false;
        public int gridID;
        public bool terminalState = false;

        public GridLocation()
        {
            isBlocked = true;
        }
        public GridLocation(int reward)
        {
            northQValue = reward;
            eastQValue = reward;
            southQValue = reward;
            westQValue = reward;
            if(reward != 0)
                terminalState = true;
        }

        public char getBestDirection()
        {
            bool nMax = false;
            bool eMax = false;
            bool sMax = false;
            bool wMax = false;
            int count = 0;
            if(northQValue >= eastQValue && northQValue >= southQValue && northQValue >= westQValue)
            {
                count++;
                nMax = true;
            }
            if (eastQValue >= northQValue && eastQValue >= southQValue && eastQValue >= westQValue)
            {
                count++;
                eMax = true;
            }
            if (southQValue >= eastQValue && southQValue >= northQValue && southQValue >= westQValue)
            {
                count++;
                sMax = true;
            }
            if (westQValue >= eastQValue && westQValue >= southQValue && westQValue >= northQValue)
            {
                count++;
                wMax = true;
            }

            if(count == 1)
            {
                if (nMax)
                    return 'n';
                if (eMax)
                    return 'e';
                if (sMax)
                    return 's';
                if (wMax)
                    return 'w';
            }
            int chooseDirection;
            if(count == 2)
            {
                chooseDirection = generateRandomNumber(2);
                if (nMax)
                {
                    if (eMax)
                    {
                        if (chooseDirection == 0)
                            return 'n';
                        if (chooseDirection == 1)
                            return 'e';
                    }

                    if (sMax)
                    {
                        if (chooseDirection == 0)
                            return 'n';
                        if (chooseDirection == 1)
                            return 's';
                    }

                    if (wMax)
                    {
                        if (chooseDirection == 0)
                            return 'n';
                        if (chooseDirection == 1)
                            return 'w';
                    }
                }
                if (eMax)
                {
                    if (nMax)
                    {
                        if (chooseDirection == 0)
                            return 'e';
                        if (chooseDirection == 1)
                            return 'n';
                    }

                    if (sMax)
                    {
                        if (chooseDirection == 0)
                            return 'e';
                        if (chooseDirection == 1)
                            return 's';
                    }

                    if (wMax)
                    {
                        if (chooseDirection == 0)
                            return 'e';
                        if (chooseDirection == 1)
                            return 'w';
                    }
                }
                if (sMax)
                {
                    if (eMax)
                    {
                        if (chooseDirection == 0)
                            return 's';
                        if (chooseDirection == 1)
                            return 'e';
                    }

                    if (nMax)
                    {
                        if (chooseDirection == 0)
                            return 's';
                        if (chooseDirection == 1)
                            return 'n';
                    }

                    if (wMax)
                    {
                        if (chooseDirection == 0)
                            return 's';
                        if (chooseDirection == 1)
                            return 'w';
                    }
                }
                if (wMax)
                {
                    if (eMax)
                    {
                        if (chooseDirection == 0)
                            return 'w';
                        if (chooseDirection == 1)
                            return 'e';
                    }

                    if (sMax)
                    {
                        if (chooseDirection == 0)
                            return 'w';
                        if (chooseDirection == 1)
                            return 's';
                    }

                    if (nMax)
                    {
                        if (chooseDirection == 0)
                            return 'w';
                        if (chooseDirection == 1)
                            return 'n';
                    }
                }
            }
            if(count == 3)
            {
                chooseDirection = generateRandomNumber(3);
                if (!nMax)
                {
                    switch (chooseDirection)
                    {
                        case 0:
                            return 'e';
                        case 1:
                            return 's';
                        case 2:
                            return 'w';
                    }
                }
                if (!eMax)
                {
                    switch (chooseDirection)
                    {
                        case 0:
                            return 'n';
                        case 1:
                            return 's';
                        case 2:
                            return 'w';
                    }
                }
                if (!sMax)
                {
                    switch (chooseDirection)
                    {
                        case 0:
                            return 'e';
                        case 1:
                            return 'n';
                        case 2:
                            return 'w';
                    }
                }
                if (!wMax)
                {
                    switch (chooseDirection)
                    {
                        case 0:
                            return 'e';
                        case 1:
                            return 's';
                        case 2:
                            return 'n';
                    }
                }
            }
            if(count == 4)
            {
                chooseDirection = generateRandomNumber(4);
                switch (chooseDirection)
                {
                    case 0:
                        return 'n';
                    case 1:
                        return 'e';
                    case 2:
                        return 's';
                    case 3:
                        return 'w';
                }
            }

            return 'x';
        }

        public int generateRandomNumber(int num)
        {
            var rand = new Random();
            return rand.Next(0, num);
        }

    }
}
