using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsAtTheRaces
{
    public class Dog
    {
        public static Random Randomizer = new Random();

        public int StartingPosition;
        public int RaceTrackLength;
        public int Location;

        public PictureBox MyPictureBox;

        public bool Run()
        {
            Location += Randomizer.Next(1, 5);
            MyPictureBox.Left = StartingPosition + Location;
            
            return MyPictureBox.Left >= RaceTrackLength;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
