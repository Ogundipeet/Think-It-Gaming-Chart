using System;
using System.Collections.Generic;

namespace Think_It_Gaming_Chart.Application.Responses.Base
{
    public class BaseResponse
    {
        public string Game { get; set; }
        public int PlayTime { get; set; }
        public string Genre { get; set; }
        public List<string> Platforms { get; set; }
    }
}
