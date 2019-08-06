namespace WorkOrder
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.aboutlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.estrTBox = new System.Windows.Forms.TextBox();
            this.datebtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gOrderbtn = new System.Windows.Forms.Button();
            this.giveOrderlbl = new System.Windows.Forms.Label();
            this.forePersonlbl = new System.Windows.Forms.Label();
            this.forePbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.giveClearbtn = new System.Windows.Forms.Button();
            this.forePClearbtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.delchrbtn = new System.Windows.Forms.Button();
            this.addchrbtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.instrTBox = new System.Windows.Forms.TextBox();
            this.addOrderbtn = new System.Windows.Forms.Button();
            this.arhivebtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ordercountlbl = new System.Windows.Forms.Label();
            this.notverifyordBox = new System.Windows.Forms.GroupBox();
            this.verifyordbtn = new System.Windows.Forms.Button();
            this.noverifyordlbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EditEmpButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dop_instrTBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tech_TBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.notverifyordBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutlabel
            // 
            this.aboutlabel.AutoSize = true;
            this.aboutlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutlabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.aboutlabel.Location = new System.Drawing.Point(122, 701);
            this.aboutlabel.Name = "aboutlabel";
            this.aboutlabel.Size = new System.Drawing.Size(40, 13);
            this.aboutlabel.TabIndex = 0;
            this.aboutlabel.Text = "About";
            this.aboutlabel.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Поручается";
            // 
            // estrTBox
            // 
            this.estrTBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Hello",
            "helo from"});
            this.estrTBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.estrTBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.estrTBox.Location = new System.Drawing.Point(9, 79);
            this.estrTBox.Name = "estrTBox";
            this.estrTBox.Size = new System.Drawing.Size(623, 20);
            this.estrTBox.TabIndex = 2;
            this.estrTBox.TextChanged += new System.EventHandler(this.estrTBox_TextChanged);
            // 
            // datebtn
            // 
            this.datebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.datebtn.ImageIndex = 9;
            this.datebtn.ImageList = this.imageList1;
            this.datebtn.Location = new System.Drawing.Point(12, 5);
            this.datebtn.Name = "datebtn";
            this.datebtn.Size = new System.Drawing.Size(180, 36);
            this.datebtn.TabIndex = 3;
            this.datebtn.Text = "Дата";
            this.datebtn.UseVisualStyleBackColor = true;
            this.datebtn.Click += new System.EventHandler(this.datebtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "12.png");
            this.imageList1.Images.SetKeyName(1, "17.png");
            this.imageList1.Images.SetKeyName(2, "18.png");
            this.imageList1.Images.SetKeyName(3, "19.png");
            this.imageList1.Images.SetKeyName(4, "20.png");
            this.imageList1.Images.SetKeyName(5, "43.png");
            this.imageList1.Images.SetKeyName(6, "98.png");
            this.imageList1.Images.SetKeyName(7, "11.png");
            this.imageList1.Images.SetKeyName(8, "36.png");
            this.imageList1.Images.SetKeyName(9, "54.png");
            this.imageList1.Images.SetKeyName(10, "warn.ico");
            this.imageList1.Images.SetKeyName(11, "provider.ico");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Отдающий распоряжение:";
            // 
            // gOrderbtn
            // 
            this.gOrderbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gOrderbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gOrderbtn.ImageIndex = 4;
            this.gOrderbtn.ImageList = this.imageList1;
            this.gOrderbtn.Location = new System.Drawing.Point(199, 57);
            this.gOrderbtn.Name = "gOrderbtn";
            this.gOrderbtn.Size = new System.Drawing.Size(35, 35);
            this.gOrderbtn.TabIndex = 5;
            this.gOrderbtn.UseVisualStyleBackColor = true;
            this.gOrderbtn.Click += new System.EventHandler(this.gOrderbtn_Click);
            // 
            // giveOrderlbl
            // 
            this.giveOrderlbl.AutoSize = true;
            this.giveOrderlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.giveOrderlbl.Location = new System.Drawing.Point(6, 67);
            this.giveOrderlbl.Name = "giveOrderlbl";
            this.giveOrderlbl.Size = new System.Drawing.Size(33, 15);
            this.giveOrderlbl.TabIndex = 6;
            this.giveOrderlbl.Text = "Нет";
            // 
            // forePersonlbl
            // 
            this.forePersonlbl.AutoSize = true;
            this.forePersonlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forePersonlbl.Location = new System.Drawing.Point(6, 67);
            this.forePersonlbl.Name = "forePersonlbl";
            this.forePersonlbl.Size = new System.Drawing.Size(33, 15);
            this.forePersonlbl.TabIndex = 9;
            this.forePersonlbl.Text = "Нет";
            // 
            // forePbtn
            // 
            this.forePbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forePbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forePbtn.ImageIndex = 4;
            this.forePbtn.ImageList = this.imageList1;
            this.forePbtn.Location = new System.Drawing.Point(180, 57);
            this.forePbtn.Name = "forePbtn";
            this.forePbtn.Size = new System.Drawing.Size(35, 35);
            this.forePbtn.TabIndex = 8;
            this.forePbtn.UseVisualStyleBackColor = true;
            this.forePbtn.Click += new System.EventHandler(this.forePbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Производитель работ:";
            // 
            // giveClearbtn
            // 
            this.giveClearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giveClearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.giveClearbtn.ImageKey = "19.png";
            this.giveClearbtn.ImageList = this.imageList1;
            this.giveClearbtn.Location = new System.Drawing.Point(240, 57);
            this.giveClearbtn.Name = "giveClearbtn";
            this.giveClearbtn.Size = new System.Drawing.Size(35, 35);
            this.giveClearbtn.TabIndex = 10;
            this.giveClearbtn.UseVisualStyleBackColor = true;
            this.giveClearbtn.Click += new System.EventHandler(this.giveClearbtn_Click);
            // 
            // forePClearbtn
            // 
            this.forePClearbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forePClearbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forePClearbtn.ImageKey = "19.png";
            this.forePClearbtn.ImageList = this.imageList1;
            this.forePClearbtn.Location = new System.Drawing.Point(221, 57);
            this.forePClearbtn.Name = "forePClearbtn";
            this.forePClearbtn.Size = new System.Drawing.Size(35, 35);
            this.forePClearbtn.TabIndex = 11;
            this.forePClearbtn.UseVisualStyleBackColor = true;
            this.forePClearbtn.Click += new System.EventHandler(this.forePClearbtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Члены бригады";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gOrderbtn);
            this.groupBox1.Controls.Add(this.giveClearbtn);
            this.groupBox1.Controls.Add(this.giveOrderlbl);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(9, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 105);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.forePbtn);
            this.groupBox2.Controls.Add(this.forePClearbtn);
            this.groupBox2.Controls.Add(this.forePersonlbl);
            this.groupBox2.Location = new System.Drawing.Point(369, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 105);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.delchrbtn);
            this.groupBox3.Controls.Add(this.addchrbtn);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(369, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 264);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(9, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 46);
            this.button1.TabIndex = 16;
            this.button1.Text = "Отчистить список";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // delchrbtn
            // 
            this.delchrbtn.BackColor = System.Drawing.SystemColors.Control;
            this.delchrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delchrbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delchrbtn.ImageIndex = 3;
            this.delchrbtn.ImageList = this.imageList1;
            this.delchrbtn.Location = new System.Drawing.Point(138, 174);
            this.delchrbtn.Name = "delchrbtn";
            this.delchrbtn.Size = new System.Drawing.Size(118, 32);
            this.delchrbtn.TabIndex = 15;
            this.delchrbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.delchrbtn.UseVisualStyleBackColor = true;
            this.delchrbtn.Click += new System.EventHandler(this.delchrbtn_Click);
            // 
            // addchrbtn
            // 
            this.addchrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addchrbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addchrbtn.ImageIndex = 4;
            this.addchrbtn.ImageList = this.imageList1;
            this.addchrbtn.Location = new System.Drawing.Point(9, 174);
            this.addchrbtn.Name = "addchrbtn";
            this.addchrbtn.Size = new System.Drawing.Size(118, 32);
            this.addchrbtn.TabIndex = 14;
            this.addchrbtn.UseVisualStyleBackColor = true;
            this.addchrbtn.Click += new System.EventHandler(this.addchrbtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 34);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(247, 134);
            this.listBox1.TabIndex = 13;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datelbl.Location = new System.Drawing.Point(67, 44);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(71, 15);
            this.datelbl.TabIndex = 31;
            this.datelbl.Text = "0.00.0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Содержание инструктажа";
            // 
            // instrTBox
            // 
            this.instrTBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.instrTBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.instrTBox.Location = new System.Drawing.Point(9, 483);
            this.instrTBox.Name = "instrTBox";
            this.instrTBox.Size = new System.Drawing.Size(623, 20);
            this.instrTBox.TabIndex = 33;
            this.instrTBox.TextChanged += new System.EventHandler(this.instrTBox_TextChanged);
            // 
            // addOrderbtn
            // 
            this.addOrderbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addOrderbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addOrderbtn.ImageIndex = 5;
            this.addOrderbtn.ImageList = this.imageList1;
            this.addOrderbtn.Location = new System.Drawing.Point(9, 621);
            this.addOrderbtn.Name = "addOrderbtn";
            this.addOrderbtn.Size = new System.Drawing.Size(623, 29);
            this.addOrderbtn.TabIndex = 34;
            this.addOrderbtn.Text = "Заполнить";
            this.addOrderbtn.UseVisualStyleBackColor = true;
            this.addOrderbtn.Click += new System.EventHandler(this.addOrderbtn_Click);
            // 
            // arhivebtn
            // 
            this.arhivebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.arhivebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arhivebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.arhivebtn.ImageKey = "36.png";
            this.arhivebtn.ImageList = this.imageList1;
            this.arhivebtn.Location = new System.Drawing.Point(18, 375);
            this.arhivebtn.Name = "arhivebtn";
            this.arhivebtn.Size = new System.Drawing.Size(233, 43);
            this.arhivebtn.TabIndex = 35;
            this.arhivebtn.Text = "Архив";
            this.arhivebtn.UseVisualStyleBackColor = true;
            this.arhivebtn.Click += new System.EventHandler(this.arhivebtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Всего распоряжений";
            // 
            // ordercountlbl
            // 
            this.ordercountlbl.AutoSize = true;
            this.ordercountlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ordercountlbl.Location = new System.Drawing.Point(183, 428);
            this.ordercountlbl.Name = "ordercountlbl";
            this.ordercountlbl.Size = new System.Drawing.Size(16, 17);
            this.ordercountlbl.TabIndex = 37;
            this.ordercountlbl.Text = "0";
            // 
            // notverifyordBox
            // 
            this.notverifyordBox.Controls.Add(this.verifyordbtn);
            this.notverifyordBox.Controls.Add(this.noverifyordlbl);
            this.notverifyordBox.Controls.Add(this.label8);
            this.notverifyordBox.Location = new System.Drawing.Point(9, 216);
            this.notverifyordBox.Name = "notverifyordBox";
            this.notverifyordBox.Size = new System.Drawing.Size(284, 100);
            this.notverifyordBox.TabIndex = 38;
            this.notverifyordBox.TabStop = false;
            this.notverifyordBox.Visible = false;
            // 
            // verifyordbtn
            // 
            this.verifyordbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyordbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verifyordbtn.ForeColor = System.Drawing.Color.Red;
            this.verifyordbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verifyordbtn.ImageIndex = 10;
            this.verifyordbtn.ImageList = this.imageList1;
            this.verifyordbtn.Location = new System.Drawing.Point(9, 45);
            this.verifyordbtn.Name = "verifyordbtn";
            this.verifyordbtn.Size = new System.Drawing.Size(233, 49);
            this.verifyordbtn.TabIndex = 2;
            this.verifyordbtn.TabStop = false;
            this.verifyordbtn.Text = "Подтвердить";
            this.verifyordbtn.UseVisualStyleBackColor = true;
            this.verifyordbtn.Click += new System.EventHandler(this.verifyordbtn_Click);
            // 
            // noverifyordlbl
            // 
            this.noverifyordlbl.AutoSize = true;
            this.noverifyordlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.noverifyordlbl.ForeColor = System.Drawing.Color.Red;
            this.noverifyordlbl.Location = new System.Drawing.Point(258, 14);
            this.noverifyordlbl.Name = "noverifyordlbl";
            this.noverifyordlbl.Size = new System.Drawing.Size(17, 17);
            this.noverifyordlbl.TabIndex = 1;
            this.noverifyordlbl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Неподтвержденных распоряжений";
            // 
            // EditEmpButton
            // 
            this.EditEmpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditEmpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditEmpButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditEmpButton.ImageIndex = 0;
            this.EditEmpButton.ImageList = this.imageList1;
            this.EditEmpButton.Location = new System.Drawing.Point(18, 322);
            this.EditEmpButton.Name = "EditEmpButton";
            this.EditEmpButton.Size = new System.Drawing.Size(233, 43);
            this.EditEmpButton.TabIndex = 39;
            this.EditEmpButton.Text = "Список работников";
            this.EditEmpButton.UseVisualStyleBackColor = true;
            this.EditEmpButton.Click += new System.EventHandler(this.EditEmpButton_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 1;
            this.button2.ImageList = this.imageList1;
            this.button2.Location = new System.Drawing.Point(9, 656);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(623, 29);
            this.button2.TabIndex = 40;
            this.button2.Text = "Отчистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dop_instrTBox
            // 
            this.dop_instrTBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dop_instrTBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.dop_instrTBox.Location = new System.Drawing.Point(9, 578);
            this.dop_instrTBox.Name = "dop_instrTBox";
            this.dop_instrTBox.Size = new System.Drawing.Size(623, 20);
            this.dop_instrTBox.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 560);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Другие указания по характеру и месту работы: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 504);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 15);
            this.label9.TabIndex = 32;
            this.label9.Text = "Технические мероприятия:";
            // 
            // tech_TBox
            // 
            this.tech_TBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tech_TBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tech_TBox.Location = new System.Drawing.Point(9, 522);
            this.tech_TBox.Name = "tech_TBox";
            this.tech_TBox.Size = new System.Drawing.Size(623, 20);
            this.tech_TBox.TabIndex = 33;
            this.tech_TBox.TextChanged += new System.EventHandler(this.instrTBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 722);
            this.Controls.Add(this.dop_instrTBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EditEmpButton);
            this.Controls.Add(this.notverifyordBox);
            this.Controls.Add(this.ordercountlbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.arhivebtn);
            this.Controls.Add(this.addOrderbtn);
            this.Controls.Add(this.tech_TBox);
            this.Controls.Add(this.instrTBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datebtn);
            this.Controls.Add(this.estrTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aboutlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма распоряжений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.notverifyordBox.ResumeLayout(false);
            this.notverifyordBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutlabel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button datebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button gOrderbtn;
        private System.Windows.Forms.Label giveOrderlbl;
        private System.Windows.Forms.Label forePersonlbl;
        private System.Windows.Forms.Button forePbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button giveClearbtn;
        private System.Windows.Forms.Button forePClearbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox instrTBox;
        private System.Windows.Forms.Button addOrderbtn;
        private System.Windows.Forms.Button arhivebtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ordercountlbl;
        private System.Windows.Forms.GroupBox notverifyordBox;
        private System.Windows.Forms.Button verifyordbtn;
        private System.Windows.Forms.Label noverifyordlbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox estrTBox;
        private System.Windows.Forms.Button delchrbtn;
        private System.Windows.Forms.Button addchrbtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button EditEmpButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox dop_instrTBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tech_TBox;
    }
}

