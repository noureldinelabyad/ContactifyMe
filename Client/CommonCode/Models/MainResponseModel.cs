using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCode.Services;


namespace CommonCode.Models

{
    public class MainResponseModel
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object Content { get; set; }
        public string Message { get; set; }

    }
}
