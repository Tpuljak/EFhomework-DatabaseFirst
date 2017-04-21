using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Domain.Repositories;
using Game.Data;

namespace Game.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            MatchRepository matches = new MatchRepository();           
            PlayerRepository players = new PlayerRepository();          
            MissionRepository missions = new MissionRepository();
            

            /*
            Player newPlayer = new Player();
            newPlayer.Password = "blabla";
            newPlayer.Username = "PlayerUno";
            newPlayer.Email = "Player.Uno@gmail.com";
            newPlayer.MMR = rnd.Next(1500, 2300);

            List<Match> newPlayerMatches = new List<Match>();
            newPlayerMatches.Add(matches.GetAllMatches()[0]);

            players.AddNewPlayer(newPlayer, newPlayerMatches);
            */

            Console.WriteLine("Welcome to the Game Database.");
            Console.WriteLine("Enter a Task number (0 to exit):");
            Console.WriteLine("List of Tasks:");
            Console.WriteLine("(1)List all Players");
            Console.WriteLine("(2)List all Matches");
            Console.WriteLine("(3)Add a new Player");
            Console.WriteLine("(4)Add a new Match");
            Console.WriteLine("(5)Add a new Mission");
            Console.WriteLine("(6)Edit a Player");
            Console.WriteLine("(7)Delete a Player");
            Console.WriteLine("(8)Delete a Match");

            int taskChoice = int.Parse(Console.ReadLine());
            while (taskChoice != 0)
            {
                switch(taskChoice)
                {
                    case 1:
                        players.ListAllPlayers();
                        break;
                    case 2:
                        matches.ListAllMatches();
                        break;
                    case 3:

                        break;
                    case 4:
                        Match newMatch = new Match();
                        Console.WriteLine("Enter the Match name.");
                        newMatch.Name = Console.ReadLine();

                        matches.AddNewMatch(newMatch);
                        break;
                    case 5:
                        Mission newMission = new Mission();

                        Console.WriteLine("Enter the Mission name.");
                        newMission.Name = Console.ReadLine();

                        Console.WriteLine("Enter the Mission text.");
                        newMission.Text = Console.ReadLine();

                        Console.WriteLine("Enter the Id of the Match to whom the Mission belongs to.");
                        newMission.MatchId = int.Parse(Console.ReadLine());

                        missions.AddNewMission(newMission);
                        break;
                    case 6:
                        Console.WriteLine("Enter the ID of the player you wish to edit: ");
                        int edditingPlayersId = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new username: ");
                        string newUsername = Console.ReadLine();

                        Console.WriteLine("Enter the new password: ");
                        string newPassword = Console.ReadLine();
                        players.EdditPlayer(edditingPlayersId, newUsername, newPassword);
                        break;
                    case 7:
                        Console.WriteLine("Enter the ID of the player you wish to delete:");
                        int deletingPlayerId = int.Parse(Console.ReadLine());

                        players.DeletePlayer(deletingPlayerId);
                        break;
                    case 8:
                        Console.WriteLine("Enter the MatchId of the match you want to delete:");
                        int deletingMatchId = int.Parse(Console.ReadLine());

                        matches.DeleteMatch(deletingMatchId);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Enter a Task number (0 to exit):");
                taskChoice = int.Parse(Console.ReadLine());
            }
        }
    }
}
