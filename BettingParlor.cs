namespace DogsAtTheRaces;

public partial class BettingParlor : Form
{

    private Dog[] dogs = new Dog[4];
    private Guy[] guys = new Guy[3];


    public BettingParlor()
    {
        InitializeComponent();

        guys[0] = new Guy { Name = "Joe", Cash = 50, MyRadioButton = rb_Guy1, MyLabel = lb_guy1BetLabel };
        guys[1] = new Guy { Name = "Bob", Cash = 75, MyRadioButton = rb_Guy2, MyLabel = lb_guy2BetLabel };
        guys[2] = new Guy { Name = "Al", Cash = 45, MyRadioButton = rb_Guy3, MyLabel = lb_guy3BetLabel };

        foreach (Guy g in guys)
            g.UpdateLabels();

        dogs[0] = new Dog { MyPictureBox = pb_dog1, StartingPosition = pb_dog1.Left, RaceTrackLength = pb_raceTrack.Width - pb_dog1.Width };
        dogs[1] = new Dog { MyPictureBox = pb_dog2, StartingPosition = pb_dog2.Left, RaceTrackLength = pb_raceTrack.Width - pb_dog2.Width };
        dogs[2] = new Dog { MyPictureBox = pb_dog3, StartingPosition = pb_dog3.Left, RaceTrackLength = pb_raceTrack.Width - pb_dog3.Width };
        dogs[3] = new Dog { MyPictureBox = pb_dog4, StartingPosition = pb_dog4.Left, RaceTrackLength = pb_raceTrack.Width - pb_dog4.Width };
    }

    private void bt_bet_Click(object sender, EventArgs e)
    {
        Guy selectedGuy = null;

        if (rb_Guy1.Checked) selectedGuy = guys[0];
        if (rb_Guy2.Checked) selectedGuy = guys[1];
        if (rb_Guy3.Checked) selectedGuy = guys[2];

        if (selectedGuy == null)
            return;

        int dog = (int)num_dogNumber.Value;

        selectedGuy.PlaceBet(5, dog);
        selectedGuy.UpdateLabels();
    }

    private void bt_race_Click(object sender, EventArgs e)
    {
        foreach (Dog d in dogs)
            d.TakeStartingPosition();

        t_raceTimer.Start();
    }

    private void t_raceTimer_Tick(object sender, EventArgs e)
    {
        for (int i = 0; i < dogs.Length; i++)
        {
            if (dogs[i].Run())
            {
                t_raceTimer.Stop();

                int winner = i + 1;

                foreach (Guy g in guys)
                {
                    g.Collect(winner);
                    g.ClearBet();
                    g.UpdateLabels();
                }

                foreach (Dog d in dogs)
                    d.TakeStartingPosition();

                MessageBox.Show($"Dog {winner} wins!");

                return;
            }
        }
    }
}
