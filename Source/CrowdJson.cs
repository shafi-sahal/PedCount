using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CrowdJson
    {
        public string message { get; set; }
        public IList<Result> result { get; set; }
    }

    public class Prediction
    {
        public string label { get; set; }
        public int xmin { get; set; }
        public int ymin { get; set; }
        public int xmax { get; set; }
        public int ymax { get; set; }
        public double score { get; set; }
    }

    public class Result
    {
        public string message { get; set; }
        public string input { get; set; }
        public IList<Prediction> prediction { get; set; }
        public int page { get; set; }
        public string request_file_id { get; set; }
        public string filepath { get; set; }
    }
}
