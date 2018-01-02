using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class DeliveryFormModel
    {
        public DeliveryFormModel()
        {

        }
        public String otid { get; set; }
        public String otdestinnom { get; set; }
        public String otdestville { get; set; }
        public int otdestnp { get; set; }
        public DateTime periode { get; set; }
        public int COUNT { get; set; }
        public int SUM { get; set; }
        public DateTime FROM { get; set; }
        public DateTime To { get; set; }
    }
}
