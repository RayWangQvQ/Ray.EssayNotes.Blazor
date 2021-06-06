using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDomain
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "部门")]
        [Required(ErrorMessage ="{0}是必填项")]
        [MaxLength(50,ErrorMessage ="{0}的长度不能超过{1}")]
        public string Name { get; set; }
    }
}
