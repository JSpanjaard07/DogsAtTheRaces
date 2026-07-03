using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAtTheRaces
{
    internal class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public bool PlaceBet(int amount, int dog)
        {
            if (amount > Cash)
            {
                return: false;
            }

            MyBet = new Bet
            {
                Amount = amount,
                Dog = dog,
                Better = this
            };

            return true;
        }

        public void Collect(int winner)
        {
            if (MyBet != null)
            {
                Cash += MyBet.PayOut(winner);
                MyBet = null;
            }
        }

    }
}
