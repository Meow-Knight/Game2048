using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048 {
    public partial class LeaderBoard : Form {
        private static Dictionary<String, int> level;

        static LeaderBoard() {
            LeaderBoard.level = new Dictionary<string, int>();
            LeaderBoard.level.Add("Level 4x4", 4);
            LeaderBoard.level.Add("Level 5x5", 5);
            LeaderBoard.level.Add("Level 6x6", 6);
        }

        public LeaderBoard(int level) {
            InitializeComponent();

            this.Level.SelectedItem = $"Level {level}x{level}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string levelKey = (string)this.Level.Items[this.Level.SelectedIndex];
            this.LeaderBoardData.DataSource = DatabaseServices.getData(LeaderBoard.level[levelKey]);
        }
    }


}
