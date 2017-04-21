using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Repositories
{
    public class PlayerRepository
    {
        public PlayerRepository()
        {
            _context = new GameEntities();
        }

        private readonly GameEntities _context;

        private List<Player> GetAllPlayers()
        {
            return _context.Players.ToList();
        }

        public void ListAllPlayers()
        {
            foreach (var player in GetAllPlayers())
            {
                Console.WriteLine($"{player.PlayerId} {player.Username} {player.Password} {player.Email} {player.MMR}");
            }
        }

        public void AddNewPlayer(Player newPlayer, List<Match> newPlayerMatches)
        {        
            if (_context.Players.Count() != 0)
            {
                newPlayer.PlayerId = _context.Players.Max(x => x.PlayerId) + 1;
            }
            else
                newPlayer.PlayerId = 1;

            foreach (var match in newPlayerMatches)
            {
                _context.Matches.FirstOrDefault(x => x.MatchId == match.MatchId).Players.Add(newPlayer);
            }
            
            _context.Players.Add(newPlayer);
            _context.SaveChanges();
            
        }

        public void EdditPlayer (int edditingPlayersId, string newUsername, string newPassword)
        {
            _context.Players.First(x => x.PlayerId == edditingPlayersId).Username = newUsername;
            _context.Players.First(x => x.PlayerId == edditingPlayersId).Password = newPassword;
            _context.SaveChanges();
        }
        
        public Player getPlayer (int playerId)
        {
            return _context.Players.First(x => x.PlayerId == playerId);
        }

        public void DeletePlayer (int deletingPlayerId)
        {
            _context.Players.Remove(getPlayer(deletingPlayerId));
            _context.SaveChanges();
        }
    }
}
