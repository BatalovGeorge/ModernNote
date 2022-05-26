using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernNote
{
    struct Repository
    {
        private Worker[] Workers;

        public Worker this[int index]
        {
            get { return Workers[index]; }
            set { Workers[index] = value; }
        }

        public Repository(params Worker[] Args)
        {
            Workers = Args;
        }
    }
}
