using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.UIModel {
    public abstract class BaseUIModel {
        public int Id { get; set; }
        public string CreateDate { get; set; }
        public DateTime ParsedCreateDate { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
