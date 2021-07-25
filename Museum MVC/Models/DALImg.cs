using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


public class DALImg
    {
    public Boolean insertImg(ImgEntity img)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertImg";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Img_photo", img.Img_photo));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", img.Work_piece_id));
        cmd.Parameters.Add(new SqlParameter("@Img_status", img.Img_status));
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


    public Boolean modifyImg(ImgEntity img)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyImg";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Img_id", img.Img_id));
        cmd.Parameters.Add(new SqlParameter("@Img_photo", img.Img_photo));
        cmd.Parameters.Add(new SqlParameter("@Work_piece_id", img.Work_piece_id));
        cmd.Parameters.Add(new SqlParameter("@Img_status", img.Img_status));


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

    public Boolean inactivateImg(int img_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateImg";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Img_id", img_id));

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

    public Boolean reactivateImg(int img_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateImg";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Img_id", img_id));

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


    public ImgEntity consultImg(int img_id)
    {
        ImgEntity img = new ImgEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultImg";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Img_id", img_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            img.Img_id = int.Parse(dr["Img_id"].ToString());
            img.Img_photo = dr["Img_photo"].ToString();
            img.Work_piece_id = int.Parse(dr["Work_piece_id"].ToString());
            img.Img_status = dr["Img_status"].ToString();
        }
        else
        {
            img = null;
        }

        aux.connect();
        return img;
    }

    public List<ImgEntity> listImgs()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListImgs";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<ImgEntity> list = new List<ImgEntity>();

        while (dr.Read())
        {
            ImgEntity img = new ImgEntity();

            img.Img_id = int.Parse(dr["Img_id"].ToString());
            img.Img_photo = dr["Img_photo"].ToString();
            img.Work_piece_id = int.Parse(dr["Work_piece_id"].ToString());
            img.Img_status = dr["Img_status"].ToString();

            list.Add(img);
        }
        aux.connect();
        return list;
    }

}
