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
    }
}
