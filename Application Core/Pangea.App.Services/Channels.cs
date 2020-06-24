using NGU.Core;
using NGU.Enums;
using NGU.Interfaces.ApiAdmin;
using NGU.Interfaces.Services;
using Pangea.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangea.App.Services
{
    public static class Channels
    {
        #region members

        private const string CONFIG_NAME = "NGU.Border.Server";

        private static IUserService _userService;
        private static IValueObjectService _valueObjectService;
        private static ISystemService _systemService;
        private static List<SystemParameter> _systemParameter;
        private static IPersonService _personService;
        private static IRequestService _requestService;

        #endregion

        #region dictionaries methods

        public static void LoadSystemSettings(bool clearCache = false)
        {
            _systemParameter = ValueObjectService.GetSystemParameters().ToList();
        }

        public static SystemParameter GetSystemSettingsValue(SystemSettingsKeys key)
        {
            if (_systemParameter == null)
                LoadSystemSettings();

            return _systemParameter.FirstOrDefault(x => x.Name == key.ToString());
        }

        #endregion

        #region instances

        private static void WaitForResponse(IBaseService service)
        {
            bool isAlive = false;
            for (int i = 0; i < 60 && !isAlive; i++)
            {
                try
                {
                    isAlive = service.IsAlive();
                }
                catch (Exception ex)
                {
                    Task.Delay(1000).Wait();
                }
            }
        }

        //[XmlIgnoreAttribute]
        public static IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = WcfHelper.CreateWCFClientByConfig<IUserService>(CONFIG_NAME);
                    WaitForResponse(_userService);
                }
                return _userService;
            }
        }

        //[XmlIgnoreAttribute]
        public static IValueObjectService ValueObjectService
        {
            get
            {
                if (_valueObjectService == null)
                {
                    _valueObjectService = WcfHelper.CreateWCFClientByConfig<IValueObjectService>(CONFIG_NAME);
                    WaitForResponse(_valueObjectService);
                }

                return _valueObjectService;
            }
        }

        //[XmlIgnoreAttribute]
        public static ISystemService SystemService
        {
            get
            {
                if (_systemService == null)
                {
                    _systemService = WcfHelper.CreateWCFClientByConfig<ISystemService>(CONFIG_NAME);
                    WaitForResponse(_systemService);
                }

                return _systemService;
            }
        }

        public static IPersonService PersonService
        {
            get
            {
                if (_personService == null)
                {
                    _personService = WcfHelper.CreateWCFClientByConfig<IPersonService>(CONFIG_NAME);
                    WaitForResponse(_personService);

                }
                return _personService;
            }
        }

        public static IRequestService RequestService
        {
            get
            {
                if (_requestService == null)
                {
                    _requestService = WcfHelper.CreateWCFClientByConfig<IRequestService>(CONFIG_NAME);
                    WaitForResponse(_requestService);
                }
                return _requestService;
            }
        }

        #endregion
    }
}
