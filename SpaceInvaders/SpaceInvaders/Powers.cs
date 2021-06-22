using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Powers
    {
        private const int NO_POWER = -1;
        private const int MORE_BULLETS = 0;
        private const int SIZE_UP = 1;
        private const int SIZE_DOWN = 2;
        private const int NO_BULLETS = 3;

        private int currPower;
        private int width;
        private int size;
        private PictureBox p;

        public Powers(int w, int s)
        {
            width = w;
            size = s;
           
        }

        public void newPower()
        {
            // choose random power
            currPower = (new Random()).Next(NO_BULLETS + 1);
            p = new PictureBox();
            p.Size = new Size(size, size);

            // choose random place at the board (X) to put the power
            p.Location = new Point((new Random()).Next(width), 0);
            p.BackgroundImage = Properties.Resources.sizeDown;
            p.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void setToNoPower()
        {
            currPower = NO_POWER;
        }

        public PictureBox getPower()
        {
            return p;
        }

        public void movePower()
        {
            p.Top = p.Top + 5;
        }

        public bool isSizeUp()
        {
            return currPower == SIZE_UP;
        }

        public bool isSizeDown()
        {
            return currPower == SIZE_DOWN;
        }

        public bool isMoreBullets()
        {
            return currPower == MORE_BULLETS;
        }

        public bool isNoBullets()
        {
            return currPower == NO_BULLETS;
        }
    }
}
