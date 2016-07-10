using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stockdata.forms.manager
{
    public partial class frmErrorMessageDetail : Form
    {
        public frmErrorMessageDetail()
        {
            InitializeComponent();
        }

        public frmErrorMessageDetail(string str1, string str2) : this()
        {
            this.textBox1.Text = str1;
            this.textBox2.Text = str2;
        }

        private void frmClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
