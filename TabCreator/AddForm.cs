using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TabCreator
{
    public partial class AddForm : Form
    {
        public int X { get; set; }
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X = (int)numericUpDown.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FormAddX_Load(object sender, EventArgs e)
        {
            this.Location = MousePosition;
        }
    }
}
