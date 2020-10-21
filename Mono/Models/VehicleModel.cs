using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mono.Models
{
    public class VehicleModel
    {
        [Key]
        public int modelId { get; set; }
        public int makeId { get; set; }
        public string modelName { get; set; }
        public string modelAbrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}