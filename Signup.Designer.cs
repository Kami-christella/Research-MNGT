namespace Research_PMS
{
    partial class Signup
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
            this.roleCOMBO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.signupBTN = new System.Windows.Forms.Button();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.emailTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roleCOMBO
            // 
            this.roleCOMBO.FormattingEnabled = true;
            this.roleCOMBO.Items.AddRange(new object[] {
            "Students",
            "Faculty"});
            this.roleCOMBO.Location = new System.Drawing.Point(170, 343);
            this.roleCOMBO.Name = "roleCOMBO";
            this.roleCOMBO.Size = new System.Drawing.Size(313, 28);
            this.roleCOMBO.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 31);
            this.label4.TabIndex = 24;
            this.label4.Text = "Role";
            // 
            // signupBTN
            // 
            this.signupBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signupBTN.ForeColor = System.Drawing.Color.Magenta;
            this.signupBTN.Location = new System.Drawing.Point(204, 386);
            this.signupBTN.Name = "signupBTN";
            this.signupBTN.Size = new System.Drawing.Size(230, 52);
            this.signupBTN.TabIndex = 22;
            this.signupBTN.Text = "SIGNUP";
            this.signupBTN.UseVisualStyleBackColor = true;
            this.signupBTN.Click += new System.EventHandler(this.signupBTN_Click);
            // 
            // passwordTB
            // 
            this.passwordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTB.Location = new System.Drawing.Point(158, 245);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(325, 35);
            this.passwordTB.TabIndex = 21;
            // 
            // emailTB
            // 
            this.emailTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTB.Location = new System.Drawing.Point(158, 155);
            this.emailTB.Name = "emailTB";
            this.emailTB.Size = new System.Drawing.Size(325, 35);
            this.emailTB.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(154, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 18;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Magenta;
            this.label1.Location = new System.Drawing.Point(113, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(819, 37);
            this.label1.TabIndex = 17;
            this.label1.Text = " UNIVERSITY RESEARCH MANAGEMENT SYSTEM";
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 450);
            this.Controls.Add(this.roleCOMBO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.signupBTN);
            this.Controls.Add(this.passwordTB);
            this.Controls.Add(this.emailTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Signup";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox roleCOMBO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button signupBTN;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox emailTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}