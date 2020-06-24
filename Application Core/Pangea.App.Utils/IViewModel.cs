using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.App.Utils
{
    public interface IViewModel
    {
        bool HasChanged { get; }

        event Action<string, NotificationAreaType> OnNotifcation;
        event Action<ViewModelName> ViewModelChange;

        void ShowNotification(string notification, NotificationAreaType type);
        void ShowNotification(NotificationMessages messages, NotificationAreaType type);
        bool Validate(ref NotificationMessages msg);
        void ResetPage();
    }
}
