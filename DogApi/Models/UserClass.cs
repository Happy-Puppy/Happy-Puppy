using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class UserClass
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
            uc.userName = nowUser.Split(' ')[0];
            uc.passWord = nowUser.Split(' ')[1];
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
                    listUser.Add(uc);
                }
            }
            return listUser;
        }
    }
}
