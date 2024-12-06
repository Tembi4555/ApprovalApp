namespace ApprovalApp.API.Contracts.Responses
{
    public record PersonsResponse
    (
        long Id,
        string? FullName,
        DateTime BirthDate
    );
        
}
