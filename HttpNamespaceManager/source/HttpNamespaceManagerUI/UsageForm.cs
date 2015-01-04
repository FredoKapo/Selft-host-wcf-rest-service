using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HttpNamespaceManager.UI
{
    public partial class UsageForm : Form
    {
        public UsageForm()
        {
            InitializeComponent();
        }

        private void UsageForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(labelUsage.Right + 18, labelUsage.Bottom + 62);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}