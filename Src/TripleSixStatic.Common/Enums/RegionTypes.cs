using System.ComponentModel;

namespace TripleSix.Static.Common.Enums
{
    public enum RegionTypes
    {
        [Description("thành phố")]
        City = 1,

        [Description("quận / huyện")]
        District = 2,

        [Description("phường / xã")]
        Ward = 3,
    }
}
