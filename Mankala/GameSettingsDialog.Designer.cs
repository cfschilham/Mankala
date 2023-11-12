using System.ComponentModel;

namespace Mankala;

partial class GameSettingsDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        startBtn = new Button();
        variantComboBox = new ComboBox();
        cupsAmountNumericUpDown = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        startingPebblesNumericUpDown = new NumericUpDown();
        label3 = new Label();
        defaultValues = new CheckBox();
        ((ISupportInitialize)cupsAmountNumericUpDown).BeginInit();
        ((ISupportInitialize)startingPebblesNumericUpDown).BeginInit();
        SuspendLayout();
        // 
        // startBtn
        // 
        startBtn.Location = new Point(165, 122);
        startBtn.Name = "startBtn";
        startBtn.Size = new Size(75, 23);
        startBtn.TabIndex = 0;
        startBtn.Text = "Start";
        startBtn.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        variantComboBox.FormattingEnabled = true;
        variantComboBox.Location = new Point(119, 6);
        variantComboBox.Name = "variantComboBox";
        variantComboBox.Size = new Size(121, 23);
        variantComboBox.TabIndex = 1;
        // 
        // numericUpDown1
        // 
        cupsAmountNumericUpDown.Enabled = false;
        cupsAmountNumericUpDown.Location = new Point(119, 52);
        cupsAmountNumericUpDown.Name = "cupsAmountNumericUpDown";
        cupsAmountNumericUpDown.Size = new Size(120, 23);
        cupsAmountNumericUpDown.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(43, 15);
        label1.TabIndex = 3;
        label1.Text = "Variant";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 54);
        label2.Name = "label2";
        label2.Size = new Size(89, 15);
        label2.TabIndex = 4;
        label2.Text = "Cups per player";
        // 
        // numericUpDown2
        // 
        startingPebblesNumericUpDown.Enabled = false;
        startingPebblesNumericUpDown.Location = new Point(119, 81);
        startingPebblesNumericUpDown.Name = "startingPebblesNumericUpDown";
        startingPebblesNumericUpDown.Size = new Size(120, 23);
        startingPebblesNumericUpDown.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 83);
        label3.Name = "label3";
        label3.Size = new Size(92, 15);
        label3.TabIndex = 6;
        label3.Text = "Starting pebbles";
        // 
        // checkBox1
        // 
        defaultValues.AutoSize = true;
        defaultValues.Checked = true;
        defaultValues.CheckState = CheckState.Checked;
        defaultValues.Location = new Point(12, 32);
        defaultValues.Name = "defaultValues";
        defaultValues.Size = new Size(147, 19);
        defaultValues.TabIndex = 7;
        defaultValues.Text = "Default variant settings";
        defaultValues.UseVisualStyleBackColor = true;
        // 
        // GameSettingsDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(264, 159);
        Controls.Add(defaultValues);
        Controls.Add(label3);
        Controls.Add(startingPebblesNumericUpDown);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(cupsAmountNumericUpDown);
        Controls.Add(variantComboBox);
        Controls.Add(startBtn);
        Name = "GameSettingsDialog";
        Text = "Create game";
        ((ISupportInitialize)cupsAmountNumericUpDown).EndInit();
        ((ISupportInitialize)startingPebblesNumericUpDown).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button startBtn;
    private ComboBox variantComboBox;
    private NumericUpDown cupsAmountNumericUpDown;
    private Label label1;
    private Label label2;
    private NumericUpDown startingPebblesNumericUpDown;
    private Label label3;
    private CheckBox defaultValues;
}