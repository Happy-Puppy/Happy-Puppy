using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class FriendClass
    {
        private int fid;
        private string userName;
        private string fUserName;

        public int Fid { get => fid; set => fid = value; }
        public string UserName { get => userName; set => userName = value; }
        public string FUserName { get => fUserName; set => fUserName = value; }

        public static FriendClass getOneFriend(string nowFriend)
        {
            FriendClass fc = new FriendClass();
            nowFriend = nowFriend.Replace("\t", " ").Replace("\r", "").Trim();
            while(nowFriend.Contains("  "))
            {
                nowFriend = nowFriend.Replace("  ", " ");
            }
            string[] lres = nowFriend.Split(' ');
            fc.Fid = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
            fc.UserName = lres[1];
            fc.FUserName = lres[2];
            return fc;
        }

        public static List<FriendClass> getListFriend(string[] lst)
        {
            List<FriendClass> listFriend = new List<FriendClass>();
            for (int i = 0; i < lst.Count(); i++)
            {
                if (lst[i].Trim() != "")
                {
                    string[] lres = lst[i].Split(' ');
                    FriendClass fc = new FriendClass();
                    fc.Fid = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
                    fc.UserName = lres[1];
                    fc.FUserName = lres[2];
                    listFriend.Add(fc);
                }
            }
            return listFriend;
        }
    }
}
