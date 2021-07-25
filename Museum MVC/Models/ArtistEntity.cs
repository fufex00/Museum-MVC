using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class ArtistEntity
 {

    public int Artist_id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string Artist_name { get; set; }

    [Display(Name = "Apellido")]
    [Required(ErrorMessage = "Se debe ingresar el apellido")]
    public string Artist_last_name { get; set; }

    [Display(Name = "Segundo Apellido")]
    [Required(ErrorMessage = "Se debe ingresar el segundo apellido")]
    public string Artist_second_last_name { get; set; }

    [Display(Name = "País de Origen")]
    [Required(ErrorMessage = "Se debe ingresar el segundo país de origen")]
    public string Artist_origin_country { get; set; }

    [Display(Name = "Biografía")]
    [Required(ErrorMessage = "Se debe ingresar la Biografía")]
    public string Artist_biography { get; set; }

    [Display(Name = "Estado")]
    public string Artist_status { get; set; }
}
