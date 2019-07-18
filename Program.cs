using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //set the number of times the user has rolled outside the loop which will be incremented each time the user decides to roll again
            int timesRolled = 1;
            
            //loop which allows the user to restart if desired.
            bool again = true;
            while (again == true)
            {
                //call the method which takes in the number of sides of the dice being rolled
                int diceSides = ReadIntegers("How many sided dice are you rolling?");
                
                //Use the method which validates yes and no to prompt the user to roll the dice. If they want to, roll both dice.
                string userResponse = GetYN($"Ready to shake 'em up and roll those bones?");
                if (userResponse == "Y" || userResponse == "YES")
                {
            
                    //call the method which rolls the dice twice and save each response to a different variable
                    int die1 = RollDice(diceSides);
                    int die2 = RollDice(diceSides);

                    //call out special dice results. If a result applies to multiple situations, append each of the special titles to each other.
                    string special = "";
                    if (die1 == die2 && die1 == 1)
                    {
                        special = special + " Snake eyes!";
                    }
                    if (die1 == die2 && die1 == 6)
                    {
                        special = special + " Boxcars!";
                    }
                    if (die1 + die2 == 2 || die1 + die2 == 3 || die1 + die2 == 12)
                    {
                        special = special + " Craps!";
                    }
                    
                    //write out the result of each die, the special cases a roll falls into, and which number roll this is for the user
                    Console.WriteLine($"For Roll # {timesRolled}, You rolled a {die1} and a {die2}.{special}");
                }

                //if the user has already told you how many sides of their dice they want, but they don't want to roll them, it's a bit of a letdown...
                else
                {
                    Console.WriteLine("Oh...Well that's disappointing. Come back when you want to, I guess.");
                    again = false;
                }

                //determine whether the user would like to roll again. If they chose not to roll the dice in the previous step, they don't want to roll, so we won't badger them.
                if (again == true)
                {
                    //use the method which validates yes and no to determine if the user wants to roll again.
                    userResponse = GetYN("Do you want to throw them again before you go?");
                    if (userResponse == "Y")
                    {
                        again = true;
                        timesRolled++;
                    }
                    else
                    {
                        again = false;
                    }
                }
            }
        }
        public static int ReadIntegers(string prompt)
        //method which prompts the user for intergers and validates that they are integers
        {
            bool isvalid = false;
            int diceSides = 0;
            while (!isvalid)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                isvalid = int.TryParse(input, out diceSides);
            }
                return diceSides;
        }
        
        public static int RollDice(int sides)
        //method which generates random numbers between 1 and the user defined side limit
        {
            Random rand = new Random();
            int result = rand.Next(1, sides + 1);
            return result;
        }

        public static string GetYN(string prompt)
        //method which prompts the user for yes/no and validates that their response is yes or no
        {
            bool isvalid = false;
            string userResponse = "";
            while (!isvalid)
            {
                Console.WriteLine(prompt);
                userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "Y" || userResponse == "YES" || userResponse == "NO" || userResponse == "N")
                    isvalid = true;

            }
                return userResponse;
        }
    }
}
