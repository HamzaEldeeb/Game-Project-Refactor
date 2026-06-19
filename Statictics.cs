using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor
{
    public class Statistics
    {
        public static int totalQuestionsPlayed = 0,
            correctAnswers = 0,
            incorrectAnswers = 0;
        public static int additionCount = 0,
            subtractionCount = 0,
            multiplicationCount = 0,
            divisionCount = 0;

        public static void Update(bool isCorrect, char currentOperator)
        {
            totalQuestionsPlayed++;

            if (isCorrect)
                correctAnswers++;
            else
                incorrectAnswers++;


            if (currentOperator == '+')
                additionCount++;
            else if (currentOperator == '-')
                subtractionCount++;
            else if (currentOperator == '*')
                multiplicationCount++;
            else
                divisionCount++;
        }
        public static void Show()
        {
            Console.WriteLine("\nGame Statistics:");
            Console.WriteLine($"Total Questions Played: {totalQuestionsPlayed}");
            Console.WriteLine($"Correct Answers: {correctAnswers}");
            Console.WriteLine($"Incorrect Answers: {incorrectAnswers}");
            Console.WriteLine($"Addition Count: {additionCount}");
            Console.WriteLine($"Subtraction Count: {subtractionCount}");
            Console.WriteLine($"Multiplication Count: {multiplicationCount}");
            Console.WriteLine($"Division Count: {divisionCount}");
        }

    }
}
