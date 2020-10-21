using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mono.Models
{
    public class VehicleMake
    {

        [Key]
        public int makeId { get; set; }
        public string makeName { get; set; }
        public string makeAbrv { get; set; }
        public virtual ICollection<VehicleModel> Make { get; set; }

    }
}