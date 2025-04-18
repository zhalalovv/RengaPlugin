using Renga;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RengaPlugin
{
    public partial class DoorWindowForm : Form
    {
        private List<ParamItem> paramItems = new List<ParamItem>();

        // Конструктор теперь не требует передачи данных
        public DoorWindowForm()
        {
            InitializeComponent();
        }

        private void AddParamItem(string type, double width, double height, double offset)
        {
            paramItems.Add(new ParamItem
            {
                Type = type,
                Width = width,
                Height = height,
                Offset = offset
            });
        }

        private void RefreshListBox()
        {
            listBoxParams.Items.Clear();
            foreach (var item in paramItems)
            {
                listBoxParams.Items.Add(item.ToString());
            }
        }

        private void listBoxParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxParams.SelectedIndex;
            if (index >= 0)
            {
                var selected = paramItems[index];
                comboBoxType.SelectedItem = selected.Type;  // Заменено на comboBoxType
                textBoxWidth.Text = selected.Width.ToString();
                textBoxHeight.Text = selected.Height.ToString();
                textBoxOffset.Text = selected.Offset.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int index = listBoxParams.SelectedIndex;
            if (index >= 0)
            {
                paramItems[index] = new ParamItem
                {
                    Type = comboBoxType.SelectedItem.ToString(),  // Заменено на comboBoxType
                    Width = double.TryParse(textBoxWidth.Text, out var w) ? w : 0,
                    Height = double.TryParse(textBoxHeight.Text, out var h) ? h : 0,
                    Offset = double.TryParse(textBoxOffset.Text, out var o) ? o : 0,
                };
                RefreshListBox();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxParams.SelectedIndex;
            if (index >= 0)
            {
                paramItems.RemoveAt(index);
                RefreshListBox();
                comboBoxType.SelectedIndex = -1;  // Очистить ComboBox
                textBoxWidth.Clear();
                textBoxHeight.Clear();
                textBoxOffset.Clear();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddParamItem(comboBoxType.SelectedItem.ToString(),  // Заменено на comboBoxType
                         double.TryParse(textBoxWidth.Text, out var w) ? w : 0,
                         double.TryParse(textBoxHeight.Text, out var h) ? h : 0,
                         double.TryParse(textBoxOffset.Text, out var o) ? o : 0);
            RefreshListBox();
        }
    }

    public class ParamItem
    {
        public string Type { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Offset { get; set; }

        public override string ToString()
        {
            return $"{Type} - W:{Width}, H:{Height}, Offset:{Offset}";
        }
    }
}
