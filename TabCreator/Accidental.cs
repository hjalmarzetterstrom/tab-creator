using System.Drawing;
using System.Windows.Forms;

namespace TabCreator
{
    public class Accidental : PictureBox
    {
        private Bitmap[] noteShapes = new Bitmap[]
        {
            new Bitmap(@"..\..\Images\natural.png"),
            new Bitmap(@"..\..\Images\flat.png"),
            new Bitmap(@"..\..\Images\sharp.png")
            
        };

        public Accidental(Point location, NoteAccidental accidental)
            : base()
        {
            this.Image = noteShapes[(int)accidental];
            this.Location = location;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}
