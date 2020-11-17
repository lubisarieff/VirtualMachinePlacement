namespace CloudService.Resources {
    public record Bandwidth : BaseResources {
        public Bandwidth(int size) {
            Size = size;
        }

        public override string ToString() {
            return $"Bandwith : {Size} Mbps";
        }
    }
}
