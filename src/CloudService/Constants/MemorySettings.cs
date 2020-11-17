using System.Collections.Generic;

namespace CloudService.Constants {
    public static class MemorySettings {
        public static readonly Dictionary<int, int> MemoryCapacities = new Dictionary<int, int>() {
            {1, 1 },
            {2, 2 },
            {3, 4 },
            {4, 8 },
            {5, 16 },
            {6, 32 },
            {7, 64 },
            {8, 128 },
            {9, 256 }
        };
    }
}
