using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

public class TicketEntity
{
    public int Ticket_id { get; set; }

    [Display(Name = "Precio ID")]
    [Required(ErrorMessage = "Se debe ingresar el id del precio")]
    public int Price_id { get; set; }

    [Display(Name = "Museo ID")]
    [Required(ErrorMessage = "Se debe ingresar el id del museo")]
    public int Museum_id { get; set; }

    [Display(Name = "Nombre del visitante")]
    [Required(ErrorMessage = "Se debe ingresar el nombre del visitante")]
    public string Ticket_visitor_name { get; set; }

    [Display(Name = "Fecha")]
    [Required(ErrorMessage = "Se debe ingresar la fecha")]
    public string Ticket_date { get; set; }

    [Display(Name = "Cantidad")]
    [Required(ErrorMessage = "Se debe ingresar la cantidad")]
    public int Ticket_quantity { get; set; }

    [Display(Name = "Subtotal")]
    [Required(ErrorMessage = "Se debe ingresar el subtotal")]
    public float Ticket_subtotal { get; set; }

    [Display(Name = "Comision")]
    [Required(ErrorMessage = "Se debe ingresar la comision")]
    public float Ticket_comission { get; set; }

    [Display(Name = "Total")]
    [Required(ErrorMessage = "Se debe ingresar el total")]
    public float Ticket_total { get; set; }

    [Display(Name = "ID Tarjeta")]
    [Required(ErrorMessage = "Se debe ingresar el id de la tarjeta")]
    public int Card_id { get; set; }

    [Display(Name = "Estado")]
    public string Ticket_status { get; set; }
}
