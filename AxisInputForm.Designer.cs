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
        private ComboBox comboBoxLevels;
        private Button buttonOK;
        private TableLayoutPanel tableLayoutPanel;


        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.comboBoxLevels = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();

            // tableLayoutPanel
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            this.tableLayoutPanel.Padding = new Padding(10);

            // label1
            this.label1.Text = "Axis X:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Dock = DockStyle.Fill;

            // label2
            this.label2.Text = "Axis Y:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Dock = DockStyle.Fill;

            // label3
            this.label3.Text = "Levels:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Dock = DockStyle.Fill;

            // textBoxX
            this.textBoxX.Dock = DockStyle.Fill;
            this.textBoxX.Margin = new Padding(5);

            // textBoxY
            this.textBoxY.Dock = DockStyle.Fill;
            this.textBoxY.Margin = new Padding(5);

            // comboBoxLevels
            this.comboBoxLevels.Dock = DockStyle.Fill;
            this.comboBoxLevels.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxLevels.Margin = new Padding(5);

            // buttonOK
            this.buttonOK.Text = "OK";
            this.buttonOK.Dock = DockStyle.Fill;
            this.buttonOK.Margin = new Padding(5);
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonOK.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.FlatStyle = FlatStyle.Flat;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);

            // Добавляем элементы в таблицу
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxX, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.textBoxY, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.comboBoxLevels, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonOK, 0, 3);
            this.tableLayoutPanel.SetColumnSpan(this.buttonOK, 2); // Кнопка занимает всю ширину

            // AxisInputForm
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "AxisInputForm";
            this.Text = "Enter Axis Data";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}