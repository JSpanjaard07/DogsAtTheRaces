namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{

    private Dog[] dogs = new Dog[4];

    public BettingParlor()
    {
        InitializeComponent();

        dogs[0] = new Dog
        {
            MyPictureBox = pb_dog1,
            StartingPosition = pb_dog1.Left,
            RaceTrackLength = pb_raceTrack.Width - pb_dog1.Width
        }
        dogs[1] = new Dog
        {
            MyPictureBox = pb_dog2,
            StartingPosition = pb_dog2.Left,
            RaceTrackLength = pb_raceTrack.Width - pb_dog2.Width
        }
        dogs[2] = new Dog
        {
            MyPictureBox = pb_dog3,
            StartingPosition = pb_dog3.Left,
            RaceTrackLength = pb_raceTrack.Width - pb_dog3.Width
        }
        dogs[3] = new Dog
        {
            MyPictureBox = pb_dog4,
            StartingPosition = pb_dog4.Left,
            RaceTrackLength = pb_raceTrack.Width - pb_dog4.Width
        }
    }


    private void bt_race_Click(object sender, EventArgs e)
    {
        foreach (Dog dog in dogs)
        {
            dog.TakeStartingPosition();
        }
        t_raceTimer.Start();
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void t_raceTimer_Tick(object sender, EventArgs e)
    {
        foreach (Dog dog in dogs)
        {
            if (dog.Run())
            {
                t_raceTimer.Stop();
                MessageBox.Show($"Dog {Array.IndexOf(dogs, dog) + 1} wins!");

                foreach (Dog d in dogs)
                {
                    d.TakeStartingPosition();
                }
                break;
            }
        }
    }
}
