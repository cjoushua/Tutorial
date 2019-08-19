using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    class JCollection
    {
        JCollection()
        {
            NameValueCollection nvc = new NameValueCollection()
            {
              {"key1", "value1"},
              {"key2", "value2"},
              {"key3", "value3"},
            };

            string ans = nvc["key3"];

            List<string> words = ans.Split(',').ToList();

            ans = words[0];
        }
    }
}
