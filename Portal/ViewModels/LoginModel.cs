using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле Логин обязательно для заполнения")]
        public string Login { get; set; }
         
        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}