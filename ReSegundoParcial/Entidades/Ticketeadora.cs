using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades
{
    public static class Ticketeadora
    {
        public static bool ImprimirTicket(this Cajon<Platano> c, string path)
        {
            try 
	        {	        
		        StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(c.ToString());
                sw.Close();
                return true;
	        }
	        catch (Exception)
	        {
		        return false;
	        }
        }
    }
}
