using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrelloCardCreationAutomation.App
{
    internal record MainJsonDto
    {
        [JsonPropertyName("cards")]
        public IEnumerable<TrelloCardJsonDto> Cards { get; set; } = new List<TrelloCardJsonDto>();
    }
}
