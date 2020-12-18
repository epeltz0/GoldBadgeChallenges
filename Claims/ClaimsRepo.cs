using System;
using System.Collections.Generic;
using System.Text;

namespace ClaimsRepository
{
   
    
   public class ClaimsRepo
    {
        
        Queue<Claims> _queueOfClaims = new Queue<Claims>();

        public void AddClaimToList(Claims claim)
        {
            _queueOfClaims.Enqueue(claim);
        }

        public Queue<Claims> ViewAllClaims()
        {
            return _queueOfClaims;
        }

        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims claim in _queueOfClaims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }

            return null;
        }

    }
}
