﻿using System;
using OpenCBS.CoreDomain.Contracts.Loans;

namespace OpenCBS.ArchitectureV2.CommandData
{
    public class ShowRepaymentViewCommandData
    {
        public Loan Loan { get; set; }
        public Action DefaultAction { get; set; }  
    }
}
