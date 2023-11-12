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
        p1name = new TextBox();
        p2name = new TextBox();
        label4 = new Label();
        label5 = new Label();
        ((ISupportInitialize)cupsAmountNumericUpDown).BeginInit();
        ((ISupportInitialize)startingPebblesNumericUpDown).BeginInit();
        SuspendLayout();
        // 
        // startBtn
        // 
        startBtn.Location = new Point(164, 182);
        startBtn.Name = "startBtn";
        startBtn.Size = new Size(75, 23);
        startBtn.TabIndex = 0;
        startBtn.Text = "Start";
        startBtn.UseVisualStyleBackColor = true;
        // 
        // variantComboBox
        // 
        variantComboBox.FormattingEnabled = true;
        variantComboBox.Location = new Point(119, 6);
        variantComboBox.Name = "variantComboBox";
        variantComboBox.Size = new Size(121, 23);
        variantComboBox.TabIndex = 1;
        // 
        // cupsAmountNumericUpDown
        // 
        cupsAmountNumericUpDown.Enabled = false;
        cupsAmountNumericUpDown.Location = new Point(120, 121);
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
        label2.Location = new Point(13, 123);
        label2.Name = "label2";
        label2.Size = new Size(89, 15);
        label2.TabIndex = 4;
        label2.Text = "Cups per player";
        // 
        // startingPebblesNumericUpDown
        // 
        startingPebblesNumericUpDown.Enabled = false;
        startingPebblesNumericUpDown.Location = new Point(120, 150);
        startingPebblesNumericUpDown.Name = "startingPebblesNumericUpDown";
        startingPebblesNumericUpDown.Size = new Size(120, 23);
        startingPebblesNumericUpDown.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(13, 152);
        label3.Name = "label3";
        label3.Size = new Size(92, 15);
        label3.TabIndex = 6;
        label3.Text = "Starting pebbles";
        // 
        // defaultValues
        // 
        defaultValues.AutoSize = true;
        defaultValues.Checked = true;
        defaultValues.CheckState = CheckState.Checked;
        defaultValues.Location = new Point(13, 101);
        defaultValues.Name = "defaultValues";
        defaultValues.Size = new Size(147, 19);
        defaultValues.TabIndex = 7;
        defaultValues.Text = "Default variant settings";
        defaultValues.UseVisualStyleBackColor = true;
        // 
        // p1name
        // 
        p1name.Location = new Point(120, 35);
        p1name.Name = "p1name";
        p1name.Size = new Size(120, 23);
        p1name.TabIndex = 8;
        p1name.Text = "Player 1";
        // 
        // p2name
        // 
        p2name.Location = new Point(120, 64);
        p2name.Name = "p2name";
        p2name.Size = new Size(120, 23);
        p2name.TabIndex = 9;
        p2name.Text = "Player 2";
        p2name.TextChanged += textBox2_TextChanged;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(12, 38);
        label4.Name = "label4";
        label4.Size = new Size(81, 15);
        label4.TabIndex = 10;
        label4.Text = "Player 1 name";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(12, 67);
        label5.Name = "label5";
        label5.Size = new Size(81, 15);
        label5.TabIndex = 11;
        label5.Text = "Player 2 name";
        // 
        // GameSettingsDialog
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(264, 217);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(p2name);
        Controls.Add(p1name);
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
    private TextBox p1name;
    private TextBox p2name;
    private Label label4;
    private Label label5;
}