using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Renga;

namespace RengaTemplate_csharp
{
    public class InitApp : Renga.IPlugin
    {
        private ActionEventSource follow_action;

        public bool Initialize(string pluginFolder)
        {
            Renga.Application renga_app = new Renga.Application();
            Renga.IUI renga_ui = renga_app.UI;
            Renga.IUIPanelExtension panel = renga_ui.CreateUIPanelExtension();

            Renga.IAction our_button = renga_ui.CreateAction();
            our_button.ToolTip = "Axis Plugin";
            our_button.DisplayName = "Axis Plugin";

            follow_action = new ActionEventSource(our_button);
            follow_action.Triggered += (sender, args) =>
            {
                ShowAxisInputForm(renga_app);
            };

            panel.AddToolButton(our_button);
            renga_ui.AddExtensionToPrimaryPanel(panel);

            return true;
        }

        private void ShowAxisInputForm(Renga.Application renga_app)
        {
            Renga.IProject project = renga_app.Project;
            if (project == null)
            {
                MessageBox.Show("Project is not open.");
                return;
            }

            IModelObjectCollection levels = project.Model.GetObjects();

            using (AxisInputForm form = new AxisInputForm(levels))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    //CreateAxes(renga_app, form.AxisX, form.AxisY);
                }
            }
        }

        //private void CreateAxes(Renga.Application renga_app, string axisX, string axisY)
        //{
        //    try
        //    {
        //        Renga.IProject project = renga_app.Project;
        //        if (project == null)
        //        {
        //            MessageBox.Show("Project is not open.");
        //            return;
        //        }

        //        Renga.IModel model = project.Model;
        //        IOperation operation = model.CreateOperation();

        //        var axisXParams = ParseAxisParameters(axisX);
        //        var axisYParams = ParseAxisParameters(axisY);

        //        double xOffset = 0.0;
        //        foreach (var param in axisXParams)
        //        {
        //            for (int i = 0; i < param.Item2; i++)
        //            {
        //                CreateAxis(model, xOffset, true);
        //                xOffset += param.Item1;
        //            }
        //        }

        //        double yOffset = 0.0;
        //        foreach (var param in axisYParams)
        //        {
        //            for (int i = 0; i < param.Item2; i++)
        //            {
        //                CreateAxis(model, yOffset, false);
        //                yOffset += param.Item1;
        //            }
        //        }

        //        operation.Apply();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }
        //}

        //private void CreateAxis(Renga.IModel model, double position, bool isXAxis)
        //{
        //    try
        //    {
        //        // Создаем ось как обычный объект модели
        //        var axis = model.CreateObject(); // Псевдокод для создания объекта, проверьте доступный метод создания объекта

        //        if (axis == null)
        //        {
        //            MessageBox.Show("Ошибка: Не удалось создать ось.");
        //            return;
        //        }

        //        // Получаем параметры объекта
        //        IParameterContainer parameters = axis.GetParameters(); // Получаем параметры объекта

        //        // Пример установки параметра оси
        //        if (parameters != null)
        //        {
        //            IParameter nameParam = parameters.Get("Name"); // Получаем параметр по имени (замените на актуальное имя)

        //            if (nameParam != null)
        //            {
        //                nameParam.SetStringValue(isXAxis ? $"X{position}" : $"Y{position}");
        //            }
        //        }

        //        // Устанавливаем позицию оси
        //        SetAxisPosition(axis, position, isXAxis);

        //        // Применяем операцию для добавления оси в модель
        //        IOperation operation = model.CreateOperation();
        //        operation.Apply(); // Применяем операцию
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при создании оси: {ex.Message}");
        //    }
        //}

        //private void SetAxisPosition(IModelObject axis, double position, bool isXAxis)
        //{
        //    try
        //    {
        //        // Для установки позиции оси, используйте правильные методы для изменения координат
        //        IPlacement3D placement = axis as IPlacement3D;
        //        if (placement != null)
        //        {
        //            placement.SetCoordinates(isXAxis ? position : 0, isXAxis ? 0 : position, 0); // Метод для установки координат
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка при установке позиции оси: {ex.Message}");
        //    }
        //}

        private List<Tuple<double, int>> ParseAxisParameters(string axisInput)
        {
            List<Tuple<double, int>> axisParams = new List<Tuple<double, int>>();
            string[] parts = axisInput.Split(',');

            foreach (string part in parts)
            {
                string[] values = part.Trim().Split('x');
                if (values.Length == 2 && double.TryParse(values[0], out double step) && int.TryParse(values[1], out int count))
                {
                    axisParams.Add(new Tuple<double, int>(step, count));
                }
            }

            return axisParams;
        }

        public void Stop()
        {
            follow_action.Dispose();
        }
    }
}
