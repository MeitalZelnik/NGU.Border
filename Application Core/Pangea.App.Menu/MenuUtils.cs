using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Pangea.App.Menu
{
    public static class MenuUtils
    {
        #region fields
        private static RootMenu _root = null;
        private static Assembly _appassembly = null;
        #endregion

        #region properties
        public static Assembly AppAssembly
        {
            get
            {
                return _appassembly ?? Assembly.GetEntryAssembly();
            }
            set
            {
                _appassembly = value;
            }
        }
        #endregion

        #region constructor
        static MenuUtils()
        {
            _root = (RootMenu)(new XmlSerializer(typeof(RootMenu)).Deserialize(
                XmlReader.Create(AppAssembly.GetManifestResourceStream(
                    AppAssembly.GetManifestResourceNames().FirstOrDefault(p => p.EndsWith("Menus.xml"))))));
        }
        #endregion

        #region private methods
        private static List<Menu> GetRootMenu(Func<AppMenu, bool> predicate)
        {
            AppMenu appMenu = _root.AppMenus.FirstOrDefault(predicate);
            if (appMenu != null)
                return appMenu.Menus;
            else
                return null;
        }

        private static List<Menu> GetSubMenus(dynamic appMenuIdentifier, Func<Menu, bool> predicate)
        {
            Menu menu = null;
            if (appMenuIdentifier is int || (appMenuIdentifier is string && appMenuIdentifier != null))
                menu = GetMenu(appMenuIdentifier, predicate);
            else
                menu = GetMenu(predicate);
            if (menu != null && menu.SubMenus != null)
                return menu.SubMenus.Menus;
            else
                return null;
        }

        private static Menu FindMenuInTree(List<Menu> menus, Func<Menu, bool> predicate)
        {
            var m = menus.FirstOrDefault(predicate);
            if (m != null)
                return m;
            foreach (var menu in menus)
            {
                if (menu.SubMenus != null)
                {
                    var found = FindMenuInTree(menu.SubMenus.Menus, predicate);
                    if (found != null)
                        return found;
                }
            }
            return null;
        }

        private static Menu GetMenu(dynamic appMenuIdentifier, Func<Menu, bool> predicate)
        {
            List<Menu> menus = GetRootMenu(appMenuIdentifier);
            return menus != null ? FindMenuInTree(menus, predicate) : null;
        }

        private static Menu GetMenu(Func<Menu, bool> predicate)
        {
            foreach (var appMenu in _root.AppMenus)
            {
                var menu = FindMenuInTree(appMenu.Menus, predicate);
                if (menu != null)
                    return menu;
            }
            return null;
        }
        #endregion

        #region public methods
        public static List<Menu> GetRootMenu(int id)
        {
            return GetRootMenu(appMenu => appMenu.Id == id);
        }

        public static List<Menu> GetRootMenu(string name)
        {
            return GetRootMenu(appMenu => appMenu.Name == name);
        }

        public static List<Menu> GetSubMenus(int appMenuId, int menuId)
        {
            return GetSubMenus(appMenuId, menu => menu.Id == menuId);
        }

        public static List<Menu> GetSubMenus(string appMenuName, string menuName)
        {
            return GetSubMenus(appMenuName, menu => menu.Name == menuName);
        }

        public static List<Menu> GetSubMenus(int menuId)
        {
            return GetSubMenus(null, menu => menu.Id == menuId);
        }

        public static List<Menu> GetSubMenus(string menuName)
        {
            return GetSubMenus(null, menu => menu.Name == menuName);
        }

        public static Menu GetMenu(int appMenuId, int id)
        {
            return GetMenu(appMenuId, menu => menu.Id == id);
        }

        public static Menu GetMenu(string appMenuName, string name)
        {
            return GetMenu(appMenuName, menu => menu.Name == name);
        }

        public static Menu GetMenu(int id)
        {
            return GetMenu(menu => menu.Id == id);
        }

        public static Menu GetMenu(string name)
        {
            return GetMenu(menu => menu.Name == name);
        }
        #endregion
    }
}
