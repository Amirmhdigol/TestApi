using System.ComponentModel.DataAnnotations;

namespace TestApi.Api.ViewModels;
public class RegisterViewModel
{
    [Required(ErrorMessage = "Please Enter phone number")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter password")]
    [MinLength(6, ErrorMessage = "Password should be more than 5 characters")]
    public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Passwords are not the same")]
    public string ConfirmPassword { get; set; }

}