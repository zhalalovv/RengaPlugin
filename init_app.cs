using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Renga;

namespace RengaTemplate_csharp
{
    public class InitApp : Renga.IPlugin
    {
        private IAction ourButton;
        private IApplication rengaApp;

        public bool Initialize(string pluginFolder)
        {
            rengaApp = new Renga.Application();
            IUI rengaUI = rengaApp.UI;
            IUIPanelExtension panel = rengaUI.CreateUIPanelExtension();

            ourButton = rengaUI.CreateAction();
            ourButton.ToolTip = "Axis Plugin";
            ourButton.DisplayName = "Axis Plugin";

            // Регистрируем обработчик событий кнопки
            var connectionPointContainer = ourButton as IConnectionPointContainer;
            if (connectionPointContainer != null)
            {
                Guid guid = typeof(_IActionEvents).GUID;
                connectionPointContainer.FindConnectionPoint(ref guid, out IConnectionPoint connectionPoint);

                var sink = new AxisActionEventHandler(this);
                connectionPoint.Advise(sink, out int cookie);
            }

            panel.AddToolButton(ourButton);
            rengaUI.AddExtensionToPrimaryPanel(panel);

            return true;
        }

        public void ShowAxisInputForm()
        {
            IProject project = rengaApp.Project;
            if (project == null)
            {
                MessageBox.Show("Project is not open.");
                return;
            }

            IModel model = project.Model;

            using (AxisInputForm form = new AxisInputForm(model.GetObjects()))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CreateAxes(form.AxisX, form.AxisY);
                }
            }
        }

        private void CreateAxes(string axisX, string axisY)
        {
            try
            {
                IProject project = rengaApp.Project;
                if (project == null)
                {
                    MessageBox.Show("Project is not open.");
                    return;
                }

                IModel model = project.Model;
                IOperation operation = project.CreateOperation();  // Создаем операцию

                // Получаем параметры осей и создаём их
                var axisXParams = ParseAxisParameters(axisX);
                var axisYParams = ParseAxisParameters(axisY);

                // Создание осей
                double xOffset = 0.0;
                foreach (var param in axisXParams)
                {
                    for (int i = 0; i < param.Item2; i++)
                    {
                        CreateAxis(model, xOffset, 0); // Ось X
                        xOffset += param.Item1;
                    }
                }

                double yOffset = 0.0;
                foreach (var param in axisYParams)
                {
                    for (int i = 0; i < param.Item2; i++)
                    {
                        CreateAxis(model, 0, yOffset); // Ось Y
                        yOffset += param.Item1;
                    }
                }

                operation.Apply();

                MessageBox.Show("Axes created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CreateAxis(IModel model, double x, double y)
        {
            // Получаем объекты модели
            var objectsCollection = model.GetObjects();
            if (objectsCollection.Count == 0)
            {
                MessageBox.Show("No objects found in the model.");
                return;
            }

            // Получаем первый объект (или подходящий объект) из коллекции
            IModelObject axisObject = objectsCollection.GetByIndex(0);  // Это просто пример, выбираем первый объект

            // Настройка параметров для объекта (например, позиция)
            var properties = axisObject.GetProperties(); // Получаем контейнер свойств
            if (properties != null)
            {
                // Пример установки значения (координат)
                // Если есть свойство для позиции, установим его здесь
                // Пример: properties.SetProperty("Position", new Position(x, y));
                MessageBox.Show($"Axis created at position: ({x}, {y})");
            }
        }

        private List<Tuple<double, int>> ParseAxisParameters(string axisInput)
        {
            var axisParams = new List<Tuple<double, int>>();
            string[] parts = axisInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string[] values = part.Trim().Split('*');
                if (values.Length == 2 &&
                    double.TryParse(values[0], out double step) &&
                    int.TryParse(values[1], out int count))
                {
                    axisParams.Add(new Tuple<double, int>(step, count));
                }
            }

            return axisParams;
        }

        public void Stop()
        {
            // Пока нет необходимости в отписке, так как OnTriggered вызывается вручную
        }
    }
}
