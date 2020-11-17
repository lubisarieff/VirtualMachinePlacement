using CloudService.Resources;

namespace CloudService.Servers {
    public record VirtualMachine {
        public string Name { get; init; }
        public Resource Resource { get; init; }

        public VirtualMachine(string name, Resource resource) =>
            (Name, Resource) = (name, resource);
    }
}
