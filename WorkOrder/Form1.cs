using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using oalib_v2;

namespace WorkOrder
{
    
    public partial class Form1 : Form
    {
        #region Forms
        FrmDate fDate = new FrmDate();
        FrmEmploy fEmployes = new FrmEmploy();
        FrmArhive fArhive = new FrmArhive();
        FrmEditEmploy fEditEmp = new FrmEditEmploy();
        FrmVerifyOrder fVerifyOrder = new FrmVerifyOrder();
        #endregion

        AutoCompleteStringCollection _ACS_estr = new AutoCompleteStringCollection();
        AutoCompleteStringCollection _ACS_instr = new AutoCompleteStringCollection();
        AutoCompleteStringCollection _ACS_dop_instr = new AutoCompleteStringCollection();

        BinaryFormatter _data_ACS = new BinaryFormatter();
        FileStream _file;

        bool Remove_br = false;

        private NotifyIcon iconTray;

        ListOrder_v2 ListOrder = new ListOrder_v2();
        
        EmpS_v2 ListEmploy = new EmpS_v2();

        List<Order_v2> NotVerOrder = new List<Order_v2>();

        Order_v2 Order = new Order_v2();

        List<Data_v2> Data_ACS = new List<Data_v2>();

        public const string ABOUT_FORMAT = "WorkOrder {0} Programming [MIR] Mendax (c) 2006-2017// СТСУ уч. ТАиВ";
        public static string fileVersion = "ver.dat";
        public const string ACS_FILE = "es_v2.wo";
        public const string ERR_DUPLECATE_EMP = "Такой работник уже есть в бригаде!";
        public const string DATE_FORMAT = "dd.MM.yyyy";
        public const string BR_OUT_DIAPOSON = "В бригаде достаточно работников!";
        public const string DOP_INSTR = "Другие указания по характеру и месту работы: ";
        //public const int R_GIVEORDER = 1;//Право отдающего распоряжение
        //public const int R_FOREPERSON = 2;//Право производителя работ
        //public const int R_OTHER = 5;//Член бригады

