using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class MuseumEntity
{
    public int Museum_id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string Museum_name { get; set; }

    public int Museum_type_id { get; set; }

    [Display(Name = "Estado")]
    public string Museum_status { get; set; }
}
