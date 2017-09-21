using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class RockPaperScissorsGame
    {
        private Random rng;
        private int wins;
        private int losses;
        private int ties;

        public RockPaperScissorsGame()
        {
            rng = new Random();
        }

        public void Play()
        {
            string userChoice;
            userChoice = PromptUser();

            while (userChoice != "Q")
            {
                string computerChoice = GetComputerChoice();
                DetermineWinner(userChoice, computerChoice);
                PrintScore();
                Console.Clear();
                userChoice = PromptUser();
            }
        }

        private void PrintScore()
        {
            Console.WriteLine();
            Console.WriteLine("wins: {0}", wins);
            Console.WriteLine("losses: {0}", losses);
            Console.WriteLine("ties: {0}", ties);
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        private void DetermineWinner(string userChoice, string computerChoice)
        {
            if(userChoice == computerChoice)
            {
                ties++;
                Console.WriteLine("You both picked {0}, you tied!",ConvertChoiceToWord(userChoice));
            }
            else if (userChoice == "R" && computerChoice == "S" || userChoice == "S" && computerChoice == "P" || userChoice == "P" && computerChoice == "R")
            {
                wins++;
                Console.WriteLine("You picked {0} and the computer picked {1}, you win!",ConvertChoiceToWord(userChoice),ConvertChoiceToWord(computerChoice));
            
            }
            else
            {
                losses++;
                Console.WriteLine("You picked {0} and the computer picked {1}, you lose!", ConvertChoiceToWord(userChoice), ConvertChoiceToWord(computerChoice));
            }
        }

        private string ConvertChoiceToWord(string choice)
        {
            if (choice == "R")
                return "Rock";
            else if (choice == "S")
                return "Scissors";
            else
                return "paper";
        }

        private string GetComputerChoice()
        {
            int choice = rng.Next(1, 4);
            if (choice == 1)
                return "R";
            else if (choice == 2)
                return "P";
            else 
                return "S";
        }

        private string PromptUser()
        {
            while (true)
            {
                Console.WriteLine("Enter your choice (R)ock, (S)cissors, (P)aper, (Q)uit");
                string choice = Console.ReadLine();
                choice = choice.ToUpper();
                if (choice == "R" || choice == "S" || choice == "P" || choice == "Q")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("That is not a valid choice!");
                }
            }
            
        }
    }
}
