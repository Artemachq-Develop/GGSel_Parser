namespace GGSel_Parser
{
    partial class GameInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            gameNameTextBox = new TextBox();
            gameLinkTextBox = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            gameNameLabel = new Label();
            gameLinkLabel = new Label();
            SuspendLayout();
            // 
            // gameNameTextBox
            // 
            gameNameTextBox.Location = new Point(12, 30);
            gameNameTextBox.Name = "gameNameTextBox";
            gameNameTextBox.Size = new Size(302, 23);
            gameNameTextBox.TabIndex = 0;
            // 
            // gameLinkTextBox
            // 
            gameLinkTextBox.Location = new Point(12, 90);
            gameLinkTextBox.Multiline = true;
            gameLinkTextBox.Name = "gameLinkTextBox";
            gameLinkTextBox.Size = new Size(302, 55);
            gameLinkTextBox.TabIndex = 0;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(12, 161);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(148, 25);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(164, 161);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(148, 25);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // gameNameLabel
            // 
            gameNameLabel.AutoSize = true;
            gameNameLabel.Location = new Point(12, 12);
            gameNameLabel.Name = "gameNameLabel";
            gameNameLabel.Size = new Size(39, 15);
            gameNameLabel.TabIndex = 2;
            gameNameLabel.Text = "Name";
            // 
            // gameLinkLabel
            // 
            gameLinkLabel.AutoSize = true;
            gameLinkLabel.Location = new Point(12, 72);
            gameLinkLabel.Name = "gameLinkLabel";
            gameLinkLabel.Size = new Size(29, 15);
            gameLinkLabel.TabIndex = 2;
            gameLinkLabel.Text = "Link";
            // 
            // GameInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 198);
            Controls.Add(gameLinkLabel);
            Controls.Add(gameNameLabel);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(gameLinkTextBox);
            Controls.Add(gameNameTextBox);
            Name = "GameInfoForm";
            Text = "GameInfoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox gameNameTextBox;
        private TextBox gameLinkTextBox;
        private Button buttonOK;
        private Button buttonCancel;
        private Label gameNameLabel;
        private Label gameLinkLabel;
    }
}