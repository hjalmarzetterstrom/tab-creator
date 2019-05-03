using System;
using System.Drawing;
using System.Windows.Forms;

namespace TabCreator
{
    public class Note
    {
        public PictureBox Picture { get; set; }
        public NoteAccidental Accidental { get; set; }
        public string Pitch { get; set; }

        private Bitmap[] _noteShapes = new Bitmap[]
        {
            new Bitmap(@"..\..\Images\note2.png"),
            new Bitmap(@"..\..\Images\highnote.png"),
            new Bitmap(@"..\..\Images\lownote.png"),
            new Bitmap(@"..\..\Images\veryhighnote.png")
        };

        private string[] _accidentalSymbols = new string[] { "", "b", "#" };

        public Note(string pitch, NoteAccidental accidental)
        {

            this.Pitch = pitch;
            this.Accidental = accidental;
        }

        public Note(string pitch, NoteAccidental accidental, Point location, NoteShape shape)
            : this(pitch, accidental)
        {
            Draw(location, shape);
        }

        public void Draw(Point location, NoteShape shape)
        {
            Picture = new PictureBox();
            Picture.Image = _noteShapes[(int)shape];
            Picture.Location = location;
            Picture.BackColor = Color.Transparent;
            Picture.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public static implicit operator PictureBox(Note note)
        {
            return note.Picture;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", Pitch, _accidentalSymbols[(int)Accidental]);
        }
    }
}
