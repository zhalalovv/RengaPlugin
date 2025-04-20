using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Renga;

namespace RengaPlugin
{
    public partial class DoorWindowForm : Form
    {
        private IProject project;
        private IModel model;
        private List<IModelObject> doorWindowObjects = new List<IModelObject>();

        public DoorWindowForm(IProject rengaProject)
        {
            InitializeComponent();
            project = rengaProject;
            model = project.Model;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (listBoxParams.SelectedItem is IModelObject selectedObj)
            {
                double width = Convert.ToDouble(textBoxWidth.Text);
                double height = Convert.ToDouble(textBoxHeight.Text);
                double offset = Convert.ToDouble(textBoxOffset.Text);

                UpdateElement(selectedObj, width, height, offset);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double width = Convert.ToDouble(textBoxWidth.Text);
            double height = Convert.ToDouble(textBoxHeight.Text);
            double offset = Convert.ToDouble(textBoxOffset.Text);

            string selectedType = comboBoxType.SelectedItem?.ToString();
            if (selectedType == "Окно")
                AddNewElementToProject("Окно", width, height, offset);
            else if (selectedType == "Дверь")
                AddNewElementToProject("Дверь", width, height, offset);
            else
                MessageBox.Show("Выберите тип элемента: Окно или Дверь.");
        }

        private void AddNewElementToProject(string type, double width, double height, double offset)
        {
            IElementType elementType = null;

            // Ищем подходящий тип элемента (окно или дверь)
            foreach (IElementType et in model.GetElementTypes())  // Понять, как работать с типами в твоей версии Renga
            {
                string name = et.Name.ToLower();
                if ((type == "Дверь" && name.Contains("дверь")) ||
                    (type == "Окно" && name.Contains("окно")))
                {
                    elementType = et;
                    break;
                }
            }

            if (elementType == null)
            {
                MessageBox.Show($"Тип {type} не найден.");
                return;
            }

            IOperation op = project.CreateOperation();
            op.Start();

            // Создание нового объекта
            IModelObject obj = model.CreateObject(elementType.Id);  // Убедись, что метод CreateObject существует
            if (obj == null)
            {
                op.RollBack();  // Убедись, что RollBack существует
                MessageBox.Show("Не удалось создать объект.");
                return;
            }

            // Установка параметров нового объекта
            SetElementParams(obj, width, height, offset);

            model.AddObject(obj);  // Убедись, что AddObject существует
            op.Apply();

            // Добавление объекта в список
            doorWindowObjects.Add(obj);
            listBoxParams.Items.Add(obj);
        }

        private void UpdateElement(IModelObject obj, double width, double height, double offset)
        {
            IOperation op = project.CreateOperation();
            op.Start();

            SetElementParams(obj, width, height, offset);

            op.Apply();
        }

        private void SetElementParams(IModelObject obj, double width, double height, double offset)
        {
            IParameterContainer parameters = obj as IParameterContainer;
            if (parameters == null)
                return;

            SetParameter(parameters, "Width", width);
            SetParameter(parameters, "Height", height);
            SetParameter(parameters, "VerticalOffset", offset);

            // Позиционирование — смещение по X (смотри, как правильно работать с Placement в Renga)
            IPlacement placement = obj.Placement;  // Проверь работу с Placement
            if (placement != null)
            {
                IPoint3D origin = placement.GetCoordinateSystem().Origin;  // Проверь, как правильно работать с координатами
                origin.X = offset;
                placement.GetCoordinateSystem().Origin = origin;
                obj.Placement = placement;
            }
        }

        private void SetParameter(IParameterContainer container, string name, double value)
        {
            IParameter param = container.GetParameter(name);
            if (param != null && param.Value is IDoubleParameterValue doubleVal)
                doubleVal.Value = value;
        }

        private void listBoxParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxParams.SelectedItem is IModelObject obj)
            {
                IParameterContainer parameters = obj as IParameterContainer;

                textBoxWidth.Text = GetParameterValue(parameters, "Width");
                textBoxHeight.Text = GetParameterValue(parameters, "Height");
                textBoxOffset.Text = GetParameterValue(parameters, "VerticalOffset");
            }
        }

        private string GetParameterValue(IParameterContainer container, string name)
        {
            IParameter param = container?.GetParameter(name);
            if (param != null && param.Value is IDoubleParameterValue doubleVal)
                return doubleVal.Value.ToString("F2");

            return "";
        }
    }
}
