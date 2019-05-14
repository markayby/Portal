using System.ComponentModel.DataAnnotations;

namespace Portal.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Поле Пароль обязательно для заполнения")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Поле Подтверждение пароля обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Поле Пароль и Подтверждение пароля должны иметь одинаковое значение")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}