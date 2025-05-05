using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCardCreationAutomation.App
{
    internal static class EnvReader
    {
        public static Dictionary<string, string> GetEnvSync()
        {
            Dictionary<string, string> env = new Dictionary<string, string>();

            string envPath = Path.Combine(AppContext.BaseDirectory, ".env");

            if (!File.Exists(envPath)) throw new Exception(".env file was not found");

            string content = File.ReadAllText(envPath);
            string[] contentByLine = content.Split("\n");

            foreach (string line in contentByLine)
            {
                string[] keyValuePair = line.Trim().Split('=');
                string key = keyValuePair[0].Replace('"', ' ').Trim();
                string value = keyValuePair[1].Replace('"', ' ').Trim();

                env.Add(key, value);
            }

            return env;
        }
    }
}
