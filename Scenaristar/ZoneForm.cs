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
    public partial class ZoneForm : Form
    {
        public ZoneForm()
        {
            InitializeComponent();
            CenterToParent();
            DialogResult = DialogResult.Cancel;
        }

        private void ZoneForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
