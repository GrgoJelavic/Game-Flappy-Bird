using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class FlappyBIrdGame : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public FlappyBIrdGame()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }         
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ||
                flappyBird.Top < -20)
                    EndGame();

            if (score > 5)
                pipeSpeed = 12;
            if (score > 10)
                pipeSpeed = 16;
            if (score > 15)
                pipeSpeed = 20;
            if (score > 20)
                pipeSpeed = 25; 
        }

        private void GameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up )
                gravity = -7;
            if (score > 10)
                gravity = -6;
            if (score > 15)
                gravity = -5;
        }

        private void GameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                gravity = 7;
            if (score > 10)
                gravity = 6;
            if (score > 15)
                gravity = 5;
        }

        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += " -  GAME OVER!";

        }
    }
}
