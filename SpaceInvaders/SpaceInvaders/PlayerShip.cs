using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class PlayerShip
    {

        // This will hold the pixels per second speed that the ship will move
        private int shipSpeed = 6;

        // Which ways can the ship move
        private const int STOPPED = 0;
        private const int LEFT = -1;
        private const int RIGHT = 1;

        // Is the ship moving and in which direction
        private int shipMoving = STOPPED;
        private bool power = false;

        public void moveLeft()
        {
            shipMoving = LEFT;
        }

        public void moveRight()
        {
            shipMoving = RIGHT;
        }

        public void stopShip()
        {
            shipMoving = STOPPED;
        }

        public int moveShip()
        {
            return shipMoving * shipSpeed;
        } 

        
        public bool getPower()
        {
            return power;
        }

        public void setPower(bool p)
        {
            power = p;
        }
         
    }
}
