namespace ApplicationCode
{
    partial class Menu
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
            this.btn_module1 = new System.Windows.Forms.Button();
            this.btn_module2 = new System.Windows.Forms.Button();
            this.btn_module3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_module1
            // 
            this.btn_module1.Location = new System.Drawing.Point(97, 65);
            this.btn_module1.Name = "btn_module1";
            this.btn_module1.Size = new System.Drawing.Size(80, 37);
            this.btn_module1.TabIndex = 0;
            this.btn_module1.Text = "Module 1";
            this.btn_module1.UseVisualStyleBackColor = true;
            this.btn_module1.Click += new System.EventHandler(this.btn_module1_Click);
            // 
            // btn_module2
            // 
            this.btn_module2.Location = new System.Drawing.Point(97, 108);
            this.btn_module2.Name = "btn_module2";
            this.btn_module2.Size = new System.Drawing.Size(80, 37);
            this.btn_module2.TabIndex = 1;
            this.btn_module2.Text = "Module 2";
            this.btn_module2.UseVisualStyleBackColor = true;
            this.btn_module2.Click += new System.EventHandler(this.btn_module2_Click);
            // 
            // btn_module3
            // 
            this.btn_module3.Location = new System.Drawing.Point(97, 151);
            this.btn_module3.Name = "btn_module3";
            this.btn_module3.Size = new System.Drawing.Size(80, 37);
            this.btn_module3.TabIndex = 2;
            this.btn_module3.Text = "Module 3";
            this.btn_module3.UseVisualStyleBackColor = true;
            this.btn_module3.Click += new System.EventHandler(this.btn_module3_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btn_module3);
            this.Controls.Add(this.btn_module2);
            this.Controls.Add(this.btn_module1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_module1;
        private System.Windows.Forms.Button btn_module2;
        private System.Windows.Forms.Button btn_module3;
    }
}

