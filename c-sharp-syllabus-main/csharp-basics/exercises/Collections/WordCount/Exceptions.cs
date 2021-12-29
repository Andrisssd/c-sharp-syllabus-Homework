using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class PathNotFoundException : Exception
    {
        public PathNotFoundException(string path) : base(String.Format("File with name: {0} not found", path.Split('\\').Last()))
        {

        }
    }
}
