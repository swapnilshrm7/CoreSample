using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AdminService
{
    public class SMSGeneration
    {
        public void SMS()
        {
            try
            {
                // Find your Account Sid and Auth Token at twilio.com/user/account 
                const string accountSid = "AC7142aef8be75aa40aaa65cbcca4b2329";
                const string authToken = "8ed4e7af2f184cf4c9a781efeff950d7";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+917038242131");
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber("+13158832734"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ). 
                    body: $"Hello !! Welcome to Asp.Net Core With Twilio SMS API !!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Registration Failure : {ex.Message} ");
            }
        }
    }
}

