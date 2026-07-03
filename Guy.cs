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

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if (MyBet == null)
            {
                MyLabel.Text = $"{Name} hasn't placed a bet";
            }
            else
            {
                MyLabel.Text = MyBet.GetDescription();
            }

            MyRadioButton.Text = $"{Name} (${Cash})";
        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public bool PlaceBet(int amount, int dog)
        {
            if (amount > Cash)
            {
                return: false;
            }

            MyBet = new Bet()
            {
                Amount = amount,
                Dog = dog,
                Bettor = this
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
