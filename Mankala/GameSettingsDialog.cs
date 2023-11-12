namespace Mankala;

public partial class GameSettingsDialog : Form
{
    public string Variant => (string)variantComboBox.SelectedItem;
    public int CupsAmount => (int)cupsAmountNumericUpDown.Value;
    public int StartingPebbles => (int)startingPebblesNumericUpDown.Value;
    
    public GameSettingsDialog()
    {
        InitializeComponent();
        variantComboBox.Items.AddRange(new [] {"Mankala", "Wari", "Wankala"});
        variantComboBox.SelectedIndex = 0;
        DefaultValuesCheckboxChanged(null, null);
        cupsAmountNumericUpDown.Minimum = 2;
        startingPebblesNumericUpDown.Minimum = 1;
        startBtn.Click += Start;
        defaultValues.Click += DefaultValuesCheckboxChanged;
    }

    void Start(object? o, EventArgs e) => DialogResult = DialogResult.OK;

    void DefaultValuesCheckboxChanged(object? o, EventArgs e)
    {
        if (defaultValues.Checked)
        {
            cupsAmountNumericUpDown.Value = 6;
            startingPebblesNumericUpDown.Value = 4;
            cupsAmountNumericUpDown.Enabled = false;
            startingPebblesNumericUpDown.Enabled = false;
            return;
        }
        cupsAmountNumericUpDown.Enabled = true;
        startingPebblesNumericUpDown.Enabled = true;
    }
}