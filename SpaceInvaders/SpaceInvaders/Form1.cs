using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {

        int score = 0;
        int playerLife = 3;
        Powers power;

        PlayerShip playerShip;
        List<Bullet> bullets;
        List<Bullet> invadersBullets;
        List<Invader> invaders;
        List<DefenceBrick> defenceBlocks;
        
        
        

        // final 
        const int InvaderCol = 11;
        const bool Winner = true;
        const int InvaderRow = 5;
        const int InvaderWidth = 30, InvaderHeight = 20;
        const int limit = 600;
        const int BlocksNum = 4;
        const int BlocksCol = 6;
        const int BlocksRow = 3;
        const int PlayerSize = 20;
        

        public Form1()
        {
            InitializeComponent();

            // double buffer, help the image be more smooth 
            this.SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            setUpGame();
            
        }

        private void setUpGame()
        {
            playerShip = new PlayerShip();
            bullets = new List<Bullet>();
            invaders = new List<Invader>();
            invadersBullets = new List<Bullet>();
            defenceBlocks = new List<DefenceBrick>();
            power = new Powers(limit, player.Width / 2);

            // add invaders to the game 
            int space = 10, x = 1, currX = x , y = 0;
            for (int i = 0; i < InvaderRow; i++)
            {
                for (int j =0; j < InvaderCol; j++)
                {
                    Invader newIn = new Invader(InvaderWidth, InvaderHeight);
                    newIn.addInvader(this, currX, y, i);
                    invaders.Add(newIn);
                    currX += InvaderWidth + space;
                }

                y += InvaderHeight + space;
                currX = x;
            }

            // add defence blocks to the game 
            addDefenceBricks();

            handlePowerTimer.Stop();
        }


        private void inavdersTimer_Tick(object sender, EventArgs e)
        {
            // move the invaders 
            moveInvaders();
        }

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            // move the player left or right 
            player.Left += playerShip.moveShip();
        }

        // handle and move the bullets that the player shot
        private void bulletsTimer_Tick(object sender, EventArgs e)
        {
            // fire bullets (if there are any)
            fireBullets();
        }

        // go through the bullets that the invaders shot and check if it's hit the player 
        // the defence brick or going out of the screen 
        private void handleShotsTimer_Tick(object sender, EventArgs e)
        {
            List<Bullet> removeBullet = new List<Bullet>();
            foreach (Bullet b in invadersBullets)
            {

                // check if the bullet hit a defence brick
                if (checkDefence(b))
                {
                    this.Controls.Remove(b.getpbBullet());
                    removeBullet.Add(b);
                    break;
                }

                // check if bullet hit player 
                if (b.getpbBullet().Bounds.IntersectsWith(player.Bounds))
                {
                    
                    this.Controls.Remove(b.getpbBullet());
                    removeBullet.Add(b);
                    loseLife();
                }
                // move bullet and check if it's still on screen 
                else if (b.moveBullet())
                {
                    this.Controls.Remove(b.getpbBullet());
                    removeBullet.Add(b);
                }
            }

            // remove each bullet that reach the end or hit something
            foreach (Bullet b in removeBullet)
                invadersBullets.Remove(b);

        }


        private void invaderShotTimer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            // make a random invader shot 
            if (invaders.Count > 0)
            {
                addBullet(invaders[rand.Next(invaders.Count)].getpbInvader());
            }
        }



        private void powersTimer_Tick(object sender, EventArgs e)
        {

            // create new power
            power.newPower();
            this.Controls.Add(power.getPower());
            powersTimer.Stop();
            handlePowerTimer.Start();

        }



        private void handlePowerTimer_Tick(object sender, EventArgs e)
        {
            // if player already have power then stop it 
            if (playerShip.getPower())
            {
                handlePowerTimer.Stop();
                handlePowerTimer.Interval = 100;
                playerShip.setPower(false);
                power.setToNoPower();
                sizePower();

            }
            else
            {
                // check if player took the power 
                if (power.getPower().Bounds.IntersectsWith(player.Bounds))
                {
                    playerShip.setPower(true);
                    handlePowerTimer.Interval = 5000;
                    this.Controls.Remove(power.getPower());
                    sizePower();
                    powersTimer.Start();
                }
                // check if power is still on screen 
                else if (power.getPower().Location.Y < player.Location.Y)
                {
                    power.movePower();
                }
                // if power pass player, remove it from the screen and start the timer to a new power
                else if (power.getPower().Location.Y > player.Location.Y)
                {
                    this.Controls.Remove(power.getPower());
                    power.setToNoPower();
                    handlePowerTimer.Stop();
                    powersTimer.Start();
                }
            }

        }


        private void addDefenceBricks()
        {
            // add defence blocks
            int totalBlocksNum = BlocksNum * 2 + 1;
            for (int i = 1; i < totalBlocksNum; i += 2)
            {
                for (int j = 0; j < BlocksRow; j++)
                {
                    for (int k = 0; k < BlocksCol; k++)
                    {
                        DefenceBrick db = new DefenceBrick(k, j, i, this.Width / (totalBlocksNum * 10), player.Location.Y);
                        this.Controls.Add(db.Brick());
                        defenceBlocks.Add(db);

                    }
                }
            }
        }



        // change the size of the player according to the powers 
        private void sizePower()
        {
            if (power.isSizeUp())
                player.Size = new Size(PlayerSize * 2, PlayerSize * 2);
            else if (power.isSizeDown())
                player.Size = new Size(PlayerSize / 2, PlayerSize / 2);
            else
                player.Size = new Size(PlayerSize, PlayerSize);
        }

        

        // Go through the bullets that been shot and see if they hit invaders, 
        // if they do remove both from the screen, if not and they reach the end 
        // remove the bullet
        private void fireBullets()
        {
            // go through the bullet list and move each one of them in the right direction, 
            // if the reach the top of the screen, add them to a different list so we could remove them . 
            List<Bullet> bullToRemove = new List<Bullet>();
            
            foreach (Bullet b in bullets)
            {

                
                // check if it hit a defence brick
                if (checkDefence(b))
                {
                    this.Controls.Remove(b.getpbBullet());
                    bullToRemove.Add(b);
                    break;
                }

                Invader removeIn = null;
                foreach (Invader i in invaders)
                {
                    if (b.getpbBullet().Bounds.IntersectsWith(i.getpbInvader().Bounds))
                    {
                        // remove the bullet and invaders
                        this.Controls.Remove(b.getpbBullet());
                        bullToRemove.Add(b);
                        this.Controls.Remove(i.getpbInvader());
                        removeIn = i;

                        // add 5 points to the score, and update the score on the screen 
                        score += i.getPoints();
                        updateScore();
                        break;
                    }
                }
                // check if the bullet hit an invaders
                // if yes, check if it was the last invader
                if (removeIn != null)
                {
                    invaders.Remove(removeIn);
                    checkIfWon();
                }

                // move the bullet and check if it's exist the screen 
                else if (b.moveBullet())
                {
                    this.Controls.Remove(b.getpbBullet());
                    bullToRemove.Add(b);
                }
            }

            // remove each bullet that reach the end
            foreach (Bullet b in bullToRemove)
                bullets.Remove(b);
        }


        // update the score on the screen 
        private void updateScore()
        {
            scoreLabel.Text = "Score : " + score;
        }


        // check if all the invaders were hit 
        private void checkIfWon()
        {
            if (invaders.Count == 0)
                gameOver(Winner);
        }

        // turn the screen black and annouce if the player won/lost
        private void gameOver(bool outcome)
        {
            // stop all timers 
            invadersTimer.Stop();
            invaderShotTimer.Stop();
            handleShotsTimer.Stop();
            bulletsTimer.Stop();
            handlePowerTimer.Stop();
            playerTimer.Stop();
            powersTimer.Stop();

            // remove everything from screen and add a end game message 
            foreach (Control c in this.Controls)
            {
                if (c is Label && c.Name == "Finish")
                {
                    Label lbl = (Label)c;
                    if (outcome == Winner)
                        lbl.Text = "Game Over! You won and got: " + score + " points!" ;
                    else
                        lbl.Text = "Game Over! You lost :(";
                }
                else
                {
                    c.Visible = false;
                }
            }
            
        }

        // move the invaders, check if they reach an edge 
        private void moveInvaders()
        {
            // check if any invader reach the edge
            var isEdge = invaderReachEdge();

            foreach (Invader i in invaders)
            {
                if (i.getpbInvader().Bounds.IntersectsWith(player.Bounds))
                    gameOver(!Winner);
                else if (isEdge)
                    i.changeDirection();
                i.move();
            }
        }


        // go throught all the invaders and check if anyone reach the edge
        private bool invaderReachEdge()
        {
            foreach (Invader i in invaders)
            {
                if (i.getpbInvader().Location.X <= 0 || i.getpbInvader().Location.X >= limit)
                    return true;
            }
            return false;
        }

        // check if a bullet hit any defence brick
        private bool checkDefence(Bullet b)
        {
            int db = -1;
            

            for (int i =0; i < defenceBlocks.Count; i++)
            {
                if (defenceBlocks[i].Brick().Bounds.IntersectsWith(b.getpbBullet().Bounds))
                {
                    db = i;
                    break;
                }
            }

            if (db == -1)
                return false;

            this.Controls.Remove(defenceBlocks[db].Brick());
            defenceBlocks.Remove(defenceBlocks[db]);
            return true;
        }


        private void keyisdown(object sender, KeyEventArgs e)
        {
            // move the player if left/ right buttom is pressed 
            if (e.KeyCode == Keys.Left) 
                playerShip.moveLeft();
            if (e.KeyCode == Keys.Right && player.Right < limit)
                playerShip.moveRight();
            // add bullet to the player 
            if (e.KeyCode == Keys.Space && 
                (bullets.Count < 2 || (power.isMoreBullets() && bullets.Count < 4 && playerShip.getPower())) &&
                !(power.isNoBullets() && playerShip.getPower()))
            {
                addBullet(player);
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                playerShip.stopShip();
        }


        // create new bullet 
        private void addBullet(PictureBox pb)
        {
            // create new bullet 
            Bullet newBullet = new Bullet(pb);
            
            // add the bullet to the screen and bring it to the front of the screen so it will be seen 
             this.Controls.Add(newBullet.getpbBullet());
            newBullet.getpbBullet().BringToFront();

            // add the bullet to a player bullets list;
            if (pb == player)
                bullets.Add(newBullet);
            else
                invadersBullets.Add(newBullet);
        }

        private void loseLife()
        {

            score -= 10;

            string str = "Life" + playerLife;

            // show on the screen that the player has one less life 
            this.Controls.Remove(this.Controls.Find(str, true)[0]);
            playerLife--;

            updateScore();

            if (playerLife == 0)
                gameOver(!Winner);
        }
    }
}
