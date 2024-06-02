using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int boruhızı = 8;
        int gravity = 10;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            BoruAlt.Left -= boruhızı;
            BoruUst.Left -= boruhızı;
            scoreText.Text = "Score: " + score;
            if (BoruAlt.Left < -150)
            {
                BoruAlt.Left = 800;
                score++;
            }
            if (BoruUst.Left < -180)
            {
                BoruUst.Left = 950;
                score++;
            }
            if (flappybird.Bounds.IntersectsWith(BoruAlt.Bounds) || flappybird.Bounds.IntersectsWith(BoruUst.Bounds) || flappybird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            if (score > 7)
            {
                boruhızı = 15; 
            }
            if (flappybird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity =10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over!!!";
        }
    }
}
