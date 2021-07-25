using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALWorkPieceType
{

    public Boolean insertWorkPieceType(WorkPieceTypeEntity workPieceType)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertWorkPieceType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Description", workPieceType.Description));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_status", workPieceType.Work_piece_type_status));

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

    public Boolean modifytWorkPieceType(WorkPieceTypeEntity workPieceType)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyWorkPieceType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_id", workPieceType.Work_piece_type_id));
        cmd.Parameters.Add(new SqlParameter("@Description", workPieceType.Description));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_status", workPieceType.Work_piece_type_status));

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

    public Boolean inactivateWorkPieceType(int workPieceType_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateWorkPieceType";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_id", workPieceType_id));

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

    public Boolean reactivateWorkPieceType(int workPieceType_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateWorkPieceType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_id", workPieceType_id));

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

    public WorkPieceTypeEntity consultWorkPieceType(int workPieceType_id)
    {
        WorkPieceTypeEntity workPieceType = new WorkPieceTypeEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultWorkPieceType";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_type_id", workPieceType_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            workPieceType.Work_piece_type_id = int.Parse(dr["Work_piece_type_id"].ToString());
            workPieceType.Description = dr["Description"].ToString();
            workPieceType.Work_piece_type_status = dr["Work_piece_type_status"].ToString();

        }
        else
        {
            workPieceType = null;
        }

        aux.connect();

        return workPieceType;

    }

    public List<WorkPieceTypeEntity> listWorkPieceTypes()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListWorkPieceTypes";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<WorkPieceTypeEntity> list = new List<WorkPieceTypeEntity>();

        while (dr.Read())
        {
            WorkPieceTypeEntity workPieceType = new WorkPieceTypeEntity();

            workPieceType.Work_piece_type_id = int.Parse(dr["Work_piece_type_id"].ToString());
            workPieceType.Description = dr["Description"].ToString();
            workPieceType.Work_piece_type_status = dr["Work_piece_type_status"].ToString();

            list.Add(workPieceType);
        }
        aux.connect();
        return list;
    }
}
