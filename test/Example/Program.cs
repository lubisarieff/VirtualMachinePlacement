
using CloudService.Core;
using CloudService.Resources;
using System;

namespace Example {
    class Program {
        static void Main(string[] args) {
            //setting jumlah virtual machine
            var resourceManager = new ResourceManagerVM(10);
            //generate random virtual machine
            resourceManager.CreateRandomVirtualMachine();

            foreach (var rm in resourceManager.VirtualMachines) {
                Console.WriteLine($"{rm.Name} : [{rm.Resource.Cpu}, {rm.Resource.Memory}, {rm.Resource.Disk}, {rm.Resource.Bandwidth}]");
            }

            //setting nilai maximum untuk capasitas sebuah server
            var setupServer = new SetupCapacityServer(new Bandwidth(500), new Cpu(16), new Disk(1000), new Memory(8));
            Console.WriteLine();
            Console.WriteLine($"Maximum Capacity Server : [{setupServer.CapacityServer.Cpu}, {setupServer.CapacityServer.Memory}, {setupServer.CapacityServer.Disk}, {setupServer.CapacityServer.Bandwidth}]");

            //packing virtual machine ke dalam server
            var serverManagerPlacement = new ServerManagerPlacement(setupServer, resourceManager.VirtualMachines);
            serverManagerPlacement.VMPack();

            Console.WriteLine();
            //Console.WriteLine($"Total Virtual Machine : {resourceManager} unit");
            Console.WriteLine($"Total Server yang dibutuhkan : {serverManagerPlacement.Servers.Count} unit");

            Console.WriteLine();
            foreach (var s in serverManagerPlacement.Servers) {
                foreach (var v in s.VirtualMachines) {
                    Console.WriteLine($"{v.Name} in {s.Name} : [{v.Resource.Cpu}, {v.Resource.Memory}, {v.Resource.Disk},{ v.Resource.Bandwidth}]");
                }
            }

            //ICollection<VirtualMachine> vms = new HashSet<VirtualMachine>();
            //for (int i = 1; i <= 10; i++) {
            //    vms.Add(new VirtualMachine($"vm-{i}", new Resource {
            //        Bandwidth = new Bandwidth(1),
            //        Cpu = new Cpu(new Random().Next(1,2) + i),
            //        Disk = new Disk(new Random().Next(3, 4)),
            //        Memory = new Memory(new Random().Next(2, 3))
            //    }));
            //}
            //IEnumerable<VirtualMachine> virtualMachine = vms;

            //var setupServer = new Server("server-setup", new Resource {
            //    Bandwidth = new Bandwidth(4),
            //    Cpu = new Cpu(11),
            //    Disk = new Disk(8),
            //    Memory = new Memory(4)
            //});

            //List<Server> servers = new List<Server>() {
            //    new Server("server-1", new Resource {
            //        Bandwidth = new Bandwidth(1),
            //        Cpu = new Cpu(1),
            //        Disk = new Disk(1),
            //        Memory = new Memory(1)
            //    })
            //};

            //foreach (var vm in virtualMachine) {
            //    bool isAllocFlag = false;

            //    foreach (var s in servers) {
            //        if (s.MaximumCapacity.Bandwidth.Size <= setupServer.MaximumCapacity.Bandwidth.Size &&
            //                s.MaximumCapacity.Cpu.Size <= setupServer.MaximumCapacity.Cpu.Size &&
            //                    s.MaximumCapacity.Disk.Size <= setupServer.MaximumCapacity.Disk.Size &&
            //                        s.MaximumCapacity.Memory.Size <= setupServer.MaximumCapacity.Memory.Size) {
            //            s.AddVirtualMachine(vm);
            //            s.MaximumCapacity.Bandwidth.Size += vm.Resource.Bandwidth.Size;
            //            s.MaximumCapacity.Cpu.Size += vm.Resource.Cpu.Size;
            //            s.MaximumCapacity.Disk.Size += vm.Resource.Disk.Size;
            //            s.MaximumCapacity.Memory.Size += vm.Resource.Memory.Size;
            //            isAllocFlag = true;
            //            break;
            //        }
            //    }

            //    if (!isAllocFlag) {
            //        servers.Add(new Server($"server-{servers.Count + 1}", new Resource {
            //            Bandwidth = new Bandwidth(0),
            //            Cpu = new Cpu(0),
            //            Disk = new Disk(0),
            //            Memory = new Memory(0)
            //        }));
            //        servers[servers.Count - 1].AddVirtualMachine(vm);   
            //    }
            //}

            //Console.WriteLine($"Total Virtual Machine : {vms.Count} unit");
            //Console.WriteLine($"Total Server yang dibutuhkan : {servers.Count} unit");

            //foreach (var ser in servers) {
            //    foreach (var v in ser.VirtualMachines) {
            //        Console.WriteLine($"{v.Name} is allocated in {ser.Name}");
            //        Console.WriteLine($@"Spesifikasi {v.Name} : 
            //                {v.Resource.Cpu}
            //                {v.Resource.Disk}
            //                {v.Resource.Memory}
            //                {v.Resource.Bandwidth}");
            //    }
            //}
        }
    }
}
