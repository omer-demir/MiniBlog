using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.Models {
    public abstract class BaseEntity {
        public int Id { get; set; }
        public long CreateDate { get; set; }
        public bool ActiveStatus{ get; set; }
    }
}
