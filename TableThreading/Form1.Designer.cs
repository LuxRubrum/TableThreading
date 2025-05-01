namespace TableThreading
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblMeasurements = new Label();
            lblX = new Label();
            lblY = new Label();
            txbX = new TextBox();
            txbY = new TextBox();
            dgvMain = new DataGridView();
            btnStart1 = new Button();
            btnStart2 = new Button();
            btnStart4 = new Button();
            lsbLog = new ListBox();
            lblStart = new Label();
            btnCreate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            SuspendLayout();
            // 
            // lblMeasurements
            // 
            lblMeasurements.AutoSize = true;
            lblMeasurements.Location = new Point(6, 12);
            lblMeasurements.Name = "lblMeasurements";
            lblMeasurements.Size = new Size(116, 15);
            lblMeasurements.TabIndex = 0;
            lblMeasurements.Text = "Размеры таблицы:";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(10, 38);
            lblX.Name = "lblX";
            lblX.Size = new Size(18, 15);
            lblX.TabIndex = 1;
            lblX.Text = "X:";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(11, 67);
            lblY.Name = "lblY";
            lblY.Size = new Size(17, 15);
            lblY.TabIndex = 2;
            lblY.Text = "Y:";
            // 
            // txbX
            // 
            txbX.Location = new Point(36, 35);
            txbX.Name = "txbX";
            txbX.Size = new Size(183, 23);
            txbX.TabIndex = 3;
            txbX.Text = "4";
            txbX.Leave += txbX_Leave;
            // 
            // txbY
            // 
            txbY.Location = new Point(36, 64);
            txbY.Name = "txbY";
            txbY.Size = new Size(183, 23);
            txbY.TabIndex = 4;
            txbY.Text = "4";
            txbY.Leave += txbY_Leave;
            // 
            // dgvMain
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Location = new Point(225, 12);
            dgvMain.Name = "dgvMain";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dgvMain.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvMain.RowTemplate.Height = 25;
            dgvMain.Size = new Size(707, 472);
            dgvMain.TabIndex = 5;
            // 
            // btnStart1
            // 
            btnStart1.Location = new Point(6, 146);
            btnStart1.Name = "btnStart1";
            btnStart1.Size = new Size(213, 23);
            btnStart1.TabIndex = 6;
            btnStart1.Text = "1 поток";
            btnStart1.UseVisualStyleBackColor = true;
            btnStart1.Click += btnStart1_Click;
            // 
            // btnStart2
            // 
            btnStart2.Location = new Point(6, 175);
            btnStart2.Name = "btnStart2";
            btnStart2.Size = new Size(213, 23);
            btnStart2.TabIndex = 7;
            btnStart2.Text = "2 потока";
            btnStart2.UseVisualStyleBackColor = true;
            btnStart2.Click += btnStart2_Click;
            // 
            // btnStart4
            // 
            btnStart4.Location = new Point(6, 204);
            btnStart4.Name = "btnStart4";
            btnStart4.Size = new Size(213, 23);
            btnStart4.TabIndex = 8;
            btnStart4.Text = "4 потока";
            btnStart4.UseVisualStyleBackColor = true;
            btnStart4.Click += btnStart4_Click;
            // 
            // lsbLog
            // 
            lsbLog.FormattingEnabled = true;
            lsbLog.ItemHeight = 15;
            lsbLog.Location = new Point(10, 490);
            lsbLog.Name = "lsbLog";
            lsbLog.Size = new Size(926, 199);
            lsbLog.TabIndex = 9;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(6, 128);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(121, 15);
            lblStart.TabIndex = 10;
            lblStart.Text = "Запуск сортировки:";
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(6, 93);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(213, 23);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Создать таблицу";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 701);
            Controls.Add(btnCreate);
            Controls.Add(lblStart);
            Controls.Add(lsbLog);
            Controls.Add(btnStart4);
            Controls.Add(btnStart2);
            Controls.Add(btnStart1);
            Controls.Add(dgvMain);
            Controls.Add(txbY);
            Controls.Add(txbX);
            Controls.Add(lblY);
            Controls.Add(lblX);
            Controls.Add(lblMeasurements);
            Name = "frmMain";
            Text = "Распараллеливание массива";
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMeasurements;
        private Label lblX;
        private Label lblY;
        private TextBox txbX;
        private TextBox txbY;
        private DataGridView dgvMain;
        private Button btnStart1;
        private Button btnStart2;
        private Button btnStart4;
        private ListBox lsbLog;
        private Label lblStart;
        private Button btnCreate;
    }
}
