using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.CommandQuerySeparation.Results;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace TestDpApi.Queries
{
    public class GetPasswdQuery : IQueryDefinition<string>
    {
    }

    public class GetPasswdQueryHandler : IQueryHandler<GetPasswdQuery, string>
    {
        private IConfiguration _configuration;

        public GetPasswdQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICqsResult<string> Execute(GetPasswdQuery query)
        {
            byte[] entropy = Convert.FromBase64String(Properties.Resources.Entropy);
            byte[] bytes = ProtectedData.Unprotect(Convert.FromBase64String(_configuration.GetSection("LocalEntry")!.Value!), entropy, DataProtectionScope.LocalMachine);
            return ICqsResult<string>.Success(Encoding.Unicode.GetString(bytes));
        }
    }
}
