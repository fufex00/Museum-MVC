using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class FacilityEntity
{
    public int Facility_id { get; set; }

    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "Se debe ingresar la descripcion")]
    public string Facility_description { get; set; }

    [Display(Name = "Estado")]
    public string Facility_status { get; set; }
}
