using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


public class CultureEntity
{

    public int Culture_id { get; set; }

    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "Se debe ingresar la descripcion")]
    public string Culture_description { get; set; }

    [Display(Name = "Estado")]
    public string Culture_status { get; set; }
}
