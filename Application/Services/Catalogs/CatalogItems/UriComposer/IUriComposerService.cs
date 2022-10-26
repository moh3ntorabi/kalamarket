using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Catalogs.CatalogItems.UriComposer
{
    public interface IUriComposerService
    {
        string ComposeImageUri(string Src);
    }
    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string Src)
        {
            return "https://localhost:44372/" +Src;
        }
    }
}
