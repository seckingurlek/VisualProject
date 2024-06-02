namespace EduConnect
{
    partial class CateriaPage
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
            this.dataGridView1NotAllowed = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ProductComboBox1 = new System.Windows.Forms.ComboBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textStudentName = new System.Windows.Forms.TextBox();
            this.textBalance = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1NotAllowed)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1NotAllowed
            // 
            this.dataGridView1NotAllowed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1NotAllowed.Location = new System.Drawing.Point(25, 40);
            this.dataGridView1NotAllowed.Name = "dataGridView1NotAllowed";
            this.dataGridView1NotAllowed.RowHeadersWidth = 51;
            this.dataGridView1NotAllowed.RowTemplate.Height = 24;
            this.dataGridView1NotAllowed.Size = new System.Drawing.Size(388, 274);
            this.dataGridView1NotAllowed.TabIndex = 0;
            this.dataGridView1NotAllowed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Not Allawed Products";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ProductComboBox1
            // 
            this.ProductComboBox1.FormattingEnabled = true;
            this.ProductComboBox1.Location = new System.Drawing.Point(25, 389);
            this.ProductComboBox1.Name = "ProductComboBox1";
            this.ProductComboBox1.Size = new System.Drawing.Size(272, 24);
            this.ProductComboBox1.TabIndex = 4;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(615, 388);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(124, 50);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(443, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textStudentName
            // 
            this.textStudentName.Location = new System.Drawing.Point(25, 320);
            this.textStudentName.Name = "textStudentName";
            this.textStudentName.Size = new System.Drawing.Size(100, 22);
            this.textStudentName.TabIndex = 7;
            this.textStudentName.Text = "NULL";
            // 
            // textBalance
            // 
            this.textBalance.Location = new System.Drawing.Point(25, 348);
            this.textBalance.Name = "textBalance";
            this.textBalance.Size = new System.Drawing.Size(100, 22);
            this.textBalance.TabIndex = 8;
            this.textBalance.Text = "NULL";
            // 
            // lblStock
            // 
            this.lblStock.Location = new System.Drawing.Point(467, 348);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(100, 22);
            this.lblStock.TabIndex = 9;
            this.lblStock.Text = "NULL";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(467, 320);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 22);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "NULL";
            this.lblPrice.TextChanged += new System.EventHandler(this.lblPrice_TextChanged);
            // 
            // CateriaPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.textBalance);
            this.Controls.Add(this.textStudentName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.ProductComboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1NotAllowed);
            this.Name = "CateriaPage";
            this.Text = "CateriaPage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1NotAllowed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1NotAllowed;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox ProductComboBox1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textStudentName;
        private System.Windows.Forms.TextBox textBalance;
        private System.Windows.Forms.TextBox lblStock;
        private System.Windows.Forms.TextBox lblPrice;
    }
}