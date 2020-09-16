using DogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Tool
{
    public class dbUserTool
    {
        public static string getuserList()
        {
            string response = dbAccess.sqlQuery("select * from users;");
            return response;
        }

        public static string getOneUser(string userName)
        {
            string response = dbAccess.sqlQuery("select * from users where userName='" + userName + "';");
            return response;
        }
        public static string addOneUser(UserClass uc)
        {
            // res = dbAccess.sqlQuery("select max(userId) from users;");
            string exsres = dbAccess.sqlChange("insert into users (userName,passWord) values('" + uc.UserName + "','" + uc.PassWord + "');");
            return exsres;
        }


        public static string deleteOneUser(string userName)
        {
            string exsres = dbAccess.sqlChange("delete from users where userName = '" + userName + "';");
            return exsres;
        }
        public static string updateOneUser(UserClass uc)
        {
            string updatesql = @"UPDATE users
                               SET passWord = '"+uc.PassWord+@"'
                             WHERE userName = '"+uc.UserName+"'";
            string exsres = dbAccess.sqlChange(updatesql);
            return exsres;
        }
    }
}
