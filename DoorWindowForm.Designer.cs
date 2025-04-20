using System.Windows.Forms;
using System.Drawing;

namespace RengaPlugin
{
    partial class DoorWindowForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxParams;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxOffset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxParams = new System.Windows.Forms.ListBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxParams
            // 
            this.listBoxParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxParams.FormattingEnabled = true;
            this.listBoxParams.Location = new System.Drawing.Point(12, 12);
            this.listBoxParams.Size = new System.Drawing.Size(360, 160);
            this.listBoxParams.SelectedIndexChanged += new System.EventHandler(this.listBoxParams_SelectedIndexChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Items.AddRange(new object[] {
            "Окно",
            "Дверь"});
            this.comboBoxType.Location = new System.Drawing.Point(12, 180);
            this.comboBoxType.Size = new System.Drawing.Size(360, 21);
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(12, 210);
            this.labelWidth.Text = "Ширина";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWidth.Location = new System.Drawing.Point(12, 230);
            this.textBoxWidth.Size = new System.Drawing.Size(360, 20);
            // 
            // labelHeight
            // 
            this.labelHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(12, 260);
            this.labelHeight.Text = "Высота";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHeight.Location = new System.Drawing.Point(12, 280);
            this.textBoxHeight.Size = new System.Drawing.Size(360, 20);
            // 
            // labelOffset
            // 
            this.labelOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOffset.AutoSize = true;
            this.labelOffset.Location = new System.Drawing.Point(12, 310);
            this.labelOffset.Text = "Отступ";
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOffset.Location = new System.Drawing.Point(12, 330);
            this.textBoxOffset.Size = new System.Drawing.Size(360, 20);
            // 
            // buttonSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 370);
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // buttonAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(216, 370);
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DoorWindowForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.MinimumSize = new System.Drawing.Size(400, 450);
            this.MaximumSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.listBoxParams);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.textBoxOffset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Text = "Параметры дверей и окон";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

