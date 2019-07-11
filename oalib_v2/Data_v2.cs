using System;
using System.Runtime.Serialization;

namespace oalib_v2
{
    /// <summary>
    /// Данные для автозаполнения
    /// </summary>
    [Serializable]
    public class Data_v2
    {
        public string estr;
        public string instr;
        [OptionalField]
        public string dop_instr;
        public Data_v2()
        {
            estr = "";
            instr = "";
        }
        public Data_v2(string e, string i, string d_i)
        {
            estr = e;
            instr = i;
            dop_instr = d_i;
        }
    }
}