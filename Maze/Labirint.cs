using System;
using System.Windows.Forms;
using System.Drawing;

namespace Maze
{
    class Labirint
    {
        public int smileX { get; set; }
        public int smileY { get; set; }
        public int height; 
        public int width;
        public int health;
        public int medals;
        public MazeObject[,] maze;
        public PictureBox[,] images;
        public static Random r = new Random();
        public Form parent;
        public Labirint(Form parent, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.parent = parent;
            maze = new MazeObject[height, width];
            images = new PictureBox[height, width];
            smileX = 0;
            smileY = 2;
            health = 100;
            medals = 0;
            Generate();
        }
        private void Generate()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    MazeObject.MazeObjectType current = MazeObject.MazeObjectType.HALL;
                    if (r.Next(5) == 0)
                    {
                        current = MazeObject.MazeObjectType.WALL;
                    }
                    if (r.Next(250) == 0)
                    {
                        current = MazeObject.MazeObjectType.MEDAL;
                    }
                    if (r.Next(250) == 0)
                    {
                        current = MazeObject.MazeObjectType.ENEMY;
                    }
                    if (r.Next(150) == 0)
                    {
                        current = MazeObject.MazeObjectType.HEALTH;
                    }
                    if (y == 0 || x == 0 || y == height - 1 | x == width - 1)
                    {
                        current = MazeObject.MazeObjectType.WALL;
                    }
                    if (x == smileX && y == smileY)
                    {
                        current = MazeObject.MazeObjectType.CHAR;
                    }
                    if (x == smileX + 1 && y == smileY || x == width - 1 && y == height - 3)
                    {
                        current = MazeObject.MazeObjectType.HALL;
                    }
                    maze[y, x] = new MazeObject(current);
                    images[y, x] = new PictureBox();
                    images[y, x].Location = new Point(x * maze[y, x].width, y * maze[y, x].height);
                    images[y, x].Parent = parent;
                    images[y, x].Width = maze[y, x].width;
                    images[y, x].Height = maze[y, x].height;
                    images[y, x].BackgroundImage = maze[y, x].texture;
                    images[y, x].Visible = false;
                }
            }
        }
        public void Show()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    images[y, x].Visible = true;
                }
            }
        }
    }
}