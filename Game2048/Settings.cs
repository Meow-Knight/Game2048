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
    public partial class Settings : Form {
        public static Dictionary<string, int> levels;

        static Settings() {
            levels = new Dictionary<string, int>();
            levels.Add("Level 4x4", 4);
            levels.Add("Level 5x5", 5);
            levels.Add("Level 6x6", 6);
        }

        public Settings() {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e) {
            this.LevelComboBox.Text = $"Level {Controller.Level}x{Controller.Level}";
        }

        private void LevelComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Controller.Level = levels[(string)this.LevelComboBox.SelectedItem];
            Controller.startGame();
        }
    }
}
