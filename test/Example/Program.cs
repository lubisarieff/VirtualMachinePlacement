using CloudService.Core;
using CloudService.Resources;
using System;
using System.Linq;

namespace Example {
    class Program {
        static void Main(string[] args) {
            //setting jumlah virtual machine
            int maxVirtualMachine = 10;

            //setting nilai maximum untuk capasitas sebuah server
            int maxBandwidth = 1000;
            int maxCpu = 16;
            int maxDisk = 1000;
            int maxMemory = 8;

            var resourceManager = new ResourceManagerVM(maxVirtualMachine);
            //generate random virtual machine
            resourceManager.CreateRandomVirtualMachine();

            foreach (var rm in resourceManager.VirtualMachines) {
                Console.WriteLine($"{rm.Name} : [{rm.Resource.Cpu}, {rm.Resource.Memory}, {rm.Resource.Disk}, {rm.Resource.Bandwidth}]");
            }

            //setup server -> nilai maximum untuk capasitas sebuah server
            var setupServer = new SetupCapacityServer(new Bandwidth(maxBandwidth), new Cpu(maxCpu), new Disk(maxDisk), new Memory(maxMemory));
            Console.WriteLine();
            Console.WriteLine($"Maximum Capacity Server : [{setupServer.CapacityServer.Cpu}, {setupServer.CapacityServer.Memory}, {setupServer.CapacityServer.Disk}, {setupServer.CapacityServer.Bandwidth}]");

            //packing virtual machine ke dalam server
            var serverManagerPlacement = new ServerManagerPlacement(setupServer, resourceManager.VirtualMachines);
            serverManagerPlacement.VMPack();

            Console.WriteLine();
            Console.WriteLine($"Total Virtual Machine : {resourceManager.VirtualMachines.Count()} unit");
            Console.WriteLine($"Total Server yang dibutuhkan : {serverManagerPlacement.Servers.Count} unit");

            Console.WriteLine();
            foreach (var s in serverManagerPlacement.Servers) {
                Console.WriteLine(s.Name);
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (var v in s.VirtualMachines) {
                    Console.WriteLine($"| {v.Name} in {s.Name} : [{v.Resource.Cpu}, {v.Resource.Memory}, {v.Resource.Disk},{ v.Resource.Bandwidth}] |");
                }
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine();
            }
        }
    }
}
