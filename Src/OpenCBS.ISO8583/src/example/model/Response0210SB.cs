﻿/**
 *  Distributed as part of Free.iso8583
 *  
 *  Free.iso8583 is ISO 8583 Message Processor library that makes message parsing/compiling esier.
 *  It will convert ISO 8583 message to a model object and vice versa. So, the other parts of
 *  application will only do the rest effort to make business process done.
 *  
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License or (at your option) any later version. 
 *  See http://gnu.org/licenses/lgpl.html
 *
 *  Developed by AT Mulyana (atmulyana@yahoo.com) 2009-2015
 *  The latest update can be found at sourceforge.net
 **/
using System;
using Free.iso8583.config.attribute;

namespace Free.iso8583.example.model
{
    [BitMap(Seq = 3, Length = 16)]
    [NullField(Seq = 1)]
    public class Response0210SB : Response0210
    {
        public Response0210SB()
        {
        }
        public Response0210SB(Object aModel) : base(aModel)
        {
        }

        public byte[] SecondBitMap { get; set; }
        
        [PropertyField(Seq = 104, FieldType = FieldType.ANS, LengthHeader = 2, PropertyType = PropertyType.String,
            FromRequest = true)]
        public String TransactionDescription { get; set; }
    }
}
