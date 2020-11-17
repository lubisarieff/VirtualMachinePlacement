using CloudService.Resources;
using CloudService.Servers;
using System.Collections.Generic;

namespace CloudService.Core {
    public class ServerManagerPlacement {
        private readonly SetupCapacityServer _setupCapacityServer;
        private readonly IEnumerable<VirtualMachine> _virtualMachines;
        private bool _isAllocFlag = false;

        public IList<Server> Servers { get; private set; } = new List<Server>() { 
            new Server("server-1", new Resource() { 
                Bandwidth = new Bandwidth(0),
                Cpu = new Cpu(0),
                Disk = new Disk(0), 
                Memory = new Memory(0)
            })
        };

        public ServerManagerPlacement(SetupCapacityServer setupCapacityServer, IEnumerable<VirtualMachine> virtualMachines) {
            _setupCapacityServer = setupCapacityServer;
            _virtualMachines = virtualMachines;
            
        }

        public void VMPack() {
            foreach (var vm in _virtualMachines) {
                _isAllocFlag = false;
                foreach (var s in Servers) {
                    SumCapacity(s, vm);

                    if (s.MaximumCapacity.Bandwidth.Size <= _setupCapacityServer.CapacityServer.Bandwidth.Size &&
                            s.MaximumCapacity.Cpu.Size <= _setupCapacityServer.CapacityServer.Cpu.Size &&
                                s.MaximumCapacity.Disk.Size <= _setupCapacityServer.CapacityServer.Disk.Size &&
                                    s.MaximumCapacity.Memory.Size <= _setupCapacityServer.CapacityServer.Memory.Size) { 
                        s.AddVirtualMachine(vm);
                        
                        _isAllocFlag = true;
                        break;
                    }
                }

                if (!_isAllocFlag)
                    AddServer(vm);
            }
        }

        private void SumCapacity(Server s, VirtualMachine vm) {
            s.MaximumCapacity.Bandwidth.Size += vm.Resource.Bandwidth.Size;
            s.MaximumCapacity.Cpu.Size += vm.Resource.Cpu.Size;
            s.MaximumCapacity.Disk.Size += vm.Resource.Disk.Size;
            s.MaximumCapacity.Memory.Size += vm.Resource.Memory.Size;            
        }

        private void AddServer(VirtualMachine vm) {
            Servers.Add(new Server($"server-{Servers.Count + 1}", new Resource {
                Bandwidth = new Bandwidth(0),
                Cpu = new Cpu(0),
                Disk = new Disk(0),
                Memory = new Memory(0)
            }));

            Servers[Servers.Count - 1].AddVirtualMachine(vm);
        }
    }
}
