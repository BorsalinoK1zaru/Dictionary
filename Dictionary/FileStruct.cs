using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal record FileStruct
    {
        public string _key;
        public Dictionary<string, List<string>> _values;
    }
}
