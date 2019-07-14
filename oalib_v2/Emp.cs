using System;
using System.Data;

namespace oalib
{
    /// <summary>
    /// Объект работника
    /// </summary>
    [Serializable]
    public class Emp
    {
        public int ID;
        public string Name;
        public int group;
        public bool RuleGiveOrder = false;
        public bool RuleForePerson = false;
        public override bool Equals(object obj)
        {
            if ((obj as Emp) == null) return false;
            return (this.Name == (obj as Emp).Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Emp()
        {
            Name = "";
            group = 0;
            RuleGiveOrder = false;
            RuleForePerson = false;
        }

        public Emp(string name, int gr)
        {
            this.Name = name;
            this.group = gr;
        }
        public Emp(string name, int group, bool rGiveOrder, bool rForePerson)
        {
            this.Name = name;
            this.group = group;
            this.RuleGiveOrder = rGiveOrder;
            this.RuleForePerson = rForePerson;
        }
        public Emp(DataRow data)
        {
            this.ID = int.Parse(data["id"].ToString());
            this.Name = data["name"].ToString();
            this.group = int.Parse(data["group"].ToString());
            this.RuleGiveOrder = data["rGiveOrder"].ToString() == "0" ? false : true;
            this.RuleForePerson = data["rForePerson"].ToString() == "0" ? false : true;
        }
        public override string ToString()
        {
            string result;
            switch (this.group)
            {
                case 1:
                    result = this.Name + " гр I";
                    break;
                case 2:
                    result = this.Name + " гр II";
                    break;
                case 3:
                    result = this.Name + " гр III";
                    break;
                case 4:
                    result = this.Name + " гр IV";
                    break;
                case 5:
                    result = this.Name + " гр V";
                    break;
                default:
                    result = "none";
                    break;
            }
            return result;
        }
    }
}