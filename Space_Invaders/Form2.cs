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
    public partial class singlePlayer : Form
    {

        const int SCREEN_WIDTH = 640;
        const int SCREEN_HEIGHT = 480;

        const float COLLISION_DISTANCE1 = 21.0f;

        bool side = true;
        int enemyLeft = 15;
        int leftRight = SCREEN_WIDTH / 2;
        int score = 0;
        bool enterPressed = false;

        Random rnd;

        Player player;


        SoundPlayer fire = new SoundPlayer(@".\sounds\shoot.wav");
        SoundPlayer explode = new SoundPlayer(@".\sounds\explosion.wav");
        SoundPlayer fire1 = new SoundPlayer(@".\sounds\shoot1.wav");
       

        #region enemyDeclaration

        Enemy enemy1, enemy4, enemy5 , enemy6, enemy7;
        Enemy enemy2, enemy8, enemy9, enemy10, enemy11;
        Enemy enemy3, enemy12, enemy13, enemy14,  enemy15;
      

        Projectile playerProjectile;
        Projectile enemyProjectile1;
        Projectile enemyProjectile2;
        Projectile enemyProjectile3;


        #endregion

        Image background;



        public singlePlayer(int i)
        {
            if (i == 1)
            {
                InitializeComponent();
                
                this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
                Initialize();
                LoadGraphicContent();
            }
            else
            {
                InitializeComponent();
                
                this.ClientSize = new Size(SCREEN_WIDTH, SCREEN_HEIGHT);
                Initialize();
                LoadGraphicContent2();
            }
        }
        
#region events
        private void singlePlayer_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            timerEnemyAnimate.Stop();
            HideGameItems();
            
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            UpdateScene();
            DrawScene();
            checkSide();
        }

      


        //timer koji sluzi samo za animaciju
        private void timer2_Tick(object sender, EventArgs e)
        {
                #region enemyAnimation
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
                enemy11.Animate();
                enemy12.Animate();
                enemy13.Animate();
                enemy14.Animate();
                enemy15.Animate();
                #endregion
            
        }


