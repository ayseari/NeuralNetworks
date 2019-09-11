using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace OUTWRITER
{
    public class OutWriter : TextWriter
    {
        public override Encoding Encoding { get; }
        public RichTextBox box;

        public override void WriteLine()
        {
            box.Invoke(new Action(() =>
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectedText += Environment.NewLine;
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.ScrollToCaret();
            }));
        }

        public override void Write(string line)
        {
            Color back = Color.Black;
            if (string.IsNullOrEmpty(line) == false)
            {
                switch (line[0])
                {
                    case '@':
                        back = Color.Blue;
                        break;
                    case '#':
                        back = Color.Red;
                        break;
                }
                if (back != Color.Black) line = line.Substring(1);
            }
            //Debug.WriteLine(line);
            box.Invoke(new Action(() =>
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = back;
                box.SelectedText += line;
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.ScrollToCaret();
            }));
        }

        public override void WriteLine(string line)
        {
            Color back = Color.Black;
            if (string.IsNullOrEmpty(line) == false)
            {
                switch (line[0])
                {
                    case '@':
                        back = Color.Blue;
                        break;
                    case '#':
                        back = Color.Red;
                        break;
                }
                if (back != Color.Black) line = line.Substring(1);
            }
            //Debug.WriteLine(line);
            box.Invoke(new Action(() =>
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.SelectionColor = back;
                box.SelectedText += line + Environment.NewLine;
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;
                box.ScrollToCaret();
            }));
        }
    }
}