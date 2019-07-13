using System;
using System.Runtime.Serialization;

namespace oalib
{
    /// <summary>
    /// Данные для автозаполнения
    /// </summary>
    [Serializable]
    public class Data
    {
        public string estr;
        public string instr;
        [OptionalField]
        public string dop_instr;
        public Data()
        {
            estr = "";
            instr = "";
        }
        public Data(string e, string i, string d_i)
        {
            estr = e;
            instr = i;
            dop_instr = d_i;
        }
    }
}