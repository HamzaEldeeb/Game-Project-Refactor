using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.NQuestion
{
    public class Question :IQuestion
    {
        Random rand;
        public char currentOperator { get; set; }
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }
        public double CorrectAnswer { get; set; }

        public Question()
        {
            rand = new Random();
        }
        // instad of constructor to less memory cost on memory
        public void Question_CorrectAnsower(int min, int max, char[] operators)
        {
            Questionn(min, max, operators);
            CorrectAnswer = CorrectAnsower();
        }
        //define question in property class
        public void Questionn(int min, int max, char[] operators)
        {
            currentOperator =
                   operators[rand.Next(operators.Length)];

            do
            {
                firstNumber = rand.Next(min, max + 1);
                secondNumber = rand.Next(min, max + 1);
            }
            while (currentOperator == '/' && secondNumber == 0);
        }
        //get correct ansower of question and put inside CorrectAnswer property
        public double CorrectAnsower()
        {
            double correctAnswer =
                               currentOperator == '+' ? firstNumber + secondNumber :
                               currentOperator == '-' ? firstNumber - secondNumber :
                               currentOperator == '*' ? firstNumber * secondNumber :
                               firstNumber / (double)secondNumber;
            return correctAnswer;
        }
        //evaluation user ansower
        public bool IsUserAnsowerCorrect(double userAnswer)
        {

            if (userAnswer == CorrectAnswer)
            {
                Console.WriteLine("Correct!");
                return true;
            }
            else
            {
                Console.WriteLine($"Not Correct! \nCorrect ansower is: {CorrectAnswer} ");
                return false;
            }

        }

    }
}
