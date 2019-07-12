namespace WorkOrder
{
    partial class FrmEditEmploy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditEmploy));
            this.listEmpLBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.rGiveOrderChBox = new System.Windows.Forms.CheckBox();
            this.rForePersonChBox = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.editButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.delbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listEmpLBox
            // 
            this.listEmpLBox.FormattingEnabled = true;
            this.listEmpLBox.Location = new System.Drawing.Point(12, 12);
            this.listEmpLBox.Name = "listEmpLBox";
            this.listEmpLBox.Size = new System.Drawing.Size(286, 342);
            this.listEmpLBox.TabIndex = 0;
            this.listEmpLBox.SelectedIndexChanged += new System.EventHandler(this.listEmpLBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Группа";
            // 
            // nameTBox
            // 
            this.nameTBox.Location = new System.Drawing.Point(395, 22);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(207, 20);
            this.nameTBox.TabIndex = 5;
            // 
            // rGiveOrderChBox
            // 
            this.rGiveOrderChBox.AutoSize = true;
            this.rGiveOrderChBox.Location = new System.Drawing.Point(395, 86);
            this.rGiveOrderChBox.Name = "rGiveOrderChBox";
            this.rGiveOrderChBox.Size = new System.Drawing.Size(157, 17);
            this.rGiveOrderChBox.TabIndex = 6;
            this.rGiveOrderChBox.Text = "Отдающий распоряжение";
            this.rGiveOrderChBox.UseVisualStyleBackColor = true;
            // 
            // rForePersonChBox
            // 
            this.rForePersonChBox.AutoSize = true;
            this.rForePersonChBox.Location = new System.Drawing.Point(395, 124);
            this.rForePersonChBox.Name = "rForePersonChBox";
            this.rForePersonChBox.Size = new System.Drawing.Size(137, 17);
            this.rForePersonChBox.TabIndex = 7;
            this.rForePersonChBox.Text = "Производитель работ";
            this.rForePersonChBox.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Location = new System.Drawing.Point(395, 54);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(120, 20);
            this.groupBox.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addButton.ImageIndex = 2;
            this.addButton.ImageList = this.imageList1;
            this.addButton.Location = new System.Drawing.Point(335, 156);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 34);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "17.png");
            this.imageList1.Images.SetKeyName(1, "18.png");
            this.imageList1.Images.SetKeyName(2, "20.png");
            this.imageList1.Images.SetKeyName(3, "29.png");
            // 
            // editButton
            // 
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.ImageIndex = 1;
            this.editButton.ImageList = this.imageList1;
            this.editButton.Location = new System.Drawing.Point(466, 156);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(122, 34);
            this.editButton.TabIndex = 10;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // abortButton
            // 
            this.abortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abortButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.abortButton.ImageIndex = 1;
            this.abortButton.ImageList = this.imageList1;
            this.abortButton.Location = new System.Drawing.Point(503, 345);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(122, 36);
            this.abortButton.TabIndex = 12;
            this.abortButton.Text = "Закрыть";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(12, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "* - Отдающий распоряжение\r\n# - Производитель работ";
            // 
            // delbutton
            // 
            this.delbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delbutton.ImageIndex = 0;
            this.delbutton.ImageList = this.imageList1;
            this.delbutton.Location = new System.Drawing.Point(335, 212);
            this.delbutton.Name = "delbutton";
            this.delbutton.Size = new System.Drawing.Size(253, 34);
            this.delbutton.TabIndex = 14;
            this.delbutton.Text = "Удалить";
            this.delbutton.UseVisualStyleBackColor = true;
            this.delbutton.Click += new System.EventHandler(this.delbutton_Click);
            // 
            // FrmEditEmploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 398);
            this.Controls.Add(this.delbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.rForePersonChBox);
            this.Controls.Add(this.rGiveOrderChBox);
            this.Controls.Add(this.nameTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listEmpLBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditEmploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Работники";
            this.Load += new System.EventHandler(this.frmEditEmploy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listEmpLBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.CheckBox rGiveOrderChBox;
        private System.Windows.Forms.CheckBox rForePersonChBox;
        private System.Windows.Forms.NumericUpDown groupBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button delbutton;
    }
}