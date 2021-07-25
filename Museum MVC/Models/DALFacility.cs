using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DALFacility
    {

    public Boolean insertFacility(FacilityEntity facility)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_description", facility.Facility_description));
        cmd.Parameters.Add(new SqlParameter("@Facility_status", facility.Facility_status));
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

    public Boolean modifyFacility(FacilityEntity facility)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_id", facility.Facility_id));
        cmd.Parameters.Add(new SqlParameter("@Facility_description", facility.Facility_description));
        cmd.Parameters.Add(new SqlParameter("@Facility_status", facility.Facility_status));


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

    public Boolean inactivateFacility(int facility_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_id", facility_id));

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

    public Boolean reactivateFacility(int facility_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_id", facility_id));

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


    public FacilityEntity consultFacility(int facility_id)
    {
        FacilityEntity facility = new FacilityEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultFacility";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Facility_id", facility_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            facility.Facility_id = int.Parse(dr["Facility_id"].ToString());
            facility.Facility_description = dr["Facility_description"].ToString();
            facility.Facility_status = dr["Facility_status"].ToString();
        }
        else
        {
            facility = null;
        }

        aux.connect();
        return facility;
    }


    public List<FacilityEntity> listFacilities()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListFacilities";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<FacilityEntity> list = new List<FacilityEntity>();

        while (dr.Read())
        {
            FacilityEntity facility = new FacilityEntity();

            facility.Facility_id = int.Parse(dr["Facility_id"].ToString());
            facility.Facility_description = dr["Facility_description"].ToString();
            facility.Facility_status = dr["Facility_status"].ToString();

            list.Add(facility);
        }
        aux.connect();
        return list;
    }



}
