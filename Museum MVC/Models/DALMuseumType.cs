using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DALMuseumType
    {


    public Boolean insertMuseumType(MuseumTypeEntity museumType)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertMuseumType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_type_description", museumType.Museum_type_description));
        cmd.Parameters.Add(new SqlParameter("@Museum_type_status", museumType.Museum_type_status));
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


    public Boolean modifyMuseumType(MuseumTypeEntity museumType)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyMuseumType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museumType.Museum_type_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_type_description", museumType.Museum_type_description));
        cmd.Parameters.Add(new SqlParameter("@Museum_type_status", museumType.Museum_type_status));


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

    public Boolean inactivateMuseumType(int museum_type_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateMuseumType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museum_type_id));

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


    public Boolean reactivateMuseumType(int museum_type_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateMuseumType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museum_type_id));

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


    public MuseumTypeEntity consultMuseumType(int museum_type_id)
    {
        MuseumTypeEntity museum = new MuseumTypeEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultMuseumType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_type_id", museum_type_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            museum.Museum_type_id = int.Parse(dr["Museum_type_id"].ToString());
            museum.Museum_type_description = dr["Museum_type_description"].ToString();
            museum.Museum_type_status = dr["Museum_type_status"].ToString();
        }
        else
        {
            museum = null;
        }

        aux.connect();
        return museum;
    }

    public List<MuseumTypeEntity> listMuseumTypes()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListMuseumTypes";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<MuseumTypeEntity> list = new List<MuseumTypeEntity>();

        while (dr.Read())
        {
            MuseumTypeEntity museum = new MuseumTypeEntity();

            museum.Museum_type_id = int.Parse(dr["Museum_type_id"].ToString());
            museum.Museum_type_description = dr["Museum_type_description"].ToString();
            museum.Museum_type_status = dr["Museum_type_status"].ToString();
            list.Add(museum);
        }
        aux.connect();
        return list;
    }


}
