using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Connection
{

    string stringConnection;

    public SqlConnection connect()
    {
       /* stringConnection = @"user=DESKTOP-35FE2PR\steve; password=adminroot; " +
                                            "server=DESKTOP-35FE2PR; Trusted_Connection=yes; database=museum; connection timeout=30";*/

        stringConnection = @"user=NITRO-5\Kobem; password=; server=NITRO-5; 
                  Trusted_Connection=yes; database=museum; connection timeout=30";


        SqlConnection conection = new SqlConnection(stringConnection);

        try
        {
            if (conection.State.Equals(ConnectionState.Closed))
            {
                conection.Open();
            }
            else
            {
                conection.Close();
            }
        }
        catch (Exception e)
        {
        }

        return conection;
    }
}
