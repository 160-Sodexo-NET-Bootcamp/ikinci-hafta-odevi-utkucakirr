using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataModel.DTOs
{
    public class GroupModelForContainers
    {
        public int GroupNumber { get; set; }
        public List<ContainerViewModel> Containers { get; set; }
    }
}
    