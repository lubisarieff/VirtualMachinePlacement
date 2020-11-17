namespace CloudService.Resources {
    public record Disk : BaseResources {
        public Disk(int size) {
            Size = size;
        }
        public override string ToString() {
            return $"Disk : {Size} Gb";
        }
    }
}
