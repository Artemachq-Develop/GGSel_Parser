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
        linksListBox = new ListBox();
        linkLabel = new Label();
        addLinksButton = new Button();
        lowPriceListBox = new ListBox();
        checkButton = new Button();
        lowPriceLebel = new Label();
        SuspendLayout();
        // 
        // linksListBox
        // 
        linksListBox.FormattingEnabled = true;
        linksListBox.HorizontalScrollbar = true;
        linksListBox.Items.AddRange(new object[] { "https://ggsel.net/catalog/helldivers-2-keys-steam" });
        linksListBox.Location = new Point(12, 39);
        linksListBox.Name = "linksListBox";
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
        // addLinksButton
        // 
        addLinksButton.Location = new Point(12, 229);
        addLinksButton.Name = "addLinksButton";
        addLinksButton.Size = new Size(150, 29);
        addLinksButton.TabIndex = 3;
        addLinksButton.Text = "Add to List";
        addLinksButton.UseVisualStyleBackColor = true;
        addLinksButton.Click += addLinksButton_Click;
        // 
        // lowPriceListBox
        // 
        lowPriceListBox.FormattingEnabled = true;
        lowPriceListBox.HorizontalScrollbar = true;
        lowPriceListBox.Location = new Point(258, 39);
        lowPriceListBox.Name = "lowPriceListBox";
        lowPriceListBox.Size = new Size(345, 184);
        lowPriceListBox.TabIndex = 0;
        // 
        // checkButton
        // 
        checkButton.Location = new Point(258, 229);
        checkButton.Name = "checkButton";
        checkButton.Size = new Size(345, 29);
        checkButton.TabIndex = 3;
        checkButton.Text = "Check";
        checkButton.UseVisualStyleBackColor = true;
        checkButton.Click += checkButton_Click;
        // 
        // lowPriceLebel
        // 
        lowPriceLebel.Location = new Point(258, 12);
        lowPriceLebel.Name = "lowPriceLebel";
        lowPriceLebel.Size = new Size(137, 24);
        lowPriceLebel.TabIndex = 1;
        lowPriceLebel.Text = "Prices";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 266);
        Controls.Add(checkButton);
        Controls.Add(addLinksButton);
        Controls.Add(lowPriceLebel);
        Controls.Add(linkLabel);
        Controls.Add(lowPriceListBox);
        Controls.Add(linksListBox);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox linksListBox;
    private System.Windows.Forms.Label linkLabel;
    private System.Windows.Forms.Button addLinksButton;

    #endregion

    private ListBox lowPriceListBox;
    private Button checkButton;
    private Label lowPriceLebel;
}