using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Bullet
    {

        private PictureBox bullet;

        // Which way is it shooting
        private const int Up = -1;
        private const int Down = 1;

        // size of bullet
        private const int Width = 5;
        private const int Height = 7;

        // Going nowhere
        private int heading = 0;



        public Bullet(PictureBox pb)
        {

            bullet = new PictureBox();
            bullet.BackgroundImage = Properties.Resources.bullet;
            bullet.BackgroundImageLayout = ImageLayout.Stretch;
            bullet.Size = new Size(Width, Height);
            
            // if the pb name is player the bullet need to go up to the invaders
            if (pb.Name != "player")
                heading = Down;
            // if it's invader, then it's need to go down to the player
            else
                heading = Up;
            bullet.Left = pb.Left + pb.Width / 2;
            bullet.Top = pb.Top + 10 * heading;
        }

        public PictureBox getpbBullet()
        {
            return bullet;
        }

        public bool moveBullet()
        {
            // more bullet up or down
            bullet.Location = new Point(bullet.Location.X, bullet.Location.Y + heading * 8);
            if (bullet.Top < 10 && heading == Up)
                return true;
            else if (bullet.Top > 500 && heading == Down)
                return true;
            return false;
        }
    }
}
