using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
        private readonly string _filePath = "savedItems.json";

        public DoorWindowForm(IApplication app, List<string> savedItems)
        {
            InitializeComponent();

            _app = app;
            _model = app.Project.Model;
            _savedItems = savedItems;

            LoadSavedItems();

            UpdateListBox();

            btnSave.Click += SaveButton_Click;
        }

        private void UpdateListBox()
        {
            listBoxParams.Items.Clear();
            foreach (var item in _savedItems)
            {
                listBoxParams.Items.Add(item);
            }
        }

        // Метод для загрузки сохранённых данных из JSON-файла
        private void LoadSavedItems()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    var savedData = File.ReadAllText(_filePath);
                    var items = JsonConvert.DeserializeObject<List<string>>(savedData);

                    foreach (var item in items)
                    {
                        if (!_savedItems.Contains(item))
                        {
                            _savedItems.Add(item);
                            listBoxParams.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        // Метод для сохранения данных в JSON-файл
        private void SaveItemsToFile()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(_savedItems, Formatting.Indented);
                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
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

            string info = $"{typeName}: Ширина={width}, Высота={height}, Позиция=({position.X}; {position.Y}; {position.Z}), Offset={offset}";

            // Проверка
            if (_savedItems.Contains(info))
            {
                MessageBox.Show("Этот объект уже сохранён.");
                return;
            }

            _savedItems.Add(info);
            listBoxParams.Items.Add(info);

            SaveItemsToFile();

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

        private void AddButton_Click(object sender, EventArgs e)
        {
            //if (listBoxParams.SelectedItem == null)
            //{
            //    MessageBox.Show("Выберите параметр из списка.");
            //    return;
            //}

            //string selectedText = listBoxParams.SelectedItem.ToString();
            //bool isWindow = selectedText.StartsWith("Окно");
            //bool isDoor = selectedText.StartsWith("Дверь");

            //if (!isWindow && !isDoor)
            //{
            //    MessageBox.Show("Неверный формат строки.");
            //    return;
            //}

            //try
            //{
            //    double width = ParseDouble(selectedText, "Ширина=");
            //    double height = ParseDouble(selectedText, "Высота=");
            //    double offset = ParseDouble(selectedText, "Offset=");
            //    Point3D position = ParsePosition(selectedText);

            //    // Создаем аргументы создания
            //    INewEntityArgs newArgs = null;
            //    _project.CreateNewEntityArgs(out newArgs);

            //    // Устанавливаем тип объекта
            //    newArgs.SetObjectType(isWindow ? "Window" : "Door");

            //    // Получаем размещение
            //    IPlacement3D placement = null;
            //    newArgs.GetPlacement3D(out placement);

            //    placement.SetOrigin(position.X, position.Y, position.Z);
            //    placement.SetAxisX(1, 0, 0);
            //    placement.SetAxisY(0, 1, 0);

            //    // Создаем объект
            //    IModelObject modelObject;
            //    _project.CreateObject(newArgs, out modelObject);

            //    if (isDoor && modelObject is IDoorParams door)
            //    {
            //        door.put_Width(width);
            //        door.put_Height(height);
            //        door.put_VerticalOffset(offset);
            //    }
            //    else if (isWindow && modelObject is IWindowParams window)
            //    {
            //        window.put_Width(width);
            //        window.put_Height(height);
            //        window.put_VerticalOffset(offset);
            //    }

            //    MessageBox.Show($"{(isWindow ? "Окно" : "Дверь")} добавлено в модель.");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при добавлении: " + ex.Message);
            //}
        }


        //private double ParseDouble(string source, string key)
        //{
        //    int start = source.IndexOf(key) + key.Length;
        //    int end = source.IndexOf(",", start);
        //    if (end == -1) end = source.Length;
        //    string value = source.Substring(start, end - start);
        //    return double.Parse(value.Trim());
        //}

        //private Point3D ParsePosition(string source)
        //{
        //    int start = source.IndexOf("Позиция=(") + "Позиция=(".Length;
        //    int end = source.IndexOf(")", start);
        //    string[] parts = source.Substring(start, end - start).Split(';');
        //    return new Point3D
        //    {
        //        X = double.Parse(parts[0]),
        //        Y = double.Parse(parts[1]),
        //        Z = double.Parse(parts[2])
        //    };
        //}
    }
}
