using System.ComponentModel.DataAnnotations;

namespace eShop.Web.Common.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; } = string.Empty;
    }
}
