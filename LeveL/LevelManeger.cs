using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.LeveL
{
    internal class LevelManeger
    {
        public static BaseLevel GetLevel(Difficulty difficulty)
        {
            switch(difficulty)
            {
                case Difficulty.Easy:
                    return new EasyLevel();
                case Difficulty.Medium:
                    return new MediumLevel();
                case Difficulty.Hard:
                    return new HardLevel();
                default:
                    return new EasyLevel();


            }
        }
        public static Difficulty NextLevel(Difficulty typeOfQuestion)
        {
            if (typeOfQuestion == Difficulty.Easy)
                typeOfQuestion = Difficulty.Medium;
            else if (typeOfQuestion == Difficulty.Medium)
                typeOfQuestion = Difficulty.Hard;
            else if (typeOfQuestion == Difficulty.Hard)
                typeOfQuestion = Difficulty.Easy;
            return typeOfQuestion;

        }
        public static void WelcomeTOLevel(Difficulty typeOfQuestion)
        {
            Console.Clear();
            Console.WriteLine(
                       typeOfQuestion == Difficulty.Easy ?
                       "Welcome to the Easy Level!" :
                       typeOfQuestion == Difficulty.Medium ?
                       "Welcome to the Medium Level!" :
                       "Welcome to the Hard Level!");

            Console.WriteLine("Let's begin!");
        }
    }
}
