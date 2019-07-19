using oalib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WorkOrder
{

    public partial class Form1 : Form
    {
        #region Forms
        private FrmDate fDate = new FrmDate();
        private FrmEmploy fEmployes = new FrmEmploy();
        private FrmArhive fArhive = new FrmArhive();
        private FrmEditEmploy fEditEmp = new FrmEditEmploy();
        private FrmVerifyOrder fVerifyOrder = new FrmVerifyOrder();
        #endregion

        private AutoCompleteStringCollection _ACS_estr = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _ACS_instr = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection _ACS_dop_instr = new AutoCompleteStringCollection();
        private BinaryFormatter _data_ACS = new BinaryFormatter();
        private FileStream _file;
        private bool Remove_br = false;

        private NotifyIcon iconTray;
        private ListOrder ListOrder = new ListOrder();
        private EmpS ListEmploy = new EmpS();
        private List<Order> NotVerOrder = new List<Order>();
        private Order Order = new Order();
        private List<Data> Data_ACS = new List<Data>();



        /// <summary>
        /// Загрузка автозаполнения
        /// </summary>
        public void LoadACS()
        {
            _ACS_estr.Clear();
            _ACS_instr.Clear();
            _ACS_dop_instr.Clear();
            DataTable dT_estr = SQL.Query("SELECT * FROM 'ac_estr'");
            foreach (DataRow item in dT_estr.Rows)
            {
                string str = item["text"].ToString();
                if (str != "")
                    _ACS_estr.Add(str);
            }

            dT_estr = SQL.Query("SELECT * FROM 'ac_instr'");
            foreach (DataRow item in dT_estr.Rows)
            {
                string str = item["text"].ToString();
                if (str != "")
                    _ACS_instr.Add(str);
            }

            dT_estr = SQL.Query("SELECT * FROM 'ac_instrd'");
            foreach (DataRow item in dT_estr.Rows)
            {
                string str = item["text"].ToString();
                if (str != "")
                    _ACS_dop_instr.Add(str);
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
        public bool DublEmpOfOrder(Emp emp)
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


            this.ordercountlbl.Text = ListOrder.CountOrder.ToString();

            datelbl.Text = DateTime.Today.ToString(Const.DATE_FORMAT);

            Order = null;
            Order = new Order();
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
        public bool AddOrder(Emp giveorder, Emp foreperson, List<Emp> Team, string date, string estr, string instr, string dop_instr)
        {
            bool result = false;
            /*УДАЛИТЬ*/
            //return true;  // УБРАТЬ ПОТОМ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
                excel.SetValue("C45", Const.DOP_INSTR + dop_instr);
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
        private void onRewrite()
        {
            datelbl.Text = Order.date.ToString(Const.DATE_FORMAT);
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
                datelbl.Text = Order.date.ToString(Const.DATE_FORMAT);
            }
        }
        /// <summary>
        /// Кнопка Добавить отдающего распоряжение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gOrderbtn_Click(object sender, EventArgs e)
        {

            fEmployes.Emps = ListEmploy.EmployesOfRule(EmpS.R_GIVEORDER); //Инициализация формы с правом отдающего распоряжение
            fEmployes.Location = new Point((Location.X + gOrderbtn.Location.X), (Location.Y + gOrderbtn.Location.Y));

            fEmployes.ShowDialog();
            if (fEmployes.SelEmp != null)
            {
                if (!DublEmpOfOrder(fEmployes.SelEmp))
                    Order.GiveOrder = fEmployes.SelEmp;
                else MessageBox.Show(Const.ERR_DUPLECATE_EMP);
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
            Order.GiveOrder = new Emp();

            onRewrite();
        }
        /// <summary>
        /// Кнопка Добавить производителя работ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forePbtn_Click(object sender, EventArgs e)
        {
            fEmployes.Emps = ListEmploy.EmployesOfRule(EmpS.R_FOREPERSON);
            fEmployes.Location = new Point((Location.X + forePbtn.Location.X), (Location.Y + forePbtn.Location.Y));

            fEmployes.ShowDialog();

            if (fEmployes.SelEmp != null)
            {
                if (!DublEmpOfOrder(fEmployes.SelEmp))
                    Order.ForePerson = fEmployes.SelEmp;
                else MessageBox.Show(Const.ERR_DUPLECATE_EMP);

            }
            onRewrite();

        }

        private void forePClearbtn_Click(object sender, EventArgs e)
        {
            Order.ForePerson = null;
            Order.ForePerson = new Emp();

            onRewrite();
        }


        private void addOrderbtn_Click(object sender, EventArgs e)
        {
            Order.estr = estrTBox.Text;
            Order.instr = instrTBox.Text;
            string d_instr = dop_instrTBox.Text;
            //Data_ACS.Add(new Data_v2(Order.estr, Order.instr, d_instr));
            SQL.InsertAC(new Data(Order.estr, Order.instr, d_instr));
            //LoadACS();
            if (Order.estr != "" && Order.instr != "")
            {
                if (Order.GiveOrder.Name != "" && Order.ForePerson.Name != "")
                {

                    if (Order.brigada.Count > 0)
                    {
                        if (AddOrder(Order.GiveOrder, Order.ForePerson, Order.brigada,
                            Order.date.ToString(Const.DATE_FORMAT), Order.estr, Order.instr, d_instr))
                        {
                            ListOrder.AddOrder(Order);

                            Order = new Order();
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
            List<Emp> list = new List<Emp>();
            list = ListEmploy.EmployesOfRule(EmpS.R_OTHER);
            list.Remove(Order.ForePerson);
            list.Remove(Order.GiveOrder);
            fEmployes.Emps = list;
            fEmployes.SelList = Order.brigada;
            fEmployes.Location = new Point((Location.X + addchrbtn.Location.X),
                (Location.Y + addchrbtn.Location.Y));
            fEmployes.ShowDialog();
            
            //if (fEmployes.SelEmp != null)
            //{
            //    if (Order.brigada.Count < 4)
            //        if (!DublEmpOfOrder(fEmployes.SelEmp))
            //        {

            //            Order.brigada.Add(fEmployes.SelEmp);


            //        }
            //        else MessageBox.Show(Const.ERR_DUPLECATE_EMP);
            //    else MessageBox.Show(Const.BR_OUT_DIAPOSON);
            //}
            if (fEmployes.SelList.Count > 0)
            {
                Order.brigada = fEmployes.SelList;
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

            aboutlabel.Text = string.Format(Const.ABOUT_FORMAT, SQL.Version("WorkOrder"));
            iconTray.Text = "WorkOrder " + SQL.Version("WorkOrder");


            iconTray.Visible = true;
            iconTray.MouseDoubleClick += new MouseEventHandler(nf_MouseDoubleClick);
        }

        private void nf_MouseDoubleClick(object sender, MouseEventArgs e)
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

            fArhive.ShowDialog();

            Order nOrd = new Order();
            if (fArhive.isSelected)
                Order = fArhive.SelOrder;
            Order.date = DateTime.Today;
            onRewrite();
        }



        private void EditEmpButton_Click(object sender, EventArgs e)
        {
            fEditEmp.DesktopLocation = Location;
            fEditEmp.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order = new Order();
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

            fVerifyOrder.DesktopLocation = Location;
            fVerifyOrder.ShowDialog();
            onRewrite();


        }

        private void estrTBox_TextChanged(object sender, EventArgs e)
        {
            Order.estr = estrTBox.Text;
        }

        private void instrTBox_TextChanged(object sender, EventArgs e)
        {
            Order.instr = instrTBox.Text;
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {

        }
    }

}
