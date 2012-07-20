using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Space_Invaders
{
    class Projectile
    {
        
        private Point position;
        private PictureBox texture;
        private Rectangle rec;
        private Size size;
      


      

        public Projectile(int positionX, int positionY)
        {
            position.X = positionX;
            position.Y = positionY;
            size = new Size(4,12);
            rec.X = positionX;
            rec.Y = positionY;
            rec.Size = size;
        }

        public Projectile() { }


       


        #region properties
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public PictureBox Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Rectangle Rec
        {
            get { return rec; }
            set { rec = value; }
        }

        
        #endregion

        public  void UpdateProjectile(int velocity)
        {
            position.Y += velocity;
            rec.Y = position.Y;
            rec.X = position.X;
         
        }


        public void DrawProjectile()
        {
            this.Texture.Location = new Point(this.Position.X , this.Position.Y );
        }


        public Point Origin
        {
            get { return new Point(texture.Width / 2, texture.Height / 2); }

        }

        public void reset(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public bool checkCollision(Rectangle playerRec)
        {
            if (rec.IntersectsWith(playerRec))
            {
                return true;
            }
            return false;
        }






    }
}
