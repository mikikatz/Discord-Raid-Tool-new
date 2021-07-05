using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Raid_Tool_Final.Forms
{
    public partial class InputTokens : Form
    {
        public InputTokens()
        {
            InitializeComponent();
        }

        private void LoadFromCopyboard_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = Clipboard.GetText().Split(Environment.NewLine.ToCharArray()).Distinct().ToList().Select(t => t.Trim()).ToList();
            list.RemoveAll(t => t.Length < 59);

            Settings.Tokens = list;
            this.Close();
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                list = File.ReadAllText(dialog.FileName).Split(Environment.NewLine.ToCharArray()).Distinct().ToList().Select(t => t.Trim()).ToList();
                list.RemoveAll(t => t.Length < 59);

                Settings.Tokens = list;
            }
            this.Close();
        }
    }
}