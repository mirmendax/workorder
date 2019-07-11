namespace SQLEditor
{
    partial class TableEmp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.emp_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_rgiveorder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.emp_foreperson = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emp_id,
            this.emp_name,
            this.emp_group,
            this.emp_rgiveorder,
            this.emp_foreperson});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // emp_id
            // 
            this.emp_id.HeaderText = "ID";
            this.emp_id.Name = "emp_id";
            this.emp_id.ReadOnly = true;
            // 
            // emp_name
            // 
            this.emp_name.HeaderText = "Имя";
            this.emp_name.Name = "emp_name";
            this.emp_name.Width = 200;
            // 
            // emp_group
            // 
            this.emp_group.HeaderText = "Группа";
            this.emp_group.Name = "emp_group";
            // 
            // emp_rgiveorder
            // 
            this.emp_rgiveorder.HeaderText = "Выдающий";
            this.emp_rgiveorder.Name = "emp_rgiveorder";
            // 
            // emp_foreperson
            // 
            this.emp_foreperson.HeaderText = "Производитель";
            this.emp_foreperson.Name = "emp_foreperson";
            // 
            // TableEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TableEmp";
            this.Text = "TableEmp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_group;
        private System.Windows.Forms.DataGridViewCheckBoxColumn emp_rgiveorder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn emp_foreperson;
    }
}