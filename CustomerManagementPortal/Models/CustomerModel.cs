using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerManagementPortal.Models
{
    public class CustomerModel
    {
        [Key]
        [Display(Name = "顧客番号")]
        public int CustomerId { get; set; }

        [Display(Name = "氏名")]
        public string Name { get; set; }

        [Display(Name = "Eメール")]
        public string Email { get; set; }

        [Display(Name = "電話番号")]
        public string Tel { get; set; }

        [Display(Name = "コメント")]
        public string Comment { get; set; }

        public virtual List<CustomerHistoryModel> Histories { get; set; }
    }
}