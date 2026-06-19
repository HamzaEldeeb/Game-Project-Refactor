using GameProject;
using GameProjectRefactor.LeveL;
using GameProjectRefactor.NQuestion;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor
{
   
    public class GameProjectAfterFefactor
    {
        public void WelcomeToGame()
        {
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("In this game, you'll practice addition, subtraction, multiplication, and division.");
            Console.WriteLine("Let's begin!");

        }
        public string AskToPlayAgain()
        {
            Console.Write("\nDo you want to move to the next level? (y/n): ");
            string choice;

            while (true)
            {
                choice = Console.ReadLine().ToLower();

                if (choice == "y" || choice == "yes" ||
                    choice == "n" || choice == "no")
                    return choice;

                Console.WriteLine("Invalid input. Please enter y or n.");
            }

        }
        public double GetUserInputNumber(int firstNumber,char currentOperator,int secondNumber)
        {
            double userAnswer;

            while (true)
            {
                Console.Write($"\nWhat is {firstNumber} {currentOperator} {secondNumber}: ");

                if (double.TryParse(Console.ReadLine(), out userAnswer))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            return userAnswer;
        }
        public void start()
        {
            WelcomeToGame();
            Difficulty typeOfQuestion = Difficulty.Easy; // 0 Easy, 1 Medium, 2 Hard
            bool playAgain = true;

            BaseLevel oBaseLevel;
            #region paly game
            while (playAgain)
            {
                LevelManeger.WelcomeTOLevel(typeOfQuestion);
                // difin level
                oBaseLevel = LevelManeger.GetLevel(typeOfQuestion);
                // play game
                oBaseLevel.Play();
                //evaluate user degree and check if can paly again or not
                bool IsPass = oBaseLevel.Evaluate();
                
                if (IsPass)
                {
                    string choice = AskToPlayAgain();
                    //define next level
                    playAgain = choice == "y" || choice == "yes";
                }
                else
                    playAgain=false;

                if (playAgain)
                    typeOfQuestion = LevelManeger.NextLevel(typeOfQuestion);
            }
            // show statistics 
            Statistics.Show();
            #endregion
        }
    }
    
    

}

