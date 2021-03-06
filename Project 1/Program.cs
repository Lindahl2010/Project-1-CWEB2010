﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Console;

namespace Random
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] position = { "Quarterback", "Running Back", "Wide-Receiver", "Defensive Lineman", "Defensive-Back", "Tight Ends", "Line-Backer's", "Offensive Tackles" };

            string[,] players =
            {
                { "Mason Rudolph", "Lamar Jackson", "Josh Rosen", "Sam Darnold", "Baker Mayfield" },
                { "Saquon Barkley","Derrius Guice","Bryce Love","Ronald Jone II","Damien Harris"},
                { "Courtland Sutton","James Washington","Marcell Ateman","Anthony Miller","Calvin Ridley"},
                { "Maurice Hurst","Vita Vea","Taven Bryan","Da'Ron Payne","Harrison Phillips"},
                { "Joshua Jackson","Derwin James","Denzel Ward","Minkah Fitzpatrick","Isaiah Oliver"},
                { "Mark Andrews","Dallas Goedert","Jaylen Samuels","Mike Gesicki","Troy Fumagalli"},
                { "Roquan Smith","Tremaine Edmunds","Kendall Joseph","Dorian O'Daniel","Malik Jefferson"},
                { "Orlando Brown","Kolton Miller","Chukwuma Okorafor","Connor Williams","Mike McGlinchey"}
            };

            string[,] state =
            {
                { "Oklahoma State","Louisville","UCLA","Southern California","Oklahoma"},
                { "Penn State","LSU","Stanford","Southern California","Alabama"},
                { "Southern Methodist","Oklahoma State","Oklahoma State","Memphis","Alabama"},
                { "Michigan","Washington","Florida","Alabama","Stanford"},
                { "Iowa","Florida State","Ohio State","Alabama","Colorado"},
                { "Oklahoma","So. Dakota State","NC State","Penn State","Wisconsin"},
                { "Georgia","Virginia Tech","Clemson","Clemson","Texas"},
                { "Oklahoma","UCLA","Western Michigan","Texas","Notre Dame"}
            };

            int[,] salary =
            {
                { 26400100,20300100,17420300,13100145,10300000},
                { 24500100,19890200,18700800,15000000,11600400},
                { 23400000,21900300,19300230,13400230,10000000},
                { 26200300,22000000,16000000,18000000,13000000},
                { 24000000,22500249,20000100,16000200,11899999},
                { 27800900,21000800,17499233,27900200,14900333},
                { 22900300,19000590,18000222,12999999,10000100},
                { 23000000,20000000,19400000,16200700,15900000}
            };

            int row, column, budget, cumulativeSalary, signingBonus;
            bool advance = true;
            List<String> playerPicks = new List<String>(); //List of all players picked by coach/user
            List<String> costEffective = new List<String>(); //List to check if there is 3 top 3 players in coaches draft picks
            ConsoleKeyInfo keyValue;

            //Introduction
            welcome(out keyValue);

            while (keyValue.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                cumulativeSalary = 0;
                budget = 95000000;

                //Display of players
                for (var x = 0; x < players.GetLength(0); x++)
                {

                    WriteLine($"{position[x]} ");

                    for (var y = 0; y < players.GetLength(1); y++)
                    {
                        WriteLine($"{x + 1}{y + 1}) {players[x, y]}");
                        WriteLine($"({state[x, y]}) ");
                        WriteLine($"{salary[x, y].ToString("c0")} ");
                    }
                    Write("\n");
                }

                do
                {
                    //Method call to get user input
                    getInput(out row, out column, ref cumulativeSalary, out signingBonus, ref budget, ref salary);
                    playerPicks.Add(players[row, column]);

                    //Checks if the pick is in the top 3 best players
                    if (column <= 2)
                    {
                        costEffective.Add(players[row, column]);
                    }

                    if (signingBonus <= 0) //If statement that checks the coach's budget
                    {
                        WriteLine("Sorry, you have exceeded your budget and do not have the money to draft any other players.");
                        break;
                    }

                    //Prints out the selected player and his salary as well as the cumulative salary of all players picked.
                    WriteLine($"\nYou have selected {players[row, column]} from {state[row, column]} with a total salary of: {salary[row, column].ToString("c0")}");
                    WriteLine($"The cumulative salary of all players selected: {cumulativeSalary.ToString("c0")}");
                    WriteLine($"You have {signingBonus.ToString("c0")} left for signing bonuses.");

                    //Error catch to break out of loop if coach has 5 player picks
                    if (playerPicks.Count == 5)
                    {
                        break;
                    }

                    //Calls restart method
                    restartInner(ref advance);

                } while (advance); //End of inner do/while loop

                //Method calls for end of program
                draftInfo(ref playerPicks, ref costEffective, ref cumulativeSalary, ref signingBonus);
                restart(out keyValue, ref playerPicks);

            }//End of outer while loop
        }//End of main method

        public static void welcome(out ConsoleKeyInfo keyValue)
        {
            //Welcome message at start of the program
            WriteLine("Welcome to the NFL Draft Picks\n");
            WriteLine("You may choose up to 5 players and have a budget of $95 million dollars.");
            WriteLine("Please press Enter to start the program or any other key to exit...");
            keyValue = ReadKey();
        }

        public static void getInput(out int row, out int column, ref int cumulativeSalary, out int signingBonus, ref int budget, ref int[,] salary)
        {
            //Gets user input and sets up the overall salary of players and money available for signing bonus
            string userInput;
            WriteLine("\nPlease enter the number of the player you wish to select: ");
            userInput = ReadLine();
            row = Convert.ToInt32(userInput.Substring(0, 1));
            column = Convert.ToInt32(userInput.Substring(1));
            row = row - 1;
            column = column - 1;
            cumulativeSalary += salary[row, column];
            signingBonus = budget - cumulativeSalary;
        }

        public static void restart(out ConsoleKeyInfo keyValue, ref List<String> playerPicks)
        {
            //Restarts the whole program based off of what key the user presses
            WriteLine("\nTo restart the program, please press Enter or any other key to exit...");
            keyValue = ReadKey();

            if (keyValue.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                playerPicks.Clear();
                welcome(out keyValue);
            }
        }

        public static void draftInfo(ref List<String> playerPicks, ref List<String> costEffective, ref int cumulativeSalary, ref int signingBonus)
        {
            //Display of draft information based on the coaches picks
            WriteLine("\nCongratulations! You have completed your NFL Draft Picks.");
            WriteLine("\nYou have selected these players: ");

            foreach (var i in playerPicks)
            {
                WriteLine($"{i} ");
            }

            WriteLine($"\nTotal cumulative salary of selected players: {cumulativeSalary.ToString("c0")} ");
            WriteLine($"\nTotal signing bonus available for selected players: {signingBonus.ToString("c0")} ");

            if (costEffective.Count == 3 && cumulativeSalary < 65000000)
            {
                WriteLine("\nCongratulations! You're draft picks are Cost Effective.");
            }
        }

        public static void restartInner(ref bool advance)
        {
            //Restart of inner loop if the user would like to enter additional players
            string sentinel;
            WriteLine("\nTo enter another player, press Y or N to exit...");
            sentinel = ReadLine();
            sentinel = sentinel.ToUpper();

            if (sentinel == "Y")
            {
                advance = true;
            }
            else
            {
                advance = false;
            }
        }
    }
}
