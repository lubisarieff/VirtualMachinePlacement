using CloudService.Constants;
using CloudService.Resources;
using CloudService.Servers;
using System;
using System.Collections.Generic;

namespace CloudService.Core {
    public class ResourceManagerVM {
        public int Request { get; init; }
        public IEnumerable<VirtualMachine> VirtualMachines { get; private set; }    

        public ResourceManagerVM(int request) {
            Request = request;
        }

        public void CreateRandomVirtualMachine() {
            var virtualMachine = new List<VirtualMachine>();
            for (int i = 1; i <= Request; i++) {
                virtualMachine.Add(new VirtualMachine($"vm-{i}", new Resource {
                    Bandwidth = new Bandwidth(BandwidthSettings.BandwidthCapacities[new Random().Next(1,4)]),
                    Cpu = new Cpu(CpuSettings.CpuCapacities[new Random().Next(1, 4)]),
                    Disk = new Disk(DiskSettings.DiskCapacities[new Random().Next(1,4)]),
                    Memory = new Memory(MemorySettings.MemoryCapacities[new Random().Next(1,4)])
                }));
            }

            VirtualMachines = virtualMachine;
        }

        public void AddRangeVirtualMachine(IList<VirtualMachine> virtualMachines) {
            VirtualMachines = virtualMachines;
        }
    }
}
