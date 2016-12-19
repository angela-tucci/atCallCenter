namespace atCallCenter.UI
{
    partial class TopRecordsForm
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
            this.dataGridViewTopRecords = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTopRecords
            // 
            this.dataGridViewTopRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTopRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTopRecords.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTopRecords.Name = "dataGridViewTopRecords";
            this.dataGridViewTopRecords.Size = new System.Drawing.Size(654, 378);
            this.dataGridViewTopRecords.TabIndex = 0;
            // 
            // TopRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 378);
            this.Controls.Add(this.dataGridViewTopRecords);
            this.Name = "TopRecordsForm";
            this.Text = "Top Records";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTopRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTopRecords;
    }
}