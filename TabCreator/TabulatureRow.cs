using System.Linq;
using System.Text;

namespace TabCreator
{
    public class TabulatureRow
    {
        private StringBuilder[] _tabBuilder;
        public string[] Tabulature
        {
            get
            {
                return _tabBuilder.Select(x => x.ToString()).ToArray();
            }
        }

        public int Length
        {
            get
            {
                return _tabBuilder[0].Length;
            }
        }

        public TabulatureRow(string[] tuning)
        {
            _tabBuilder = tuning.Select(x => new StringBuilder(x + "|")).ToArray();
        }

        public TabulatureRow(string[] tuning, string[] tabulature)
            : this(tuning)
        {
            for (int i = 0; i < tabulature.Length; i++)
            {
                _tabBuilder[i].Append(tabulature[i].Skip(tabulature[i].Length - 6));
            }
        }

        public void Add(int space, params TabNote[] notes)
        {
            foreach (var item in notes)
            {
                _tabBuilder[item.GuitarString].Append('-', space);
                _tabBuilder[item.GuitarString].Append(item.Input);
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
        }

        public void Add(int space, int numberOfEntries, params TabNote[] notes)
        {
            foreach (var item in notes)
            {
                for (int i = 0; i < numberOfEntries; i++)
                {
                    _tabBuilder[item.GuitarString].Append('-', space);
                    _tabBuilder[item.GuitarString].Append(item.Input);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
        }

        public void AddSplitter()
        {
            foreach (var item in _tabBuilder)
            {
                item.Append('|');
            }
        }

        public void Undo()
        {
            if (Length > 2)
                _tabBuilder = _tabBuilder.Select(x => x.Remove(x.Length - 1, 1)).ToArray();
        }

        public override string ToString()
        {
            StringBuilder tab = new StringBuilder();

            foreach (var item in Tabulature)
            {
                tab.Append(item + "\r\n");
            }

            return tab.ToString();
        }
    }
}
