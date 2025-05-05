using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrelloCardCreationAutomation.App
{
    internal record TrelloCardJsonDto
    {
        [JsonPropertyName("labelId")]
        public string LabelId { get; set; }
        [JsonPropertyName("topic")]
        public string Topic { get; set; }
    }
}
