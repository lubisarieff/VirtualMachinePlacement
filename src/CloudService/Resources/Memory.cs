namespace CloudService.Resources {
    public record Memory : BaseResources {
        public Memory(int size) {
            Size = size;
        }
        public override string ToString() {
            return $"Memory : {Size} Gb";
        }
    }
}
