using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class OTPResponse<T>
    {
        public string OTP { get; set; }
        public string FullName { get; set; }
        public bool IsOTPVerify { get; set; }
        public string Contact { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string StatusCode { get; set; }
    }
}
