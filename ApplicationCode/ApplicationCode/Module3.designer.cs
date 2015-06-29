namespace ApplicationCode
{
    partial class Module3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Module3));
            this.groupBox_Explications = new System.Windows.Forms.GroupBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.label_text = new System.Windows.Forms.Label();
            this.axActiveHaptekX = new AxACTIVEHAPTEKXLib.AxActiveHaptekX();
            this.groupBox_Finish = new System.Windows.Forms.GroupBox();
            this.btn_finish = new System.Windows.Forms.Button();
            this.label_title_finish = new System.Windows.Forms.Label();
            this.label_text_finish = new System.Windows.Forms.Label();
            this.groupBox_Question = new System.Windows.Forms.GroupBox();
            this.btn_BackInTime = new System.Windows.Forms.Button();
            this.groupBox_Explications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHaptekX)).BeginInit();
            this.groupBox_Finish.SuspendLayout();
            this.groupBox_Question.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Explications
            // 
            this.groupBox_Explications.Controls.Add(this.btn_OK);
            this.groupBox_Explications.Controls.Add(this.label_title);
            this.groupBox_Explications.Controls.Add(this.label_text);
            this.groupBox_Explications.Location = new System.Drawing.Point(528, 12);
            this.groupBox_Explications.Name = "groupBox_Explications";
            this.groupBox_Explications.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Explications.TabIndex = 18;
            this.groupBox_Explications.TabStop = false;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(396, 384);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(70, 102);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(99, 20);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "Consigne : ";
            // 
            // label_text
            // 
            this.label_text.AutoSize = true;
            this.label_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text.Location = new System.Drawing.Point(71, 137);
            this.label_text.MaximumSize = new System.Drawing.Size(390, 0);
            this.label_text.Name = "label_text";
            this.label_text.Size = new System.Drawing.Size(249, 16);
            this.label_text.TabIndex = 2;
            this.label_text.Text = "Choisissez la réponse qui vous convient.";
            // 
            // axActiveHaptekX
            // 
            this.axActiveHaptekX.Enabled = true;
            this.axActiveHaptekX.Location = new System.Drawing.Point(13, 12);
            this.axActiveHaptekX.Name = "axActiveHaptekX";
            this.axActiveHaptekX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActiveHaptekX.OcxState")));
            this.axActiveHaptekX.Size = new System.Drawing.Size(500, 500);
            this.axActiveHaptekX.TabIndex = 15;
            // 
            // groupBox_Finish
            // 
            this.groupBox_Finish.Controls.Add(this.btn_finish);
            this.groupBox_Finish.Controls.Add(this.label_title_finish);
            this.groupBox_Finish.Controls.Add(this.label_text_finish);
            this.groupBox_Finish.Location = new System.Drawing.Point(528, 12);
            this.groupBox_Finish.Name = "groupBox_Finish";
            this.groupBox_Finish.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Finish.TabIndex = 16;
            this.groupBox_Finish.TabStop = false;
            this.groupBox_Finish.Visible = false;
            // 
            // btn_finish
            // 
            this.btn_finish.Location = new System.Drawing.Point(396, 384);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(75, 23);
            this.btn_finish.TabIndex = 2;
            this.btn_finish.Text = "OK";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // label_title_finish
            // 
            this.label_title_finish.AutoSize = true;
            this.label_title_finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title_finish.Location = new System.Drawing.Point(70, 102);
            this.label_title_finish.Name = "label_title_finish";
            this.label_title_finish.Size = new System.Drawing.Size(208, 20);
            this.label_title_finish.TabIndex = 1;
            this.label_title_finish.Text = "Vous avez fini ce module";
            // 
            // label_text_finish
            // 
            this.label_text_finish.AutoSize = true;
            this.label_text_finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_text_finish.Location = new System.Drawing.Point(71, 137);
            this.label_text_finish.Name = "label_text_finish";
            this.label_text_finish.Size = new System.Drawing.Size(284, 16);
            this.label_text_finish.TabIndex = 0;
            this.label_text_finish.Text = "Pour revenir au menu principal, cliquez sur OK !";
            // 
            // groupBox_Question
            // 
            this.groupBox_Question.Controls.Add(this.btn_BackInTime);
            this.groupBox_Question.Location = new System.Drawing.Point(528, 12);
            this.groupBox_Question.Name = "groupBox_Question";
            this.groupBox_Question.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Question.TabIndex = 17;
            this.groupBox_Question.TabStop = false;
            this.groupBox_Question.Text = "Choisissez l\'action que vous souhaitez réaliser :";
            // 
            // btn_BackInTime
            // 
            this.btn_BackInTime.Location = new System.Drawing.Point(16, 442);
            this.btn_BackInTime.Name = "btn_BackInTime";
            this.btn_BackInTime.Size = new System.Drawing.Size(94, 42);
            this.btn_BackInTime.TabIndex = 0;
            this.btn_BackInTime.Text = "Revenir en arrière";
            this.btn_BackInTime.UseVisualStyleBackColor = true;
            this.btn_BackInTime.Click += new System.EventHandler(this.btn_BackInTime_Click);
            // 
            // Module3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 524);
            this.Controls.Add(this.axActiveHaptekX);
            this.Controls.Add(this.groupBox_Question);
            this.Controls.Add(this.groupBox_Explications);
            this.Controls.Add(this.groupBox_Finish);
            this.Name = "Module3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module 3";
            this.groupBox_Explications.ResumeLayout(false);
            this.groupBox_Explications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHaptekX)).EndInit();
            this.groupBox_Finish.ResumeLayout(false);
            this.groupBox_Finish.PerformLayout();
            this.groupBox_Question.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Explications;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_text;
        private AxACTIVEHAPTEKXLib.AxActiveHaptekX axActiveHaptekX;
        private System.Windows.Forms.GroupBox groupBox_Finish;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Label label_title_finish;
        private System.Windows.Forms.Label label_text_finish;
        private System.Windows.Forms.GroupBox groupBox_Question;
        private System.Windows.Forms.Button btn_BackInTime;        
    }
}