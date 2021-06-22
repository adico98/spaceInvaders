using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class DefenceBrick
    {
        private PictureBox brick;


        public DefenceBrick(int row, int col, int blockNum, int width, int playerHeight)
        {

            int blockSize = width * 10;
            brick = new PictureBox();
            brick.BackgroundImage = Properties.Resources.bullet;
            brick.Size = new Size(width + 5, 15);
            brick.Location = new Point((blockSize * blockNum) + (row * (width + 5)) + 2 * row,
                                            (playerHeight - 50) - (col * 15) - 2 * col);
        }

        public PictureBox Brick()
        {
            return brick;
        }
    }
}
