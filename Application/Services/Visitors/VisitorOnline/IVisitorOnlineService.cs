using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Visitors.VisitorOnline
{
    public interface IVisitorOnlineService
    {
        void ConnectUser(string ClientId);
        void DisConnectUser(string ClientId);
        int GetCount();
    }
}
