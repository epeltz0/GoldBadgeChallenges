using System;
using System.Collections.Generic;

namespace BadgesRepository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors { get; set; }

        public Badges() { }

        public Badges(int badgeId, List<string> listOfDoors)
        {
            BadgeID = badgeId;
            ListOfDoors = listOfDoors;
        }

        
    }
}
