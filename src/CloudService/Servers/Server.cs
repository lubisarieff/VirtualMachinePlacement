using CloudService.Resources;
using System.Collections.Generic;

namespace CloudService.Servers {
    public class Server {
        public string Name { get; init; }
        public ICollection<VirtualMachine> VirtualMachines { get; set; }
        public Resource MaximumCapacity { get; set; }

        public Server(string name, Resource maximumCapacity) {
            Name = name;
            MaximumCapacity = maximumCapacity;
            VirtualMachines = new HashSet<VirtualMachine>();
        }      

        public bool AddVirtualMachine(VirtualMachine virtualMachine) {
            VirtualMachines.Add(virtualMachine);
            return true;
        }

        public bool RemoveVirtualMachine(VirtualMachine virtualMachine) {
            VirtualMachines.Remove(virtualMachine);
            return true;
        }

        public int SumOfBandwidthVM() {
            int total = 0;
            foreach (var vm in VirtualMachines) {
                total += vm.Resource.Bandwidth.Size;
            }
            return total;
        }

        public IDictionary<string, int> SumOfCapacityVM() {           
            int totalBandwidth = 0;
            int totalCpu = 0;
            int totalDisk = 0;
            int totalMemory = 0;

            foreach (var vm in VirtualMachines) {
                totalBandwidth += vm.Resource.Bandwidth.Size;
                totalCpu += vm.Resource.Cpu.Size;
                totalDisk += vm.Resource.Disk.Size;
                totalMemory += vm.Resource.Memory.Size;
            }
            var totalCapacityVM = new Dictionary<string, int>() {
                { "bandwidth",totalBandwidth }, 
                { "cpu",totalCpu }, 
                { "disk",totalDisk }, 
                { "memory",totalMemory }, 
            };
            return totalCapacityVM;
        }

    }
}
