using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Nodes
    {
        iron,
        copper,
        limestone,
        coal,
        caterium,
        sulfer,
        oil,
        bauxite,
        uramium,
        water
    }
}
