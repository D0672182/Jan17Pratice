using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jan17Pratice.Models
{
    public class car
    {
        [Display(Name="員工編號")]  //自訂"顯示欄位"名稱, Model類別屬性的"表示法"
        public int Id { get; set; }
        [Display(Name ="品牌")]
        public string brand { get; set; }
        [Display(Name ="型號")]
        public string model { get; set; }
        [Display(Name = "馬力")]
        public double hp { get; set; }
        [Display(Name ="建議售價")]
        public double price { get; set; }
        [Display(Name = "車型")]
        public string classification { get; set; }
        }
    }
