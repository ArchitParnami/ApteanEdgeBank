namespace ApteanEdgeBankUI
{
    partial class LiabilityAccountForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.balanceTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.customerIDTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.accountTransferGroupBox = new System.Windows.Forms.GroupBox();
            this.accountTransferComboBox = new System.Windows.Forms.ComboBox();
            this.transferAccountBalanceTextBox = new System.Windows.Forms.TextBox();
            this.accountCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.repayAmountBox = new System.Windows.Forms.NumericUpDown();
            this.totalPaymentTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.interestTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.issueLoanButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.activityLogbutton = new System.Windows.Forms.Button();
            this.closeWindowButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.accountTransferGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repayAmountBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.accountIDTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.balanceTextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.customerIDTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.statusTextBox);
            this.groupBox1.Controls.Add(this.typeTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account ID";
            // 
            // accountIDTextBox
            // 
            this.accountIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountIDTextBox.Location = new System.Drawing.Point(198, 39);
            this.accountIDTextBox.Name = "accountIDTextBox";
            this.accountIDTextBox.ReadOnly = true;
            this.accountIDTextBox.Size = new System.Drawing.Size(155, 26);
            this.accountIDTextBox.TabIndex = 1;
            this.accountIDTextBox.TabStop = false;
            this.accountIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(428, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer ID";
            // 
            // balanceTextBox
            // 
            this.balanceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceTextBox.Location = new System.Drawing.Point(198, 149);
            this.balanceTextBox.Name = "balanceTextBox";
            this.balanceTextBox.ReadOnly = true;
            this.balanceTextBox.Size = new System.Drawing.Size(155, 26);
            this.balanceTextBox.TabIndex = 1;
            this.balanceTextBox.TabStop = false;
            this.balanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Balance";
            // 
            // customerIDTextBox
            // 
            this.customerIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIDTextBox.Location = new System.Drawing.Point(569, 36);
            this.customerIDTextBox.Name = "customerIDTextBox";
            this.customerIDTextBox.ReadOnly = true;
            this.customerIDTextBox.Size = new System.Drawing.Size(155, 26);
            this.customerIDTextBox.TabIndex = 1;
            this.customerIDTextBox.TabStop = false;
            this.customerIDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextBox.Location = new System.Drawing.Point(569, 91);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(155, 26);
            this.statusTextBox.TabIndex = 1;
            this.statusTextBox.TabStop = false;
            this.statusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeTextBox.Location = new System.Drawing.Point(198, 94);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(155, 26);
            this.typeTextBox.TabIndex = 1;
            this.typeTextBox.TabStop = false;
            this.typeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Repay Amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.accountTransferGroupBox);
            this.groupBox2.Controls.Add(this.okButton);
            this.groupBox2.Controls.Add(this.repayAmountBox);
            this.groupBox2.Controls.Add(this.totalPaymentTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.interestTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 388);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Repayment";
            // 
            // accountTransferGroupBox
            // 
            this.accountTransferGroupBox.Controls.Add(this.accountTransferComboBox);
            this.accountTransferGroupBox.Controls.Add(this.transferAccountBalanceTextBox);
            this.accountTransferGroupBox.Controls.Add(this.accountCheckbox);
            this.accountTransferGroupBox.Controls.Add(this.label8);
            this.accountTransferGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTransferGroupBox.Location = new System.Drawing.Point(22, 215);
            this.accountTransferGroupBox.Name = "accountTransferGroupBox";
            this.accountTransferGroupBox.Size = new System.Drawing.Size(337, 147);
            this.accountTransferGroupBox.TabIndex = 3;
            this.accountTransferGroupBox.TabStop = false;
            this.accountTransferGroupBox.Text = "Repay from Account";
            // 
            // accountTransferComboBox
            // 
            this.accountTransferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountTransferComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTransferComboBox.FormattingEnabled = true;
            this.accountTransferComboBox.Location = new System.Drawing.Point(179, 38);
            this.accountTransferComboBox.Name = "accountTransferComboBox";
            this.accountTransferComboBox.Size = new System.Drawing.Size(146, 28);
            this.accountTransferComboBox.TabIndex = 2;
            this.accountTransferComboBox.SelectedIndexChanged += new System.EventHandler(this.accountTransferComboBox_SelectedIndexChanged);
            // 
            // transferAccountBalanceTextBox
            // 
            this.transferAccountBalanceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferAccountBalanceTextBox.Location = new System.Drawing.Point(179, 100);
            this.transferAccountBalanceTextBox.Name = "transferAccountBalanceTextBox";
            this.transferAccountBalanceTextBox.ReadOnly = true;
            this.transferAccountBalanceTextBox.Size = new System.Drawing.Size(146, 26);
            this.transferAccountBalanceTextBox.TabIndex = 5;
            this.transferAccountBalanceTextBox.TabStop = false;
            this.transferAccountBalanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // accountCheckbox
            // 
            this.accountCheckbox.AutoSize = true;
            this.accountCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountCheckbox.Location = new System.Drawing.Point(38, 42);
            this.accountCheckbox.Name = "accountCheckbox";
            this.accountCheckbox.Size = new System.Drawing.Size(87, 24);
            this.accountCheckbox.TabIndex = 1;
            this.accountCheckbox.Text = "Account";
            this.accountCheckbox.UseVisualStyleBackColor = true;
            this.accountCheckbox.CheckedChanged += new System.EventHandler(this.accountCheckbox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Balance";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(388, 46);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 29);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // repayAmountBox
            // 
            this.repayAmountBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repayAmountBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.repayAmountBox.Location = new System.Drawing.Point(201, 49);
            this.repayAmountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repayAmountBox.Name = "repayAmountBox";
            this.repayAmountBox.Size = new System.Drawing.Size(158, 26);
            this.repayAmountBox.TabIndex = 1;
            this.repayAmountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.repayAmountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // totalPaymentTextBox
            // 
            this.totalPaymentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPaymentTextBox.Location = new System.Drawing.Point(201, 155);
            this.totalPaymentTextBox.Name = "totalPaymentTextBox";
            this.totalPaymentTextBox.ReadOnly = true;
            this.totalPaymentTextBox.Size = new System.Drawing.Size(158, 26);
            this.totalPaymentTextBox.TabIndex = 5;
            this.totalPaymentTextBox.TabStop = false;
            this.totalPaymentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total Repayment  ";
            // 
            // interestTextBox
            // 
            this.interestTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interestTextBox.Location = new System.Drawing.Point(201, 100);
            this.interestTextBox.Name = "interestTextBox";
            this.interestTextBox.ReadOnly = true;
            this.interestTextBox.Size = new System.Drawing.Size(158, 26);
            this.interestTextBox.TabIndex = 5;
            this.interestTextBox.TabStop = false;
            this.interestTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Interest (10%)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.issueLoanButton);
            this.groupBox3.Location = new System.Drawing.Point(507, 481);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 103);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // issueLoanButton
            // 
            this.issueLoanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueLoanButton.Location = new System.Drawing.Point(46, 35);
            this.issueLoanButton.Name = "issueLoanButton";
            this.issueLoanButton.Size = new System.Drawing.Size(124, 39);
            this.issueLoanButton.TabIndex = 1;
            this.issueLoanButton.Text = "Issue Loan";
            this.issueLoanButton.UseVisualStyleBackColor = true;
            this.issueLoanButton.Click += new System.EventHandler(this.issueLoanButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.activityLogbutton);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(507, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(218, 115);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // activityLogbutton
            // 
            this.activityLogbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activityLogbutton.Location = new System.Drawing.Point(46, 39);
            this.activityLogbutton.Name = "activityLogbutton";
            this.activityLogbutton.Size = new System.Drawing.Size(124, 39);
            this.activityLogbutton.TabIndex = 1;
            this.activityLogbutton.Text = "Activity Log";
            this.activityLogbutton.UseVisualStyleBackColor = true;
            this.activityLogbutton.Click += new System.EventHandler(this.activityLogbutton_Click);
            // 
            // closeWindowButton
            // 
            this.closeWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeWindowButton.Location = new System.Drawing.Point(335, 648);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(121, 37);
            this.closeWindowButton.TabIndex = 6;
            this.closeWindowButton.Text = "Close Window";
            this.closeWindowButton.UseVisualStyleBackColor = true;
            this.closeWindowButton.Click += new System.EventHandler(this.closeWindowButton_Click);
            // 
            // LiabilityAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 696);
            this.Controls.Add(this.closeWindowButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LiabilityAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liability Account";
            this.Load += new System.EventHandler(this.LiabilityAccountForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.accountTransferGroupBox.ResumeLayout(false);
            this.accountTransferGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repayAmountBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accountIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox balanceTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox customerIDTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox accountCheckbox;
        private System.Windows.Forms.ComboBox accountTransferComboBox;
        private System.Windows.Forms.NumericUpDown repayAmountBox;
        private System.Windows.Forms.TextBox totalPaymentTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox interestTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button issueLoanButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button activityLogbutton;
        private System.Windows.Forms.Button closeWindowButton;
        private System.Windows.Forms.TextBox transferAccountBalanceTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox accountTransferGroupBox;
    }
}