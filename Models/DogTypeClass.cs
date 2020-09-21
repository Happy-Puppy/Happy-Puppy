using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class DogTypeClass
    {
        private int typeId;
        private string name;

        public int TypeId { get => typeId; set => typeId = value; }
        public string Name { get => name; set => name = value; }


        public static DogTypeClass getOneDogType(string nowDogType)
        {
            DogTypeClass fc = new DogTypeClass();
            nowDogType = nowDogType.Replace("\t", " ").Replace("\r", "").Trim();
            while (nowDogType.Contains("  "))
            {
                nowDogType = nowDogType.Replace("  ", " ");
            }
            string[] lres = nowDogType.Split(' ');
            fc.TypeId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
            fc.Name = lres[1];
            return fc;
        }

        public static List<DogTypeClass> getListDogType(string[] lst)
        {
            List<DogTypeClass> listDogType = new List<DogTypeClass>();
            for (int i = 0; i < lst.Count(); i++)
            {
                if (lst[i].Trim() != "")
                {
                    string[] lres = lst[i].Split(' ');
                    DogTypeClass fc = new DogTypeClass();
                    fc.TypeId = lres[0] == "" ? 0 : Convert.ToInt32(lres[0]);
                    fc.Name = lres[1]; 
                    listDogType.Add(fc);
                }
            }
            return listDogType;
        }

    }
}
