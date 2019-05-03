using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabCreator_Exclude
{
    public struct Range
    {
        //public int Start { get; set; }
        //public int End { get; set; }

        //public bool isBetween(int value)
        //{
        //    return value >= Start && value < End;
        //}

        //public int ToPointY()
        //{
        //    return (int)new int[] { Start, End }.Average();
        //}

        //public override string ToString()
        //{
        //    return String.Format("{0} to {1}", Start, End);
        //}
    }

    public partial class SheetMusicForm : Form
    {
        //List<PictureBox> notes;
        //Dictionary<int, string> YToNote;
        //Dictionary<Range, NoteShape> YToShape;
        //Dictionary<Range, int> coordinateToY;
        //Dictionary<NoteAccidental, string> accidentalToSymbol;
        //int nextX;

        //public List<Note> NoteQueue { get; set; }

        public SheetMusicForm()
        {
            InitializeComponent();
        //    notes = new List<PictureBox>();
        //    coordinateToY = new Dictionary<Range, int>();
        //    YToNote = new Dictionary<int, string>();
        //    YToShape = new Dictionary<Range, NoteShape>();
        //    accidentalToSymbol = new Dictionary<NoteAccidental, string>();
        //    NoteQueue = new List<Note>();
        //    nextX = 100;

        //    string[] pitches = "E D C B A G F E D C B A G F E D C B A G F E".Split(' ');
        //    for (int coordinate = 10, i = 0; coordinate <= 115; coordinate += 5, i++)
        //    {
        //        YToNote.Add(coordinate, pitches[i]);
        //        coordinateToY.Add(new Range() { Start = coordinate - 2, End = coordinate + 3 }, coordinate);
        //    }

        //    YToShape.Add(new Range() { Start = 0, End = 35 }, NoteShape.UpsideDownStrikeThrough);
        //    YToShape.Add(new Range() { Start = 35, End = 60 }, NoteShape.UpsideDown);
        //    YToShape.Add(new Range() { Start = 60, End = 85 }, NoteShape.Normal);
        //    YToShape.Add(new Range() { Start = 85, End = 999 }, NoteShape.NormalStrikeThrough);

        //    accidentalToSymbol.Add(NoteAccidental.Sharp, "#");
        //    accidentalToSymbol.Add(NoteAccidental.Flat, "b");
        //    accidentalToSymbol.Add(NoteAccidental.Natural, "");
        }

        private void FormSheetMusic_Load(object sender, EventArgs e)
        {

        }

        private void FormSheetMusic_MouseClick(object sender, MouseEventArgs e)
        {
        //    switch (e.Button)
        //    {
        //        case MouseButtons.Left:
        //            AddNoteOnMousePosition(e);
        //            break;
        //        case MouseButtons.Right:
        //            Undo();
        //            break;
        //    }
        }

        //private void AddNoteOnMousePosition(MouseEventArgs e)
        //{
        //    if (nextX < 900 && coordinateToY.Any(x => x.Key.isBetween(e.Y)))
        //    {
        //        var Y = coordinateToY.Single(x => x.Key.isBetween(e.Y)).Value;
        //        var shape = YToShape.Single(x => x.Key.isBetween(Y)).Value;
        //        var accidental = GetAccidental();
        //        var pitch = new StringBuilder(YToNote[Y]);
        //        var imagePosition = new Point(nextX, Y - 10);
        //        var newNote = new Note(pitch.ToString(), accidental);

        //        pitch.Append(accidentalToSymbol[accidental]);

        //        switch (accidental)
        //        {
        //            case NoteAccidental.Flat:
        //                imagePosition.Y -= 5;
        //                var newAccidental = new Accidental(imagePosition, accidental);
        //                panel1.Controls.Add(newAccidental);
        //                nextX += 10;
        //                break;
        //            case NoteAccidental.Sharp:
        //                newAccidental = new Accidental(imagePosition, accidental);
        //                panel1.Controls.Add(newAccidental);
        //                nextX += 10;
        //                break;
        //        }

        //        pitch.Append(" ");
        //        textBox1.Text += pitch.ToString();
        //        Y -= (int)shape % 2 == 0 ? 30 : 5; //Reposition image for note.

        //        imagePosition = new Point(nextX, Y);
        //        newNote.Draw(imagePosition, shape);

        //        panel1.Controls.Add(newNote);
        //        NoteQueue.Add(newNote);

        //        nextX += 25;
        //    }
        //}

        //private void Undo()
        //{
        //    if (panel1.Controls.Count > 3)
        //    {
        //        panel1.Controls.RemoveAt(panel1.Controls.Count - 1);
        //        textBox1.Text = textBox1.Text.Trim();
        //        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        //        nextX -= 25;

        //        if (panel1.Controls[panel1.Controls.Count - 1] is Accidental)
        //        {
        //            Undo();
        //            nextX += 15;
        //        }

        //    }
        //}

        //private NoteAccidental GetAccidental()
        //{
        //    var accidental = NoteAccidental.Natural;
        //    if (radioFlat.Checked)
        //        accidental = NoteAccidental.Flat;
        //    if (radioSharp.Checked)
        //        accidental = NoteAccidental.Sharp;
        //    return accidental;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            //NoteQueue = textBox1.Text.Split(' ');

        }
    }
}
