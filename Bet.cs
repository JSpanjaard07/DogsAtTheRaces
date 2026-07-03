using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAtTheRaces
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }

        public string GetDescription()
        {
            if (Bettor == null)
                return "No bet placed";

            return $"{Bettor.Name} bets {Amount} on dog {Dog}";
        }

    }
}