#endregion

        public void Initialize()
        {
            
            rnd = new Random();
            
            player = new Player(SCREEN_WIDTH/2,SCREEN_HEIGHT-90);

            
            
            labelYouWon.Location = new Point(SCREEN_WIDTH / 2 - labelYouWon.Width/2, SCREEN_HEIGHT / 5-labelYouWon.Height/2);
            labelYouWon.Hide();



            labelScore.Location = new Point(10, 10);
            labelLives.Location = new Point(SCREEN_WIDTH - labelLives.Width-10, 10);
            labelControles.Location = new Point(SCREEN_WIDTH / 2 - labelControles.Width / 2, SCREEN_HEIGHT / 2 - labelControles.Height / 2);


            playerProjectile = new Projectile(-100,-100);
            enemyProjectile1 = new Projectile(SCREEN_WIDTH + 1, SCREEN_HEIGHT + 1);
            enemyProjectile2 = new Projectile(SCREEN_WIDTH + 1, SCREEN_HEIGHT + 1);
            enemyProjectile3 = new Projectile(SCREEN_WIDTH + 1, SCREEN_HEIGHT + 1);
           

            #region enemyInitialization
            enemy1 = new Enemy(SCREEN_WIDTH / 2 - 100, SCREEN_HEIGHT / 6,30,30);
            enemy4 = new Enemy(SCREEN_WIDTH / 2 - 200, SCREEN_HEIGHT / 6,30,30);
            enemy5 = new Enemy(SCREEN_WIDTH / 2 + 5 , SCREEN_HEIGHT / 6,30,30);
            enemy6 = new Enemy(SCREEN_WIDTH / 2 + 105, SCREEN_HEIGHT / 6,30,30);
            enemy7 = new Enemy(SCREEN_WIDTH / 2 + 205, SCREEN_HEIGHT / 6,30,30);

            enemy2 = new Enemy(SCREEN_WIDTH / 2 - 80, SCREEN_HEIGHT / 3,40,30);
            enemy8 = new Enemy(SCREEN_WIDTH / 2 - 160, SCREEN_HEIGHT / 3,40,30);
            enemy9 = new Enemy(SCREEN_WIDTH / 2 , SCREEN_HEIGHT / 3,40,30);
            enemy10 = new Enemy(SCREEN_WIDTH / 2 + 80, SCREEN_HEIGHT / 3,40,30);
            enemy11 = new Enemy(SCREEN_WIDTH / 2 + 160, SCREEN_HEIGHT / 3,40,30);

            enemy3 = new Enemy(SCREEN_WIDTH / 2 - 90, SCREEN_HEIGHT / 4,40,30);
            enemy12 = new Enemy(SCREEN_WIDTH / 2 - 180, SCREEN_HEIGHT / 4,40,30);
            enemy13 = new Enemy(SCREEN_WIDTH / 2 , SCREEN_HEIGHT / 4,40,30);
            enemy14 = new Enemy(SCREEN_WIDTH / 2 + 90, SCREEN_HEIGHT / 4,40,30);
            enemy15 = new Enemy(SCREEN_WIDTH / 2 + 180, SCREEN_HEIGHT / 4,40,30);
          
            #endregion


            Cursor.Hide();
        }

        

        private void LoadGraphicContent()
        {

            background = Image.FromFile("modernBackground.png");
            this.BackgroundImage = background;

            pictureBoxPlayer.Load("player.png");
            player.Texture = pictureBoxPlayer;

            playerProjectile.Texture = pictureBoxPlayerProjecite;
            pictureBoxPlayerProjecite.Load("playerProjectile.png");

            enemyProjectile1.Texture = pictureBoxEnemyProjectile1;
            pictureBoxEnemyProjectile1.Load("enemyProjectile.png");

            enemyProjectile2.Texture = pictureBoxEnemyProjectile2;
            pictureBoxEnemyProjectile2.Load("enemyProjectile.png");

            enemyProjectile3.Texture = pictureBoxEnemyProjectile3;
            pictureBoxEnemyProjectile3.Load("enemyProjectile.png");

            #region enemyGraphicLoad NE OTVARAJ :)
            
            enemy1.Texture1 = pictureBoxEnemy1_1;
            enemy1.Texture2 = pictureBoxEnemy1_2;
            pictureBoxEnemy1_1.Load("enemy1_1.png");
            pictureBoxEnemy1_2.Load("enemy1_2.png");

            
            enemy4.Texture1 = pictureBoxEnemy4_1;
            enemy4.Texture2 = pictureBoxEnemy4_2;
            pictureBoxEnemy4_1.Load("enemy1_1.png");
            pictureBoxEnemy4_2.Load("enemy1_2.png");

            enemy5.Texture1 = pictureBoxEnemy5_1;
            enemy5.Texture2 = pictureBoxEnemy5_2;
            pictureBoxEnemy5_1.Load("enemy1_1.png");
            pictureBoxEnemy5_2.Load("enemy1_2.png");

            enemy6.Texture1 = pictureBoxEnemy6_1;
            enemy6.Texture2 = pictureBoxEnemy6_2;
            pictureBoxEnemy6_1.Load("enemy1_1.png");
            pictureBoxEnemy6_2.Load("enemy1_2.png");

            
            enemy7.Texture1 = pictureBoxEnemy7_1;
            enemy7.Texture2 = pictureBoxEnemy7_2;
            pictureBoxEnemy7_1.Load("enemy1_1.png");
            pictureBoxEnemy7_2.Load("enemy1_2.png");

            
            enemy2.Texture1 = pictureBoxEnemy2_1;
            enemy2.Texture2 = pictureBoxEnemy2_2;
            pictureBoxEnemy2_1.Load("enemy2_1.png");
            pictureBoxEnemy2_2.Load("enemy2_2.png");

           
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

           
            enemy11.Texture1 = pictureBoxEnemy11_1;
            enemy11.Texture2 = pictureBoxEnemy11_2;
            pictureBoxEnemy11_1.Load("enemy2_1.png");
            pictureBoxEnemy11_2.Load("enemy2_2.png");


           
            enemy3.Texture1 = pictureBoxEnemy3_1;
            enemy3.Texture2 = pictureBoxEnemy3_2;
            pictureBoxEnemy3_1.Load("enemy3_1.png");
            pictureBoxEnemy3_2.Load("enemy3_2.png");


          
            enemy12.Texture1 = pictureBoxEnemy12_1;
            enemy12.Texture2 = pictureBoxEnemy12_2;
            pictureBoxEnemy12_1.Load("enemy3_1.png");
            pictureBoxEnemy12_2.Load("enemy3_2.png");


        
            enemy13.Texture1 = pictureBoxEnemy13_1;
            enemy13.Texture2 = pictureBoxEnemy13_2;
            pictureBoxEnemy13_1.Load("enemy3_1.png");
            pictureBoxEnemy13_2.Load("enemy3_2.png");


          
            enemy14.Texture1 = pictureBoxEnemy14_1;
            enemy14.Texture2 = pictureBoxEnemy14_2;
            pictureBoxEnemy14_1.Load("enemy3_1.png");
            pictureBoxEnemy14_2.Load("enemy3_2.png");

          
            enemy15.Texture1 = pictureBoxEnemy15_1;
            enemy15.Texture2 = pictureBoxEnemy15_2;
            pictureBoxEnemy15_1.Load("enemy3_1.png");
            pictureBoxEnemy15_2.Load("enemy3_2.png");

            

            #endregion

        }

        private void LoadGraphicContent2()
        {

            background = Image.FromFile("modernBackground.png");
            this.BackgroundImage = background;

            pictureBoxPlayer.Load("defender.png");
            player.Texture = pictureBoxPlayer;

            playerProjectile.Texture = pictureBoxPlayerProjecite;
            pictureBoxPlayerProjecite.Load("rocketModern1.png");

            enemyProjectile1.Texture = pictureBoxEnemyProjectile1;
            pictureBoxEnemyProjectile1.Load("rocketModern2.png");

            enemyProjectile2.Texture = pictureBoxEnemyProjectile2;
            pictureBoxEnemyProjectile2.Load("rocketModern2.png");

            enemyProjectile3.Texture = pictureBoxEnemyProjectile3;
            pictureBoxEnemyProjectile3.Load("rocketModern2.png");

            #region enemyGraphicLoad NE OTVARAJ :)

            enemy1.Texture1 = pictureBoxEnemy1_1;
            enemy1.Texture2 = pictureBoxEnemy1_2;
            pictureBoxEnemy1_1.Load("enemyModern3.png");
            pictureBoxEnemy1_2.Load("enemyModern3.png");


            enemy4.Texture1 = pictureBoxEnemy4_1;
            enemy4.Texture2 = pictureBoxEnemy4_2;
            pictureBoxEnemy4_1.Load("enemyModern3.png");
            pictureBoxEnemy4_2.Load("enemyModern3.png");

            enemy5.Texture1 = pictureBoxEnemy5_1;
            enemy5.Texture2 = pictureBoxEnemy5_2;
            pictureBoxEnemy5_1.Load("enemyModern3.png");
            pictureBoxEnemy5_2.Load("enemyModern3.png");

            enemy6.Texture1 = pictureBoxEnemy6_1;
            enemy6.Texture2 = pictureBoxEnemy6_2;
            pictureBoxEnemy6_1.Load("enemyModern3.png");
            pictureBoxEnemy6_2.Load("enemyModern3.png");


            enemy7.Texture1 = pictureBoxEnemy7_1;
            enemy7.Texture2 = pictureBoxEnemy7_2;
            pictureBoxEnemy7_1.Load("enemyModern3.png");
            pictureBoxEnemy7_2.Load("enemyModern3.png");


            enemy2.Texture1 = pictureBoxEnemy2_1;
            enemy2.Texture2 = pictureBoxEnemy2_2;
            pictureBoxEnemy2_1.Load("enemyModern1.png");
            pictureBoxEnemy2_2.Load("enemyModern1.png");


            enemy8.Texture1 = pictureBoxEnemy8_1;
            enemy8.Texture2 = pictureBoxEnemy8_2;
            pictureBoxEnemy8_1.Load("enemyModern1.png");
            pictureBoxEnemy8_2.Load("enemyModern1.png");


            enemy9.Texture1 = pictureBoxEnemy9_1;
            enemy9.Texture2 = pictureBoxEnemy9_2;
            pictureBoxEnemy9_1.Load("enemyModern1.png");
            pictureBoxEnemy9_2.Load("enemyModern1.png");


            enemy10.Texture1 = pictureBoxEnemy10_1;
            enemy10.Texture2 = pictureBoxEnemy10_2;
            pictureBoxEnemy10_1.Load("enemyModern1.png");
            pictureBoxEnemy10_2.Load("enemyModern1.png");


            enemy11.Texture1 = pictureBoxEnemy11_1;
            enemy11.Texture2 = pictureBoxEnemy11_2;
            pictureBoxEnemy11_1.Load("enemyModern1.png");
            pictureBoxEnemy11_2.Load("enemyModern1.png");



            enemy3.Texture1 = pictureBoxEnemy3_1;
            enemy3.Texture2 = pictureBoxEnemy3_2;
            pictureBoxEnemy3_1.Load("enemyModern2.png");
            pictureBoxEnemy3_2.Load("enemyModern2.png");



            enemy12.Texture1 = pictureBoxEnemy12_1;
            enemy12.Texture2 = pictureBoxEnemy12_2;
            pictureBoxEnemy12_1.Load("enemyModern2.png");
            pictureBoxEnemy12_2.Load("enemyModern2.png");



            enemy13.Texture1 = pictureBoxEnemy13_1;
            enemy13.Texture2 = pictureBoxEnemy13_2;
            pictureBoxEnemy13_1.Load("enemyModern2.png");
            pictureBoxEnemy13_2.Load("enemyModern2.png");



            enemy14.Texture1 = pictureBoxEnemy14_1;
            enemy14.Texture2 = pictureBoxEnemy14_2;
            pictureBoxEnemy14_1.Load("enemyModern2.png");
            pictureBoxEnemy14_2.Load("enemyModern2.png");


            enemy15.Texture1 = pictureBoxEnemy15_1;
            enemy15.Texture2 = pictureBoxEnemy15_2;
            pictureBoxEnemy15_1.Load("enemyModern2.png");
            pictureBoxEnemy15_2.Load("enemyModern2.png");



            #endregion

        }

       

        private void DrawScene()
        {
                player.DrawPlayer();
                playerProjectile.DrawProjectile();
                enemyProjectile1.DrawProjectile();
                enemyProjectile2.DrawProjectile();
                enemyProjectile3.DrawProjectile();

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
                enemy11.DrawEnemy();
                enemy12.DrawEnemy();
                enemy13.DrawEnemy();
                enemy14.DrawEnemy();
                enemy15.DrawEnemy();
                #endregion
          
        }

        private void UpdateScene()
        {
            
              
                moveEnemies();
                playerProjectile.UpdateProjectile(-25);
                enemyProjectile1.UpdateProjectile(5);
                enemyProjectile2.UpdateProjectile(5);
                enemyProjectile3.UpdateProjectile(5);
                checkEnemyFire();
                checkEnemyCollision();
                checkPlayerCollision();
                checkScore();
                checkLives();
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
                enemy11.UpdateEnemy(3);
                enemy12.UpdateEnemy(3);
                enemy13.UpdateEnemy(3);
                enemy14.UpdateEnemy(3);
                enemy15.UpdateEnemy(3);
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
                enemy11.UpdateEnemy(-3);
                enemy12.UpdateEnemy(-3);
                enemy13.UpdateEnemy(-3);
                enemy14.UpdateEnemy(-3);
                enemy15.UpdateEnemy(-3);
                leftRight -= 3;
            }
        }

        private void checkSide()
        {
            if (leftRight >= SCREEN_WIDTH/2 + 67) side = false;
            if (leftRight <= SCREEN_WIDTH/2 - 103) side = true;
        }


        public void CheckFire()
        {
            if (playerProjectile.Position.Y < 0)
            {
                int projectileX = player.PlayerPosition.X+ player.Origin1.X -2;
                int projectileY = SCREEN_HEIGHT - 78 ;

                playerProjectile.Position = new Point(projectileX, projectileY);
                fire1.Play();

            }
        }

        private void checkEnemyFire()
        {
            if (enemyProjectile1.Position.Y > SCREEN_HEIGHT)
            {
                int i = rnd.Next(1, 6);
                switch(i){
                    case 1:
                        enemyProjectile1.Position = new Point(enemy1.Position.X + enemy1.Origin1.X, enemy1.Position.Y + enemy1.Origin1.Y);
                        if(enemy1.IsAlive) fire.Play();
                        break;
                    case 2: 
                        enemyProjectile1.Position = new Point(enemy4.Position.X + enemy4.Origin1.X, enemy4.Position.Y + enemy4.Origin1.Y);
                        if (enemy4.IsAlive) fire.Play();
                        break;
                    case 3:
                        enemyProjectile1.Position = new Point(enemy5.Position.X + enemy5.Origin1.X, enemy5.Position.Y + enemy5.Origin1.Y);
                        if (enemy5.IsAlive) fire.Play();
                        break;
                    case 4:
                        enemyProjectile1.Position = new Point(enemy6.Position.X + enemy6.Origin1.X, enemy6.Position.Y + enemy6.Origin1.Y);
                        if (enemy6.IsAlive) fire.Play();
                        break;
                    case 5:
                        enemyProjectile1.Position = new Point(enemy7.Position.X + enemy7.Origin1.X, enemy7.Position.Y + enemy7.Origin1.Y);
                        if (enemy7.IsAlive) fire.Play();
                        break;
                    default:
                        break;

                }
            }

            if (enemyProjectile2.Position.Y > SCREEN_HEIGHT)
            {
                int i = rnd.Next(1, 6);
                switch (i)
                {
                    case 1:
                        enemyProjectile2.Position = new Point(enemy2.Position.X + enemy2.Origin1.X, enemy2.Position.Y + enemy2.Origin1.Y);
                        if (enemy2.IsAlive) fire.Play();
                        break;
                    case 2:
                        enemyProjectile2.Position = new Point(enemy8.Position.X + enemy8.Origin1.X, enemy8.Position.Y + enemy8.Origin1.Y);
                        if (enemy8.IsAlive) fire.Play();
                        break;
                    case 3:
                        enemyProjectile2.Position = new Point(enemy9.Position.X + enemy9.Origin1.X, enemy9.Position.Y + enemy9.Origin1.Y);
                        if (enemy9.IsAlive) fire.Play();
                        break;
                    case 4:
                        enemyProjectile2.Position = new Point(enemy10.Position.X + enemy10.Origin1.X, enemy10.Position.Y + enemy10.Origin1.Y);
                        if (enemy10.IsAlive) fire.Play();
                        break;
                    case 5:
                        enemyProjectile2.Position = new Point(enemy11.Position.X + enemy11.Origin1.X, enemy11.Position.Y + enemy11.Origin1.Y);
                        if (enemy11.IsAlive) fire.Play();
                        break;
                    default:
                        break;
                }
            }

            if (enemyProjectile3.Position.Y > SCREEN_HEIGHT)
            {
                int i = rnd.Next(1, 6);
                switch (i)
                {
                    case 1:
                        enemyProjectile3.Position = new Point(enemy3.Position.X + enemy3.Origin1.X, enemy3.Position.Y + enemy3.Origin1.Y);
                        if (enemy3.IsAlive) fire.Play();
                        break;
                    case 2:
                        enemyProjectile3.Position = new Point(enemy12.Position.X + enemy12.Origin1.X, enemy12.Position.Y + enemy12.Origin1.Y);
                        if (enemy12.IsAlive) fire.Play();
                        break;
                    case 3:
                        enemyProjectile3.Position = new Point(enemy13.Position.X + enemy13.Origin1.X, enemy13.Position.Y + enemy13.Origin1.Y);
                        if (enemy13.IsAlive) fire.Play();
                        break;
                    case 4:
                        enemyProjectile3.Position = new Point(enemy14.Position.X + enemy14.Origin1.X, enemy14.Position.Y + enemy14.Origin1.Y);
                        if (enemy14.IsAlive) fire.Play();
                        break;
                    case 5:
                        enemyProjectile3.Position = new Point(enemy15.Position.X + enemy15.Origin1.X, enemy15.Position.Y + enemy15.Origin1.Y);
                        if (enemy15.IsAlive) fire.Play();
                        break;
                    default:
                        break;
                }
            }
        }



        public void checkEnemyCollision()
        {
            #region checkingCollision
            if (enemy1.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy1.Position = new Point(-500,100);
                enemy1.IsAlive = false;
                enemyLeft--;
                score += 30;
                explode.Play();
            }
            else if (enemy2.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy2.Position = new Point(-500, 100);
                enemy2.IsAlive = false;
                enemyLeft--;
                score += 20;
                explode.Play();
            }
            else if (enemy3.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy3.Position = new Point(-500, 100);
                enemy3.IsAlive = false;
                enemyLeft--;
                score += 10;
                explode.Play();
                
            }
            else if (enemy4.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy4.Position = new Point(-500, 100);
                enemy4.IsAlive = false;
                enemyLeft--;
                score += 30;
                explode.Play();
            }
            else if (enemy5.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy5.Position = new Point(-500, 100);
                enemy5.IsAlive = false;
                enemyLeft--;
                score += 30;
                explode.Play();
            }
            else if (enemy6.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy6.Position = new Point(-500, 100);
                enemy6.IsAlive = false;
                enemyLeft--;
                score += 30;
                explode.Play();
            }
            else if (enemy7.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy7.Position = new Point(-500, 100);
                enemy7.IsAlive = false;
                enemyLeft--;
                score += 30;
                explode.Play();
            }
            else if (enemy8.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy8.Position = new Point(-500, 100);
                enemy8.IsAlive = false;
                enemyLeft--;
                score += 20;
                explode.Play();
            }
            else if (enemy9.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy9.Position = new Point(-500, 100);
                enemy9.IsAlive = false;
                enemyLeft--;
                score += 20;
                explode.Play();
            }
            else if (enemy10.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy10.Position = new Point(-500, 100);
                enemy10.IsAlive = false;
                enemyLeft--;
                score += 20;
                explode.Play();
            }
            else if (enemy11.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy11.Position = new Point(-500, 100);
                enemy11.IsAlive = false;
                enemyLeft--;
                score += 20;
                explode.Play();
            }
            else if (enemy12.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy12.Position = new Point(-500, 100);
                enemy12.IsAlive = false;
                enemyLeft--;
                score += 10;
                explode.Play();
            }
            else if (enemy13.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy13.Position = new Point(-500, 100);
                enemy13.IsAlive = false;
                enemyLeft--;
                score += 10;
                explode.Play();
                
            }
            else if (enemy14.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy14.Position = new Point(-500, 100);
                enemy14.IsAlive = false;
                enemyLeft--;
                score += 10;
                explode.Play();
            }
            else if (enemy15.checkCollision(playerProjectile.Rec))
            {
                playerProjectile.reset(-100, -100);
                enemy15.Position = new Point(-500, 100);
                enemy15.IsAlive = false;
                enemyLeft--;
                score += 10;
                explode.Play();
            }
            #endregion
        }

        private void checkPlayerCollision()
        {
            if (enemyProjectile1.Rec.IntersectsWith(player.Rec))
            {
                enemyProjectile1.reset(SCREEN_WIDTH + 1, SCREEN_HEIGHT + 1);
                player.Lives -= 1;
                explode.Play();
               
                
            }

            else if (enemyProjectile2.Rec.IntersectsWith(player.Rec))
            {
                enemyProjectile2.reset(SCREEN_WIDTH + 1, SCREEN_HEIGHT + 1);
                player.Lives -= 1;
                explode.Play();
                
                
            }

            else if (enemyProjectile3.Rec.IntersectsWith(player.Rec))
            {
                enemyProjectile3.reset(SCREEN_WIDTH+1, SCREEN_HEIGHT+1);
                player.Lives -= 1;
                explode.Play();

                
            }
        }


        private void checkEndGame()
        {
            if (enemyLeft == 0) labelYouWon.Show();
            if (player.Lives == 0)
            {
                labelYouWon.Text = "YOU LOSE TRY AGAIN";
                labelYouWon.Show();
                timer1.Stop();
            }
        }


        private void checkScore()
        {
            labelScore.Text = "Score:" + score;
        }

        private void checkLives()
        {
            labelLives.Text = "Lives:"+player.Lives;
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
            pictureBoxEnemy11_1.Hide();
            pictureBoxEnemy11_2.Hide();
            pictureBoxEnemy12_1.Hide();
            pictureBoxEnemy12_2.Hide();
            pictureBoxEnemy13_1.Hide();
            pictureBoxEnemy13_2.Hide();
            pictureBoxEnemy14_1.Hide();
            pictureBoxEnemy14_2.Hide();
            pictureBoxEnemy15_1.Hide();
            pictureBoxEnemy15_2.Hide();
            pictureBoxEnemyProjectile1.Hide();
            pictureBoxEnemyProjectile2.Hide();
            pictureBoxEnemyProjectile3.Hide();
            pictureBoxPlayer.Hide();
            pictureBoxPlayerProjecite.Hide();

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
            pictureBoxEnemy11_1.Show();
            pictureBoxEnemy12_1.Show();
            pictureBoxEnemy13_1.Show();
            pictureBoxEnemy14_1.Show();
            pictureBoxEnemy15_1.Show();
            pictureBoxEnemyProjectile1.Show();
            pictureBoxEnemyProjectile2.Show();
            pictureBoxEnemyProjectile3.Show();
            pictureBoxPlayer.Show();
            pictureBoxPlayerProjecite.Show();    
        }



        private void singlePlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                player.UpdatePlayer(6); 
            }
            else if (e.KeyCode == Keys.Left)
            {
                player.UpdatePlayer(-6);
            }

            if (e.KeyCode == Keys.Space) CheckFire();

            if (e.KeyCode == Keys.Escape) Application.Restart();

            if (e.KeyCode == Keys.Q) Application.Exit();
            if (e.KeyCode == Keys.Enter)
            {
                if (!enterPressed)
                {
                    labelControles.Hide();
                    timer1.Start();
                    timerEnemyAnimate.Start();
                    showGameItem();
                    enterPressed = true;
                }
            }

        }

      


        private void pictureBoxEnemy14_1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxCheckRight_Click(object sender, EventArgs e)
        {

        }

        
         
        
    }
}
