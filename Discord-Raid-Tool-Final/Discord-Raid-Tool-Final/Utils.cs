using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Raid_Tool_Final
{
    public class Visuals
    {
        public class Movers
        {
            private static Point downPoint = Point.Empty;
            private Form form = null;

            public Movers(Form frm)
            {
                this.form = frm;
            }

            public void MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    downPoint = new Point(e.X, e.Y);
            }

            public void MouseMove(object sender, MouseEventArgs e)
            {
                if (downPoint != Point.Empty)
                    form.Location = new Point(form.Left + e.X - downPoint.X, form.Top + e.Y - downPoint.Y);
            }

            public void MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                    downPoint = Point.Empty;
            }
        }

        public class RGB
        {
            public static Color SpectrumColor()
            {
                float time = (float)((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() % 62830) / 2000.0);
                return Color.FromArgb(255,
                    (int)((Math.Sin(time) * .5f + .5f) * 255.0f),
                    (int)((Math.Sin(time + 2 * Math.PI / 3) * .5f + .5f) * 255.0f),
                    (int)((Math.Sin(time + 4 * Math.PI / 3) * .5f + .5f) * 255.0f));
            }
        }

        public class Location
        {
            public int x;
            public int y;

            public Location(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }

    public class IO
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}