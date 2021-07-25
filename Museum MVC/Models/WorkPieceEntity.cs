using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class Work_pieceEntity
{
    public int Work_piece_id { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Se debe ingresar el nombre")]
    public string Work_piece_name { get; set; }

    [Display(Name = "ID Artista")]
    [Required(ErrorMessage = "Se debe ingresar el id artista")]
    public int Artist_id { get; set; }

    [Display(Name = "QR")]
    [Required(ErrorMessage = "Se debe ingresar el QR")]
    public string Work_piece_QR { get; set; }

    [Display(Name = "ID coleccion")]
    [Required(ErrorMessage = "Se debe ingresar el id")]
    public string Collection_id { get; set; }

    [Display(Name = "ID tipo obra de arte")]
    [Required(ErrorMessage = "Se debe ingresar el id tipo")]
    public string Work_type_id { get; set; }

    [Display(Name = "Cultura")]
    [Required(ErrorMessage = "Se debe ingresar la cultura")]
    public string Culture_id { get; set; }

    [Display(Name = "Detalles generales")]
    [Required(ErrorMessage = "Se debe ingresar los detalles")]
    public string General_details { get; set; }

    [Display(Name = "Estado")]
    public string Work_piece_status { get; set; }
}
