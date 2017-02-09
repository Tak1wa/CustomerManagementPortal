using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomerManagementPortal.Models
{
    public class CustomerHistoryModel
    {
        [Key]
        public int CustomerHistoryModelId { get; set; }

        [Display(Name = "来店日")]
        public DateTime VisitDate { get; set; }

        [Display(Name = "情報")]
        public string Content { get; set; }

        [Display(Name = "コメント")]
        public string Comment { get; set; }

        public virtual CustomerModel CustomerModel { get; set; }

        [ForeignKey("CustomerModel")]
        public virtual int CustomerId { get; set; }
    }
}