using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DALMuseumHasFacility
    {
    public Boolean insertMuseumMuseumHasFacility(MuseumHasFacilityEntity museum)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertMuseumHasFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Museum_id", museum.Museum_id));
        cmd.Parameters.Add(new SqlParameter("@Facility_id", museum.Facility_id));
        cmd.Parameters.Add(new SqlParameter("@Status", museum.status));

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


    ///Modificar no tiene sentido en este contexto, es mejor eliminar la relacion y volverla a insertar

    public Boolean inactivateMuseumHasFacility(int id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateMuseumHasFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@ID",id));

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


    public Boolean reactivateMuseumHasFacility(int id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateMuseumHasFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@ID", id));

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

    public MuseumHasFacilityEntity consultMuseumHasFacilityByFacility(string facility_description)
    {
        MuseumHasFacilityEntity museum = new MuseumHasFacilityEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultMuseumHasFacilityByFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_description", facility_description));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            museum.ID = int.Parse(dr["ID"].ToString());
            museum.Museum_name= dr["Museum_name"].ToString();
            museum.Facility_description = dr["Facility_description"].ToString();
        }
        else
        {
            museum = null;
        }

        aux.connect();
        return museum;
    }



    public MuseumHasFacilityEntity consultMuseumHasFacilityByMuseum(string musuem_name)
    {
        MuseumHasFacilityEntity museum = new MuseumHasFacilityEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultMuseumHasFacilityByMuseum";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_description", musuem_name));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            museum.ID = int.Parse(dr["ID"].ToString());
            museum.Museum_name = dr["Museum_name"].ToString();
            museum.Facility_description = dr["Facility_description"].ToString();
        }
        else
        {
            museum = null;
        }

        aux.connect();
        return museum;
    }



    public List<MuseumHasFacilityEntity> listMuseumHasFacilities()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procMuseumHasFacilities";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<MuseumHasFacilityEntity> list = new List<MuseumHasFacilityEntity>();

        while (dr.Read())
        {
            MuseumHasFacilityEntity museum = new MuseumHasFacilityEntity();

            museum.ID = int.Parse(dr["ID"].ToString());
            museum.Museum_name = dr["Museum_name"].ToString();
            museum.Facility_description = dr["Facility_description"].ToString();

            list.Add(museum);
        }
        aux.connect();
        return list;
    }




}
