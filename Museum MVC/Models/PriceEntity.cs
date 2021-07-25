using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class PriceEntity
{
    public int Price_id { get; set; }

    [Display(Name = "Id museo")]
    [Required(ErrorMessage = "Se debe ingresar el id del museo")]
    public int Museum_id { get; set; }

    [Display(Name = "Modalidad")]
    [Required(ErrorMessage = "Se debe ingresar la modalidad")]
    public string Price_modality { get; set; }

    [Display(Name = "Monto")]
    [Required(ErrorMessage = "Se debe ingresar el monto")]
    public float Price_amount { get; set; }

    [Display(Name = "Estado")]
    public string Price_status { get; set; }
}
