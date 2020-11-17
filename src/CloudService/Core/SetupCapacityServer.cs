using CloudService.Resources;

namespace CloudService.Core {
    public class SetupCapacityServer {
        public Resource CapacityServer { get; init; }

        public SetupCapacityServer(Bandwidth maxBandwidth, Cpu maxCpu, Disk maxDisk, Memory maxMemory) {
            CapacityServer = new Resource {
                Bandwidth = new Bandwidth(maxBandwidth.Size),
                Cpu = new Cpu(maxCpu.Size),
                Disk = new Disk(maxDisk.Size),
                Memory = new Memory(maxMemory.Size)
            };
        }
    }
}
