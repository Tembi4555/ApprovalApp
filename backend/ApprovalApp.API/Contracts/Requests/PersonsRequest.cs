namespace ApprovalApp.API.Contracts.Requests
{
    public record PersonsRequest
    (
        string? FullName,
        DateTime BirthDate
    );
}
