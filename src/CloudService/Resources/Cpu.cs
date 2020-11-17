namespace CloudService.Resources {
    public record Cpu : BaseResources {
        public Cpu(int size) {
            Size = size;
        }

        public override string ToString() {
            return $"Cpu : {Size} Core";
        }
    }
}
