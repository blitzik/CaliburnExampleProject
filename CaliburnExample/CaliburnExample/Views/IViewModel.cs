using CaliburnExample.Security;

namespace CaliburnExample.Views
{
    public interface IViewModel
    {
        IIdentity Identity { get; set; }
    }
}
