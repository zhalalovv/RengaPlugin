using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RengaTemplate_csharp
{
    public partial class AxisInputForm : Form
    {
        public string AxisX { get; private set; }
        public string AxisY { get; private set; }
        public string Levels { get; private set; }

        public AxisInputForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AxisX = textBoxX.Text;
            AxisY = textBoxY.Text;
            Levels = textBoxLevels.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

