namespace Lao_Sign_Language_Alphabet_Recognition
{
    partial class Form1
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
            pictBox = new PictureBox();
            btnStart = new Button();
            btnStop = new Button();
            predict = new Label();
            pictBoxRoi = new PictureBox();
            groupBox1 = new GroupBox();
            lblConfidence = new Label();
            ((System.ComponentModel.ISupportInitialize)pictBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictBoxRoi).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictBox
            // 
            pictBox.BorderStyle = BorderStyle.FixedSingle;
            pictBox.Location = new Point(48, 81);
            pictBox.Name = "pictBox";
            pictBox.Size = new Size(598, 427);
            pictBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBox.TabIndex = 0;
            pictBox.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.Location = new Point(108, 543);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(171, 54);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnStop.Location = new Point(381, 543);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(171, 54);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // predict
            // 
            predict.AutoSize = true;
            predict.Font = new Font("Noto Sans Lao", 7.79999971F, FontStyle.Bold, GraphicsUnit.Point);
            predict.Location = new Point(15, 52);
            predict.Name = "predict";
            predict.Size = new Size(132, 21);
            predict.TabIndex = 3;
            predict.Text = "Predicted Label: ";
            // 
            // pictBoxRoi
            // 
            pictBoxRoi.BorderStyle = BorderStyle.FixedSingle;
            pictBoxRoi.Location = new Point(675, 81);
            pictBoxRoi.Name = "pictBoxRoi";
            pictBoxRoi.Size = new Size(296, 267);
            pictBoxRoi.SizeMode = PictureBoxSizeMode.StretchImage;
            pictBoxRoi.TabIndex = 4;
            pictBoxRoi.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblConfidence);
            groupBox1.Controls.Add(predict);
            groupBox1.Font = new Font("Segoe UI Historic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(679, 376);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(297, 137);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Result";
            // 
            // lblConfidence
            // 
            lblConfidence.AutoSize = true;
            lblConfidence.Font = new Font("Noto Sans Lao", 7.79999971F, FontStyle.Bold, GraphicsUnit.Point);
            lblConfidence.Location = new Point(44, 98);
            lblConfidence.Name = "lblConfidence";
            lblConfidence.Size = new Size(103, 21);
            lblConfidence.TabIndex = 6;
            lblConfidence.Text = "Confidence: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 616);
            Controls.Add(groupBox1);
            Controls.Add(pictBoxRoi);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(pictBox);
            Name = "Form1";
            Text = "LSLA Recognition";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictBoxRoi).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictBox;
        private Button btnStart;
        private Button btnStop;
        private Label predict;
        private PictureBox pictBoxRoi;
        private GroupBox groupBox1;
        private Label lblConfidence;
    }
}