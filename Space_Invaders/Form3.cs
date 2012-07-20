using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Space_Invaders
{
    public partial class Form3 : Form
    {

        const int SCREEN_HEIGHT = 480;
        const int SCREEN_WIDTH = 900;

        SoundPlayer fire = new SoundPlayer(@".\sounds\shoot.wav");
        SoundPlayer explode = new SoundPlayer(@".\sounds\explosion.wav");
        SoundPlayer fire1 = new SoundPlayer(@".\sounds\shoot1.wav");


        Player player1;
        Player player2;
        Enemy enemy1, enemy2, enemy3, enemy4 ,enemy7, enemy8,enemy9,enemy10;
        Enemy enemy5, enemy6;
        Projectile player1Projectile;
        Projectile player2Projectile;
        int leftRight = SCREEN_WIDTH / 2;
        bool side = true;
        int enemyLeft1 = 5;
        int enemyLeft2 = 5;
        Image background;
        bool enterPressed = false;

        public Form3()
        {
            InitializeComponent();
            this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
            Initialize();
            LoadGraphicContent();
        }



        public void Initialize()
        {

            labelControles.Location = new Point(SCREEN_WIDTH / 2 - labelControles.Width / 2, SCREEN_HEIGHT / 2 - labelControles.Height / 2);
            labelYouWon.Location = new Point(SCREEN_WIDTH / 2 - labelYouWon.Width / 2, SCREEN_HEIGHT / 5 - labelYouWon.Height / 2);
            labelYouWon.Hide();

            player1 = new Player(SCREEN_WIDTH / 4 - 5 - pictureBoxPlayer1.Width / 2, SCREEN_HEIGHT - pictureBoxPlayer1.Height-78);
            player2 = new Player(3 * (SCREEN_WIDTH / 4 + 5) - pictureBoxPlayer2.Width / 2, SCREEN_HEIGHT - pictureBoxPlayer2.Height-78);
            
            enemy1 = new Enemy(SCREEN_WIDTH/4 - pictureBoxEnemy1_1.Width/2,SCREEN_HEIGHT/6,30,30);
            enemy2 = new Enemy(3*(SCREEN_WIDTH/4) ,SCREEN_HEIGHT/6,30,30);
            enemy3 = new Enemy(SCREEN_WIDTH/3 - pictureBoxEnemy3_1.Width/2,SCREEN_HEIGHT/6,40,30);
            enemy4 = new Enemy(2*(SCREEN_WIDTH/3) , SCREEN_HEIGHT/6,40,30);
            enemy5 = new Enemy(SCREEN_WIDTH/6 - pictureBoxEnemy5_1.Width/2,SCREEN_HEIGHT/6,40,30);
            enemy6 = new Enemy(5*(SCREEN_WIDTH/6-2),SCREEN_HEIGHT/6,40,30);
            enemy7 = new Enemy(SCREEN_WIDTH / 5-10, SCREEN_HEIGHT / 4, 40, 30);
            enemy8 = new Enemy(SCREEN_WIDTH / 4+10, SCREEN_HEIGHT / 4, 40, 30);
            enemy9 = new Enemy(3 * (SCREEN_WIDTH / 4) - 40, SCREEN_HEIGHT / 4, 40, 30);
            enemy10 = new Enemy(3 * (SCREEN_WIDTH / 4) + 20 + 10, SCREEN_HEIGHT / 4, 40, 30);

            player1Projectile = new Projectile(-100, -100);
            player2Projectile = new Projectile(-100, -100);

            Cursor.Hide();
        
        }

        public void LoadGraphicContent()
        {

           background = Image.FromFile("modernBackground.jpg");
           this.BackgroundImage = background;

            player1.Texture = pictureBoxPlayer1;
            player2.Texture = pictureBoxPlayer2;
            pictureBoxPlayer1.Load("player.png");
            pictureBoxPlayer2.Load("player.png");

            player1Projectile.Texture = pictureBoxPlayer1Projectile;
            player2Projectile.Texture = pictureBoxPlayer2Projectile;
            pictureBoxPlayer2Projectile.Load("playerProjectile.png");
            pictureBoxPlayer1Projectile.Load("playerProjectile.png");

            enemy1.Texture1 = pictureBoxEnemy1_1;
            enemy1.Texture2 = pictureBoxEnemy1_2;
            pictureBoxEnemy1_1.Load("enemy1_1.png");
            pictureBoxEnemy1_2.Load("enemy1_2.png");

            enemy2.Texture1 = pictureBoxEnemy2_1;
            enemy2.Texture2 = pictureBoxEnemy2_2;
            pictureBoxEnemy2_1.Load("enemy1_1.png");
            pictureBoxEnemy2_2.Load("enemy1_2.png");

            enemy3.Texture1 = pictureBoxEnemy3_1;
            enemy3.Texture2 = pictureBoxEnemy3_2;
            pictureBoxEnemy3_1.Load("enemy3_1.png");
            pictureBoxEnemy3_2.Load("enemy3_2.png");

            enemy4.Texture1 = pictureBoxEnemy4_1;
            enemy4.Texture2 = pictureBoxEnemy4_2;
            pictureBoxEnemy4_1.Load("enemy3_1.png");
            pictureBoxEnemy4_2.Load("enemy3_2.png");

            enemy5.Texture1 = pictureBoxEnemy5_1;
            enemy5.Texture2 = pictureBoxEnemy5_2;
            pictureBoxEnemy5_1.Load("enemy2_1.png");
            pictureBoxEnemy5_2.Load("enemy2_2.png");

            enemy6.Texture1 = pictureBoxEnemy6_1;
            enemy6.Texture2 = pictureBoxEnemy6_2;
            pictureBoxEnemy6_1.Load("enemy2_1.png");
            pictureBoxEnemy6_2.Load("enemy2_2.png");

            enemy7.Texture1 = pictureBoxEnemy7_1;
            enemy7.Texture2 = pictureBoxEnemy7_2;
            pictureBoxEnemy7_1.Load("enemy2_1.png");
            pictureBoxEnemy7_2.Load("enemy2_2.png");

            enemy8.Texture1 = pictureBoxEnemy8_1;
            enemy8.Texture2 = pictureBoxEnemy8_2;
            pictureBoxEnemy8_1.Load("enemy2_1.png");
            pictureBoxEnemy8_2.Load("enemy2_2.png");

            enemy9.Texture1 = pictureBoxEnemy9_1;
            enemy9.Texture2 = pictureBoxEnemy9_2;
            pictureBoxEnemy9_1.Load("enemy2_1.png");
            pictureBoxEnemy9_2.Load("enemy2_2.png");

            enemy10.Texture1 = pictureBoxEnemy10_1;
            enemy10.Texture2 = pictureBoxEnemy10_2;
            pictureBoxEnemy10_1.Load("enemy2_1.png");
            pictureBoxEnemy10_2.Load("enemy2_2.png");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
          
            timer1.Stop();
            timerEnemyAnimation.Stop();
            HideGameItems();
        }


        private void DrawScene()
        {
                player1.DrawPlayer();
                player2.DrawPlayer();
                player1Projectile.DrawProjectile();
                player2Projectile.DrawProjectile();
                

                #region enemyDraw
                enemy1.DrawEnemy();
                enemy2.DrawEnemy();
                enemy3.DrawEnemy();
                enemy4.DrawEnemy();
                enemy5.DrawEnemy();
                enemy6.DrawEnemy();
                enemy7.DrawEnemy();
                enemy8.DrawEnemy();
                enemy9.DrawEnemy();
                enemy10.DrawEnemy();
                #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateScene();
            DrawScene();
            checkSide();
        }

      

        private void UpdateScene()
        {
            moveEnemies();
            CheckFire2();
            player1Projectile.UpdateProjectile(-25);
            player2Projectile.UpdateProjectile(-25);
            checkEnemyCollision();
            UpdatePlayer2();
            checkEndGame();
        }

       

        private void moveEnemies()
        {
            if (side)
            {
                enemy1.UpdateEnemy(3);
                enemy2.UpdateEnemy(3);
                enemy3.UpdateEnemy(3);
                enemy4.UpdateEnemy(3);
                enemy5.UpdateEnemy(3);
                enemy6.UpdateEnemy(3);
                enemy7.UpdateEnemy(3);
                enemy8.UpdateEnemy(3);
                enemy9.UpdateEnemy(3);
                enemy10.UpdateEnemy(3);
                leftRight += 3;

            }
            else
            {
                enemy1.UpdateEnemy(-3);
                enemy2.UpdateEnemy(-3);
                enemy3.UpdateEnemy(-3);
                enemy4.UpdateEnemy(-3);
                enemy5.UpdateEnemy(-3);
                enemy6.UpdateEnemy(-3);
                enemy7.UpdateEnemy(-3);
                enemy8.UpdateEnemy(-3);
                enemy9.UpdateEnemy(-3);
                enemy10.UpdateEnemy(-3);
                leftRight -= 3;
            }
        }

        private void checkSide()
        {
            if (leftRight >= SCREEN_WIDTH / 2 + 85) side = false;
            if (leftRight <= SCREEN_WIDTH / 2 - 103) side = true;
        }

        private void CheckFire1()
        {
            if (player1Projectile.Position.Y < 0)
            {
                int projectileX = player1.PlayerPosition.X + player1.Origin1.X - 2;
                int projectileY = SCREEN_HEIGHT - 78;

                player1Projectile.Position = new Point(projectileX, projectileY);
                fire1.Play();

            }
        }


        public void CheckFire2()
        {
            if (MouseButtons == MouseButtons.Left && player2Projectile.Position.Y < 0)
            {
                int projectileX = player2.PlayerPosition.X + player2.Origin1.X - 2;
                int projectileY = SCREEN_HEIGHT - 78;

                player2Projectile.Position = new Point(projectileX, projectileY);
                fire1.Play();

            }
        }
        private void UpdatePlayer2()
        {
            if (this.PointToClient(MousePosition).X > SCREEN_WIDTH / 2 + pictureBoxPlayer2.Width)
            {
                int playerX = this.PointToClient(MousePosition).X;
                int playerY = SCREEN_HEIGHT - player2.Origin1.Y;
                player2.UpdatePlayer2(playerX, playerY);
            }

            
        }

        private void checkEnemyCollision()
        {
            #region checkingCollision
            if (enemy1.checkCollision(player1Projectile.Rec))
            {
                player1Projectile.reset(-100, -100);
                enemy1.Position = new Point(-500, 100);
                enemy1.IsAlive = false;
                enemyLeft1--;
                explode.Play();
            }
            else if (enemy2.checkCollision(player2Projectile.Rec))
            {
                player2Projectile.reset(-100, -100);
                enemy2.Position = new Point(-500, 100);
                enemy2.IsAlive = false;
                enemyLeft2--;
                explode.Play();
            }
            else if (enemy3.checkCollision(player1Projectile.Rec))
            {
                player1Projectile.reset(-100, -100);
                enemy3.Position = new Point(-500, 100);
                enemy3.IsAlive = false;
                enemyLeft1--;
                explode.Play();

            }
            else if (enemy4.checkCollision(player2Projectile.Rec))
            {
                player2Projectile.reset(-100, -100);
                enemy4.Position = new Point(-500, 100);
                enemy4.IsAlive = false;
                enemyLeft2--;
                explode.Play();
            }
            else if (enemy5.checkCollision(player1Projectile.Rec))
            {
                player1Projectile.reset(-100, -100);
                enemy5.Position = new Point(-500, 100);
                enemy5.IsAlive = false;
                enemyLeft1--;
                explode.Play();
            }
            else if (enemy6.checkCollision(player2Projectile.Rec))
            {
                player2Projectile.reset(-100, -100);
                enemy6.Position = new Point(-500, 100);
                enemy6.IsAlive = false;
                enemyLeft2--;
                explode.Play();
            }
            else if (enemy7.checkCollision(player1Projectile.Rec))
            {
                player1Projectile.reset(-100, -100);
                enemy7.Position = new Point(-500, 100);
                enemy7.IsAlive = false;
                enemyLeft1--;
                explode.Play();
            }
            else if (enemy8.checkCollision(player1Projectile.Rec))
            {
                player1Projectile.reset(-100, -100);
                enemy8.Position = new Point(-500, 100);
                enemy8.IsAlive = false;
                enemyLeft1--;
                explode.Play();
            }

            else if (enemy9.checkCollision(player2Projectile.Rec))
            {
                player2Projectile.reset(-100, -100);
                enemy9.Position = new Point(-500, 100);
                enemy9.IsAlive = false;
                enemyLeft2--;
                explode.Play();
            }

            else if (enemy10.checkCollision(player2Projectile.Rec))
            {
                player2Projectile.reset(-100, -100);
                enemy10.Position = new Point(-500, 100);
                enemy10.IsAlive = false;
                enemyLeft2--;
                explode.Play();
            }
            #endregion
        }

        private void HideGameItems()
        {
            pictureBoxEnemy1_1.Hide();
            pictureBoxEnemy1_2.Hide();
            pictureBoxEnemy2_1.Hide();
            pictureBoxEnemy2_2.Hide();
            pictureBoxEnemy3_1.Hide();
            pictureBoxEnemy3_2.Hide();
            pictureBoxEnemy4_1.Hide();
            pictureBoxEnemy4_2.Hide();
            pictureBoxEnemy5_1.Hide();
            pictureBoxEnemy5_2.Hide();
            pictureBoxEnemy6_1.Hide();
            pictureBoxEnemy6_2.Hide();
            pictureBoxEnemy7_1.Hide();
            pictureBoxEnemy7_2.Hide();
            pictureBoxEnemy8_1.Hide();
            pictureBoxEnemy8_2.Hide();
            pictureBoxEnemy9_1.Hide();
            pictureBoxEnemy9_2.Hide();
            pictureBoxEnemy10_1.Hide();
            pictureBoxEnemy10_2.Hide();
            pictureBoxPlayer1.Hide();
            pictureBoxPlayer1Projectile.Hide();
            pictureBoxPlayer2.Hide();
            pictureBoxPlayer2Projectile.Hide();
        }


        private void showGameItem()
        {
            pictureBoxEnemy1_1.Show();
            pictureBoxEnemy2_1.Show();
            pictureBoxEnemy3_1.Show();
            pictureBoxEnemy4_1.Show();
            pictureBoxEnemy5_1.Show();
            pictureBoxEnemy6_1.Show();
            pictureBoxEnemy7_1.Show();
            pictureBoxEnemy8_1.Show();
            pictureBoxEnemy9_1.Show();
            pictureBoxEnemy10_1.Show();
            pictureBoxPlayer1.Show();
            pictureBoxPlayer1Projectile.Show();
            pictureBoxPlayer2.Show();
            pictureBoxPlayer2Projectile.Show();
        }

        private void checkEndGame()
        {
            if (enemyLeft1 == 0)
            {
                labelYouWon.Text = "PLAYER1 WON\nPRESS ESP TO BACK\nQ TO GO QUIT";
                labelYouWon.Show();
                timer1.Stop();
                timerEnemyAnimation.Stop();
                HideGameItems();
            
            }
            if (enemyLeft2 == 0)
            {
                labelYouWon.Text = "PLAYER2 WON\nPRESS ESP TO BACK\nQ TO GO QUIT";
                labelYouWon.Show();
                timer1.Stop();
                timerEnemyAnimation.Stop();
                HideGameItems();
                
            }
        }


        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if(pictureBoxPlayer1.Left < SCREEN_WIDTH/2 - 2*pictureBoxPlayer1.Width) player1.UpdatePlayer(5);
            }
            else if (e.KeyCode == Keys.Left)
            {
                player1.UpdatePlayer(-5); player1.UpdatePlayer(-5);
            }

            if (e.KeyCode == Keys.Space) CheckFire1();

            if (e.KeyCode == Keys.Escape) Application.Restart();

            if (e.KeyCode == Keys.Q) Application.Exit();
            if (e.KeyCode == Keys.Enter)
            {
                if (!enterPressed)
                {
                    labelControles.Hide();
                    timer1.Start();
                    timerEnemyAnimation.Start();
                    showGameItem();
                    enterPressed = true;
                }
            }
        }

        private void timerEnemyAnimation_Tick(object sender, EventArgs e)
        {
            enemy1.Animate();
            enemy2.Animate();
            enemy3.Animate();
            enemy4.Animate();
            enemy5.Animate();
            enemy6.Animate();
            enemy7.Animate();
            enemy8.Animate();
            enemy9.Animate();
            enemy10.Animate(); 
            
        }


       
        

       

    }

}
