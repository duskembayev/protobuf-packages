using Grpc.Core;
using Microsoft.Extensions.Logging;
using ProtoBufPackages.Services;

namespace Service.Example;

public class ServerExample(ILogger<ServerExample> logger) : StatementService.StatementServiceBase
{
    public override Task<GetStatementsResponse> List(GetStatementsRequest request, ServerCallContext context)
    {
        logger.LogInformation(
            "List called for account {accountId}: {start}-{end}",
            request.AccountId, (DateTimeOffset)request.Start, (DateTimeOffset)request.End);

        throw new NotImplementedException();
    }
}