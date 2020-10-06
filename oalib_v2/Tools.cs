using System;

namespace oalib
{
    public class Tools
    {
        public static int IsID(string str)
        {
            try
            {
                string[] s = str.Split(new char[] { ':' });
                int id = int.Parse(s[0]);
                return id;
            }
            catch (Exception ex)
            {

                new Log("Error Parse: " + ex.Message);
                return 0;
            }

        }
    }


}