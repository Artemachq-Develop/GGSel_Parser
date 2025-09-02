namespace GGSel_Parser;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        components = new System.ComponentModel.Container();
        linksListBox = new ListBox();
        linkLabel = new Label();
        linksTextBox = new TextBox();
        addLinksButton = new Button();
        lowPriceListBox = new ListBox();
        notifyIcon1 = new NotifyIcon(components);
        checkButton = new Button();
        SuspendLayout();
        // 
        // linksListBox
        // 
        linksListBox.FormattingEnabled = true;
        linksListBox.HorizontalScrollbar = true;
        linksListBox.Items.AddRange(new object[] { "https://ggsel.net/catalog/helldivers-2-keys-steam" });
        linksListBox.Location = new Point(12, 39);
        linksListBox.Name = "linksListBox";
        linksListBox.SelectionMode = SelectionMode.None;
        linksListBox.Size = new Size(150, 184);
        linksListBox.TabIndex = 0;
        // 
        // linkLabel
        // 
        linkLabel.Location = new Point(9, 12);
        linkLabel.Name = "linkLabel";
        linkLabel.Size = new Size(137, 24);
        linkLabel.TabIndex = 1;
        linkLabel.Text = "Links";
        // 
        // linksTextBox
        // 
        linksTextBox.Location = new Point(9, 244);
        linksTextBox.Name = "linksTextBox";
        linksTextBox.Size = new Size(150, 23);
        linksTextBox.TabIndex = 2;
        // 
        // addLinksButton
        // 
        addLinksButton.Location = new Point(9, 273);
        addLinksButton.Name = "addLinksButton";
        addLinksButton.Size = new Size(150, 29);
        addLinksButton.TabIndex = 3;
        addLinksButton.Text = "Add to List";
        addLinksButton.UseVisualStyleBackColor = true;
        // 
        // lowPriceListBox
        // 
        lowPriceListBox.FormattingEnabled = true;
        lowPriceListBox.HorizontalScrollbar = true;
        lowPriceListBox.Location = new Point(258, 39);
        lowPriceListBox.Name = "lowPriceListBox";
        lowPriceListBox.Size = new Size(150, 184);
        lowPriceListBox.TabIndex = 0;
        // 
        // notifyIcon1
        // 
        notifyIcon1.Text = "notifyIcon1";
        notifyIcon1.Visible = true;
        // 
        // checkButton
        // 
        checkButton.Location = new Point(258, 244);
        checkButton.Name = "checkButton";
        checkButton.Size = new Size(150, 29);
        checkButton.TabIndex = 3;
        checkButton.Text = "Check";
        checkButton.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(423, 437);
        Controls.Add(checkButton);
        Controls.Add(addLinksButton);
        Controls.Add(linksTextBox);
        Controls.Add(linkLabel);
        Controls.Add(lowPriceListBox);
        Controls.Add(linksListBox);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ListBox linksListBox;
    private System.Windows.Forms.Label linkLabel;
    private System.Windows.Forms.TextBox linksTextBox;
    private System.Windows.Forms.Button addLinksButton;

    #endregion

    private ListBox lowPriceListBox;
    private NotifyIcon notifyIcon1;
    private Button checkButton;
}