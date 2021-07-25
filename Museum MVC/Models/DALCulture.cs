using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALCulture
{

    public Boolean insertCulture(CultureEntity culture)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertCulture";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Culture_description", culture.Culture_description));
        cmd.Parameters.Add(new SqlParameter("@Culture_status", culture.Culture_status));
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

    public Boolean modifyCulture(CultureEntity culture)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyCulture";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Culture_id", culture.Culture_id));
        cmd.Parameters.Add(new SqlParameter("@Culture_description", culture.Culture_description));
        cmd.Parameters.Add(new SqlParameter("@Culture_status", culture.Culture_status));


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

    public Boolean inactivateCulture(int culture_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateCulture";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Culture_id", culture_id));

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

    public Boolean reactivateCulture(int culture_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateCulture";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Culture_id", culture_id));

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

    public CultureEntity consultCulture(int culture_id)
    {
        CultureEntity culture = new CultureEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultCulture";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Culture_id", culture_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            culture.Culture_id = int.Parse(dr["Culture_id"].ToString());
            culture.Culture_description = dr["Culture_description"].ToString();
            culture.Culture_status = dr["Culture_status"].ToString();
        }
        else
        {
            culture = null;
        }

        aux.connect();
        return culture;
    }

    public List<CultureEntity> listCultures()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListCultures";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<CultureEntity> list = new List<CultureEntity>();

        while (dr.Read())
        {
            CultureEntity culture = new CultureEntity();

            culture.Culture_id = int.Parse(dr["Culture_id"].ToString());
            culture.Culture_description = dr["Culture_description"].ToString();
            culture.Culture_status = dr["Culture_status"].ToString();

            list.Add(culture);
        }
        aux.connect();
        return list;
    }

}
