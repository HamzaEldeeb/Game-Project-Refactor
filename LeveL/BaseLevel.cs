using GameProjectRefactor.NQuestion;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.LeveL
{
    public abstract class BaseLevel
    {
        public abstract int Min { get; }
        public abstract int Max { get; }
        public abstract int NumberOfQuestions { get;  }
        public abstract char[] Operators { get;}
        public  int correctAnswersInLevel =0;

        public double SuccessPersantage = 0.5;

        public  void Play()
        {
            IQuestion question = new Question();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                question.Question_CorrectAnsower(Min, Max, Operators);
                //user ansower
                double userAnswer = GetUserInputNumber(question.firstNumber, question.currentOperator, question.secondNumber);
                //Is correct ansower
                bool isCorrect = question.IsUserAnsowerCorrect(userAnswer);
                //increment of correct ansower in level
                if (isCorrect)
                    correctAnswersInLevel++;
                // modify statistic
                Statistics.Update(isCorrect, question.currentOperator);

            }

        }
        public  bool Evaluate()
        {
            double ActualPercentage = (double)correctAnswersInLevel / NumberOfQuestions;

            bool playAgain;
            if (ActualPercentage >= SuccessPersantage)
            {
                Console.WriteLine($"Congratulations! You've passed this level with {ActualPercentage:P} correct answers.");
                //Check if user need to continue
                playAgain=true;


            }
            else
            {
                Console.WriteLine("Sorry, you didn't pass this level.");
                playAgain = false;
            }
            return playAgain;
        }
        public double GetUserInputNumber(int firstNumber, char currentOperator, int secondNumber)
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
    }


}
