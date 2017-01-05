using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace SpracheGameCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int numberToGuess = rand.Next(1, 100);
            bool finished = false;

            Console.WriteLine("******************************************************");
            Console.WriteLine("*                                                    *");
            Console.WriteLine("* Guess the number by asking questions               *");
            Console.WriteLine("* Use < X to ask if the number is less than X        *");
            Console.WriteLine("* Use > X to ask if the number is greater than X     *");
            Console.WriteLine("* Use X <> Y to ask if the number is between X and Y *");
            Console.WriteLine("* Use = X to guess the number                        *");
            Console.WriteLine("* Use q to quit                                      *");
            Console.WriteLine("*                                                    *");
            Console.WriteLine("******************************************************");

            while (!finished)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (input.Trim() == "q")
                        finished = true;
                    else
                    {
                        Play play = GameParser.Play.Parse(input);
                        bool result = play.Evaluate(numberToGuess);
                        Console.WriteLine(result);

                        if (play.Command == Command.Equal && result == true)
                        {
                            Console.WriteLine("You guessed right.");
                            finished = true;
                        }
                    }
                }
                catch (ParseException ex)
                {
                    Console.WriteLine("There was an error: {0}", ex.Message);
                }

                Console.WriteLine();
            }
        }

    }
}
