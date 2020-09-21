using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class UserClass: BaseClass
    { 
        private string userName;
        private string passWord;
         
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }


        public static UserClass getOneUser(string nowUser)
        {
            UserClass uc = new UserClass();
            nowUser = nowUser.Replace("\t", " ").Replace("\r", "");
            while (nowUser.Contains("  "))
            {
                nowUser = nowUser.Replace("  ", " ");
            }
            string[] lres = nowUser.Split(' ');
            uc.UserName = lres[0];
            uc.PassWord = lres[1];
            uc.Lat = lres[2] == "" ? 0.0 : Convert.ToDouble(lres[2]);
            uc.Lng = lres[3] == "" ? 0.0 : Convert.ToDouble(lres[3]);
            uc.Alt = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]);
            return uc;
        }

        public static List<UserClass> getListUser(string[] lst)
        {
            List<UserClass> listUser = new List<UserClass>();
            for(int i = 0; i < lst.Count(); i++)
            {
                if (lst[i].Trim() != "")
                {
                    string[] lres = lst[i].Split(' ');
                    UserClass uc = new UserClass();
                    uc.UserName = lres[0];
                    uc.PassWord = lres[1];
                    uc.Lat = lres[2] == "" ? 0.0 : Convert.ToDouble(lres[2]);
                    uc.Lng = lres[3] == "" ? 0.0 : Convert.ToDouble(lres[3]);
                    uc.Alt = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]); 
                    listUser.Add(uc);
                }
            }
            return listUser;
        }
    }
}
