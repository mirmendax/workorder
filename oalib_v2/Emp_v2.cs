using System;

namespace oalib_v2
{
    /// <summary>
    /// Объект работника
    /// </summary>
    [Serializable]
    public class Emp_v2
    {
        public string Name;
        public int group;
        public bool RuleGiveOrder = false;
        public bool RuleForePerson = false;
        public override bool Equals(object obj)
        {
            if ((obj as Emp_v2) == null) return false;
            return (this.Name == (obj as Emp_v2).Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Emp_v2() 
        {
            Name = "";
            group = 0;
            RuleGiveOrder = false;
            RuleForePerson = false;
        }

        public Emp_v2(string name, int gr)
        {
            this.Name = name;
            this.group = gr;
        }
        public Emp_v2(string name, int group, bool rGiveOrder, bool rForePerson)
        {
            this.Name = name;
            this.group = group;
            this.RuleGiveOrder = rGiveOrder;
            this.RuleForePerson = rForePerson;
        }
        public override string ToString()
        {
            string result;
            switch (this.group)
            {
                case 1: result = this.Name + " гр I";
                    break;
                case 2: result = this.Name + " гр II";
                    break;
                case 3: result = this.Name + " гр III";
                    break;
                case 4: result = this.Name + " гр IV";
                    break;
                case 5: result = this.Name + " гр V";
                    break;
                default: result = "none";
                    break;
            }
            return result;
        }
    }
}