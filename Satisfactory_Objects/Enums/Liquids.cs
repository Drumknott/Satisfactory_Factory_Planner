using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Liquids
    {
        water,
        crude_Oil,
        sulfuric_Acid,
        alumina_Soloution,
        fuel,
        heavy_Oil_Residue,
        liquid_Biofuel,
        nitric_Acid,
        nitrogen_Gas,
        turbofuel,
    }
}
