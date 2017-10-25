using ManageIt.Data.Context;
using ManageIt.Domain.Contracts.Applications;
using ManageIt.Domain.Entities;
using ManageIt.Exceptions;
using ManageIt.Resources.ResourceFile;
using System;
using System.Linq;
using System.Resources;

namespace ManageIt.Application.Applications
{
    public class HomeApplication : IHomeApplication
    {
        public HomeApplication(ConfigurationContext context)
        {
            _context = context;
            ResourceManager rm = new ResourceManager(typeof(EntitiesName));
            _entityName = rm.GetString(nameof(Info));
        }

        private readonly ConfigurationContext _context;
        private readonly string _entityName;

        public void Dispose()
        {
            _context.Dispose();
        }

        public string Index()
        {
            var result = _context.Infos.OrderBy(item => item.Id).FirstOrDefault();
            if (result == null)
            {
                throw new BusinessException(string.Format(ErrorMessage.NotFound, _entityName), 404);
            }
            return result.Version;
        }
    }
}
