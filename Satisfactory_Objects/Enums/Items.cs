using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Items
    {
        //Bio items
        alienCarapace,
        alienOrgans,
        alienProtein,
        mycelia,
        wood,
        biomass,
        leaves,
        organicDataCapsule,
        solidBiofuel,
        plasmaSpitterRemains,
        stingerRemains,
        colorCartridge,
        flowerPetals,

        //Overclocking
        powerShard,
        bluePowerSlug,
        yellowPowerSlug,
        purplePowerSlug,

        //Ores
        ironOre,
        copperOre,
        cateriumOre,
        limestone,
        coal,
        sulfur,
        bauxiteOre,
        uraniumOre,
        rawQuartz,
        compactedCoal,

        //Ingots
        ironIngot,
        copperIngot,
        cateriumIngot,
        steelIngot,
        aluminumIngot,
        pureAluminumIngot,

        //Base Items
        ironRod,
        ironPlate,
        screw,
        wire,
        cable,
        copperSheet,
        concrete,
        quickwire,
        rubber,
        silica,
        plastic,
        quartzCrystal,
        aluminumScrap,
        petroleumCoke,
        polymerResin,

        //Complex Items
        reinforcedIronPlate,
        modularFrame,
        steelPipe,
        steelBeam,
        encasedIndustrialBeam,
        rotor,
        stator,
        motor,
        AILimiter,
        alcladAluminumSheet,
        aluminumCasing,
        assemblyDirectorSystem,
        adaptiveControlUnit,
        supercomputer,
        automatedWiring,
        blackPowder,
        circuitBoard,
        clusterNobelisk,
        emptyCanister,
        computer,
        electromagneticControlRod,
        encasedPlutoniumCell,
        fabric,
        gasNobelisk,
        heatSink,
        homingRifleAmmo,
        nobelisk,
        plutoniumFuelRod,
        pressureConversionCube,
        pulseNobelisk,
        rifleAmmo,
        shatterRebar,
        smartPlating,
        stunRebar,
        versatileFramework,
        colorcartridge,
        copperPowder,
        emptyFluidTank,
        spikedRebar,
        ironRebar,
        smokelessRebar,

        //very complex items
        heavyModularFrame,
        portableMiner,
        highSpeedConnector,
        beacon,
        battery,
        crystalOscillator,
        gasFilter,
        encasedUraniumCell,
        iodineInfusedFilter,
        magneticFieldGenerator,
        nukeNobelisk,
        radioControlUnit,
        rifleCartridge,
        thermalPropulsionRocket,
        turboMotor,
        coolingSystem,
        fusedModularFrame,
        turboRifleAmmo,
        uraniumFuelRod,
        modularEngine,
        radioControlSystem,

        //packaged Items
        packagedAluminaSoloution,
        packagedFuel,
        packagedHeavyOilResidue,
        packagedLiquidBiofuel,
        packagedNitricAcid,
        packagedNitrogenGas,
        packagedOil,
        packagedSulfuricAcid,
        packagedTurbofuel,
        packagedWater,

        //fluids
        water,
        aluminaSoloution,
        fuel,
        heavyOilResidue,
        liquidBiofuel,
        nitricAcid,
        crudeOil,
        sulfuricAcid,
        turbofuel,
        residualFuel,

        //Refinery Items
        polyesterFabric,
        residualPlastic,
        residualRubber,
        smokelessPowder


    }
}
