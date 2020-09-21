using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class DogClass : BaseClass
    {
        private int dogId;
        private string name;
        private int age;
        private int typeId;
        private string typeName;

        public int DogId { get => dogId; set => dogId = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int TypeId { get => typeId; set => typeId = value; }
        public string TypeName { get => typeName; set => typeName = value; }

        public static DogClass getOneDog(string nowDog)
        {
            DogClass dc = new DogClass();
            nowDog = nowDog.Replace("\t", " ").Replace("\r", "").Trim();
            while (nowDog.Contains("  "))
            {
                nowDog = nowDog.Replace("  ", " ");
            }
            string[] lres = nowDog.Split(' ');
            dc.DogId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
            dc.Name = lres[1];
            dc.Age = lres[2] == "" ? 0 : Convert.ToInt32(lres[2]);
            dc.TypeId = lres[3] == "" ? 0 : Convert.ToInt32(lres[3]);
            dc.Lat = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]);
            dc.Lng = lres[5] == "" ? 0.0 : Convert.ToDouble(lres[5]);
            dc.Alt = lres[6] == "" ? 0.0 : Convert.ToDouble(lres[6]);
            return dc;
        }

        public static List<DogClass> getListDog(string[] lst)
        {
            List<DogClass> listDog = new List<DogClass>();
            for (int i = 0; i < lst.Count(); i++)
            {
                if (lst[i].Trim() != "")
                {
                    string[] lres = lst[i].Split(' ');
                    DogClass dc = new DogClass();
                    dc.DogId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
                    dc.Name = lres[1];
                    dc.Age = lres[2] == "" ? 0 : Convert.ToInt32(lres[2]);
                    dc.TypeId = lres[3] == "" ? 0 : Convert.ToInt32(lres[3]);
                    dc.Lat = lres[4] == "" ? 0.0 : Convert.ToDouble(lres[4]);
                    dc.Lng = lres[5] == "" ? 0.0 : Convert.ToDouble(lres[5]);
                    dc.Alt = lres[6] == "" ? 0.0 : Convert.ToDouble(lres[6]);
                    listDog.Add(dc);
                }
            }
            return listDog;
        }
    }
}
