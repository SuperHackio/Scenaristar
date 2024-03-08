using DarkModeForms;

namespace Scenaristar;

public partial class StarAppearenceForm : Form
{
    public StarAppearenceForm(ScenarioEditorForm MF, Dictionary<string, string> ListSource)
    {
        Loading = true;
        InitializeComponent();
        CenterToParent();
        MainParent = MF;

        AppearenceListBox.DataSource = new BindingSource(ListSource, null);
        AppearenceListBox.DisplayMember = "Value";
        AppearenceListBox.ValueMember = "Key";

        foreach (var item in ListSource)
        {
            if (item.Key.Equals(MainParent.AppearenceTextBox.Text))
            {
                AppearenceListBox.SelectedItem = item;
                break;
            }
        }

        ProgramColors.ReloadTheme(this);
        Loading = false;
    }

    private readonly ScenarioEditorForm MainParent;
    private readonly bool Loading;

    private void AppearenceListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        MainParent.AppearenceTextBox.Text = AppearenceListBox.SelectedValue?.ToString() ?? "";
    }
}
