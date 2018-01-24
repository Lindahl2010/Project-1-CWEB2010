using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project_1
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

            string[,] salary =
            {
                { "26,400,100","20,300,100","17,420,300","13,100,145","10,300,000"},
                { "24,500,100","19,890,200","18,700,800","15,000,000","11,600,400"},
                { "23,400,000","21,900,300","19,300,230","13,400,230","10,000,000"},
                { "26,200,300","22,000,000","16,000,000","18,000,000","13,000,000"},
                { "24,000,000","22,500,249","20,000,100","16,000,200","11,899,999"},
                { "27,800,900","21,000,800","17,499,233","27,900,200","14,900,333"},
                { "22,900,300","19,000,590","18,000,222","12,999,999","10,000,100"},
                { "23,000,000","20,000,000","19,400,000","16,200,700","15,900,000"}
            };

            string userInput;
            int row, column;
            int budget = 95000000;
            bool advance;
            string sentinel;
            List<String> playerPicks = new List<String>();
            List<int> cost = new List<int>();
            List<String> info = new List<String>();

            for (var x = 0; x < players.GetLength(0); x++)
            {
                WriteLine($"\n {position[x]} ");

                for(var y = 0; y < players.GetLength(1); y++)
                {
                    Write($" {players[x, y]} ");
                    Write($"\n {state[x, y]} ");
                    Write($"\n ${salary[x, y]} \n");
                }
                Write(" \n ");
            }
            ReadLine();

        }
    }
}
