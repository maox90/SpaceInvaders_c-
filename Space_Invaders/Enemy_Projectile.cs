using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    class Enemy_Projectile
    {
        private Point position;
        private PictureBox texture;





        public Enemy_Projectile(int positionX, int positionY)
        {
            position.X = positionX;
            position.Y = positionY;
        }

        public Enemy_Projectile() { }





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


        #endregion

        public void UpdateProjectile(int velocity)
        {
            position.Y += velocity;
        }


        public void DrawProjectile()
        {
            this.Texture.Location = new Point(this.Position.X, this.Position.Y);
        }


        public Point Origin
        {
            get { return new Point(texture.Width / 2, texture.Height / 2); }


        }


    }
}
