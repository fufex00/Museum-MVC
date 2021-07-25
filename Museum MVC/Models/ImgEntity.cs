using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class ImgEntity
{
    public int Img_id { get; set; }

    [Display(Name = "Foto")]
    [Required(ErrorMessage = "Se debe ingresar la foto")]
    public string Img_photo { get; set; }

    public int Work_piece_id { get; set; }

    [Display(Name = "Estado")]
    public string Img_status { get; set; }
}
