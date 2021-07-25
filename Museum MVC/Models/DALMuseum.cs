using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DALMuseum
    {


    public Boolean insertMuseum(MuseumEntity museum)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_name", museum.Museum_name));
        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museum.Museum_type_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_status", museum.Museum_status));
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

    public Boolean modifyMuseum(MuseumEntity museum)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", museum.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_name", museum.Museum_name));
        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museum.Museum_type_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_status", museum.Museum_status));


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


    public Boolean inactivateMuseum(int museum_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", museum_id));

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

    public Boolean reactivateMuseum(int museum_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", museum_id));

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


    public MuseumEntity consultMuseum(int museum_id)
    {
        MuseumEntity museum = new MuseumEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", museum_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            museum.Museum_id = int.Parse(dr["Museum_id"].ToString());
            museum.Museum_name = dr["Museum_name"].ToString();
            museum.Museum_type_id = int.Parse(dr["Museum_type_id"].ToString());
            museum.Museum_status = dr["Museum_status"].ToString();
        }
        else
        {
            museum = null;
        }

        aux.connect();
        return museum;
    }



    public List<MuseumEntity> listMuseums()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListMuseums";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<MuseumEntity> list = new List<MuseumEntity>();

        while (dr.Read())
        {
            MuseumEntity museum = new MuseumEntity();

            museum.Museum_id = int.Parse(dr["Museum_id"].ToString());
            museum.Museum_name = dr["Museum_name"].ToString();
            museum.Museum_type_id = int.Parse(dr["Museum_type_id"].ToString());
            museum.Museum_status = dr["Museum_status"].ToString();

            list.Add(museum);
        }
        aux.connect();
        return list;
    }

}
