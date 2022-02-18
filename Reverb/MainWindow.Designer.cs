namespace Reverb
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.Bass = new System.Windows.Forms.TrackBar();
            this.Middle = new System.Windows.Forms.TrackBar();
            this.Treble = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Bass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Middle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Treble)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartBtn.Location = new System.Drawing.Point(607, 49);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 78);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopBtn.Location = new System.Drawing.Point(607, 148);
            this.StopBtn.Margin = new System.Windows.Forms.Padding(4);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(100, 78);
            this.StopBtn.TabIndex = 1;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // Bass
            // 
            this.Bass.Location = new System.Drawing.Point(92, 49);
            this.Bass.Margin = new System.Windows.Forms.Padding(4);
            this.Bass.Maximum = 3000;
            this.Bass.Minimum = 1;
            this.Bass.Name = "Bass";
            this.Bass.Size = new System.Drawing.Size(507, 56);
            this.Bass.TabIndex = 2;
            this.Bass.Value = 1000;
            this.Bass.Scroll += new System.EventHandler(this.Bass_Scroll);
            // 
            // Middle
            // 
            this.Middle.Location = new System.Drawing.Point(92, 112);
            this.Middle.Margin = new System.Windows.Forms.Padding(4);
            this.Middle.Maximum = 3000;
            this.Middle.Minimum = 1;
            this.Middle.Name = "Middle";
            this.Middle.Size = new System.Drawing.Size(507, 56);
            this.Middle.TabIndex = 3;
            this.Middle.Value = 1000;
            this.Middle.Scroll += new System.EventHandler(this.Middle_Scroll);
            // 
            // Treble
            // 
            this.Treble.Location = new System.Drawing.Point(92, 175);
            this.Treble.Margin = new System.Windows.Forms.Padding(4);
            this.Treble.Maximum = 3000;
            this.Treble.Minimum = 1;
            this.Treble.Name = "Treble";
            this.Treble.Size = new System.Drawing.Size(507, 56);
            this.Treble.TabIndex = 4;
            this.Treble.Value = 1000;
            this.Treble.Scroll += new System.EventHandler(this.Treble_Scroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Reverb Delay";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 56);
            this.label2.TabIndex = 6;
            this.label2.Text = "Bass";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 56);
            this.label3.TabIndex = 7;
            this.label3.Text = "Middle";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 56);
            this.label4.TabIndex = 8;
            this.label4.Text = "Treble";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 240);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Treble);
            this.Controls.Add(this.Middle);
            this.Controls.Add(this.Bass);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Reverb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Bass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Middle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Treble)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TrackBar Bass;
        private System.Windows.Forms.TrackBar Middle;
        private System.Windows.Forms.TrackBar Treble;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

