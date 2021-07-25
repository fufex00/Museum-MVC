using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class DALCollection
    {

    public Boolean insertCollection(CollectionEntity collection)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertCollection";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Collection_name", collection.Collection_name));
        cmd.Parameters.Add(new SqlParameter("@Collection_century", collection.Collection_century));
        cmd.Parameters.Add(new SqlParameter("@Collection_observation", collection.Collection_observation));
        cmd.Parameters.Add(new SqlParameter("@Museum_id", collection.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Collection_status", collection.Collection_status));

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


    public Boolean modifyCollection(CollectionEntity collection)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyCollection";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Collection_id", collection.Collection_id));
        cmd.Parameters.Add(new SqlParameter("@Collection_name", collection.Collection_name));
        cmd.Parameters.Add(new SqlParameter("@Collection_century", collection.Collection_century));
        cmd.Parameters.Add(new SqlParameter("@Collection_observation", collection.Collection_observation));
        cmd.Parameters.Add(new SqlParameter("@Museum_id", collection.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Collection_status", collection.Collection_status));


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

    public Boolean inactivateCollection(int collection_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateCollection";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Collection_id", collection_id));

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

    public Boolean reactivateCollection(int collection_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateCollection";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Collection_id", collection_id));

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



    public CollectionEntity consultCollection(int collection_id)
    {
        CollectionEntity collection = new CollectionEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultCollection";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Collection_id", collection_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            collection.Collection_id = int.Parse(dr["Collection_id"].ToString());
            collection.Collection_name = dr["Collection_name"].ToString();
            collection.Collection_century = int.Parse(dr["Collection_century"].ToString());
            collection.Collection_observation = dr["Collection_observation"].ToString();
            collection.Museum_id = int.Parse(dr["Museum_id"].ToString());
            collection.Collection_status = dr["Collection_status"].ToString();
        }
        else
        {
            collection = null;
        }

        aux.connect();
        return collection;
    }



    public List<CollectionEntity> listCollections()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListCollections";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<CollectionEntity> list = new List<CollectionEntity>();

        while (dr.Read())
        {
            CollectionEntity collection = new CollectionEntity();
            collection.Collection_id = int.Parse(dr["Collection_id"].ToString());
            collection.Collection_name = dr["Collection_name"].ToString();
            collection.Collection_century = int.Parse(dr["Collection_century"].ToString());
            collection.Collection_observation = dr["Collection_observation"].ToString();
            collection.Museum_id = int.Parse(dr["Museum_id"].ToString());
            collection.Collection_status = dr["Collection_status"].ToString();

            list.Add(collection);
        }
        aux.connect();
        return list;
    }



}