        /// <summary>
        /// Загрузка автозаполнения
        /// </summary>
        public void LoadACS()
        {
            if (File.Exists(ACS_FILE))
            {
                _file = File.Open(ACS_FILE, FileMode.Open, FileAccess.ReadWrite);
                try
                {
                    Data_ACS = ((_data_ACS.Deserialize(_file)) as List<Data_v2>);
                }
                catch (System.Runtime.Serialization.SerializationException e)
                {
                    new Log("Error Data_v2 of:" + e.Message);
                }
                _file.Close();
            }
            _ACS_estr.Clear();
            _ACS_instr.Clear();
            _ACS_dop_instr.Clear();
            foreach (Data_v2 d in Data_ACS)
            {
                _ACS_estr.Add(d.estr);
                _ACS_instr.Add(d.instr);
                if (d.dop_instr != string.Empty && d.dop_instr != "" && d.dop_instr != null)
                    _ACS_dop_instr.Add(d.dop_instr);
                
            }
            estrTBox.AutoCompleteCustomSource = _ACS_estr;
            instrTBox.AutoCompleteCustomSource = _ACS_instr;
            
            if (_ACS_dop_instr.Count > 0)
                dop_instrTBox.AutoCompleteCustomSource = _ACS_dop_instr;
            else
            {
                dop_instrTBox.AutoCompleteMode = AutoCompleteMode.None;
            }

        }
        /// <summary>
        /// Сохранение автозополнения
        /// </summary>
        public void SaveACS()
        {
            _file = File.Open(ACS_FILE, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            _data_ACS.Serialize(_file, Data_ACS);
            _file.Close();
        }
       
        public Form1()
        {
            InitializeComponent();
            LoadAndRefresh();
            LoadACS();
            
            
        }
      /// <summary>
      /// Проверка на повторяющихся работников
      /// </summary>
      /// <param name="emp">Добовляемый работник</param>
      /// <returns>true если уже есть</returns>
        public bool DublEmpOfOrder(Emp_v2 emp)
        {
            
            bool result = false;
            /*
            if (emp != null)
            {
                
                for (int i = 0; i <= Order.brigada.Count - 1; i++)
                {
                    if (Order.brigada[i] != null)
                    {
                        if (Order.brigada[i].Name == emp.Name)
                        {
                            result = true;
                            break;
                        }
                    }
                }
                if (Order.GiveOrder.Name == emp.Name) result = true;
                if (Order.ForePerson.Name == emp.Name) result = true;
            }*/
            return result;
        }
             
        /// <summary>
        /// Загрузка данных и обнуление формы
        /// </summary>
        public void LoadAndRefresh()
        {
            ListOrder.Load();
            ListEmploy.Load();
            this.ordercountlbl.Text = ListOrder.CountOrder.ToString();

            
            datelbl.Text = DateTime.Today.ToString(DATE_FORMAT);///////////////////////////////////////////////////////////////////////////////////
            
            Order = null;
            Order = new Order_v2();
            Order.date = DateTime.Today;
            Order.brigada.Clear();
            onRewrite();
            

        }
        /// <summary>
        /// Ввод данных в Excel
        /// </summary>
        /// <param name="giveorder">Отдающий распоряжение</param>
        /// <param name="foreperson">Производитель работ</param>
        /// <param name="Team">Бригада</param>
        /// <param name="date">Дата</param>
        /// <param name="estr">Поручается</param>
        /// <param name="instr">Иструктаж</param>
        /// <param name="dop_instr">Другие указания</param>
        /// <returns>true если успешно введены</returns>
        public bool AddOrder(Emp_v2 giveorder, Emp_v2 foreperson, List<Emp_v2> Team, string date, string estr, string instr, string dop_instr)
        {
            bool result = false;
            Excel excel = new Excel();
            try
            {
                excel.OpenDocument(Application.StartupPath + "\\Order1.xltx");
                excel.Visible = true;
                excel.SetValue("D6", date);
                if (estr.Length > 60)
                {
                    string[] strArray1 = estr.Split(Convert.ToChar(" "));
                    int index1 = 0;
                    string[] strArray2 = new string[4]
                    {
                        "",
                        "",
                        "",
                        ""
                    };
                    foreach (string str in strArray1)
                    {
                        string[] strArray3;
                        int index2;
                        (strArray3 = strArray2)[(int)(index2 = (int)index1)] = strArray3[index2] + str + " ";
                        if (strArray2[index1].Length > 60)
                            ++index1;
                    }
                    if (strArray2[0].Length != 0)
                        excel.SetValue("D8", strArray2[0]);
                    if (strArray2[1].Length != 0)
                        excel.SetValue("D9", strArray2[1]);
                    if (strArray2[2].Length != 0)
                        excel.SetValue("D10", strArray2[2]);
                    if (strArray2[3].Length != 0)
                        excel.SetValue("D11", strArray2[3]);
                }
                else
                    excel.SetValue("D8", estr);
                excel.SetValue("E15", giveorder.ToString());
                excel.SetValue("I15", foreperson.ToString());
                excel.SetValue("I20", foreperson.ToString());
                excel.SetValue("I24", Team[0].ToString());
                if (Team.Count > 1 && Team[1] != null)
                    excel.SetValue("I26", Team[1].ToString());
                if (Team.Count > 2 && Team[2] != null)
                    excel.SetValue("I28", Team[2].ToString());
                if (Team.Count > 3 && Team[3] != null)
                    excel.SetValue("I30", Team[3].ToString());
                if (instr.Length > 70)
                {
                    string[] strArray1 = instr.Split(Convert.ToChar(" "));
                    int index1 = 0;
                    string[] strArray2 = new string[4]
          {
            "",
            "",
            "",
            ""
          };
                    foreach (string str in strArray1)
                    {
                        string[] strArray3;
                        int index2;
                        (strArray3 = strArray2)[(int)(index2 = (int)index1)] = strArray3[index2] + str + " ";
                        if (strArray2[index1].Length > 70)
                            ++index1;
                    }
                    if (strArray2[0].Length != 0)
                        excel.SetValue("G33", strArray2[0]);
                    if (strArray2[1].Length != 0)
                        excel.SetValue("G34", strArray2[1]);
                    if (strArray2[2].Length != 0)
                        excel.SetValue("G35", strArray2[2]);
                    if (strArray2[3].Length == 0)
                        excel.SetValue("G36", strArray2[3]);
                }
                else
                    excel.SetValue("G33", instr);
                excel.SetValue("C45", DOP_INSTR + dop_instr);
                result = true;
            }
            catch (Exception ex)
            {
                new Log("Out of Excel " + ex.Message);
            }
            return result;
        }
        /// <summary>
        /// Перезапись формы с новыми данными
        /// </summary>
        void onRewrite()
        {
            datelbl.Text = Order.date.ToString(DATE_FORMAT);//////////////////////////////////////////////////
            instrTBox.Text = Order.instr;
            estrTBox.Text = Order.estr;
            giveOrderlbl.Text = Order.GiveOrder.ToString();
            forePersonlbl.Text = Order.ForePerson.ToString();
            listBox1.Items.Clear();
            ordercountlbl.Text = ListOrder.CountOrder.ToString();
            for (int i = 0; i <= Order.brigada.Count - 1; i++)
            {
                listBox1.Items.Add(Order.brigada[i].ToString());
            }
            NotVerOrder = ListOrder.NotVerifydOrderList();
            if (NotVerOrder.Count != 0)
            {
                notverifyordBox.Visible = true;
                noverifyordlbl.Text = NotVerOrder.Count.ToString();
            }
            else notverifyordBox.Visible = false;
        }
      

        
        /// <summary>
        /// Кнопка Дата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datebtn_Click(object sender, EventArgs e)
        {
            
            fDate.StartPosition = FormStartPosition.Manual;
            
            fDate.Location = new Point((Location.X + datebtn.Location.X), (Location.Y + datebtn.Location.Y));
            fDate.ShowDialog();
            if (fDate._IsSelected)
            {
                Order.date = fDate._Date;
                onRewrite();
                datelbl.Text = Order.date.ToString(DATE_FORMAT);
            }
        }
        /// <summary>
        /// Кнопка Добавить отдающего распоряжение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gOrderbtn_Click(object sender, EventArgs e)
        {

            fEmployes.Emps = ListEmploy.EmployesOfRule(EmpS_v2.R_GIVEORDER); //Инициализация формы с правом отдающего распоряжение
            fEmployes.Location = new Point((Location.X + gOrderbtn.Location.X), (Location.Y + gOrderbtn.Location.Y));
            
            fEmployes.ShowDialog();
            if (fEmployes.SelEmp != null)
            {
                if (!DublEmpOfOrder(fEmployes.SelEmp))
                    Order.GiveOrder = fEmployes.SelEmp;
                else MessageBox.Show(ERR_DUPLECATE_EMP);
            }
            onRewrite();
        }
        /// <summary>
        /// Кнопка Удалить отдающего распоряжение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void giveClearbtn_Click(object sender, EventArgs e)
        {
            Order.GiveOrder = null;
            Order.GiveOrder = new Emp_v2();

            onRewrite();
        }
        /// <summary>
        /// Кнопка Добавить производителя работ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forePbtn_Click(object sender, EventArgs e)
        {
            fEmployes.Emps = ListEmploy.EmployesOfRule(EmpS_v2.R_FOREPERSON);
            fEmployes.Location = new Point((Location.X + forePbtn.Location.X), (Location.Y + forePbtn.Location.Y));

            fEmployes.ShowDialog();

            if (fEmployes.SelEmp != null)
            {
                if (!DublEmpOfOrder(fEmployes.SelEmp))
                    Order.ForePerson = fEmployes.SelEmp;
                else MessageBox.Show(ERR_DUPLECATE_EMP);
                
            }
            onRewrite();

        }

        private void forePClearbtn_Click(object sender, EventArgs e)
        {
            Order.ForePerson = null;
            Order.ForePerson = new Emp_v2();

            onRewrite();
        }
        

        private void addOrderbtn_Click(object sender, EventArgs e)
        {
            Order.estr = estrTBox.Text;
            Order.instr = instrTBox.Text;
            string d_instr = dop_instrTBox.Text;
            Data_ACS.Add(new Data_v2(Order.estr, Order.instr, d_instr));
            SaveACS();
            LoadACS();
            if (Order.estr != "" && Order.instr != "")
            {
                if (Order.GiveOrder.Name != "" && Order.ForePerson.Name != "")
                {
                    
                    if (Order.brigada.Count > 0)
                    {
                        if (AddOrder(Order.GiveOrder, Order.ForePerson, Order.brigada,
                            Order.date.ToString(DATE_FORMAT), Order.estr, Order.instr, d_instr))
                        {
                            ListOrder.AddOrder(Order);
                            
                            Order = new Order_v2();
                            Order.date = DateTime.Today;
                            dop_instrTBox.Clear();
                            
                            onRewrite();
                        }

                    }
                    else MessageBox.Show("Добавьте одного члена бригады. ");
                }
                else MessageBox.Show("Нет отдающего распоряжения или производителя работ.");
            }
            else MessageBox.Show("Нет задания или мер ТБ.");
        }

        private void addchrbtn_Click(object sender, EventArgs e)
        {
            fEmployes.Emps = ListEmploy.EmployesOfRule(EmpS_v2.R_OTHER);
            fEmployes.Location = new Point((Location.X + addchrbtn.Location.X),
                (Location.Y + addchrbtn.Location.Y));
            fEmployes.ShowDialog();
            if (fEmployes.SelEmp != null)
            {
                if (Order.brigada.Count < 4)
                    if (!DublEmpOfOrder(fEmployes.SelEmp))
                    {

                        Order.brigada.Add(fEmployes.SelEmp);


                    }
                    else MessageBox.Show(ERR_DUPLECATE_EMP);
                else MessageBox.Show(BR_OUT_DIAPOSON);
            }
            onRewrite();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (Remove_br)
            {
                
                int i = lb.SelectedIndex;

                if (i != -1)
                    Order.brigada.Remove(Order.brigada[i]);
                
                delchrbtn.Text = "-";
                Remove_br = false;
            }
            onRewrite();
            
            
            
        }

        private void delchrbtn_Click(object sender, EventArgs e)
        {
            delchrbtn.Text = "(-)";
            Remove_br = true;          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Order.brigada.Clear();
            onRewrite();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iconTray = new NotifyIcon();
            iconTray.Icon = this.Icon;
            if (File.Exists(fileVersion))
            {
                FileStream fver = File.Open(fileVersion, FileMode.Open);
                byte[] ver = new byte[fver.Length];
                fver.Read(ver, 0, (int)fver.Length);
                fver.Close();
                string v = Encoding.ASCII.GetString(ver, 0, ver.Length);
                aboutlabel.Text = string.Format(ABOUT_FORMAT, v);
                iconTray.Text = "WorkOrder "+v;
            }
            else
            {
                aboutlabel.Text = string.Format(ABOUT_FORMAT, "");
                iconTray.Text = "WorkOrder";
            }
            
            iconTray.Visible = true;
            iconTray.MouseDoubleClick += new MouseEventHandler(nf_MouseDoubleClick);
        }

        void nf_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                //this.ShowInTaskbar = true;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                //this.ShowInTaskbar = false;
            }
        }

