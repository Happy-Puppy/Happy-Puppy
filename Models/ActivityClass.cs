using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class ActivityClass : BaseClass
    {
        private int actId;
        private string name;
        private string note;

        public int ActId { get => actId; set => actId = value; }
        public string Name { get => name; set => name = value; }
        public string Note { get => note; set => note = value; }

        public static ActivityClass getOneActivity(string nowActivity)
        {
            ActivityClass ac = new ActivityClass();
            nowActivity = nowActivity.Replace("\t", " ").Replace("\r", "").Trim();
            while (nowActivity.Contains("  "))
            {
                nowActivity = nowActivity.Replace("  ", " ");
            }
            string[] lres = nowActivity.Split(' ');
            ac.ActId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
            ac.Name = lres[1];
            ac.Note = lres[2];
            ac.Lat = lres[3] == "" ? 0.0 : Convert.ToDouble(lres[3]);
            ac.Lng = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]);
            ac.Alt = lres[5] == "" ? 0.0 : Convert.ToDouble(lres[5]);
            return ac;
        }

        public static List<ActivityClass> getListActivity(string[] lst)
        {
            List<ActivityClass> listActivity = new List<ActivityClass>();
            for (int i = 0; i < lst.Count(); i++)
            {
                if (lst[i].Trim() != "")
                {
                    string[] lres = lst[i].Split(' ');
                    ActivityClass ac = new ActivityClass();
                    ac.ActId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
                    ac.Name = lres[1];
                    ac.Note = lres[2];
                    ac.Lat = lres[3] == "" ? 0.0 : Convert.ToDouble(lres[3]);
                    ac.Lng = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]);
                    ac.Alt = lres[5] == "" ? 0.0 : Convert.ToDouble(lres[5]);
                    listActivity.Add(ac);
                }
            }
            return listActivity;
        }

    }
}
