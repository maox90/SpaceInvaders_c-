using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Space_Invaders
{
    public partial class SpaceInvadersIntro : Form
    {

        SoundPlayer player = new SoundPlayer(@".\sounds\intro.wav");
        SoundPlayer click = new SoundPlayer(@".\sounds\click.wav");
        SoundPlayer exit = new SoundPlayer(@".\sounds\exit.wav");

        public SpaceInvadersIntro()
        {
            InitializeComponent();
            pictureBoxClassic.Hide();
            pictureBoxModern.Hide();
            pictureBoxBack.Hide();
            
        }
        

        private void SpaceInvadersIntro_Load(object sender, EventArgs e)
        {
            pictureBoxExit.Load("button_exit.png");
            pictureBoxSingle.Load("button_single2.png");
            pictureBoxmMulty.Load("button_multy.png");
            player.Play();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            exit.Play();
            Thread.Sleep(500);
            Application.Exit();
        }

        private void pictureBoxmMulty_Click(object sender, EventArgs e)
        {
            click.Play();
            Thread.Sleep(500);
            new Form3().Show();
            this.Hide();
            player.Stop();
        }

        private void pictureBoxSingle_Click(object sender, EventArgs e)
        {
            
            
            pictureBoxSingle.Hide();
            pictureBoxmMulty.Hide();
            pictureBoxClassic.Show();
            pictureBoxModern.Show();
            pictureBoxBack.Show();
            
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            
            Thread.Sleep(500);
            pictureBoxSingle.Show();
            pictureBoxmMulty.Show();
            pictureBoxClassic.Hide();
            pictureBoxModern.Hide();
            pictureBoxBack.Hide();
        }

        private void pictureBoxClassic_Click(object sender, EventArgs e)
        {
            click.Play();
            Thread.Sleep(500);
            new singlePlayer(1).Show();
            this.Hide();
            player.Stop();
        }

        private void pictureBoxModern_Click(object sender, EventArgs e)
        {
            click.Play();
            Thread.Sleep(500);
            new singlePlayer(2).Show();
            this.Hide();
            player.Stop();
        }
       

        
    }
}
