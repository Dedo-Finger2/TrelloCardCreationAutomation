using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrelloCardCreationAutomation.App
{
    internal record CreateCardRequestBody
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }
        public string IdLabels { get; init; }
    }
}
