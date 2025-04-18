using System;
using Renga;
using System.Windows.Forms;

namespace RengaPlugin
{
    public class InitApp : Renga.IPlugin
    {
        private Renga.ActionEventSource follow_action;
        private IApplication _app;
        private DoorWindowForm _form;

        public bool Initialize(string pluginFolder)
        {
            _app = new Renga.Application();

            IUI renga_ui = _app.UI;
            IUIPanelExtension panel = renga_ui.CreateUIPanelExtension();

            // Создаем кнопку для активации плагина
            IAction our_button = renga_ui.CreateAction();
            our_button.ToolTip = "Test plugin";
            our_button.DisplayName = "Start Test Message Box";

            // Событие нажатия на кнопку
            follow_action = new ActionEventSource(our_button);
            follow_action.Triggered += (sender, args) =>
            {
                // Создаем форму сразу при запуске плагина
                _form = new DoorWindowForm(); // Вы можете передать параметры, если нужно

                // Показываем форму
                _form.ShowDialog();
            };

            panel.AddToolButton(our_button);
            renga_ui.AddExtensionToPrimaryPanel(panel);

            return true;
        }

        public void Stop()
        {
            follow_action.Dispose();
        }

    }
}
