
namespace GameProjectRefactor
{
    internal class CodeBeforeRefactore
    {
        enum Difficulty { Easy, Medium, Hard }
        
            static void start()
            {
                var easy = (Min: 1, Max: 10, QCount: 5, Opps: new char[] { '+', '-' });
                var medium = (Min: 1, Max: 20, QCount: 6, Opps: new char[] { '+', '-', '*' });
                var hard = (Min: 1, Max: 50, QCount: 7, Opps: new char[] { '+', '-', '*', '/' });

                int totalQuestionPlayed = 0;
                int correctQuestions = 0;
                int inCorrectQuestions = 0;
                int addCount = 0;
                int subCount = 0;
                int mulCount = 0;
                int divCount = 0;

                Random rand = new Random();
                Difficulty cl = Difficulty.Easy;
                bool playAgain = true;

                while (playAgain)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the " + cl + " Level");

                    var currentDetails = cl == Difficulty.Easy ? easy : (cl == Difficulty.Medium ? medium : hard);
                    int correctInLevel = 0;

                    for (int i = 0; i < currentDetails.QCount; i++)
                    {
                        char opp = currentDetails.Opps[rand.Next(0, currentDetails.Opps.Length)];
                        int num1 = rand.Next(currentDetails.Min, currentDetails.Max + 1);
                        int num2 = rand.Next(currentDetails.Min, currentDetails.Max + 1);

                        if (opp == '/' && num2 == 0) num2 = 1;

                        double correctAnswer = 0;
                        switch (opp)
                        {
                            case '+':
                                correctAnswer = num1 + num2;
                                addCount++;
                                break;
                            case '-':
                                correctAnswer = num1 - num2;
                                subCount++;
                                break;
                            case '*':
                                correctAnswer = num1 * num2;
                                mulCount++;
                                break;
                            case '/':
                                correctAnswer = Math.Round((double)num1 / num2, 2);
                                divCount++;
                                break;
                        }

                        Console.Write("Question " + (i + 1) + ": " + num1 + " " + opp + " " + num2 + " = ");
                        double userAnwser = double.Parse(Console.ReadLine());

                        totalQuestionPlayed++;
                        if (userAnwser == correctAnswer)
                        {
                            Console.WriteLine("Correct!");
                            correctQuestions++;
                            correctInLevel++;
                        }
                        else
                        {
                            Console.WriteLine("InCorrect! The right answer was " + correctAnswer);
                            inCorrectQuestions++;
                        }
                    }

                    double result = (double)correctInLevel / currentDetails.QCount;
                    if (result >= 0.5)
                    {
                        Console.WriteLine("Congratulations! You passed " + cl + " level.");
                        Console.Write("Do you want to move to the next level? (y/n): ");
                        string choice = Console.ReadLine().ToLower();

                        if (choice == "y")
                        {
                            if (cl == Difficulty.Easy) cl = Difficulty.Medium;
                            else if (cl == Difficulty.Medium) cl = Difficulty.Hard;
                            else
                            {
                                Console.WriteLine("You finished all levels!");
                                playAgain = false;
                            }
                        }
                        else playAgain = false;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you failed. Game Over.");
                        playAgain = false;
                    }



                    Console.WriteLine("\n--- Final Statistics ---");
                    Console.WriteLine("Total Played: " + totalQuestionPlayed);
                    Console.WriteLine("Correct: " + correctQuestions + " | Incorrect: " + inCorrectQuestions);
                    Console.WriteLine("Operations -> Add: " + addCount + ", Sub: " + subCount + ", Mul: " + mulCount + ", Div: " + divCount);
                    Console.ReadKey();
                }
            }
        


    }

}