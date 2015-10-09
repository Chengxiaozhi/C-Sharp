using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace SETTING
{
    class SetDatebase
    {
        public string selectSetting(string value)
        {
            string str = "Server=localhost;User ID=root;Password=123456;Database=qdgl;CharSet=utf8;";
            MySqlConnection conn = new MySqlConnection(str);
            conn.Open();
            string sqlFinger = "select " + value + " from gunark_gunark";
            MySqlCommand cmd = new MySqlCommand(sqlFinger, conn);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);
            DataTable dt = ds.Tables[0];
            int len1 = ds.Tables[0].Rows.Count;
            int n = len1 - 1;
            string ID = "";

            ID = ds.Tables[0].Rows[n][0].ToString();
            string IP = ID;
            ID = "";

            return IP;
        }

        public string[]  selectconfig(string value)
        {
            string conn1 = "Server = localhost;User ID = root; Password = 123456; Database = qdgl;charset = utf8; ";
            MySqlConnection conn = new MySqlConnection(conn1);
            conn.Open();
            string selectSub  = "select " + value + " from gunark_gunark";
            MySqlCommand cmd =new MySqlCommand(selectSub,conn);
            MySqlDataAdapter dada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dada.Fill(ds);
            DataTable dt =ds.Tables[0];
            int len1 = dt.Rows.Count;
            string[] config = new string[len1];
            int i = 0;
            for (i= 0; i < len1;i++ )
            {
                config[i] = dt.Rows[i][0].ToString();
           

            }
            return config;

        }
    }
}
