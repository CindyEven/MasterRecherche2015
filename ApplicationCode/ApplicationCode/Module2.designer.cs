namespace ApplicationCode
{
    partial class Module2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Module2));
            this.axActiveHaptekX = new AxACTIVEHAPTEKXLib.AxActiveHaptekX();
            this.groupBox_Explications = new System.Windows.Forms.GroupBox();
            this.label_consigne_patientanswer = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.label_text = new System.Windows.Forms.Label();
            this.patientAnswer = new System.Windows.Forms.Label();
            this.groupBox_Finish = new System.Windows.Forms.GroupBox();
            this.btn_finish = new System.Windows.Forms.Button();
            this.label_title_finish = new System.Windows.Forms.Label();
            this.label_text_finish = new System.Windows.Forms.Label();
            this.groupBox_Question = new System.Windows.Forms.GroupBox();
            this.label_feedback = new System.Windows.Forms.Label();
            this.btn_valider = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label_question = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHaptekX)).BeginInit();
            this.groupBox_Explications.SuspendLayout();
            this.groupBox_Finish.SuspendLayout();
            this.groupBox_Question.SuspendLayout();
            this.SuspendLayout();
            // 
            // axActiveHaptekX
            // 
            this.axActiveHaptekX.Enabled = true;
            this.axActiveHaptekX.Location = new System.Drawing.Point(12, 12);
            this.axActiveHaptekX.Name = "axActiveHaptekX";
            this.axActiveHaptekX.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axActiveHaptekX.OcxState")));
            this.axActiveHaptekX.Size = new System.Drawing.Size(500, 500);
            this.axActiveHaptekX.TabIndex = 5;
            // 
            // groupBox_Explications
            // 
            this.groupBox_Explications.Controls.Add(this.label_consigne_patientanswer);
            this.groupBox_Explications.Controls.Add(this.btn_OK);
            this.groupBox_Explications.Controls.Add(this.label_title);
            this.groupBox_Explications.Controls.Add(this.label_text);
            this.groupBox_Explications.Location = new System.Drawing.Point(529, 12);
            this.groupBox_Explications.Name = "groupBox_Explications";
            this.groupBox_Explications.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Explications.TabIndex = 14;
            this.groupBox_Explications.TabStop = false;
            // 
            // label_consigne_patientanswer
            // 
            this.label_consigne_patientanswer.AutoSize = true;
            this.label_consigne_patientanswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_consigne_patientanswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label_consigne_patientanswer.Location = new System.Drawing.Point(71, 447);
            this.label_consigne_patientanswer.MaximumSize = new System.Drawing.Size(400, 0);
            this.label_consigne_patientanswer.Name = "label_consigne_patientanswer";
            this.label_consigne_patientanswer.Size = new System.Drawing.Size(188, 18);
            this.label_consigne_patientanswer.TabIndex = 16;
            this.label_consigne_patientanswer.Text = "Le dialogue sera affiché ici !";
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
            this.label_text.Size = new System.Drawing.Size(379, 64);
            this.label_text.TabIndex = 2;
            this.label_text.Text = resources.GetString("label_text.Text");
            // 
            // patientAnswer
            // 
            this.patientAnswer.AutoSize = true;
            this.patientAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.patientAnswer.Location = new System.Drawing.Point(71, 447);
            this.patientAnswer.MaximumSize = new System.Drawing.Size(400, 0);
            this.patientAnswer.Name = "patientAnswer";
            this.patientAnswer.Size = new System.Drawing.Size(101, 18);
            this.patientAnswer.TabIndex = 15;
            this.patientAnswer.Text = "Votre réponse";
            // 
            // groupBox_Finish
            // 
            this.groupBox_Finish.Controls.Add(this.btn_finish);
            this.groupBox_Finish.Controls.Add(this.label_title_finish);
            this.groupBox_Finish.Controls.Add(this.label_text_finish);
            this.groupBox_Finish.Location = new System.Drawing.Point(529, 12);
            this.groupBox_Finish.Name = "groupBox_Finish";
            this.groupBox_Finish.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Finish.TabIndex = 12;
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
            this.label_text_finish.Size = new System.Drawing.Size(202, 16);
            this.label_text_finish.TabIndex = 0;
            this.label_text_finish.Text = "Un peu de blabla pour expliquer.";
            // 
            // groupBox_Question
            // 
            this.groupBox_Question.Controls.Add(this.patientAnswer);
            this.groupBox_Question.Controls.Add(this.label_feedback);
            this.groupBox_Question.Controls.Add(this.btn_valider);
            this.groupBox_Question.Controls.Add(this.listBox);
            this.groupBox_Question.Controls.Add(this.label_question);
            this.groupBox_Question.Location = new System.Drawing.Point(529, 12);
            this.groupBox_Question.Name = "groupBox_Question";
            this.groupBox_Question.Size = new System.Drawing.Size(529, 500);
            this.groupBox_Question.TabIndex = 13;
            this.groupBox_Question.TabStop = false;
            // 
            // label_feedback
            // 
            this.label_feedback.AutoSize = true;
            this.label_feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_feedback.Location = new System.Drawing.Point(65, 384);
            this.label_feedback.Name = "label_feedback";
            this.label_feedback.Size = new System.Drawing.Size(170, 25);
            this.label_feedback.TabIndex = 8;
            this.label_feedback.Text = "Bonne réponse !";
            // 
            // btn_valider
            // 
            this.btn_valider.Location = new System.Drawing.Point(381, 309);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(90, 42);
            this.btn_valider.TabIndex = 6;
            this.btn_valider.Text = "Valider";
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.Window;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 25;
            this.listBox.Items.AddRange(new object[] {
            "La joie",
            "La tristesse",
            "La colère",
            "Neutre"});
            this.listBox.Location = new System.Drawing.Point(70, 121);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(200, 154);
            this.listBox.TabIndex = 7;
            // 
            // label_question
            // 
            this.label_question.AutoSize = true;
            this.label_question.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_question.Location = new System.Drawing.Point(64, 71);
            this.label_question.Name = "label_question";
            this.label_question.Size = new System.Drawing.Size(407, 31);
            this.label_question.TabIndex = 4;
            this.label_question.Text = "Quelle émotion est exprimée ?";
            // 
            // Module2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 524);
            this.Controls.Add(this.groupBox_Explications);
            this.Controls.Add(this.groupBox_Finish);
            this.Controls.Add(this.groupBox_Question);
            this.Controls.Add(this.axActiveHaptekX);
            this.Name = "Module2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module 2";
            ((System.ComponentModel.ISupportInitialize)(this.axActiveHaptekX)).EndInit();
            this.groupBox_Explications.ResumeLayout(false);
            this.groupBox_Explications.PerformLayout();
            this.groupBox_Finish.ResumeLayout(false);
            this.groupBox_Finish.PerformLayout();
            this.groupBox_Question.ResumeLayout(false);
            this.groupBox_Question.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxACTIVEHAPTEKXLib.AxActiveHaptekX axActiveHaptekX;
        private System.Windows.Forms.GroupBox groupBox_Explications;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_text;
        private System.Windows.Forms.GroupBox groupBox_Finish;
        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.Label label_title_finish;
        private System.Windows.Forms.Label label_text_finish;
        private System.Windows.Forms.GroupBox groupBox_Question;
        private System.Windows.Forms.Label label_feedback;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label_question;
        private System.Windows.Forms.Label patientAnswer;
        private System.Windows.Forms.Label label_consigne_patientanswer;
    }
}