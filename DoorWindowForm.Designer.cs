using System.Windows.Forms;
using System.Drawing;

namespace RengaPlugin
{
    partial class DoorWindowForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxParams;
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
            //this.listBoxParams.SelectedIndexChanged += new System.EventHandler(this.listBoxParams_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 180);
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // buttonAdd
            // 
            //this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnAdd.Location = new System.Drawing.Point(216, 370);
            //this.btnAdd.Size = new System.Drawing.Size(90, 30);
            //this.btnAdd.Text = "Добавить";
            //this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DoorWindowForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 220);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.MaximumSize = new System.Drawing.Size(700, 300);
            this.Controls.Add(this.listBoxParams);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAdd);
            this.Text = "Параметры дверей и окон";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

