using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartphoneShop.Models
{
    public class SmartphoneFeature
    {
        [Key]
        public string MobileId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        [Display(Name = "Screen Size")]
        public double ScreenSize { get; set; }
        public int RAM { get; set; }
        [Display(Name = "Internal Storage")]
        public int InternalStorage { get; set; }
        [Display(Name = "Front Camera")]
        public int FrontCamera { get; set; }
        [Display(Name = "Rear Camera")]
        public int RearCamera { get; set; }
        public string OS { get; set; }
        public string Sim { get; set; }
        public string Sensor { get; set; }
        [Display(Name = "Battery Capacity")]
        public int BatteryCapacity { get; set; }
        public string Color { get; set; }
        [StringLength(1024)]
        public string Image { get; set; }
    }
}