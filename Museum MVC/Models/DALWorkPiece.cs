using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALWorkPiece
{
    public Boolean insertWorkPiece(WorkPieceEntity workPiece)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inserWorkPiece";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_name", workPiece.Work_piece_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_id", workPiece.Artist_id));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_QR", workPiece.Work_piece_QR));
        cmd.Parameters.Add(new SqlParameter("@Collection_id", workPiece.Collection_id));
        cmd.Parameters.Add(new SqlParameter("@Work_type_id", workPiece.Work_type_id));
        cmd.Parameters.Add(new SqlParameter("@Culture_id", workPiece.Culture_id));
        cmd.Parameters.Add(new SqlParameter("@General_details", workPiece.General_details));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_status", workPiece.Work_piece_status));

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

    public Boolean modifyWorkPiece(WorkPieceEntity workPiece)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", workPiece.Work_piece_id));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_name", workPiece.Work_piece_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_id", workPiece.Artist_id));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_QR", workPiece.Work_piece_QR));
        cmd.Parameters.Add(new SqlParameter("@Collection_id", workPiece.Collection_id));
        cmd.Parameters.Add(new SqlParameter("@Work_type_id", workPiece.Work_type_id));
        cmd.Parameters.Add(new SqlParameter("@Culture_id", workPiece.Culture_id));
        cmd.Parameters.Add(new SqlParameter("@General_details", workPiece.General_details));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_status", workPiece.Work_piece_status));

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

    public Boolean inactivateWorkPiece(int workPiece_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateWorkPiece";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", workPiece_id));

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

    public Boolean reactivateArtist(int workPiece_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateWorkPiece";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", workPiece_id));

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

    public WorkPieceEntity consultWorkPiece(int workPiece_id)
    {
        WorkPieceEntity workPiece = new WorkPieceEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultWorkPiece";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", workPiece_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            workPiece.Work_piece_id = int.Parse(dr["Work_piece_id"].ToString());
            workPiece.Work_piece_name = dr["Work_piece_name"].ToString();
            workPiece.Artist_id = int.Parse(dr["Artist_id"].ToString());
            workPiece.Work_piece_QR = dr["Work_piece_QR"].ToString();
            workPiece.Collection_id = int.Parse(dr["Collection_id"].ToString());
            workPiece.Work_type_id = int.Parse(dr["Work_type_id"].ToString());
            workPiece.Culture_id = int.Parse(dr["Culture_id"].ToString());
            workPiece.General_details = dr["General_details"].ToString();
            workPiece.Work_piece_status = dr["Work_piece_status"].ToString();

        }
        else
        {
            workPiece = null;
        }

        aux.connect();

        return workPiece;

    }

    public List<WorkPieceEntity> listWorkPieces()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListWorkPieces";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<WorkPieceEntity> list = new List<WorkPieceEntity>();

        while (dr.Read())
        {
            WorkPieceEntity workPiece = new WorkPieceEntity();

            workPiece.Work_piece_id = int.Parse(dr["Work_piece_id"].ToString());
            workPiece.Work_piece_name = dr["Work_piece_name"].ToString();
            workPiece.Artist_id = int.Parse(dr["Artist_id"].ToString());
            workPiece.Work_piece_QR = dr["Work_piece_QR"].ToString();
            workPiece.Collection_id = int.Parse(dr["Collection_id"].ToString());
            workPiece.Work_type_id = int.Parse(dr["Work_type_id"].ToString());
            workPiece.Culture_id = int.Parse(dr["Culture_id"].ToString());
            workPiece.General_details = dr["General_details"].ToString();
            workPiece.Work_piece_status = dr["Work_piece_status"].ToString();

            list.Add(workPiece);
        }
        aux.connect();
        return list;
    }
}