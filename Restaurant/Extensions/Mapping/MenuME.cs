using Restaurant.Models.DataTransferLayer;
using Restaurant.Models.EntityLayer;
using Restaurant.ViewModels.ObjectViewModels;

namespace Restaurant.Extensions.Mapping
{
    public static class MenuME
    {
        public static MenuDTO ToDTO(this Menu menu)
        {
            return new MenuDTO
            {
                Id = menu.MenuId,
                Name = menu.Name,
                Discount = menu.Discount
            };
        }

        public static MenuDTO ToDTO(this MenuViewModel menuViewModel)
        {
            return new MenuDTO
            {
                Id = menuViewModel.Id,
                Name = menuViewModel.Name,
                Discount = menuViewModel.Discount
            };
        }

        public static Menu ToEntity(this MenuDTO menuDTO)
        {
            return new Menu
            {
                MenuId = menuDTO.Id,
                Name = menuDTO.Name ?? "",
                Discount = menuDTO.Discount
            };
        }

        public static MenuViewModel ToViewModel(this MenuDTO menuDTO)
        {
            return new MenuViewModel
            {
                Id = menuDTO.Id,
                Name = menuDTO.Name ?? "",
                Discount = menuDTO.Discount
            };
        }
    }
}