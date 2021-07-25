using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALTicket
{
    public Boolean insertTicket(TicketEntity ticket)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertTicket";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", ticket.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Ticket_visitor_name", ticket.Ticket_visitor_name));
        cmd.Parameters.Add(new SqlParameter("@Ticket_date", ticket.Ticket_date));
        cmd.Parameters.Add(new SqlParameter("@Ticket_quantity", ticket.Ticket_quantity));
        cmd.Parameters.Add(new SqlParameter("@Ticket_subtotal", ticket.Ticket_subtotal));
        cmd.Parameters.Add(new SqlParameter("@Ticket_comission", ticket.Ticket_comission));
        cmd.Parameters.Add(new SqlParameter("@Ticket_total", ticket.Ticket_total));
        cmd.Parameters.Add(new SqlParameter("@Card_id", ticket.Card_id));
        cmd.Parameters.Add(new SqlParameter("@Ticket_status", ticket.Ticket_status));

        int x = cmd.ExecuteNonQuery();
        aux.connect();

        if (x >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public Boolean modifytTicket(TicketEntity ticket)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyTicket";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Ticket_id", ticket.Ticket_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_id", ticket.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Ticket_visitor_name", ticket.Ticket_visitor_name));
        cmd.Parameters.Add(new SqlParameter("@Ticket_date", ticket.Ticket_date));
        cmd.Parameters.Add(new SqlParameter("@Ticket_quantity", ticket.Ticket_quantity));
        cmd.Parameters.Add(new SqlParameter("@Ticket_subtotal", ticket.Ticket_subtotal));
        cmd.Parameters.Add(new SqlParameter("@Ticket_comission", ticket.Ticket_comission));
        cmd.Parameters.Add(new SqlParameter("@Ticket_total", ticket.Ticket_total));
        cmd.Parameters.Add(new SqlParameter("@Card_id", ticket.Card_id));
        cmd.Parameters.Add(new SqlParameter("@Ticket_status", ticket.Ticket_status));

        int x = cmd.ExecuteNonQuery();
        aux.connect();

        if (x >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public Boolean inactivateTicket(int ticket_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateTicket";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Ticket_id", ticket_id));

        int x = cmd.ExecuteNonQuery();
        aux.connect();

        if (x >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean reactivateTicket(int ticket_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateTicket";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Ticket_id", ticket_id));

        int x = cmd.ExecuteNonQuery();
        aux.connect();

        if (x >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public TicketEntity consultTicekt(int ticket_id)
    {
        TicketEntity ticket = new TicketEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultTicket";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Ticket_id", ticket_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            ticket.Ticket_id = int.Parse(dr["Ticket_id"].ToString());
            ticket.Museum_id = int.Parse(dr["Museum_id"].ToString());
            ticket.Ticket_visitor_name = dr["Ticket_visitor_name"].ToString();
            ticket.Ticket_date = dr["Ticket_date"].ToString();
            ticket.Ticket_quantity = int.Parse(dr["Ticket_quantity"].ToString());
            ticket.Ticket_subtotal = float.Parse(dr["Ticket_subtotal"].ToString());
            ticket.Ticket_comission = float.Parse(dr["Ticket_comission"].ToString());
            ticket.Ticket_total = float.Parse(dr["Ticket_total"].ToString());
            ticket.Card_id = int.Parse(dr["Card_id"].ToString());
            ticket.Ticket_status = dr["Ticket_status"].ToString();
        }
        else
        {
            ticket = null;
        }

        aux.connect();

        return ticket;

    }

    public List<TicketEntity> listTickets()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListTickets";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<TicketEntity> list = new List<TicketEntity>();

        while (dr.Read())
        {
            TicketEntity ticket = new TicketEntity();

            ticket.Ticket_id = int.Parse(dr["Ticket_id"].ToString());
            ticket.Museum_id = int.Parse(dr["Museum_id"].ToString());
            ticket.Ticket_visitor_name = dr["Ticket_visitor_name"].ToString();
            ticket.Ticket_date = dr["Ticket_date"].ToString();
            ticket.Ticket_quantity = int.Parse(dr["Ticket_quantity"].ToString());
            ticket.Ticket_subtotal = float.Parse(dr["Ticket_subtotal"].ToString());
            ticket.Ticket_comission = float.Parse(dr["Ticket_comission"].ToString());
            ticket.Ticket_total = float.Parse(dr["Ticket_total"].ToString());
            ticket.Card_id = int.Parse(dr["Card_id"].ToString());
            ticket.Ticket_status = dr["Ticket_status"].ToString();

            list.Add(ticket);
        }
        aux.connect();
        return list;
    }
}
