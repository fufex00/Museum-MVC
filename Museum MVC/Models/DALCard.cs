using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DALCard
    {


    public Boolean insertCard(CardEntity card)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "insertCard";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Card_commission", card.Card_commission));
        cmd.Parameters.Add(new SqlParameter("@Card_issuer", card.Card_issuer));
        cmd.Parameters.Add(new SqlParameter("@Card_status", card.Card_status));
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


    public Boolean modifyCard(CardEntity card)
    {

        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "modifyCard";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Card_id", card.Card_id));
        cmd.Parameters.Add(new SqlParameter("@Card_commission", card.Card_commission));
        cmd.Parameters.Add(new SqlParameter("@Card_issuer", card.Card_issuer));
        cmd.Parameters.Add(new SqlParameter("@Card_status", card.Card_status));


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

    public Boolean inactivateCard(int card_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "inactivateCard";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Card_id", card_id));

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

    public Boolean reactivateCard(int card_id)
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "reactivateCard";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Card_id", card_id));

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


    public CardEntity consultCard(int card_id)
    {
        CardEntity card = new CardEntity();
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.connect();

        cmd.CommandText = "consultCard";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@Card_id", card_id));

        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            card.Card_id = int.Parse(dr["Card_id"].ToString());
            card.Card_commission = float.Parse(dr["Card_commission"].ToString());
            card.Card_issuer = dr["Card_issuer"].ToString();
            card.Card_status = dr["Card_status"].ToString();      
        }
        else
        {
            card = null;
        }

        aux.connect();
        return card;
    }

    public List<CardEntity> listCards()
    {
        Connection aux = new Connection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.connect();

        cmd.CommandText = "procListCards";
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataReader dr = cmd.ExecuteReader();
        List<CardEntity> list = new List<CardEntity>();

        while (dr.Read())
        {
            CardEntity card = new CardEntity();

            card.Card_id = int.Parse(dr["Card_id"].ToString());
            card.Card_commission = float.Parse(dr["Card_commission"].ToString());
            card.Card_issuer = dr["Card_issuer"].ToString();
            card.Card_status = dr["Card_status"].ToString();

            list.Add(card);
        }
        aux.connect();
        return list;
    }

}
