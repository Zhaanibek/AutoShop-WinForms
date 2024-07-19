namespace ProjectOSh14
{
    partial class OrderForm
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
            this.AddForType = new System.Windows.Forms.ComboBox();
            this.AddForName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.AddForOrderButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DeleteFromOrderButton = new System.Windows.Forms.Button();
            this.ConfirmOrderButton = new System.Windows.Forms.Button();
            this.CancelOrderButton = new System.Windows.Forms.Button();
            this.DeleteOrder = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.AddLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DeleteLabel = new System.Windows.Forms.Label();
            this.TotalCostLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddForType
            // 
            this.AddForType.FormattingEnabled = true;
            this.AddForType.Location = new System.Drawing.Point(81, 118);
            this.AddForType.Name = "AddForType";
            this.AddForType.Size = new System.Drawing.Size(200, 33);
            this.AddForType.TabIndex = 0;
            // 
            // AddForName
            // 
            this.AddForName.FormattingEnabled = true;
            this.AddForName.Location = new System.Drawing.Point(81, 242);
            this.AddForName.Name = "AddForName";
            this.AddForName.Size = new System.Drawing.Size(200, 33);
            this.AddForName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type of product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(76, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name of product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(76, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(81, 375);
            this.textBoxQuantity.Multiline = true;
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(200, 31);
            this.textBoxQuantity.TabIndex = 5;
            // 
            // AddForOrderButton
            // 
            this.AddForOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddForOrderButton.ForeColor = System.Drawing.Color.White;
            this.AddForOrderButton.Location = new System.Drawing.Point(81, 591);
            this.AddForOrderButton.Name = "AddForOrderButton";
            this.AddForOrderButton.Size = new System.Drawing.Size(124, 72);
            this.AddForOrderButton.TabIndex = 6;
            this.AddForOrderButton.Text = "Add for order";
            this.AddForOrderButton.UseVisualStyleBackColor = true;
            this.AddForOrderButton.Click += new System.EventHandler(this.AddForOrderButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 505);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(360, 31);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(76, 448);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date";
            // 
            // DeleteFromOrderButton
            // 
            this.DeleteFromOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteFromOrderButton.ForeColor = System.Drawing.Color.White;
            this.DeleteFromOrderButton.Location = new System.Drawing.Point(81, 827);
            this.DeleteFromOrderButton.Name = "DeleteFromOrderButton";
            this.DeleteFromOrderButton.Size = new System.Drawing.Size(124, 72);
            this.DeleteFromOrderButton.TabIndex = 9;
            this.DeleteFromOrderButton.Text = "Delete from order";
            this.DeleteFromOrderButton.UseVisualStyleBackColor = true;
            this.DeleteFromOrderButton.Click += new System.EventHandler(this.DeleteFromOrderButton_Click);
            // 
            // ConfirmOrderButton
            // 
            this.ConfirmOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmOrderButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmOrderButton.Location = new System.Drawing.Point(1248, 776);
            this.ConfirmOrderButton.Name = "ConfirmOrderButton";
            this.ConfirmOrderButton.Size = new System.Drawing.Size(124, 72);
            this.ConfirmOrderButton.TabIndex = 10;
            this.ConfirmOrderButton.Text = "Confirm order";
            this.ConfirmOrderButton.UseVisualStyleBackColor = true;
            this.ConfirmOrderButton.Click += new System.EventHandler(this.ConfirmOrderButton_Click);
            // 
            // CancelOrderButton
            // 
            this.CancelOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelOrderButton.ForeColor = System.Drawing.Color.White;
            this.CancelOrderButton.Location = new System.Drawing.Point(561, 776);
            this.CancelOrderButton.Name = "CancelOrderButton";
            this.CancelOrderButton.Size = new System.Drawing.Size(124, 72);
            this.CancelOrderButton.TabIndex = 11;
            this.CancelOrderButton.Text = "Cancel this order";
            this.CancelOrderButton.UseVisualStyleBackColor = true;
            this.CancelOrderButton.Click += new System.EventHandler(this.CancelOrderButton_Click);
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.FormattingEnabled = true;
            this.DeleteOrder.Location = new System.Drawing.Point(81, 741);
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(200, 33);
            this.DeleteOrder.TabIndex = 13;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(561, 118);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(811, 604);
            this.listBox1.TabIndex = 14;
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.ForeColor = System.Drawing.Color.Red;
            this.AddLabel.Location = new System.Drawing.Point(76, 688);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(0, 25);
            this.AddLabel.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(755, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 25);
            this.label5.TabIndex = 16;
            // 
            // DeleteLabel
            // 
            this.DeleteLabel.AutoSize = true;
            this.DeleteLabel.ForeColor = System.Drawing.Color.Red;
            this.DeleteLabel.Location = new System.Drawing.Point(76, 926);
            this.DeleteLabel.Name = "DeleteLabel";
            this.DeleteLabel.Size = new System.Drawing.Size(0, 25);
            this.DeleteLabel.TabIndex = 17;
            // 
            // TotalCostLabel
            // 
            this.TotalCostLabel.AutoSize = true;
            this.TotalCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalCostLabel.ForeColor = System.Drawing.Color.White;
            this.TotalCostLabel.Location = new System.Drawing.Point(845, 817);
            this.TotalCostLabel.Name = "TotalCostLabel";
            this.TotalCostLabel.Size = new System.Drawing.Size(163, 31);
            this.TotalCostLabel.TabIndex = 18;
            this.TotalCostLabel.Text = "Total cost: 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1539, 77);
            this.panel1.TabIndex = 19;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CloseButton.Location = new System.Drawing.Point(1459, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 77);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1539, 1035);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TotalCostLabel);
            this.Controls.Add(this.DeleteLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.DeleteOrder);
            this.Controls.Add(this.CancelOrderButton);
            this.Controls.Add(this.ConfirmOrderButton);
            this.Controls.Add(this.DeleteFromOrderButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.AddForOrderButton);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddForName);
            this.Controls.Add(this.AddForType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AddForType;
        private System.Windows.Forms.ComboBox AddForName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button AddForOrderButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DeleteFromOrderButton;
        private System.Windows.Forms.Button ConfirmOrderButton;
        private System.Windows.Forms.Button CancelOrderButton;
        private System.Windows.Forms.ComboBox DeleteOrder;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label AddLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DeleteLabel;
        private System.Windows.Forms.Label TotalCostLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CloseButton;
    }
}