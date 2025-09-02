using System;

namespace GGSel_Parser
{
    internal partial class GameInfoForm : Form
    {
        public GameInfo? GameInfo = null;

        public GameInfoForm()
        {
            InitializeComponent();
        }

        // Конструктор с начальными данными (опционально)
        public GameInfoForm(GameInfo existingInfo) : this()
        {
            if (existingInfo != null)
            {
                gameNameTextBox.Text = existingInfo.Name;
                gameLinkTextBox.Text = existingInfo.Link;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Создаем объект GameInfo с введенными данными
            GameInfo = new GameInfo
            {
                Name = gameNameTextBox.Text,
                Link = gameLinkTextBox.Text
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