        private void arhivebtn_Click(object sender, EventArgs e)
        {
            fArhive.DesktopLocation = Location;
            fArhive.ListOrder = ListOrder;
            fArhive.ShowDialog();

            
            
            Order_v2 nOrd = new Order_v2();
            if (fArhive.isSelected)
            {

                Order = fArhive.SelOrder;
                Order.date = DateTime.Today;
                onRewrite();
            }
            if (fArhive.IsDeleteAll)
            {
                ListOrder.ClearArhive();
                onRewrite();
            }
        }

        private void EditEmpButton_Click(object sender, EventArgs e)
        {
            fEditEmp.DesktopLocation = Location;
            fEditEmp.ListEmps = ListEmploy.Employees;
            fEditEmp.ShowDialog();

            if (fEditEmp.IsSaved)
            {
                ListEmploy.Employees = fEditEmp.NewListEmp;
                ListEmploy.Save();
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order = new Order_v2();
            Order.date = DateTime.Today;
            dop_instrTBox.Clear();
            onRewrite();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            iconTray.Visible = false;
            iconTray.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            iconTray.Visible = false;
            iconTray.Dispose();
        }

        private void verifyordbtn_Click(object sender, EventArgs e)
        {
            try
            {
                fVerifyOrder.Order = NotVerOrder[0];
                fVerifyOrder.ShowDialog();

                if (fVerifyOrder.IsVerify && fVerifyOrder.Number != 0)
                {
                    if (ListOrder.VerifyOrder(NotVerOrder[0], fVerifyOrder.Number))
                    {
                        onRewrite();
                    }
                }
                if (fVerifyOrder.IsDelOrder)
                {
                    if (ListOrder.DeleteOrderNotVerify(fVerifyOrder.Order))
                        MessageBox.Show("Распоряжение " + (fVerifyOrder.Order.ID + 1) + " удалено");
                    onRewrite();
                }
            }
            catch (Exception ex)
            {
                new Log("Verify error: " + ex.Source + " >>>" + ex.Message);
            }
        }

        private void estrTBox_TextChanged(object sender, EventArgs e)
        {
            Order.estr = estrTBox.Text;
        }

        private void instrTBox_TextChanged(object sender, EventArgs e)
        {
            Order.instr = instrTBox.Text;
        }

       
    }
    
}
