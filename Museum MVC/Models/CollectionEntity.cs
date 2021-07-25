using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class CollectionEntity
{

    public int Collection_id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string Collection_name { get; set; }

    [Display(Name = "Siglo")]
    [Required(ErrorMessage = "Se debe ingresar el siglo")]
    public int Collection_century { get; set; }

    [Display(Name = "Observacion")]
    [Required(ErrorMessage = "Se debe ingresar la observacion")]
    public string Collection_observation { get; set; }

    [Display(Name = "Id Museo")]
    [Required(ErrorMessage = "Se debe ingresar el id del museo")]
    public int Museum_id { get; set; }

    [Display(Name = "Estado")]
    public string Collection_status { get; set; }
}
