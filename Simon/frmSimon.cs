
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media; // includes packages for audio
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon
{
    public partial class frmSimon : Form
    {
        private int tilesPlayedBack = 0;

        private int tilesGen = 0; // track how many tiles have been generated
        private int tryCount = 0; // track how many tiles user has selected in current round
        private int score = 0; // the user's total score
        private int points = 0; // the points earned after each completed sequence

        List<int> colorCombo = new List<int>(); // track the tile sequence as integers 0 - 3

        SoundPlayer simpleSound = new SoundPlayer(); // instantiate sound player
        string myDir = Directory.GetCurrentDirectory(); // get path of program


        public frmSimon()
        {
            InitializeComponent();

            // implement event handlers for buttons
            // hover events
            btnGreen.MouseHover += new EventHandler(btnGreen_MouseHover);
            btnRed.MouseHover += new EventHandler(btnRed_MouseHover);
            btnYellow.MouseHover += new EventHandler(btnYellow_MouseHover);
            btnBlue.MouseHover += new EventHandler(btnBlue_MouseHover);

            // MouseLeave events
            btnGreen.MouseLeave += new EventHandler(btnGreen_MouseLeave);
            btnRed.MouseLeave += new EventHandler(btnRed_MouseLeave);
            btnBlue.MouseLeave += new EventHandler(btnBlue_MouseLeave);
            btnYellow.MouseLeave += new EventHandler(btnYellow_MouseLeave);
        }

        private void frmSimon_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            startGame(); // Start game
        }

        // begin new game
        private void startGame()
        {
            int rndNum = 0;
            Random rnd = new Random();

            // loop 3 times to generate initial sequence
            for (int i = 0; i < 3; i++)
            {
                // generates a number between 0 and 3 (inclusive)
                rndNum = rnd.Next(0, 4);
                Debug.Print(rndNum.ToString());

                // ** STORE TILES IN ARRAY LIST **

                // add number to the array list
                // This value determines what tile is played back
                colorCombo.Add(rndNum);

                tilesGen++; // track number of tiles generated
            }

            tmrSimon.Enabled = true; // start the timer

        } // end startGame

        // generate the next tile in the sequence and store it
        private void nextTile()
        {
            int rndNum = 0;
            Random rnd = new Random();

            // generates a number between 0 and 3 (inclusive)
            rndNum = rnd.Next(0, 4);

            // add number to the array list
            colorCombo.Add(rndNum);

            Debug.Print("colorCombo list count = " + colorCombo.Count);

            tilesGen++; // increment tilesGen
            Debug.Print("\ntilesGen = " + tilesGen + "Total items: " + colorCombo.Count + "\n\nEnd of function\n");
        }

        // function for when a tile is clicked
        private void tileSelected(string theTile)
        {
            switch (theTile)
            {
                case "btnGreen": // green tile selected
                    
                    // set path of sound and play back
                    simpleSound.SoundLocation = "Sounds/Simon Low.wav";
                    simpleSound.Play();

                    checkTile("btnGreen"); // check if this is the correct tile
                    break;

                case "btnRed": // red tile selected

                    // set path of sound and play back
                    simpleSound.SoundLocation = "Sounds/Simon Low Middle.wav";
                    simpleSound.Play();

                    checkTile("btnRed"); // check if this is the correct tile
                    break;

                case "btnYellow": // yellow tile selected

                    // set path of sound and play back
                    simpleSound.SoundLocation = "Sounds/Simon High Middle.wav";
                    simpleSound.Play();

                    checkTile("btnYellow"); // check if this is the correct tile
                    break;

                case "btnBlue": // blue tile selected

                    // set path of sound and play back
                    simpleSound.SoundLocation = "Sounds/Simon High.wav";
                    simpleSound.Play();

                    checkTile("btnBlue"); // check if this is the correct tile
                    break;
            }

            // user has selected all tiles in the sequence
            if (tryCount == tilesGen)
            {
                tryCount = 0; // reset tries
                tmrSimon.Enabled = true; // re-enable the timer
                score = tallyScore();
                lblScore.Text = "Score: " + score;

                nextTile(); // generate another tile
            }
        } // end function tileSelected

        /*
         * 
         * Tally score and points:
         * 
         * private int score - the user's total score
         * private int points - the points earned after each completed sequence
         * 
         */
        // need to code this next, then I'm done!
        private int tallyScore()
        {
            // increment score
            // add 100 points per round to total points given
            points = points + 100;
            score = score + points;

            return score;
        }

        // function to play tiles after correct sequence
        private void playTiles(object sender, EventArgs e)
        {
            // look at array list to determine which buttons to light up
            switch (colorCombo[tilesPlayedBack].ToString())
            {
                case "0":
                    simpleSound.SoundLocation = "Sounds/Simon Low.wav";
                    simpleSound.Play();
                    btnGreen_MouseHover(sender, e); // call btnGreen hover function
                    break;

                case "1":
                    simpleSound.SoundLocation = "Sounds/Simon Low Middle.wav";
                    simpleSound.Play();
                    btnRed_MouseHover(sender, e); // call btnRed hover function
                    break;

                case "2":
                    simpleSound.SoundLocation = "Sounds/Simon High Middle.wav";
                    simpleSound.Play();
                    btnYellow_MouseHover(sender, e); // call btnYellow hover function
                    break;

                case "3":
                    simpleSound.SoundLocation = "Sounds/Simon High.wav";
                    simpleSound.Play();
                    btnBlue_MouseHover(sender, e); // call btnBlue hover function
                    break;
            }

            tilesPlayedBack++; // iterate tilesPlayedBack
        }

        // function to determine if user's tile selection matches the generated sequence
        private void checkTile(string button)
        {
            /*
             * Tiles are associated with an integer. The switch will look at which button is clicked as a string and then check if the
             * value in the array list corresponding with the number of tries is the same as this integer. The selection is correct if so
             * 
             * startGame associates the tiles initially
             * 
             * Green tile: 0
             * Red tile: 1
             * Yellow tile: 2
             * Blue tile: 3
             */

            // ArrayList of integers: colorCombo

            switch (button)
            {
                case "btnGreen": // green tile selected

                    if ( colorCombo[tryCount] == 0 )
                    {
                        // do nothing; selection is correct
                    }
                    else // incorrect selection
                    {
                        gameOver();
                    }

                    break; // end case btnGreen

                case "btnRed": // red tile selected

                    if (colorCombo[tryCount] == 1)
                    {
                        // do nothing; selection is correct
                    }
                    else // incorrect selection
                    {
                        gameOver();
                    }

                    break; // end case btnRed

                case "btnYellow": // yellow tile selected

                    if (colorCombo[tryCount] == 2)
                    {
                        // do nothing; selection is correct
                    }
                    else // incorrect selection
                    {
                        gameOver();
                    }

                    break; // end case btnYellow

                case "btnBlue": // blue tile selected

                    if (colorCombo[tryCount] == 3)
                    {
                        // do nothing; selection is correct
                    }
                    else // incorrect selection
                    {
                        gameOver();
                    }

                    break; // end case btnBlue
            }

            tryCount++;
        }

        // implement a timer to play back tiles
        private void tmrSimon_Tick(object sender, EventArgs e)
        {
            // timer will control the interval in which tiles are played back
            // could have a basic counter: 
            /*
             * played = 0; --will track how many tiles have been played back
             *             --cannot set to zero in timer, but it needs to be set to zero elsewhere
             * 
             * plug value of played into array list
             * set color of tile 
             * 
             */

            // tilesPlayedBack will iterate by one in this timer
            // all tiles have been played back
            if ( tilesPlayedBack == tilesGen )
            {
                tilesPlayedBack = 0; // reset count of tiles played

                Debug.Print("Line 248: tilesGen = " + tilesGen);

                // disable timer to stop playback and enable buttons to allow input
                btnGreen.Enabled = true;
                btnRed.Enabled = true;
                btnYellow.Enabled = true;
                btnBlue.Enabled = true;

                tmrSimon.Enabled = false;

                return; // exit function
            }
            else
            {
                // disable timer to stop playback and enable buttons to allow input
                btnGreen.Enabled = false;
                btnRed.Enabled = false;
                btnYellow.Enabled = false;
                btnBlue.Enabled = false;
            }

            // play tiles back
            playTiles(sender, e);

        } // end tmrSimon

        // hover event for btnGreen
        private void btnGreen_MouseHover(object sender, EventArgs e)
        {
            btnGreen.BackColor = Color.FromArgb(0, 255, 0);

            // reset colors for other buttons
            btnYellow_MouseLeave(sender, e);
            btnBlue_MouseLeave(sender, e);
            btnRed_MouseLeave(sender, e);
        }

        private void btnGreen_MouseLeave(object sender, EventArgs e)
        {
            btnGreen.BackColor = Color.FromArgb(0, 120, 0);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            tileSelected("btnGreen"); // call function
        }

        // hover event for btnRed
        private void btnRed_MouseHover(object sender, EventArgs e)
        {
            btnRed.BackColor = Color.FromArgb(255, 0, 0);

            // reset colors for other buttons
            btnGreen_MouseLeave(sender, e);
            btnYellow_MouseLeave(sender, e);
            btnBlue_MouseLeave(sender, e);
        }

        private void btnRed_MouseLeave(object sender, EventArgs e)
        {
            btnRed.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            tileSelected("btnRed"); // call function
        }

        // hover event for btnYellow
        private void btnYellow_MouseHover(object sender, EventArgs e)
        {
            btnYellow.BackColor = Color.FromArgb(255, 255, 0);

            // reset colors for other buttons
            btnGreen_MouseLeave(sender, e);
            btnRed_MouseLeave(sender, e);
            btnBlue_MouseLeave(sender, e);
        }

        private void btnYellow_MouseLeave(object sender, EventArgs e)
        {
            btnYellow.BackColor = Color.FromArgb(255, 215, 0);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            tileSelected("btnYellow"); // call function
        }

        // hover event for btnBlue
        private void btnBlue_MouseHover(object sender, EventArgs e)
        {
            btnBlue.BackColor = Color.FromArgb(0, 191, 255);

            // reset colors for other buttons
            btnGreen_MouseLeave(sender, e);
            btnYellow_MouseLeave(sender, e);
            btnRed_MouseLeave(sender, e);
        }

        private void btnBlue_MouseLeave(object sender, EventArgs e)
        {
            btnBlue.BackColor = Color.FromArgb(0, 0, 255);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            tileSelected("btnBlue"); // call function
        }

        // function for game over
        private void gameOver()
        {
            // reset values
            tryCount = 0;
            tilesGen = 0;
            tilesPlayedBack = 0;

            // disable the buttons
            btnGreen.Enabled = false;
            btnRed.Enabled = false;
            btnYellow.Enabled = false;
            btnBlue.Enabled = false;

            // play sound on game over
            simpleSound.SoundLocation = "Sounds/Buzzer.wav";
            simpleSound.Play();

            tmrEndGame.Enabled = true;
        }

        // timer to create delay for sound bite after incorrect selection
        private void tmrEndGame_Tick(object sender, EventArgs e)
        {
            // play sound on game over
            simpleSound.SoundLocation = "Sounds/Gameover.wav";
            simpleSound.Play();

            tmrEndGame.Enabled = false;
        }

        private void lblScore_Click(object sender, EventArgs e)
        {
            
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            frmScores scoreForm = new frmScores();
            scoreForm.ShowDialog();
        }
    }
}
