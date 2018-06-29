using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkOrder
{
    public partial class FrmRunLoad : Form
    {
        int progres = 0;

        public FrmRunLoad()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            progres++;
            if (progres >= 100)
                Close();
        }

        private void FrmRunLoad_Load(object sender, EventArgs e)
        {

        }
    }
}
