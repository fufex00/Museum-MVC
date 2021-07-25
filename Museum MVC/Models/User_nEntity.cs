using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class User_nEntity
{
    public int User_DNI { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string User_name { get; set; }

    [Display(Name = "Apellido")]
    [Required(ErrorMessage = "Se debe ingresar el apellido")]
    public string User_last_name { get; set; }

    [Display(Name = "Rol")]
    [Required(ErrorMessage = "Se debe ingresar el rol")]
    public string User_role { get; set; }

    [Display(Name = "Contraseña")]
    [Required(ErrorMessage = "Se debe ingresar la contraseña")]
    public string User_password { get; set; }

}
