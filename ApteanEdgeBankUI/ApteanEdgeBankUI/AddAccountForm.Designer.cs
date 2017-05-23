namespace ApteanEdgeBankUI
{
    partial class AddAccountForm
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
            this.chequingAccountButton = new System.Windows.Forms.RadioButton();
            this.tfsAccountButton = new System.Windows.Forms.RadioButton();
            this.liabilityAccountButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.balanceBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chequingAccountButton
            // 
            this.chequingAccountButton.AutoSize = true;
            this.chequingAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chequingAccountButton.Location = new System.Drawing.Point(25, 42);
            this.chequingAccountButton.Name = "chequingAccountButton";
            this.chequingAccountButton.Size = new System.Drawing.Size(192, 29);
            this.chequingAccountButton.TabIndex = 1;
            this.chequingAccountButton.TabStop = true;
            this.chequingAccountButton.Text = "Chequing Account";
            this.chequingAccountButton.UseVisualStyleBackColor = true;
            this.chequingAccountButton.CheckedChanged += new System.EventHandler(this.chequingAccountButton_CheckedChanged);
            // 
            // tfsAccountButton
            // 
            this.tfsAccountButton.AutoSize = true;
            this.tfsAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tfsAccountButton.Location = new System.Drawing.Point(25, 88);
            this.tfsAccountButton.Name = "tfsAccountButton";
            this.tfsAccountButton.Size = new System.Drawing.Size(262, 29);
            this.tfsAccountButton.TabIndex = 2;
            this.tfsAccountButton.TabStop = true;
            this.tfsAccountButton.Text = "Tax Free Savings Account";
            this.tfsAccountButton.UseVisualStyleBackColor = true;
            this.tfsAccountButton.CheckedChanged += new System.EventHandler(this.tfsAccountButton_CheckedChanged);
            // 
            // liabilityAccountButton
            // 
            this.liabilityAccountButton.AutoSize = true;
            this.liabilityAccountButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liabilityAccountButton.Location = new System.Drawing.Point(25, 134);
            this.liabilityAccountButton.Name = "liabilityAccountButton";
            this.liabilityAccountButton.Size = new System.Drawing.Size(171, 29);
            this.liabilityAccountButton.TabIndex = 3;
            this.liabilityAccountButton.TabStop = true;
            this.liabilityAccountButton.Text = "Liability Account";
            this.liabilityAccountButton.UseVisualStyleBackColor = true;
            this.liabilityAccountButton.CheckedChanged += new System.EventHandler(this.liabilityAccountButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tfsAccountButton);
            this.groupBox1.Controls.Add(this.liabilityAccountButton);
            this.groupBox1.Controls.Add(this.chequingAccountButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 185);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starting Balance";
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(237, 301);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(73, 32);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(321, 301);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(73, 32);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // balanceBox
            // 
            this.balanceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.balanceBox.Location = new System.Drawing.Point(193, 238);
            this.balanceBox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.balanceBox.Name = "balanceBox";
            this.balanceBox.Size = new System.Drawing.Size(201, 30);
            this.balanceBox.TabIndex = 2;
            this.balanceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 343);
            this.Controls.Add(this.balanceBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add new account";
            this.Load += new System.EventHandler(this.AddAccountForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton chequingAccountButton;
        private System.Windows.Forms.RadioButton tfsAccountButton;
        private System.Windows.Forms.RadioButton liabilityAccountButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NumericUpDown balanceBox;
    }
}