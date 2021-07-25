using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class MuseumHasFacilityEntity
{
    public int ID { get; set; }

    [Display(Name = "Id Museo")]
    [Required(ErrorMessage = "Se debe ingresar el id del museo")]
    public int Museum_id { get; set; }

    [Display(Name = "Id instalacion")]
    [Required(ErrorMessage = "Se debe ingresar el id de la instalacion")]
    public int Facility_id { get; set; }

    [Display(Name = "Estado")]
    public string status { get; set; }

    public string Museum_name { get; set; }

    public string Facility_description { get; set; }
}
