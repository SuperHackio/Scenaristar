using DarkModeForms;

namespace Scenaristar;

public partial class ZoneForm : Form
{
    public ZoneForm()
    {
        InitializeComponent();
        CenterToParent();
        ProgramColors.ReloadTheme(this);
    }

    private void OKButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameTextBox.Text))
        {
            MessageBox.Show("Can't set the zone name to be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void AbortButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
