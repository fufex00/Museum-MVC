using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALArtist
 {

    public Boolean insertArtist(ArtistEntity artist)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Artist_name", artist.Artist_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_last_name", artist.Artist_last_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_second_last_name", artist.Artist_second_last_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_origin_country", artist.Artist_origin_country));
        cmd.Parameters.Add(new SqlParameter("@Artist_biography", artist.Artist_biography));
        cmd.Parameters.Add(new SqlParameter("@Artist_status", artist.Artist_status));

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

    public Boolean modifytArtist(ArtistEntity artist)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Artist_id", artist.Artist_id));
        cmd.Parameters.Add(new SqlParameter("@Artist_name", artist.Artist_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_last_name", artist.Artist_last_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_second_last_name", artist.Artist_second_last_name));
        cmd.Parameters.Add(new SqlParameter("@Artist_origin_country", artist.Artist_origin_country));
        cmd.Parameters.Add(new SqlParameter("@Artist_biography", artist.Artist_biography));
        cmd.Parameters.Add(new SqlParameter("@Artist_status", artist.Artist_status));

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

    public Boolean inactivateArtist(int artist_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Artist_id", artist_id));

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

    public Boolean reactivateArtist(int artist_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Artist_id", artist_id));

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

    public ArtistEntity consultArtist(int artist_id)
    {
        ArtistEntity artist = new ArtistEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultArtist";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Artist_id", artist_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            artist.Artist_id = int.Parse(dr["Artist_id"].ToString());
            artist.Artist_name = dr["Artist_name"].ToString();
            artist.Artist_last_name = dr["Artist_last_name"].ToString();
            artist.Artist_second_last_name = dr["Artist_second_last_name"].ToString();
            artist.Artist_origin_country = dr["Artist_origin_country"].ToString();
            artist.Artist_biography = dr["Artist_biography"].ToString();
            artist.Artist_status = dr["Artist_status"].ToString();
        }
        else
        {
            artist = null;
        }

        aux.connect();

        return artist;

    }

    public List<ArtistEntity> listArtists()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListArtists";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<ArtistEntity> list = new List<ArtistEntity>();

        while (dr.Read())
        {
            ArtistEntity artist = new ArtistEntity();

            artist.Artist_id = int.Parse(dr["Artist_id"].ToString());
            artist.Artist_name = dr["Artist_name"].ToString();
            artist.Artist_last_name = dr["Artist_last_name"].ToString();
            artist.Artist_second_last_name = dr["Artist_second_last_name"].ToString();
            artist.Artist_origin_country = dr["Artist_origin_country"].ToString();
            artist.Artist_biography = dr["Artist_biography"].ToString();
            artist.Artist_status = dr["Artist_status"].ToString();

            list.Add(artist);
        }
        aux.connect();
        return list;
    }
}