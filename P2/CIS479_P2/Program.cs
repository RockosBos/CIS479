using System;
using System.Collections.Generic;

namespace CIS479_P2
{
    /*
    Sensing
        Reading Empty as Empty = 85%
        Reading Empty as Obstructed = 15%
        Reading Obstructed as Empty = 20%
        Reading Obstructed as Obstructed = 80%

    Moving
        Drifting Is based on robots perspective
        Drift Left - 10%
        Drift Right - 10%
        Correct Movement - 80%


    */
    class Program
    {
        static void Main(string[] args)
        {
            double[,] initialMatrix = new double[6, 7] { { 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263 }, { 0.0263, -1, 0.0263, 0.0263, -1, 0.0263, 0.0263 }, { 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263 }, { 0.0263, -1, 0.0263, 0.0263, -1, 0.0263, 0.0263 }, { 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263 }, { 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263, 0.0263 } };
         
            Robot robot = new Robot(initialMatrix);
            robot.outputMatrix();
            robot.sensing(0, 0, 0, 0);
            robot.outputMatrix();
            robot.moving('N');
            robot.outputMatrix();
            robot.sensing(1, 0, 0, 0);
            robot.outputMatrix();
            robot.moving('N');
            robot.outputMatrix();
            robot.sensing(0, 0, 0, 0);
            robot.outputMatrix();
            robot.moving('W');
            robot.outputMatrix();
            robot.sensing(0, 1, 0, 1);
            robot.outputMatrix();
            robot.moving('W');
            robot.outputMatrix();
            robot.sensing(1, 0, 0, 0);
            robot.outputMatrix();

        }
    }
}
