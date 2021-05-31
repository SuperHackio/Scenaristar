using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenaristar
{
    public partial class CometTimerForm : Form
    {
        public CometTimerForm(int time)
        {
            InitializeComponent();
            CenterToParent();
            CometMinutesNumericUpDown.Value = time / 60;
            CometSecondsNumericUpDown.Value = time % 60;
        }

        public int TimeLimit => (int)((60 * CometMinutesNumericUpDown.Value) + CometSecondsNumericUpDown.Value);

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
