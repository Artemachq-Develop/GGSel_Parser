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
        Splitter splitter1;
        linksListBox = new ListBox();
        linksContextMenuStrip = new ContextMenuStrip(components);
        addToolStripMenuItem = new ToolStripMenuItem();
        removeToolStripMenuItem = new ToolStripMenuItem();
        addLinksButton = new Button();
        lowPriceListBox = new ListBox();
        checkButton = new Button();
        lowPriceLabel = new Label();
        toolTip1 = new ToolTip(components);
        progressBar1 = new ProgressBar();
        splitContainer1 = new SplitContainer();
        linksLabel = new Label();
        splitter3 = new Splitter();
        splitter1 = new Splitter();
        linksContextMenuStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitter1
        // 
        splitter1.Dock = DockStyle.Top;
        splitter1.Location = new Point(0, 21);
        splitter1.Name = "splitter1";
        splitter1.Size = new Size(256, 3);
        splitter1.TabIndex = 4;
        splitter1.TabStop = false;
        // 
        // linksListBox
        // 
        linksListBox.ContextMenuStrip = linksContextMenuStrip;
        linksListBox.Dock = DockStyle.Fill;
        linksListBox.FormattingEnabled = true;
        linksListBox.HorizontalScrollbar = true;
        linksListBox.Items.AddRange(new object[] { "https://ggsel.net/catalog/helldivers-2-keys-steam" });
        linksListBox.Location = new Point(0, 24);
        linksListBox.Name = "linksListBox";
        linksListBox.Size = new Size(256, 242);
        linksListBox.TabIndex = 0;
        // 
        // linksContextMenuStrip
        // 
        linksContextMenuStrip.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, removeToolStripMenuItem });
        linksContextMenuStrip.Name = "linksContextMenuStrip";
        linksContextMenuStrip.Size = new Size(176, 48);
        linksContextMenuStrip.Text = "sadas";
        // 
        // addToolStripMenuItem
        // 
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new Size(175, 22);
        addToolStripMenuItem.Text = "Добавить элемент";
        addToolStripMenuItem.Click += addToolStripMenuItem_Click;
        // 
        // removeToolStripMenuItem
        // 
        removeToolStripMenuItem.Name = "removeToolStripMenuItem";
        removeToolStripMenuItem.Size = new Size(175, 22);
        removeToolStripMenuItem.Text = "Удалить элемент";
        removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
        // 
        // addLinksButton
        // 
        addLinksButton.Dock = DockStyle.Bottom;
        addLinksButton.Location = new Point(0, 266);
        addLinksButton.Name = "addLinksButton";
        addLinksButton.Size = new Size(256, 34);
        addLinksButton.TabIndex = 3;
        addLinksButton.Text = "Add to List";
        addLinksButton.UseVisualStyleBackColor = true;
        addLinksButton.Click += addLinksButton_Click;
        // 
        // lowPriceListBox
        // 
        lowPriceListBox.Dock = DockStyle.Fill;
        lowPriceListBox.FormattingEnabled = true;
        lowPriceListBox.HorizontalScrollbar = true;
        lowPriceListBox.Location = new Point(0, 24);
        lowPriceListBox.Name = "lowPriceListBox";
        lowPriceListBox.Size = new Size(353, 242);
        lowPriceListBox.TabIndex = 0;
        // 
        // checkButton
        // 
        checkButton.Dock = DockStyle.Bottom;
        checkButton.Location = new Point(0, 266);
        checkButton.Name = "checkButton";
        checkButton.Size = new Size(353, 34);
        checkButton.TabIndex = 3;
        checkButton.Text = "Check";
        checkButton.UseVisualStyleBackColor = true;
        checkButton.Click += checkButton_Click;
        // 
        // lowPriceLabel
        // 
        lowPriceLabel.Dock = DockStyle.Top;
        lowPriceLabel.Location = new Point(0, 0);
        lowPriceLabel.Name = "lowPriceLabel";
        lowPriceLabel.Size = new Size(353, 21);
        lowPriceLabel.TabIndex = 1;
        lowPriceLabel.Text = "Prices";
        lowPriceLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // progressBar1
        // 
        progressBar1.Dock = DockStyle.Top;
        progressBar1.Location = new Point(0, 24);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(353, 19);
        progressBar1.TabIndex = 4;
        progressBar1.Visible = false;
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(linksListBox);
        splitContainer1.Panel1.Controls.Add(splitter1);
        splitContainer1.Panel1.Controls.Add(linksLabel);
        splitContainer1.Panel1.Controls.Add(addLinksButton);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(progressBar1);
        splitContainer1.Panel2.Controls.Add(lowPriceListBox);
        splitContainer1.Panel2.Controls.Add(splitter3);
        splitContainer1.Panel2.Controls.Add(lowPriceLabel);
        splitContainer1.Panel2.Controls.Add(checkButton);
        splitContainer1.Size = new Size(613, 300);
        splitContainer1.SplitterDistance = 256;
        splitContainer1.TabIndex = 5;
        // 
        // linksLabel
        // 
        linksLabel.Dock = DockStyle.Top;
        linksLabel.Location = new Point(0, 0);
        linksLabel.Name = "linksLabel";
        linksLabel.Size = new Size(256, 21);
        linksLabel.TabIndex = 5;
        linksLabel.Text = "Links";
        linksLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // splitter3
        // 
        splitter3.Dock = DockStyle.Top;
        splitter3.Location = new Point(0, 21);
        splitter3.Name = "splitter3";
        splitter3.Size = new Size(353, 3);
        splitter3.TabIndex = 6;
        splitter3.TabStop = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(613, 300);
        Controls.Add(splitContainer1);
        Name = "Form1";
        Text = "Form1";
        linksContextMenuStrip.ResumeLayout(false);
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox linksListBox;
    private System.Windows.Forms.Button addLinksButton;

    #endregion

    private ListBox lowPriceListBox;
    private Button checkButton;
    private Label lowPriceLabel;
    private ToolTip toolTip1;
    private ContextMenuStrip linksContextMenuStrip;
    private ToolStripMenuItem addToolStripMenuItem;
    private ToolStripMenuItem removeToolStripMenuItem;
    private ProgressBar progressBar1;
    private SplitContainer splitContainer1;
    private Splitter splitter1;
    private Label linksLabel;
    private Splitter splitter3;
}