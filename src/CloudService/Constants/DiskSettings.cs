using System.Collections.Generic;

namespace CloudService.Constants {
    public static class DiskSettings {
        public static readonly Dictionary<int, int> DiskCapacities = new Dictionary<int, int>() {
            {1, 128 },
            {2, 256 },
            {3, 512 },
            {4, 1000 },
            {5, 2000 },
        };
    }
}
