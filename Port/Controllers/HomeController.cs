using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace Port.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string connectionString = "Server = localhost; Database = port; Uid = root; Pwd =''";

            MySqlConnection connect = new MySqlConnection(connectionString);

            connect.Open();

            MySqlCommand CommandSecteur = new MySqlCommand("SELECT IdSecteur, NomSecteur FROM `Secteur`", connect);

            MySqlDataReader Reader = CommandSecteur.ExecuteReader();
            string secteur = "";
            while (Reader.Read())
            {
                secteur += "<option>" + Reader["IdSecteur"] + " : " + Reader["NomSecteur"];
            }

            ViewData["resultat"] = secteur;

            return View("Index");
        }
    }
}