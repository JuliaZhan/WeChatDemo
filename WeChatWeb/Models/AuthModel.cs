using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WeChatWeb.Models
{
    public class AuthModel
    {
        [Display(Name="签名")]
        [Required(ErrorMessage ="{0}必填")]
        public string signature { get; set; }
        [Required(ErrorMessage = "时间戳必填")]
        public string timestamp { get; set; }
        [Required(ErrorMessage = "nonce必填")]
        public string nonce { get; set; }
        [Required(ErrorMessage = "token必填")]
        public string token { get; set; }
    }
}
