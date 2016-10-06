using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace samSnake
{
    public partial class Form1 : Form
    {
        private List<circle> Snake = new List<circle>();
        private circle food = new circle();
        settings settings = new settings();
        public Form1()
        {
            InitializeComponent();
            //set settings to default
            //setting speed and starter time
            GameTimer.Interval = 1000 / settings.Speed;
            //GameTimer.Tick += (UpdateScreen);
            GameTimer.Start();

            //start game
            StartGame();
        }



        private void StartGame()
        {
            labelGameOver.Visible = false;
            //new Settings();
            //clear game
            Snake.Clear();
            circle head = new circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);
            labelScore.Text = settings.Score.ToString();
            GenerateFood();

        }




        //place random food
        private void GenerateFood()
        {
            //determine height and width of game scheme
            int maxXposition = picframe.Size.Width / settings.Width;
            int maxYposition = picframe.Size.Height / settings.Height;
            Random random = new Random();
            //positions food inside the game scheme
            food = new circle();
            food.X = random.Next(0, maxXposition);
            food.Y = random.Next(0, maxYposition);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picframe_Click(object sender, EventArgs e)
        {

        }

        private void picframe_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (!settings.gameOver)
            {
                //set snake colour
                Brush snakeColour;
                //draw snake
                for (int i = 0; i < Snake.Count; i++)
                {

                    if (i == 0)
                    {
                        snakeColour = Brushes.Black; //draw head
                    }
                    else
                    {
                        snakeColour = Brushes.Green;//rest of the body
                    }
                    //draw snake
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * settings.Width,
                                     Snake[i].Y * settings.Height,
                                     settings.Width, settings.Height));
                    //draw food
                    canvas.FillEllipse(Brushes.Red,
                                       food.X * settings.Width,
                                       food.Y * settings.Height,
                                       settings.Width, settings.Height);
                }
            }
            else
            {
                string GameOver = "GAME OVER \n Your final score is : " + settings.Score + "\n press enter to try again ";
                labelGameOver.Text = GameOver;
                labelGameOver.Visible = true;
            }
        }
        //defining movement
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i > 0; i--)
            {
                //move head
                if (i == 0)
                {
                    switch (settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;

                    }
                    //GET MAX X and Y POSSIBLE
                    int maxXpossible = picframe.Size.Width / settings.Width;
                    int maxYpossible = picframe.Size.Height / settings.Height;
                    if (Snake[i].X > 0 || Snake[i].Y > 0
                        || Snake[i].X >= maxXpossible || Snake[i].Y >= maxYpossible)
                    {
                        die();
                    }
                    //detect collision with body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            die();
                        }
                    }
                    //detect collision with food piece
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        swallow();
                    }

                }

               // move body
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;


                }
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            INPUT.changeState(e.KeyCode, true);
            StartGame();
        }
                
            



        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            INPUT.changeState(e.KeyCode, false);
            StartGame();
        }
        private void die()
        {
            settings.gameOver = true;
        }
        private void swallow()
        {
            circle food = new circle();
            food.Y = Snake[Snake.Count - 1].Y;
            //add food to snake body
            Snake.Add(food);
            //update score
            settings.Score += settings.Points;
            labelScore.Text = settings.Score.ToString();
            GenerateFood();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            //checks FOR GAMEover
            if (settings.gameOver == true)
            {
                //
                //check if enter key is pressed
                if (INPUT.keyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (INPUT.keyPressed(Keys.Right) && settings.direction != Direction.Left)
                {
                    settings.direction = Direction.Right;
                }
                else if (INPUT.keyPressed(Keys.Left) && settings.direction != Direction.Right)
                {
                    settings.direction = Direction.Left;
                }
                else if (INPUT.keyPressed(Keys.Up) && settings.direction != Direction.Down)
                {
                    settings.direction = Direction.Up;
                }
                else if (INPUT.keyPressed(Keys.Down) && settings.direction != Direction.Up)
                {
                    settings.direction = Direction.Down;
                    MovePlayer();
                }

                picframe.Invalidate();
            }
        }

        private void labelGameOver_Click(object sender, EventArgs e)
        {

        }
        }

    }

