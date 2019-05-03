using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCreator
{
    public class Sheet
    {
        public List<TabulatureRow> Rows { get; set; }
        public string[] Tuning { get; set; }

        public Dictionary<string, TabNote[]> FretboardMap = TabNote.GetFretboardMap();

        TabulatureRow this[int index]
        {
            get
            {
                return Rows[index];
            }
            set
            {
                Rows[index] = value;
            }
        }

        public Sheet(string[] tuning)
        {
            this.Tuning = tuning;
            Rows = new List<TabulatureRow>();
            Rows.Add(new TabulatureRow(Tuning));
        }

        public void NewRow()
        {
            Rows.Add(new TabulatureRow(Tuning));
        }

        public void AddTab(int space, params TabNote[] notes)
        {
            Rows.Last().Add(space, notes);
        }

        public void AddTab(int space, int numberOfEntries, params TabNote[] notes)
        {
            Rows.Last().Add(space, numberOfEntries, notes);
        }

        public void AddSplitter()
        {
            Rows.Last().AddSplitter();
        }

        public void Undo()
        {
            if (Rows.Last().Length == 2 && Rows.Count > 1)
                Rows.Remove(Rows.Last());
            else
                Rows.Last().Undo();
        }

        public List<TabulatureRow> GenerateFromNote(string note, out TabNote[] notes)
        {
            var thisList = new List<TabulatureRow>();
            var collection = FretboardMap[note];
            notes = collection;

            for (int i = 0; i < collection.Count(); i++)
            {
                thisList.Add(new TabulatureRow(Tuning));
                thisList[i].Add(0, collection[i]);
            }

            return thisList;
        }

        public List<TabulatureRow> GenerateFromNote(string note, Sort sort, out TabNote[] notes)
        {
            var thisList = new List<TabulatureRow>();
            var collection = GetTabsFromNote(note, sort);

            for (int i = 0; i < collection.Count(); i++)
            {
                thisList.Add(new TabulatureRow(Tuning));
                thisList[i].Add(0, collection[i]);
            }

            notes = collection;
            return thisList;
        }

        private TabNote[] GetTabsFromNote(string note, Sort sort)
        {
            TabNote[] collection;
            switch (sort)
            {
                case Sort.Octaves:
                    collection = FretboardMap[note];
                    break;
                case Sort.Frets:
                    collection = FretboardMap[note].OrderBy(x => int.Parse(x.Input)).ToArray();
                    break;
                case Sort.Strings:
                    collection = FretboardMap[note].OrderBy(x => x.GuitarString).ToArray();
                    break;
                default:
                    collection = FretboardMap[note];
                    break;
            }
            return collection;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Rows)
            {
                builder.Append(item.ToString());
                builder.Append("\r\n\r\n");
            }

            return builder.ToString();
        }
    }
}
