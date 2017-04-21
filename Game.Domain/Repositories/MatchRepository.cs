using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Repositories
{
    public class MatchRepository
    {
        public MatchRepository()
        {
            _context = new GameEntities();
        }
        private readonly GameEntities _context;

        public List<Match> GetAllMatches()
        {
            return _context.Matches.ToList();
        }

        public void ListAllMatches()
        {
            foreach (var match in GetAllMatches())
            {
                Console.WriteLine($"{match.MatchId} {match.Name}");
            }
        }

        public void AddNewMatch (Match newMatch)
        {
            if (_context.Matches.Count() != 0)
            {
                newMatch.MatchId = _context.Matches.Max(x => x.MatchId) + 1;
            }
            else
                newMatch.MatchId = 1;

            _context.Matches.Add(newMatch);
            _context.SaveChanges();
        }

        private Match getMatch (int matchId)
        {
            return _context.Matches.First(x => x.MatchId == matchId);
        }

        public void DeleteMatch (int deletingMatchId)
        {
            _context.Matches.Remove(getMatch(deletingMatchId));
            _context.SaveChanges();
        }
    } 
}
