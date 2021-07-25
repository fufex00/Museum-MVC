using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class MuseumTypeEntity
{
    public int Museum_type_id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string Museum_type_description { get; set; }

    [Display(Name = "Estado")]
    public string Museum_type_status { get; set; }
}
