using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Port.Models
{
    public class Data
    {
        public static string GetLiaison(string texte) 
        {
            int i = 0;
            string id = "";

            while (texte[i] != ' ' && texte[i + 1] != ':')
            {
                id += texte[i];
                i++;
            }

            string connectionString = "Server = localhost; Database = port; Uid = root; Pwd =''";

            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand CommandLiaison = new MySqlCommand("SELECT IdLiaison, Distance, depart.NomPort AS Nom_Port_Depart, arrive.NomPort AS Nom_Port_Arrive, IdSecteur, IdPortDepart, IdPortArrive FROM `Liaison` inner join port depart on(depart.IdPort = IdPortDepart) inner join port arrive on (arrive.IdPort = IdPortArrive) WHERE IdSecteur = " + id, connect);

            MySqlDataReader Reader = CommandLiaison.ExecuteReader();

            string Liaison = "";

            while (Reader.Read())
            {
                Liaison += "<tr><td>" + Reader["IdLiaison"] + " </td><td> " + Reader["Distance"] + " </td><td> " + Reader["Nom_Port_Depart"] + "</td><td>" + Reader["Nom_Port_Arrive"] + "</td><td>" + Reader["IdSecteur"] + "</td><td>" + Reader["IdPortDepart"] + "</td><td>" + Reader["IdPortArrive"] + "</td></tr>";
            }

            connect.Close(); //Ferme l
            return Liaison;
        }
        public static string GetAllLiaison()
        {
            string connectionString = "Server = localhost; Database = port; Uid = root; Pwd =''";

            MySqlConnection connect = new MySqlConnection(connectionString);
            connect.Open();

            MySqlCommand CommandLiaison = new MySqlCommand("SELECT IdLiaison, Distance, depart.NomPort AS Nom_Port_Depart, arrive.NomPort AS Nom_Port_Arrive, IdSecteur, IdPortDepart, IdPortArrive FROM `Liaison` inner join port depart on(depart.IdPort = IdPortDepart) inner join port arrive on (arrive.IdPort = IdPortArrive)" , connect);

            MySqlDataReader Reader = CommandLiaison.ExecuteReader();

            string Liaison = "";

            while (Reader.Read())
            {
                Liaison += "<tr><td>" + Reader["IdLiaison"] + " </td><td> " + Reader["Distance"] + " </td><td> " + Reader["Nom_Port_Depart"] + "</td><td>" + Reader["Nom_Port_Arrive"] + "</td><td>" + Reader["IdSecteur"] + "</td><td>" + Reader["IdPortDepart"] + "</td><td>" + Reader["IdPortArrive"] + "</td></tr>";
            }

            connect.Close(); 
            return Liaison;
        }
    }
}