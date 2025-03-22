using System;
using Renga;
using System.Windows.Forms;

namespace RengaTemplate_csharp
{
    public class init_app : Renga.IPlugin
    {
        Renga.ActionEventSource follow_action;
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
                ShowAxisInputForm();
            };

            panel.AddToolButton(our_button);
            renga_ui.AddExtensionToPrimaryPanel(panel);

            return true;
        }

        private void ShowAxisInputForm()
        {
            using (AxisInputForm form = new AxisInputForm())
            {
                form.ShowDialog();
            }
        }

        public void Stop()
        {
            follow_action.Dispose();
        }
    }
}
