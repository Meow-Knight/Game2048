using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048
{
    public partial class Home : Form
    {
        private Graphics graphics;
        private List<Cell2048> cells;
        private int size;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e) {
            Controller.home = this;
            Controller.startGame();
        }

        public void setBestScore(int bestScore) {
            this.bestScore.Text = bestScore.ToString();
        }

        private void itemSettings_Click(object sender, EventArgs e) {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            int capacity = Controller.Level * Controller.Level;
            this.size = e.ClipRectangle.Width / Controller.Level;

            this.graphics = e.Graphics;
            this.cells = new List<Cell2048>(capacity);

            this.render();
        }

        private void addRectangle(int index, int value) {
            if (value == 0)
                return;

            int xCoordinate = index % Controller.Level * this.size;
            int yCoordinate = index / Controller.Level * this.size;

            Cell2048 cell = new Cell2048(xCoordinate, yCoordinate, this.size, value);
            
            this.cells.Add(cell);
        }

        private void render() {
            this.lbScore.Text = Controller.score.ToString();

            for (int i = 0; i < Controller.CellPosition.Length; ++i) { 
                addRectangle(i, Controller.CellPosition[i]);
            }

            foreach (Cell2048 cell in this.cells) {
                cell.draw(this.graphics);
            }

            this.clean();
        }

        private void clean() {
            this.graphics.Dispose();
        }

        private void Home_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyValue) {
                case 37: // Left
                    Controller.moveToLeft();
                    break;
                case 38: // Top
                    Controller.moveToTop();
                    break;
                case 39: // Right
                    Controller.moveToRight();
                    break;
                case 40: // Bottom
                    Controller.moveToBottom();
                    break;
            }

            Controller.generateRandomCell();
        }

        public void drawAgain() {
            this.panel1.Invalidate();
        }

        private void leaderBoardToolStripMenuItem_Click(object sender, EventArgs e) {
            LeaderBoard leaderBoard = new LeaderBoard(4);
            leaderBoard.ShowDialog();
        }
    }
}
