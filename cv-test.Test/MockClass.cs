using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_test.Test
{
    public class MockClass
    {
        public class Captions
        {
            public string? text { get; set; }
            public double? confidence { get; set; }

        }
        public class Description
        {
            public IList<string>? tags { get; set; }
            public IList<Captions>? captions { get; set; }

        }
        public class Metadata
        {
            public int? height { get; set; }
            public int? width { get; set; }
            public string? format { get; set; }

        }
        public class Application
        {
            public Description? description { get; set; }
            public string? requestId { get; set; }
            public Metadata? metadata { get; set; }
            public string? modelVersion { get; set; }

        }
    }
}
