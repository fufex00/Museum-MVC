using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class CardEntity
{

    public int Card_id { get; set; }

    [Display(Name = "Comision")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public float Card_commission { get; set; }

    [Display(Name = "Emisor")]
    [Required(ErrorMessage = "Se debe ingresar el apellido")]
    public string Card_issuer { get; set; }

    [Display(Name = "Estado")]
    public string Card_status { get; set; }
}
