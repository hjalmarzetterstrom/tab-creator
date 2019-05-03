using System;
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
                return _tabBuilder.OrderByDescending(x => x.Length).ElementAt(0).Length;
            }
        }

        public TabulatureRow(string[] tuning)
        {
            _tabBuilder = tuning.Select(x => new StringBuilder(x + "|")).ToArray();
        }

        public TabulatureRow(string tabulature)
        {
            _tabBuilder = new StringBuilder[6];
            var splitIntoSingleLines = tabulature.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < splitIntoSingleLines.Length; i++)
            {
                _tabBuilder[i] = new StringBuilder(splitIntoSingleLines[i]);
            }
            var thisLength = this.Length;
            foreach (var line in _tabBuilder)
            {
                line.Append('-', thisLength - line.Length);
            }
        }

        public int Add(int space, params TabNote[] notes)
        {
            int before = this.Length;
            foreach (var item in notes)
            {
                _tabBuilder[item.StringIndex].Append('-', space);
                _tabBuilder[item.StringIndex].Append(item.Input);
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
            return this.Length - before;
        }

        public int Add(int space, int numberOfEntries, params TabNote[] notes)
        {
            int before = this.Length;
            foreach (var item in notes)
            {
                for (int i = 0; i < numberOfEntries; i++)
                {
                    _tabBuilder[item.StringIndex].Append('-', space);
                    _tabBuilder[item.StringIndex].Append(item.Input);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int dif = _tabBuilder.Max(x => x.Length) - _tabBuilder[i].Length;
                _tabBuilder[i].Append('-', dif);
            }
            return this.Length - before;
        }

        public void AddSplitter()
        {
            foreach (var item in _tabBuilder)
            {
                item.Append('|');
            }
        }

        public void Backspace()
        {
            if (Length > 2)
                _tabBuilder = _tabBuilder.Select(x => x.Remove(x.Length - 1, 1)).ToArray();
        }

        public void ChangeTuning(string[] tuning)
        {
            var anySharp = tuning.Any(x => x.Length > 1);
            for (int i = 0; i < tuning.Length; i++)
            {
                var thisSharp = tuning[i].Length > 1;

                _tabBuilder[i][0] = tuning[i][0];

                if (anySharp)
                {
                    if (thisSharp)
                    {
                        if (!Char.IsWhiteSpace(_tabBuilder[i][1]))
                            _tabBuilder[i].Insert(1, tuning[i][1]);
                        else
                            _tabBuilder[i][1] = tuning[i][1];
                    }
                    else
                    {
                        if (!Char.IsWhiteSpace(_tabBuilder[i][1]))
                            _tabBuilder[i].Insert(1, ' ');
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder tab = new StringBuilder();

            foreach (var item in Tabulature)
            {
                tab.Append(item);
                tab.Append("\r\n");
            }

            return tab.ToString().TrimEnd('\r', '\n');
        }
    }
}
