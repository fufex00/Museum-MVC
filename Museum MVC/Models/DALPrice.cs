using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



public class DALPrice
    {

   public Boolean insertPrice(PriceEntity price)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertPrice";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", price.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Price_modality", price.Price_modality));
        cmd.Parameters.Add(new SqlParameter("@Price_amount", price.Price_amount));
        cmd.Parameters.Add(new SqlParameter("@Price_status", price.Price_status));
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


    public Boolean modifyPrice(PriceEntity price)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyPrice";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Price_id", price.Price_id));
        cmd.Parameters.Add(new SqlParameter("@Museum_id", price.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Price_modality", price.Price_modality));
        cmd.Parameters.Add(new SqlParameter("@Price_amount", price.Price_amount));
        cmd.Parameters.Add(new SqlParameter("@Price_status", price.Price_status));


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



    public Boolean inactivatePrice(int price_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivatePrice";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Price_id", price_id));

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

    public Boolean reactivatePrice(int price_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivatePrice";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Price_id", price_id));

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


    public PriceEntity consultPrice(int culture_id)
    {
        PriceEntity price = new PriceEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultPrice";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Price_id", culture_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            price.Price_id= int.Parse(dr["Price_id"].ToString());
            price.Museum_id = int.Parse(dr["Museum_id"].ToString());
            price.Price_modality = dr["Price_modality"].ToString();
            price.Price_amount = float.Parse(dr["Price_amount"].ToString());
            price.Price_status = dr["Price_status"].ToString();
        }
        else
        {
            price = null;
        }

        aux.connect();
        return price;
    }


    public List<PriceEntity> listPrices()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListPrices";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<PriceEntity> list = new List<PriceEntity>();

        while (dr.Read())
        {
            PriceEntity price = new PriceEntity();

            price.Price_id = int.Parse(dr["Price_id"].ToString());
            price.Museum_id = int.Parse(dr["Museum_id"].ToString());
            price.Price_modality = dr["Price_modality"].ToString();
            price.Price_amount = float.Parse(dr["Price_amount"].ToString());
            price.Price_status = dr["Price_status"].ToString();

            list.Add(price);
        }
        aux.connect();
        return list;
    }


}
