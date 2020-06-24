using NGU.App.DTO;
using Pangea.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NGU.App.Client.Utitlities
{
    public class MenuUtilities
    {
        public static List<ViewModelName> PermittedMenus { get; set; }

        public static List<MenuNodeDTO> ConvertToMenuDTO(IList<Pangea.App.Menu.Menu> menuTree, MenuNodeDTO module = null)
        {
            IList<MenuNodeDTO> result = new List<MenuNodeDTO>();
            foreach (Pangea.App.Menu.Menu menu in menuTree)
            {
                result.Add(ConvertToMenuDTO(menu, module));
            }

            return result.ToList();
        }

        public static MenuNodeDTO ConvertToMenuDTO(Pangea.App.Menu.Menu menu, MenuNodeDTO module = null) 
        {
            MenuNodeDTO menuDTO = new MenuNodeDTO();
            //menuDTO.Name = menu.GetType().GetProperty(AppUtilities.rm.GetString("DescriptionLang")).GetValue(menu, null).ToString();
            menuDTO.Name = Lang.Resources.ResourceManager.GetString(menu.Name); // AppUtilities.rm.GetString(menu.Name); 
            menuDTO.ModuleType = menu.Module?.Type;
            menuDTO.MenuId = menu.Id;
            menuDTO.ShowSideMenu = (menu.Module == null ? false : menu.Module.ShowSideMenu);
            menuDTO.IsProcess = (menu.Module == null ? false : menu.Module.IsProcess);
            menuDTO.Image = menu.Image == null ? null : (ImageSource)System.Windows.Application.Current.TryFindResource(menu.Image);
            menuDTO.ViewModelName = menu.Invocation.ViewModelName;
            menuDTO.AssembleyName = menu.Invocation.Assembly;
            menuDTO.ParamFunction = menu.Invocation.Param;
            menuDTO.Accessibility = menu.Accessibility != null ? menu.Accessibility.Split(',').ToList() : new List<string>();

            if (menu.SubMenus != null && menu.SubMenus.Menus.Count > 0)
            {
                menu.SubMenus.Menus.ForEach(m =>
                {
                    if (m.Accessibility != null)
                        menuDTO.Accessibility.AddRange(m.Accessibility.Split(',').ToList());
                });
            }

            if (module == null) // mainmenu
            {
                // TODO - bring PermittedMenus back to life
                menuDTO.IsEnabled = true; // PermittedMenus.Contains((ViewModelName)menu.Id);
            }
            else if (module.IsProcess)
                menuDTO.IsEnabled = false;
            else
                menuDTO.IsEnabled = true;

            menuDTO.ShowDetailsBox = menu.DetailsBox;
            menuDTO.IsModule = menu.IsModule;

            return menuDTO;
        }
    }
}
