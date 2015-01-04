using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HttpNamespaceManager.UI
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string title, string prompt)
        {
            InitializeComponent();
            this.Text = title;
            this.labelPrompt.Text = prompt;
            this.Size = new Size(Math.Max(this.labelPrompt.Width + 31, 290), this.labelPrompt.Height + 103);
        }

        public static DialogResult Show(string title, string prompt, out string result)
        {
            InputBox input = new InputBox(title, prompt);
            DialogResult retval = input.ShowDialog();
            result = input.textInput.Text;
            return retval;
        }
    }
}