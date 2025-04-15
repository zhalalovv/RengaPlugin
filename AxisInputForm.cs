using System;
using System.Windows.Forms;
using Renga;

namespace RengaTemplate_csharp
{
    public partial class AxisInputForm : Form
    {
        public string AxisX { get; private set; }
        public string AxisY { get; private set; }
        public int SelectedLevel { get; private set; }

        public AxisInputForm(IModelObjectCollection levels)
        {
            InitializeComponent();
            PopulateLevels(levels);
        }

        private void PopulateLevels(IModelObjectCollection levels)
        {
            for (int i = 0; i < levels.Count; i++)
            {
                IModelObject level = levels.GetByIndex(i);
                comboBoxLevels.Items.Add(new ComboBoxItem(level.Name, level.Id));
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxLevels.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите уровень перед продолжением.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AxisX = textBoxX.Text;
            AxisY = textBoxY.Text;
            SelectedLevel = ((ComboBoxItem)comboBoxLevels.SelectedItem).Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboBoxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}