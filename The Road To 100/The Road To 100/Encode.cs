using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace The_Road_To_100
{
    class Encode
    {
        public int encode(int content)
        {
            return (content * 2) - 7;
        }
        public int encode()
        {
            return 0;
        }
        private int GetContent(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                char[] x = (sr.ReadToEnd()).ToCharArray();
                string content = x[0].ToString();

                return int.Parse(content);
            }
                
        }
    }
}
