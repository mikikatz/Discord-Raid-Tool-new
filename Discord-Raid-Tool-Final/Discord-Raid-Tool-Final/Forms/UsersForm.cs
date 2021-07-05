using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Raid_Tool_Final.Forms
{
    public partial class UsersForm : Form
    {
        private ulong UserId;
        private string MessageContent;
        private string EmojiTxt;
        private ulong MessageId;
        private ulong CallId;

        public UsersForm()
        {
            InitializeComponent();
        }

        private void StartFrienderBtn_Click(object sender, EventArgs e)
        {
            if (UserId == 0 && UserId.ToString().Length != 16)
            {
                MessageBox.Show("Enter a vaild user id!!!!!!!!!");
                return;
            }
        }

        private void UserIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserIdTextBox.Text) || String.IsNullOrWhiteSpace(UserIdTextBox.Text))
                return;

            try { UserId = ulong.Parse(UserIdTextBox.Text); }
            catch
            {
                if (UserIdTextBox.Text.Length > 1)
                    UserIdTextBox.Text = UserIdTextBox.Text.Substring(0, UserIdTextBox.Text.Length - 1);
                else
                    UserIdTextBox.Text = "";

                MessageBox.Show("Retard enter a vaild user id!");
            }
        }

        private void MessageContentTextBox_TextChanged(object sender, EventArgs e)
        {
            MessageContent = MessageContentTextBox.Text;
        }

        private void EmojiTextBox_TextChanged(object sender, EventArgs e)
        {
            if (EmojiTextBox.Text.Length > 1)
            {
                EmojiTextBox.Text = "";
                MessageBox.Show("Not a vaild emoji format!");
            }
        }

        private void MessageIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MessageIdTextBox.Text) || String.IsNullOrWhiteSpace(MessageIdTextBox.Text))
                return;

            try { MessageId = ulong.Parse(MessageIdTextBox.Text); }
            catch
            {
                if (MessageIdTextBox.Text.Length > 1)
                    MessageIdTextBox.Text = MessageIdTextBox.Text.Substring(0, MessageIdTextBox.Text.Length - 1);
                else
                    MessageIdTextBox.Text = "";

                MessageBox.Show("Retard enter a vaild message id!");
            }
        }

        private void PrivateCallIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PrivateCallIdTextBox.Text) || String.IsNullOrWhiteSpace(PrivateCallIdTextBox.Text))
                return;

            try { CallId = ulong.Parse(PrivateCallIdTextBox.Text); }
            catch
            {
                if (PrivateCallIdTextBox.Text.Length > 1)
                    PrivateCallIdTextBox.Text = PrivateCallIdTextBox.Text.Substring(0, PrivateCallIdTextBox.Text.Length - 1);
                else
                    PrivateCallIdTextBox.Text = "";

                MessageBox.Show("Retard enter a vaild call id!");
            }
        }
    }
}