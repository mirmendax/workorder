namespace WorkOrder
{
    partial class FrmVerifyOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerifyOrder));
            this.estrlbl = new System.Windows.Forms.Label();
            this.giveprslbl = new System.Windows.Forms.Label();
            this.foreprslbl = new System.Windows.Forms.Label();
            this.brglbl = new System.Windows.Forms.Label();
            this.instlbl = new System.Windows.Forms.Label();
            this.verifybtn = new System.Windows.Forms.Button();
            this.datelbl = new System.Windows.Forms.Label();
            this.delordbtn = new System.Windows.Forms.Button();
            this.numberTBox = new System.Windows.Forms.NumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numberTBox)).BeginInit();
            this.SuspendLayout();
            // 
            // estrlbl
            // 
            this.estrlbl.AutoEllipsis = true;
            this.estrlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.estrlbl.Location = new System.Drawing.Point(12, 30);
            this.estrlbl.Name = "estrlbl";
            this.estrlbl.Size = new System.Drawing.Size(434, 39);
            this.estrlbl.TabIndex = 0;
            this.estrlbl.Text = "none";
            // 
            // giveprslbl
            // 
            this.giveprslbl.AutoSize = true;
            this.giveprslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.giveprslbl.Location = new System.Drawing.Point(12, 76);
            this.giveprslbl.Name = "giveprslbl";
            this.giveprslbl.Size = new System.Drawing.Size(35, 13);
            this.giveprslbl.TabIndex = 1;
            this.giveprslbl.Text = "none";
            // 
            // foreprslbl
            // 
            this.foreprslbl.AutoSize = true;
            this.foreprslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foreprslbl.Location = new System.Drawing.Point(222, 76);
            this.foreprslbl.Name = "foreprslbl";
            this.foreprslbl.Size = new System.Drawing.Size(35, 13);
            this.foreprslbl.TabIndex = 2;
            this.foreprslbl.Text = "none";
            // 
            // brglbl
            // 
            this.brglbl.AutoEllipsis = true;
            this.brglbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brglbl.Location = new System.Drawing.Point(222, 99);
            this.brglbl.Name = "brglbl";
            this.brglbl.Size = new System.Drawing.Size(134, 88);
            this.brglbl.TabIndex = 3;
            this.brglbl.Text = "none";
            // 
            // instlbl
            // 
            this.instlbl.AutoEllipsis = true;
            this.instlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.instlbl.Location = new System.Drawing.Point(12, 195);
            this.instlbl.Name = "instlbl";
            this.instlbl.Size = new System.Drawing.Size(434, 33);
            this.instlbl.TabIndex = 4;
            this.instlbl.Text = "label1";
            // 
            // verifybtn
            // 
            this.verifybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.verifybtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.verifybtn.ImageIndex = 1;
            this.verifybtn.ImageList = this.imageList1;
            this.verifybtn.Location = new System.Drawing.Point(136, 237);
            this.verifybtn.Name = "verifybtn";
            this.verifybtn.Size = new System.Drawing.Size(137, 43);
            this.verifybtn.TabIndex = 6;
            this.verifybtn.Text = "Подтвердить";
            this.verifybtn.UseVisualStyleBackColor = true;
            this.verifybtn.Click += new System.EventHandler(this.verifybtn_Click);
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datelbl.Location = new System.Drawing.Point(12, 8);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(57, 13);
            this.datelbl.TabIndex = 7;
            this.datelbl.Text = "00.00.00";
            // 
            // delordbtn
            // 
            this.delordbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delordbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delordbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delordbtn.ImageIndex = 0;
            this.delordbtn.ImageList = this.imageList1;
            this.delordbtn.Location = new System.Drawing.Point(292, 237);
            this.delordbtn.Name = "delordbtn";
            this.delordbtn.Size = new System.Drawing.Size(137, 43);
            this.delordbtn.TabIndex = 8;
            this.delordbtn.Text = "Удалить";
            this.delordbtn.UseVisualStyleBackColor = true;
            this.delordbtn.Click += new System.EventHandler(this.delordbtn_Click);
            // 
            // numberTBox
            // 
            this.numberTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberTBox.Location = new System.Drawing.Point(12, 238);
            this.numberTBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numberTBox.Name = "numberTBox";
            this.numberTBox.Size = new System.Drawing.Size(100, 42);
            this.numberTBox.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "17.png");
            this.imageList1.Images.SetKeyName(1, "18.png");
            // 
            // FrmVerifyOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 292);
            this.Controls.Add(this.numberTBox);
            this.Controls.Add(this.delordbtn);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.verifybtn);
            this.Controls.Add(this.instlbl);
            this.Controls.Add(this.brglbl);
            this.Controls.Add(this.foreprslbl);
            this.Controls.Add(this.giveprslbl);
            this.Controls.Add(this.estrlbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerifyOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтверждение работы по распоряжению";
            this.Load += new System.EventHandler(this.FrmVerifyOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberTBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label estrlbl;
        private System.Windows.Forms.Label giveprslbl;
        private System.Windows.Forms.Label foreprslbl;
        private System.Windows.Forms.Label brglbl;
        private System.Windows.Forms.Label instlbl;
        private System.Windows.Forms.Button verifybtn;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Button delordbtn;
        private System.Windows.Forms.NumericUpDown numberTBox;
        private System.Windows.Forms.ImageList imageList1;
    }
}