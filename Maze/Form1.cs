using System.Drawing;
using System.Windows.Forms;

namespace Maze
{
    public partial class Form1 : Form
    {
        const int sizeX = 30;
        const int sizeY = 30;
        Labirint l;
        public Form1()
        {
            InitializeComponent();
            Options();
            StartGame();
        }
        public void Options()
        {
            Text = "Здоровье - 100, медалей - 0";
            BackColor = Color.FromArgb(255, 92, 118, 137);
            this.ClientSize = new Size(sizeX * 16, sizeY * 16);
            StartPosition = FormStartPosition.CenterScreen;
        }
        public void StartGame()
        {
            l = new Labirint(this, sizeX, sizeY);
            l.Show();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) 
            { 
                if (l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.HALL)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.HEALTH)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.health += 5;
                    if (l.health > 100) l.health = 100;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.MEDAL)
                {
                    l.medals++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY)
                {
                    l.health -= 20;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                Winning();
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.HALL)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                }
                if (l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.HEALTH)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.health += 5;
                    if (l.health > 100) l.health = 100;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.MEDAL)
                {
                    l.medals++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileX--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY)
                {
                    l.health -= 20;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                Winning();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.HALL)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                }
                if (l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.HEALTH)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.health += 5;
                    if (l.health > 100) l.health = 100;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.MEDAL)
                {
                    l.medals++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY--;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY - 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.ENEMY)
                {
                    l.health -= 20;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                Winning();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.HALL)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                }
                if (l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.HEALTH)
                {
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.health += 5;
                    if (l.health > 100) l.health = 100;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.MEDAL)
                {
                    l.medals++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[0];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    l.smileY++;
                    l.maze[l.smileY, l.smileX].texture = MazeObject.images[4];
                    l.images[l.smileY, l.smileX].BackgroundImage = l.maze[l.smileY, l.smileX].texture;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                if (l.maze[l.smileY + 1, l.smileX].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY, l.smileX - 1].type == MazeObject.MazeObjectType.ENEMY || l.maze[l.smileY, l.smileX + 1].type == MazeObject.MazeObjectType.ENEMY)
                {
                    l.health -= 20;
                    this.Text = "Здоровье - " + l.health + ", медалей - " + l.medals;
                }
                Winning();
            }
        }
        public void Winning()
        {
            if (l.smileY == 27 && l.smileX == 28)
            {
                DialogResult result = MessageBox.Show("Вы победили - найден выход.", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Dispose();
                }
            }
            //if (кол-во медалей) не догнал, как подсчитать
            //{
            //    DialogResult result = MessageBox.Show("Вы победили, собрав все медали.", "", MessageBoxButtons.OK);
            //    if (result == DialogResult.OK)
            //    {
            //        Dispose();
            //    }
            //}
            else if (l.health <= 0)
            {
                l.health = 0;
                this.Text = "Здоровье: " + l.health + ", медалей: " + l.medals;
                DialogResult result = MessageBox.Show("Вы проиграли - закончилось здоровье.", "", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Dispose();
                }
            }
        }
    }
}