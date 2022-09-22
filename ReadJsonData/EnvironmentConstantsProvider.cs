using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace SendEmailPOMTest.ReadJsonData
{
    public class EnvironmentConstantsProvider
    {
        private const string _nameJsonFile = "userDataForTests.json";

        public void Provide(out EnvironmentConstants environmentConstantsObject)
        {
            string objectJsonFile = File.ReadAllText(_nameJsonFile);

            environmentConstantsObject = JsonSerializer.Deserialize<EnvironmentConstants>(objectJsonFile) ?? throw new NullReferenceException("Deserialization JSON file error in EnvironmentConstantsProvider");
        }


    }
}
