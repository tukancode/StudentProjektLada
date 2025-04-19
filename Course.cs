using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladaprojekt
{
    internal class Course
    {

         public int ID { get; set; }
        [MaxLength(50)]
        public string CourseName { get; set; }
        public int Credits { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
