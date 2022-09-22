using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SendEmailPOMTest.ReadJsonData
{
    public class EnvironmentConstants
    {
        public string Email { get; set; } = "";

        public string Password { get; set; } = "";

        public string EmailReciever { get; set; } = "";

        public string MessageBody { get; } = "This is a test for verifying sending and recieving email.";

        public readonly string subject = UniqueStringGenerator.UniqueStringGeneration();

    }
}
