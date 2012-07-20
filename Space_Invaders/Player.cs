using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    class Player:Enemy
    {

        public Point position;
        private PictureBox texture1;
        private Rectangle rec;
        private Size size;
        private int lives = 3;



        public Player()
        {
        }

        public Player(int playerX, int playerY) 
        {
            position.X = playerX;
            position.Y = playerY;
            size = new Size(50,30);
            rec.X = playerX;
            rec.Y = playerY;
            rec.Size = size;
        }


        public Point PlayerPosition
        {
            get { return position; }
            set { position = value; }
        }

        public PictureBox Texture
        {
            get { return texture1; }
            set { texture1 = value; }
        }

        public Point Origin1
        {
            get { return new Point(texture1.Width / 2, texture1.Height / 2); }

        }

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public Rectangle Rec
        {
            get { return rec; }
            set { rec = value; }
        }

        
        public  void UpdatePlayer(int xMove)
        {
            position.X += xMove;
            rec.X = position.X;
            rec.Y = position.Y;
        }

        public void UpdatePlayer2(int playerX, int playery)
        {
            position.X = playerX;
            position.Y = position.Y;
        }

        public void DrawPlayer()
        {
            this.Texture.Location = new Point(this.PlayerPosition.X, this.PlayerPosition.Y );
            
        }

       

    }
}
