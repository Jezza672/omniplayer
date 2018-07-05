using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PlayerLibrary.Structures.Songs
{
    public class Local : Song
    {
        public override Stream Load()
        {
            using (StreamReader s = new StreamReader(Location))
                return s.BaseStream;
        }
    }
}
