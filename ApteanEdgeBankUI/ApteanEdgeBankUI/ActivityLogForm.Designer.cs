namespace ApteanEdgeBankUI
{
    partial class ActivityLogForm
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
            this.calculateBalanceButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // calculateBalanceButton
            // 
            this.calculateBalanceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.calculateBalanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculateBalanceButton.Location = new System.Drawing.Point(204, 518);
            this.calculateBalanceButton.Name = "calculateBalanceButton";
            this.calculateBalanceButton.Size = new System.Drawing.Size(175, 47);
            this.calculateBalanceButton.TabIndex = 1;
            this.calculateBalanceButton.Text = "Calculate Balance";
            this.calculateBalanceButton.UseVisualStyleBackColor = true;
            this.calculateBalanceButton.Click += new System.EventHandler(this.calculateBalanceButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextBox.Location = new System.Drawing.Point(5, 12);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(561, 500);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.Text = "";
            // 
            // ActivityLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 571);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.calculateBalanceButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ActivityLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account activity log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button calculateBalanceButton;
        private System.Windows.Forms.RichTextBox logTextBox;
    }
}