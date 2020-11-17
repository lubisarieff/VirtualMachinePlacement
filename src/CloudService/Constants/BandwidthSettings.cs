using System.Collections.Generic;

namespace CloudService.Constants {
    public static class BandwidthSettings {
        public static readonly Dictionary<int, int> BandwidthCapacities = new Dictionary<int, int>() {
            {1, 100 },
            {2, 200 },
            {3, 300 },
            {4, 400 }
        };
    }
}
