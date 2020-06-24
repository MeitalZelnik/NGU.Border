using NGU.App.Client.Utitlities;
using NGU.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Pangea.Extensions;
using Pangea.BaseStructures;
using Pangea.App.Utils;

namespace NGU.App.Client.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {

        public Request DetailsApplication
        {
            get
            {
                return AppUtilities.CurrentApp;
            }
        }

        public string DetailsViewString
        {
            get
            {
                
                return string.Empty;
            }
        }

        //public string EnteredFormNumber
        //{
        //    get
        //    {
        //        if (!IsFormNumberEnable)
        //            return DetailsApplication.ID.ToString();
        //        else return _enteredFormNumber;
        //    }
        //    set
        //    {
        //        _enteredFormNumber = value;
        //        NotifyPropertyChanged(() => EnteredFormNumber);
        //        NotifyPropertyChanged(() => CanSearchForm);
        //    }
        //}

        //public bool IsFormNumberEnable
        //{
        //    get
        //    {
        //        return (DetailsApplication == null || 
        //            DetailsApplication.RequestStatus == null);
        //    }
        //}


        //public int? PersonNo
        //{
        //    get
        //    {
        //        return null;
        //        //if (DetailsApplication == null)
        //        //    return null;
        //        //if (DetailsApplication.PersonNo.HasValue == false)
        //        //    return null;
        //        //return DetailsApplication.PersonNo.Value;
        //    }
        //}
        //public bool CanSearchForm
        //{
        //    get
        //    {
        //        return IsFormNumberEnable == true && !EnteredFormNumber.IsNullOrEmpty();
        //    }
        //}

        //public override bool HasChanged
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public ICommand SearchApplicationCommand
        //{
        //    get
        //    {
        //        if (_searchApplicationCommand == null)
        //        {
        //            _searchApplicationCommand = new RelayCommand(SearchApplication);
        //        }

        //        return _searchApplicationCommand;
        //    }
        //}

        //private bool IsValid()
        //{
        //    return true;
        //}

        //private void SearchApplication(object obj)
        //{

        //    if (!this.IsValid())
        //    {
        //        this.ShowNotification(Lang.Resources.ResourceManager.GetString("ERR_IncorrectAppNumber"), NotificationAreaType.Error);
        //        return;
        //    }

        //    long formNum = 0;
        //    long.TryParse(EnteredFormNumber, out formNum);

        //    //var currentApp = Services.FormService.GetApplication(formNum);
        //    //if (currentApp == null)
        //    //    this.ShowNotification(Domain.Enums.NotificationMessages.NoDataFound, NotificationAreaType.Error);
        //    //else
        //    //{
        //    //    this.ClearNotification();
        //    //    AppUtilities.CurrentApp = currentApp;
        //    //}

        //    NotifyPropertyChanged(() => IsFormNumberEnable);
        //    NotifyPropertyChanged(() => DetailsApplication);
        //    NotifyPropertyChanged(() => PersonNo);
        //    NotifyPropertyChanged(() => CanSearchForm);
        //}

        public override void Refresh()
        {
            NotifyPropertyChanged(() => DetailsApplication);
            NotifyPropertyChanged(() => DetailsViewString);

        }
    }
}
