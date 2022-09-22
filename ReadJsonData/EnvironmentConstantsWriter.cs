using System;
using System.IO;
using System.Text.Json;


namespace SendEmailPOMTest.ReadJsonData
{
    public class EnvironmentConstantsWriter
    {
        public void WriteDown()
        {
            var usernameForTests = new EnvironmentConstants();

            string objectSerialized = JsonSerializer.Serialize(usernameForTests);

            File.WriteAllText("userDataForTests.json", objectSerialized);
        }
    }
}
