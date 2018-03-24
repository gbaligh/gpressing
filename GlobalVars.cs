using System;
using System.Collections.Generic;
using System.Text;

namespace GP
{
    static class GlobalVars
    {
        public enum Operation { Pressing, Repassage, Tenture, Autre };       

        /************* Utilisateur du GPressing ***********************/

        public static TB_User Utilisateur;

        public static string ConnexionTime = DateTime.Now.ToShortTimeString();

        public static string PrefixFacture = "F";

        public static string PremierFacture;

        public static string PrefixClient = "C";

        
        /************* Les Constantes de Configuration ****************/
        

        /* DataBase */
        public static string connString;

        /*Imprimante*/
        public static string namePrinter;
        public static string nombreCopieTicket;
        public static string page;
        public static string maxPressing;
        public static string maxRepassage;
        public static string maxTenture;
        public static string maxAutre;
    }
}
