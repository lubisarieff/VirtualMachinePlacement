using System.Collections.Generic;

namespace CloudService.Constants {
    public static class CpuSettings {
        public static readonly Dictionary<int, int> CpuCapacities = new Dictionary<int, int>() {
            {1, 1 },
            {2, 2 },
            {3, 4 },
            {4, 8 },
            {5, 16 },
            {6, 32 },
            {7, 40 },
            {8, 48 },
            {9, 64 },
            {10, 96 },
        };
    }
}
