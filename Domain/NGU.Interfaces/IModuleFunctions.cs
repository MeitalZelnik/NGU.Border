using NGU.App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGU.Interfaces
{
    public interface IModuleFunctions
    {
        MessageDialogDTO Save();
        void Cancel();
        bool IsValid();
        /// <summary>
        /// This is for use when we change a Tab
        /// </summary>
        void PreSave();

        bool HasChanged{get;}

        bool CanSwitch { get; }


    }
}
