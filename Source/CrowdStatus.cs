using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CrowdStatus
    {
        public string model_id { get; set; }
        public string model_type { get; set; }
        public int state { get; set; }
        public string status { get; set; }
        public double accuracy { get; set; }
        public IList<Category> categories { get; set; }
        public string email { get; set; }
        public bool is_public { get; set; }
    }

    public class Category
    {
        public string name { get; set; }
        public int count { get; set; }
    }
}
