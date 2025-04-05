using Renga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RengaTemplate_csharp
{
    class AxisActionEventHandler : _IActionEvents
    {
        private readonly InitApp _plugin;

        public AxisActionEventHandler(InitApp plugin)
        {
            _plugin = plugin;
        }

        public void OnToggled(bool isChecked) { }

        public void OnTriggered()
        {
            _plugin.ShowAxisInputForm(); // показываем форму при нажатии кнопки
        }
    }
}
