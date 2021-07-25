using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class WorkPieceTypeEntity
{
    public int Work_piece_type_id { get; set; }

    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = "Se debe ingresar la descripcion")]
    public string Description { get; set; }

    [Display(Name = "Estado")]
    public string Work_piece_type_status { get; set; }
}
