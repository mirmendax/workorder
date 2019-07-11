using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using oalib_v2;

namespace SQLEditor
{
    public partial class Form1 : Form
    {
        const string DATA_FILE = "data.db";
        SQLiteConnection m_Connect;
        SQLiteCommand m_SQL;
        public Form1()
        {
            InitializeComponent();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(DATA_FILE))
            {
                SQLiteConnection.CreateFile(DATA_FILE);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
