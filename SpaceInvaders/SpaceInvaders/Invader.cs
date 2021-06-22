using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Invader
    {

        // const 
        private const int Left = -3;
        private const int Right = 3;

        private int width, height;
        private int x, y;
        private int direction = Right;
        private int picNum = 2;
        private PictureBox invader;


        public Invader(int w, int h)
        {
            width = w;
            height = h;
        }

        public void addInvader(Form p, int x, int y, int row)
        {
            // create new invader and give it the right picture via row
            this.x = x;
            this.y = y;
            invader = new PictureBox();
            invader.Location = new Point(x, y);
            invader.Size = new Size(width, height);
            if (row == 0)
                invader.BackgroundImage = Properties.Resources.a1;
            else if (row == 1 || row == 2)
                invader.BackgroundImage = Properties.Resources.a2;
            else
                invader.BackgroundImage = Properties.Resources.a3;

            invader.BackgroundImageLayout = ImageLayout.Stretch;
            invader.Name = "Invader" + row;
            p.Controls.Add(invader);
        }

        public PictureBox getpbInvader()
        {
            return invader;
        }

        public void changeDirection()
        {
            if (direction == Left)
                direction = Right;
            else
                direction = Left;

            y += height;
        }

        public void move()
        {
            x += direction;
            invader.Location = new Point(x, y);

            // change picture 
            if (picNum == 1)
            {
                if (invader.Name == "Invader0")
                    invader.BackgroundImage = Properties.Resources.a1;
                else if (invader.Name == "Invader1" || invader.Name == "Invader2")
                    invader.BackgroundImage = Properties.Resources.a2;
                else
                    invader.BackgroundImage = Properties.Resources.a3;

                picNum++;
            }
            else if (picNum == 2)
            {
                if (invader.Name == "Invader0")
                    invader.BackgroundImage = Properties.Resources.a11;
                else if (invader.Name == "Invader1" || invader.Name == "Invader2")
                    invader.BackgroundImage = Properties.Resources.a22;
                else
                    invader.BackgroundImage = Properties.Resources.a33;
                picNum = 1;
            }

        }

        public int getPoints()
        {
            if (invader.Name == "Invader0")
                return 40;
            else if (invader.Name == "Invader1" || invader.Name == "Invader2")
                return 20;
            else
                return 10;
        }

    }
}
