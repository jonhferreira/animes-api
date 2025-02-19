﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Abstractions
{
    public interface IApiResponse<T>
    {
        bool Success { get; set; }
        HttpStatusCode StatusCode { get; set; }
        T Data { get; set; }
        string Message { get; set; }
        string MoreDetails { get; set; }
    }
}
