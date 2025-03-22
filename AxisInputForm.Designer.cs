using System;
using System.Windows.Forms;

namespace RengaTemplate_csharp
{
    public partial class AxisInputForm : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxX;
        private TextBox textBoxY;
        private TextBox textBoxLevels;
        private Button buttonOK;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxLevels = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axis X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Axis Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Levels";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(53, 12);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(200, 20);
            this.textBoxX.TabIndex = 3;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(53, 38);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(200, 20);
            this.textBoxY.TabIndex = 4;
            // 
            // textBoxLevels
            // 
            this.textBoxLevels.Location = new System.Drawing.Point(53, 64);
            this.textBoxLevels.Name = "textBoxLevels";
            this.textBoxLevels.Size = new System.Drawing.Size(200, 20);
            this.textBoxLevels.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(178, 90);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AxisInputForm
            // 
            this.ClientSize = new System.Drawing.Size(265, 125);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxLevels);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AxisInputForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

