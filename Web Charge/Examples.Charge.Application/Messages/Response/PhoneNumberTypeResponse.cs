﻿using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneNumberTypeResponse : BaseResponse
    {
        public List<PhoneNumberTypeDto> PersonObjects { get; set; }
    }
}
