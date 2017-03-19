namespace SignatureValidation
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadResults = new System.Windows.Forms.Button();
            this.txtResultTitle = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridcsv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRepo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnClearResult = new System.Windows.Forms.Button();
            this.txtRepo = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProcessing = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnExport2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridcsv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Result Management";
            // 
            // btnLoadResults
            // 
            this.btnLoadResults.Location = new System.Drawing.Point(20, 139);
            this.btnLoadResults.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadResults.Name = "btnLoadResults";
            this.btnLoadResults.Size = new System.Drawing.Size(94, 29);
            this.btnLoadResults.TabIndex = 1;
            this.btnLoadResults.Text = "Browse";
            this.btnLoadResults.UseVisualStyleBackColor = true;
            this.btnLoadResults.Click += new System.EventHandler(this.btnLoadResults_Click);
            // 
            // txtResultTitle
            // 
            this.txtResultTitle.AutoSize = true;
            this.txtResultTitle.Location = new System.Drawing.Point(16, 99);
            this.txtResultTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtResultTitle.Name = "txtResultTitle";
            this.txtResultTitle.Size = new System.Drawing.Size(107, 20);
            this.txtResultTitle.TabIndex = 2;
            this.txtResultTitle.Text = "Choose a file";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(121, 140);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(641, 26);
            this.txtFilePath.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridcsv
            // 
            this.dataGridcsv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridcsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridcsv.Location = new System.Drawing.Point(20, 213);
            this.dataGridcsv.Name = "dataGridcsv";
            this.dataGridcsv.ReadOnly = true;
            this.dataGridcsv.RowTemplate.Height = 24;
            this.dataGridcsv.Size = new System.Drawing.Size(742, 327);
            this.dataGridcsv.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(863, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose a file";
            // 
            // buttonRepo
            // 
            this.buttonRepo.Location = new System.Drawing.Point(867, 140);
            this.buttonRepo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRepo.Name = "buttonRepo";
            this.buttonRepo.Size = new System.Drawing.Size(94, 29);
            this.buttonRepo.TabIndex = 6;
            this.buttonRepo.Text = "Browse";
            this.buttonRepo.UseVisualStyleBackColor = true;
            this.buttonRepo.Click += new System.EventHandler(this.btnLoadRepo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(860, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repository";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(867, 266);
            this.btnValidate.Margin = new System.Windows.Forms.Padding(4);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(111, 29);
            this.btnValidate.TabIndex = 10;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnClearResult
            // 
            this.btnClearResult.Location = new System.Drawing.Point(20, 176);
            this.btnClearResult.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearResult.Name = "btnClearResult";
            this.btnClearResult.Size = new System.Drawing.Size(160, 29);
            this.btnClearResult.TabIndex = 11;
            this.btnClearResult.Text = "Clear Results";
            this.btnClearResult.UseVisualStyleBackColor = true;
            this.btnClearResult.Click += new System.EventHandler(this.btnClearResult_Click);
            // 
            // txtRepo
            // 
            this.txtRepo.Enabled = false;
            this.txtRepo.Location = new System.Drawing.Point(867, 213);
            this.txtRepo.Name = "txtRepo";
            this.txtRepo.Size = new System.Drawing.Size(521, 26);
            this.txtRepo.TabIndex = 8;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(868, 299);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(135, 20);
            this.lblResult.TabIndex = 14;
            this.lblResult.Text = "Validation Result";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1009, 291);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 29);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 612);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(739, 29);
            this.progressBar.TabIndex = 16;
            // 
            // lblProcessing
            // 
            this.lblProcessing.AutoSize = true;
            this.lblProcessing.Location = new System.Drawing.Point(388, 651);
            this.lblProcessing.Name = "lblProcessing";
            this.lblProcessing.Size = new System.Drawing.Size(0, 20);
            this.lblProcessing.TabIndex = 17;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnExport2
            // 
            this.btnExport2.Location = new System.Drawing.Point(794, 612);
            this.btnExport2.Name = "btnExport2";
            this.btnExport2.Size = new System.Drawing.Size(75, 28);
            this.btnExport2.TabIndex = 18;
            this.btnExport2.Text = "Export";
            this.btnExport2.UseVisualStyleBackColor = true;
            this.btnExport2.Click += new System.EventHandler(this.btnExport2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 988);
            this.Controls.Add(this.btnExport2);
            this.Controls.Add(this.lblProcessing);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnClearResult);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtRepo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRepo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridcsv);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.txtResultTitle);
            this.Controls.Add(this.btnLoadResults);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Signature Validation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridcsv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadResults;
        private System.Windows.Forms.Label txtResultTitle;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridcsv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRepo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnClearResult;
        private System.Windows.Forms.TextBox txtRepo;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProcessing;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnExport2;
        
    }
}

