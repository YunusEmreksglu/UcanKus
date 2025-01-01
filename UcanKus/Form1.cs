

namespace UcanKus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                button1.Top = button1.Location.Y - 40;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 200; // 1 saniye
            timer.Tick += Timer_Tick;
            timer.Start();

            System.Windows.Forms.Timer timerz = new System.Windows.Forms.Timer();
            timerz.Interval = 3000; // 1 saniye
            timerz.Tick += TimerZ_Tick;
            timerz.Start();
        }

        public void bsds()
        {
            Button button = new Button();
            Button button1 = new Button();

            button1.Size = new Size(50, new Random().Next(50, 200));
            button1.Location = new Point(this.Width-75, this.Height - button1.Size.Height);


            this.Controls.Add(button1);
            


            button.Size = new Size(50, this.Height - (button1.Size.Height) - 131 );
            button.Location = new Point(this.Width - 75, 0);

            this.Controls.Add(button);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            button1.Top = button1.Top + 10;
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Button obstacle && obstacle != button1)
                {
                    obstacle.Left -= 20;

                    if (obstacle.Bounds.IntersectsWith(button1.Bounds))
                    {
                        MessageBox.Show("Game Over!");
                        Application.Exit();
                    }

                    if (obstacle.Right < 0)
                    {
                        this.Controls.Remove(obstacle);
                        obstacle.Dispose();
                    }
                }
            }
        }

        private void TimerZ_Tick(object sender, EventArgs e)
        {

            bsds();
        }
    }
}
