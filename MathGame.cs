using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public enum Difficulty { Easy, Medium, Hard }
    public class Levels
    {
        //main proberty
        public int Min { get; }
        public int Max { get; }
        public int NumberOfQuestions { get; }
        public char[] Operators { get; }

        public static int correctAnswersInLevel=0;

         Difficulty TypeOfQuestion;

        public static int totalQuestionsPlayed = 0, correctAnswers = 0, incorrectAnswers = 0;
        public static int additionCount = 0, subtractionCount = 0, multiplicationCount = 0, divisionCount = 0;

        public Levels()
        {
            Operators = new char[4];
        }
        public Levels(int min,int max,int numberOfQuestions, char[] operators, Difficulty typeOfQuestion)
        {
            Min = min;
            Max = max;
            NumberOfQuestions = numberOfQuestions;
            Operators = operators;
            TypeOfQuestion=typeOfQuestion;  
        }


    }
    public class MathGame   
    {
        #region Variables
        Levels easy = new Levels(1, 10, 5, new char[] { '+', '-' }, Difficulty.Easy);
        Levels medium= new Levels(1, 10, 6, new char[] { '+', '-', '*' }, Difficulty.Medium);
        Levels hard = new Levels(1, 20, 7, new char[] { '+', '-', '*', '/' }, Difficulty.Hard);

        Random rand = new Random();
        #endregion

        #region Methods
        void StartWelcome()
        {
            Console.WriteLine("Welcome to the Math Game!");
            Console.WriteLine("In this game, you'll practice addition, subtraction, multiplication, and division.");
            Console.WriteLine("Let's begin!");
        }

        Levels StartLevel(Difficulty difficulty)
        {
            Console.Clear();
            //welcome level statment
            string WelcomeLevelStatment = difficulty == Difficulty.Easy ? "Welcome to the Easy Level!" :
                              difficulty == Difficulty.Medium ? "Welcome to the Medium Level!" :
                              "Welcome to the Hard Level!";
            Console.WriteLine(WelcomeLevelStatment);
            Console.WriteLine("Let's begin!");
            //return current level
            var levelDetails = difficulty == Difficulty.Easy ? easy :
                   difficulty == Difficulty.Medium ? medium :
                   hard;

            return levelDetails;
        }

        double GetCorrectAnswear(char currentOperator,int firstNumber,int secondNumber)
        {
            double correctAnswer = currentOperator == '+' ? firstNumber + secondNumber :
                               currentOperator == '-' ? firstNumber - secondNumber :
                               currentOperator == '*' ? firstNumber * secondNumber :
                               firstNumber / (double)secondNumber;
            return correctAnswer;
        }

        double GetUserInput(char currentOperator, int firstNumber, int secondNumber)
        {
            Console.Write($"\nWhat is {firstNumber} {currentOperator} {secondNumber} : ");
            bool isConvert = double.TryParse(Console.ReadLine(), out double userAnswer);
            
            while (!isConvert)
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
                Console.Write($"\nWhat is {firstNumber} {currentOperator} {secondNumber} : ");
                isConvert = double.TryParse(Console.ReadLine(), out userAnswer);
            }
            return userAnswer;
        }

        bool IsCorrectAnswear(double correctAnswer,double userAnswer) 
        {
            Levels.totalQuestionsPlayed++;
            if (userAnswer == correctAnswer)
            {
                Levels.correctAnswers++;
                Levels.correctAnswersInLevel++;
                Console.WriteLine("Correct!");
                return true;
            }
            else
            {
                Levels.incorrectAnswers++;
                Console.WriteLine($"Incorrect! The correct answer is {correctAnswer}.");
                return false;
            }
        }

        void UpdateStatistics(char currentOperator)
        {
            if (currentOperator == '+') Levels.additionCount++;
            else if (currentOperator == '-') Levels.subtractionCount++;
            else if (currentOperator == '*') Levels.multiplicationCount++;
            else if (currentOperator == '/') Levels.divisionCount++;
        }
        //
        void PlayLevel(Levels levelDetails)
        {
            for (int i = 0; i < levelDetails.NumberOfQuestions; i++)
            {
                #region Get Mext Question
                //get random operator char
                char currentOperator = levelDetails.Operators[rand.Next(levelDetails.Operators.Length)];
                int firstNumber, secondNumber;
                //get random firstNumber and random  secondNumber
                do
                {
                    firstNumber = rand.Next(levelDetails.Min, levelDetails.Max + 1);
                    secondNumber = rand.Next(levelDetails.Min, levelDetails.Max + 1);
                } while (currentOperator == '/' && secondNumber == 0);
                #endregion

                double correctAnswer = GetCorrectAnswear(currentOperator, firstNumber, secondNumber);   

                double userAnswer = GetUserInput(currentOperator, firstNumber, secondNumber);

                IsCorrectAnswear(correctAnswer, userAnswer);

                UpdateStatistics(currentOperator);
            }
        }
        //
        bool AskToPlayAgain()
        {
            string continueChoice;
            while (true)
            {
                continueChoice = Console.ReadLine().ToLower();
                if (continueChoice == "y" || continueChoice == "yes" || continueChoice == "n" || continueChoice == "no")
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter 'y' or 'n':");
            }

            return continueChoice == "y" || continueChoice == "yes";
        }

        Difficulty NextLevel(Difficulty difficulty)
        {
            if (difficulty == Difficulty.Easy)
                difficulty = Difficulty.Medium;
            else if (difficulty == Difficulty.Medium)
                difficulty = Difficulty.Hard;

            return difficulty;
        }
        //
        bool EvaluatePerformance(int numberOfQuestions)
        {
            #region Calculate Level Percentage
            bool playAgain = false;
            double passPersantage = 0.5;
            double userPersantage = (double)Levels.correctAnswersInLevel / numberOfQuestions;
            #endregion

            #region Sucess Case
            if (userPersantage >= passPersantage)
            {
                Console.WriteLine($"Congratulations! You've passed this level with {userPersantage:P} correct answers.");
                Console.Write("\nDo you want to move to the next level? (y/n): ");
                playAgain= AskToPlayAgain();
            }
            #endregion

            #region Failure Case
            else
            {
                Console.WriteLine($"Sorry, you didn't pass this level. You needed at least {passPersantage:P} correct answers.");
                playAgain = false;
            } 
            #endregion
            return playAgain;
        }
        //
        void ShowStatistics()
        {
            Console.WriteLine("\nGame Statistics:");
            Console.WriteLine($"Total Questions Played: {Levels.totalQuestionsPlayed}");
            Console.WriteLine($"Correct Answers:      {Levels.correctAnswers}");
            Console.WriteLine($"Incorrect Answers:    {Levels.incorrectAnswers}");
            Console.WriteLine($"Addition Count:       {Levels.additionCount}");
            Console.WriteLine($"Subtraction Count:    {Levels.subtractionCount}");
            Console.WriteLine($"Multiplication Count: {Levels.multiplicationCount}");
            Console.WriteLine($"Division Count:       {Levels.divisionCount}");
        } 
        #endregion
        public void Start()
        {
            StartWelcome();
            bool playAgain = true;
            Difficulty oDifficulty = Difficulty.Easy;

            #region Play Level
            while (playAgain)
            {
                var levelDetails = StartLevel(oDifficulty);
                PlayLevel(levelDetails);

                
                playAgain = EvaluatePerformance(levelDetails.NumberOfQuestions);

                if (playAgain)
                    oDifficulty = NextLevel(Difficulty.Easy);
            }
            #endregion

            ShowStatistics();
        }
    }
}
