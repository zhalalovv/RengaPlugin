using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Renga;

namespace RengaPlugin
{
    public partial class DoorWindowForm : Form
    {
        private readonly IModel _model;
        private readonly IApplication _app;
        private readonly List<string> _savedItems;
        private int? _savedObjectId;

        public DoorWindowForm(IApplication app)
        {
            InitializeComponent();

            _app = app;
            _model = app.Project.Model;
            _savedItems = new List<string>();

            btnSave.Click += SaveButton_Click;
        }

        private IModelObject FindObjectById(int id)
        {
            try
            {
                IModelObjectCollection modelObjects = _model.GetObjects();
                return modelObjects.GetById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении объекта: " + ex.Message);
                return null;
            }
        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            var selection = _app.Selection;
            object selectedObjects = selection.GetSelectedObjects();

            // Преобразуем SAFEARRAY в обычный массив int[]
            int[] selectedIds = ConvertToIntArray(selectedObjects);

            if (selectedIds == null || selectedIds.Length != 1)
            {
                MessageBox.Show("Пожалуйста, выберите одну дверь или окно.");
                return;
            }

            var objectId = selectedIds[0];
            _savedObjectId = objectId;

            // Получаем объект из модели
            var element = FindObjectById(objectId);
            if (element == null)
            {
                MessageBox.Show("Не удалось получить элемент.");
                return;
            }

            string typeName;
            double width = 0, height = 0, offset = 0;
            Point3D position;

            if (element is IDoorParams door)
            {
                typeName = "Дверь";
                width = door.Width;
                height = door.Height;
                offset = door.VerticalOffset;
                position = door.Position;
            }
            else if (element is IWindowParams window)
            {
                typeName = "Окно";
                width = window.Width;
                height = window.Height;
                offset = window.VerticalOffset;
                position = window.Position;
            }
            else
            {
                MessageBox.Show("Выбранный объект не является дверью или окном.");
                return;
            }

            string info = $"{typeName}: Ширина={width:0.##}, Высота={height:0.##}, Позиция=({position.X:0.##}; {position.Y:0.##}; {position.Z:0.##}), Offset={offset:0.##}";
            _savedItems.Add(info);
            listBoxParams.Items.Add(info);

            // Снять выделение после сохранения
            selection.SetSelectedObjects(new int[0]);
        }

        private int[] ConvertToIntArray(object selectedObjects)
        {
            if (selectedObjects is Array safeArray)
            {
                int[] result = new int[safeArray.Length];
                Array.Copy(safeArray, result, safeArray.Length);
                return result;
            }
            return null;
        }
    }
}
