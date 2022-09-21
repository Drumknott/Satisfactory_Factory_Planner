using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Machines
    {
        Miner,
        Smelter,
        Foundry,
        Constructor,
        Assembler,
        Manufacturer,
        Refinery
    }
}
