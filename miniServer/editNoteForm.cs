using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniServer
{
    public partial class editNoteForm : Form
    {
        public string note { get;private set; }
        public editNoteForm(string currentNote)
        {
            InitializeComponent();
            note = textBox1.Text = currentNote;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            note = this.textBox1.Text;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
