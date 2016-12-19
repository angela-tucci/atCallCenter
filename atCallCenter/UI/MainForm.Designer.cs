namespace atCallCenter.UI
{
    partial class MainForm
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
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.groupBoxChooseRepo = new System.Windows.Forms.GroupBox();
            this.comboBoxChooseRepo = new System.Windows.Forms.ComboBox();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.checkBoxAnsweredCalls = new System.Windows.Forms.CheckBox();
            this.groupBoxCount = new System.Windows.Forms.GroupBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.groupBoxFromPhoneNumber = new System.Windows.Forms.GroupBox();
            this.comboBoxFromPhoneNumber = new System.Windows.Forms.ComboBox();
            this.buttonDisplayTopRecords = new System.Windows.Forms.Button();
            this.textBoxDisplayTopRecords = new System.Windows.Forms.TextBox();
            this.groupBoxRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.groupBoxChooseRepo.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            this.groupBoxCount.SuspendLayout();
            this.groupBoxFromPhoneNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Controls.Add(this.dataGridViewRecords);
            this.groupBoxRecords.Location = new System.Drawing.Point(12, 132);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Size = new System.Drawing.Size(701, 248);
            this.groupBoxRecords.TabIndex = 0;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "Records";
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRecords.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.Size = new System.Drawing.Size(695, 229);
            this.dataGridViewRecords.TabIndex = 0;
            // 
            // groupBoxChooseRepo
            // 
            this.groupBoxChooseRepo.Controls.Add(this.comboBoxChooseRepo);
            this.groupBoxChooseRepo.Location = new System.Drawing.Point(505, 62);
            this.groupBoxChooseRepo.Name = "groupBoxChooseRepo";
            this.groupBoxChooseRepo.Size = new System.Drawing.Size(186, 54);
            this.groupBoxChooseRepo.TabIndex = 1;
            this.groupBoxChooseRepo.TabStop = false;
            this.groupBoxChooseRepo.Text = "Choose Repository";
            // 
            // comboBoxChooseRepo
            // 
            this.comboBoxChooseRepo.FormattingEnabled = true;
            this.comboBoxChooseRepo.Location = new System.Drawing.Point(32, 19);
            this.comboBoxChooseRepo.Name = "comboBoxChooseRepo";
            this.comboBoxChooseRepo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChooseRepo.TabIndex = 0;
            this.comboBoxChooseRepo.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseRepo_SelectedIndexChanged);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.checkBoxAnsweredCalls);
            this.groupBoxDisplay.Location = new System.Drawing.Point(360, 62);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(127, 54);
            this.groupBoxDisplay.TabIndex = 2;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Display";
            // 
            // checkBoxAnsweredCalls
            // 
            this.checkBoxAnsweredCalls.AutoSize = true;
            this.checkBoxAnsweredCalls.Location = new System.Drawing.Point(22, 19);
            this.checkBoxAnsweredCalls.Name = "checkBoxAnsweredCalls";
            this.checkBoxAnsweredCalls.Size = new System.Drawing.Size(97, 17);
            this.checkBoxAnsweredCalls.TabIndex = 0;
            this.checkBoxAnsweredCalls.Text = "Answered Only";
            this.checkBoxAnsweredCalls.UseVisualStyleBackColor = true;
            this.checkBoxAnsweredCalls.CheckedChanged += new System.EventHandler(this.checkBoxAnsweredCalls_CheckedChanged);
            // 
            // groupBoxCount
            // 
            this.groupBoxCount.Controls.Add(this.labelCount);
            this.groupBoxCount.Location = new System.Drawing.Point(211, 62);
            this.groupBoxCount.Name = "groupBoxCount";
            this.groupBoxCount.Size = new System.Drawing.Size(131, 54);
            this.groupBoxCount.TabIndex = 3;
            this.groupBoxCount.TabStop = false;
            this.groupBoxCount.Text = "Count";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(7, 19);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 13);
            this.labelCount.TabIndex = 0;
            // 
            // groupBoxFromPhoneNumber
            // 
            this.groupBoxFromPhoneNumber.Controls.Add(this.comboBoxFromPhoneNumber);
            this.groupBoxFromPhoneNumber.Location = new System.Drawing.Point(12, 62);
            this.groupBoxFromPhoneNumber.Name = "groupBoxFromPhoneNumber";
            this.groupBoxFromPhoneNumber.Size = new System.Drawing.Size(181, 54);
            this.groupBoxFromPhoneNumber.TabIndex = 4;
            this.groupBoxFromPhoneNumber.TabStop = false;
            this.groupBoxFromPhoneNumber.Text = "From Phone Number";
            // 
            // comboBoxFromPhoneNumber
            // 
            this.comboBoxFromPhoneNumber.FormattingEnabled = true;
            this.comboBoxFromPhoneNumber.Location = new System.Drawing.Point(7, 19);
            this.comboBoxFromPhoneNumber.Name = "comboBoxFromPhoneNumber";
            this.comboBoxFromPhoneNumber.Size = new System.Drawing.Size(168, 21);
            this.comboBoxFromPhoneNumber.TabIndex = 0;
            this.comboBoxFromPhoneNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxFromPhoneNumber_SelectedIndexChanged);
            // 
            // buttonDisplayTopRecords
            // 
            this.buttonDisplayTopRecords.Location = new System.Drawing.Point(19, 4);
            this.buttonDisplayTopRecords.Name = "buttonDisplayTopRecords";
            this.buttonDisplayTopRecords.Size = new System.Drawing.Size(138, 24);
            this.buttonDisplayTopRecords.TabIndex = 5;
            this.buttonDisplayTopRecords.Text = "Display Top Records";
            this.buttonDisplayTopRecords.UseVisualStyleBackColor = true;
            this.buttonDisplayTopRecords.Click += new System.EventHandler(this.buttonDisplayTopRecords_Click);
            // 
            // textBoxDisplayTopRecords
            // 
            this.textBoxDisplayTopRecords.Location = new System.Drawing.Point(211, 4);
            this.textBoxDisplayTopRecords.Name = "textBoxDisplayTopRecords";
            this.textBoxDisplayTopRecords.Size = new System.Drawing.Size(131, 20);
            this.textBoxDisplayTopRecords.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 384);
            this.Controls.Add(this.textBoxDisplayTopRecords);
            this.Controls.Add(this.buttonDisplayTopRecords);
            this.Controls.Add(this.groupBoxFromPhoneNumber);
            this.Controls.Add(this.groupBoxCount);
            this.Controls.Add(this.groupBoxDisplay);
            this.Controls.Add(this.groupBoxChooseRepo);
            this.Controls.Add(this.groupBoxRecords);
            this.Name = "MainForm";
            this.Text = "Call Center Records";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.groupBoxChooseRepo.ResumeLayout(false);
            this.groupBoxDisplay.ResumeLayout(false);
            this.groupBoxDisplay.PerformLayout();
            this.groupBoxCount.ResumeLayout(false);
            this.groupBoxCount.PerformLayout();
            this.groupBoxFromPhoneNumber.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.GroupBox groupBoxChooseRepo;
        private System.Windows.Forms.ComboBox comboBoxChooseRepo;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.CheckBox checkBoxAnsweredCalls;
        private System.Windows.Forms.GroupBox groupBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.GroupBox groupBoxFromPhoneNumber;
        private System.Windows.Forms.ComboBox comboBoxFromPhoneNumber;
        private System.Windows.Forms.Button buttonDisplayTopRecords;
        private System.Windows.Forms.TextBox textBoxDisplayTopRecords;
    }
}