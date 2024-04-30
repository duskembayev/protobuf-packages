using ProtoBufPackages.Services;

namespace Service.Example;

public class ClientExample(StatementService.StatementServiceClient innerClient)
{
    public async Task<GetStatementsResponse> ListAsync(GetStatementsRequest request,
        CancellationToken cancellationToken = default)
    {
        return await innerClient.ListAsync(request, cancellationToken: cancellationToken);
    }
}