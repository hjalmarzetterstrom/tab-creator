using System;

namespace TabCreator
{
    class NoteEventArgs : EventArgs
    {
        public string Pitch { get; set; }

        public NoteEventArgs(string pitch) : base()
        {
            this.Pitch = pitch;
        }
    }
}
