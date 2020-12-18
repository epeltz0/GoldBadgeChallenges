using BadgesRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BadgesRepository
{
    public class BadgesRepo
    {
        private List<string> listOfDoors = new List<string>();
        private Dictionary<int, Badges> BadgeDictionary = new Dictionary<int, Badges>();

        public void AddBadgeToDictionary(Badges badge)
        {
            BadgeDictionary.Add(badge.BadgeID, badge);
        }

        public Dictionary<int, Badges> GetBadgesDictionary()
        {
            return BadgeDictionary;
        }

        public bool UpdateExistingBadges(int originalBadgeID, Badges newBadge)
        {
            Badges oldBadge = GetBadgeByID(originalBadgeID);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.ListOfDoors = newBadge.ListOfDoors;

                return true;
            }
            else
            {
                return false;
            }

        }

        public void UpdateBadges(Dictionary<int, List<string>> dic, int key, List<string> newValue)
        {
            if(dic.TryGetValue(key,out newValue))
                {
                dic[key] = newValue;
                }
            else
            {
                dic.Add(key, newValue);
            }
        }


        public Badges GetBadgeByID(int badgeID)
        {
            foreach (KeyValuePair<int, Badges> badges in BadgeDictionary)
            {
                if (badges.Key == badgeID)
                {
                    return badges.Value;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }
    }
}
