using Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Domain.Repositories
{
    public class MissionRepository
    {
        public MissionRepository()
        {
            _context = new GameEntities();
        }

        private readonly GameEntities _context;

        public void AddNewMission(Mission newMission)
        {
            if (_context.Matches.Any(x => x.MatchId == newMission.MatchId))
            {
                if (_context.Missions.Count() != 0)
                    newMission.MissionId = _context.Missions.Max(x => x.MissionId) + 1;
                else
                    newMission.MissionId = 1;

                _context.Missions.Add(newMission);
                _context.SaveChanges();
            }
            else
                Console.WriteLine("Mission doesn't belong to a valid match therefore it can't be added.");
        }
    }
}
