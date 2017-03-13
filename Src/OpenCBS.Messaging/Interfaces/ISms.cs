﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using CodeScales.Http;
using CodeScales.Http.Methods;
using CodeScales.Http.Common;
using CodeScales.Http.Entity;
using System.Web;
using RestSharp.Contrib;

namespace OpenCBS.Messaging.Interfaces
{
    public abstract class ISms
    {
        private string url = null;
        private bool httpEncode = false;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public bool HttpEncode
        {
            get { return httpEncode; }
            set { httpEncode = value; }
        }

        private string userName = null;
        public string UserName
        {
            get { return userName; }
            //set { userName = HttpUtility.UrlEncode(value); }
            set { userName = value; }
        }
        
        private string password = null;
        public string Password
        {
            get { return password; }
            //set { password = HttpUtility.UrlEncode(value); }
            set { password = value; }
        }

        private List<string> messageTo = new List<string>();
        public string MessageTo
        {
            get 
            {
                return string.Join(",", messageTo.ToArray());                
            }            
        }

        private string messageFrom = null;
        public string MessageFrom
        {
            get { return messageFrom; }
            set
            {
                messageFrom = HttpEncode ? HttpUtility.UrlEncode(value) : value;
            }
        }

        private string message = null;
        public string Message
        {
            get { return message; }
            set
            {
                message = HttpEncode ? HttpUtility.UrlEncode(value) : value;
            }
        }

        private string postData = null;
        public string PostData
        {
            get { return postData; }
            set { postData = value; }
        }
        

        public void AddRecipient(string phoneNumber) 
        {
            messageTo.Add(FormatPhoneNumber(phoneNumber));
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            StringBuilder phoneNo = new StringBuilder();
            if (phoneNumber.StartsWith("0"))
            {
                phoneNo.Append("234");
                for (int i = 1; i < phoneNumber.Length; i++)
                {
                    phoneNo.Append(phoneNumber[i]);
                }
            }
            else
            {
                phoneNo.Append(phoneNumber);
            }
            return phoneNo.ToString();
        }

        public abstract string GetBalance();
        public abstract string SendSms();
                
    }
}
