using Satisfactory_Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects
{
    public class Output
    {
        public Dictionary<Items, MultiValue> outputList = new Dictionary<Items, MultiValue>();
       
        public class MultiValue
        {
            public decimal amountPerMinute;
            public Machines machine;
            public int numberOfMachinesNeeded;
            public int numberOfPowerShardsNeeded;
        }

        public void AddToOutput(KeyValuePair<Items, decimal> item, Machines machine, int numberOfMachines, int numberOfShards)
        {
            if (outputList.ContainsKey(item.Key))
            {
                outputList[item.Key].amountPerMinute += item.Value;
                outputList[item.Key].numberOfMachinesNeeded += numberOfMachines;
                outputList[item.Key].numberOfPowerShardsNeeded += numberOfShards;
            }
            else
            {
                outputList.Add(item.Key, new MultiValue
                {
                    amountPerMinute = item.Value,
                    machine = machine,
                    numberOfMachinesNeeded = numberOfMachines,
                    numberOfPowerShardsNeeded = numberOfShards                    
                });
            }
        }

        public void PrintOutput()
        {
            foreach (KeyValuePair<Items, MultiValue> item in outputList)
            {
                Console.WriteLine($"\n{item.Key}: {item.Value.amountPerMinute}/min");
                Console.WriteLine($"{item.Value.machine} x{item.Value.numberOfMachinesNeeded}, {item.Value.numberOfPowerShardsNeeded} power shards needed");
            }
        }
    }
}
