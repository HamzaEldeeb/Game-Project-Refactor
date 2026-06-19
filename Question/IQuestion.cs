using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.NQuestion
{
    internal interface IQuestion
    {
        public char currentOperator { get;  set; }
        public int firstNumber { get;  set; }
        public int secondNumber { get; set; }
        public double CorrectAnswer { get; set; }

        public void Questionn(int min, int max, char[] operators);
        public double CorrectAnsower();
        public bool IsUserAnsowerCorrect(double userAnswer);
        // used instad of constructor to less memory cost on memory
        public void Question_CorrectAnsower(int min, int max, char[] operators);


    }
}
