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
    public partial class UserNamePrompt : Form {
        public UserNamePrompt() {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e) {
            string userName = this.UserNameTextBox.Text;
            DatabaseServices.update(Controller.Level, userName, Controller.score);
            this.Close();
        }
    }
}
