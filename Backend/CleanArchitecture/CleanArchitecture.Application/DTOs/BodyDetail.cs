using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.DTOs
{
    public class BodyDetail
    {
        public List<BodyDetail2> detail { get; set; }
    }

    public class BodyDetail2
    {
        public List<string> loc { get; set; }
        public string msg { get; set; }
        public string type { get; set; }
    }
}
