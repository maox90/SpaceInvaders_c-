using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    class Enemy
    {
 
        public Point position;
        private PictureBox texture1;
        private PictureBox texture2;
        private Boolean tik = true;
        private Rectangle rec;
        private Size size;
        private bool isAlive = true;


        


      

        public Enemy(int positionX, int positionY, int sizeX, int sizeY)
        {
            position.X = positionX;
            position.Y = positionY;
            size = new Size(sizeX, sizeY);
            rec.X = positionX;
            rec.Y = positionY;
            rec.Size = size;
        }

        public Enemy() { }


       


        #region properties
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public PictureBox Texture1
        {
            get { return texture1; }
            set { texture1 = value; }
        }

        public PictureBox Texture2
        {
            get { return texture2; }
            set { texture2 = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        #endregion

        public  void UpdateEnemy(int velocity)
        {
            position.X += velocity;
            rec.X = position.X;
        }



        public void DrawEnemy()
        {
            this.Texture1.Location = new Point(this.Position.X , this.Position.Y );
            this.Texture2.Location = new Point(this.Position.X , this.Position.Y );
        }

        public void Animate()
        {
            if (tik)
            {
                texture1.Hide();
                texture2.Show();
                tik = false;
            }
            else
            {
                texture1.Show();
                texture2.Hide();
                tik = true;
            }

        }

        public bool checkCollision(Rectangle playerProjectile)
        {
            if (rec.IntersectsWith(playerProjectile))
            {
                return true;
            }
            return false;
        }

        public Point Origin1
        {
            get { return new Point(texture1.Width / 2, texture1.Height / 2); }

        }
    }
}
    

