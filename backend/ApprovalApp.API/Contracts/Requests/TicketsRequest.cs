namespace ApprovalApp.API.Contracts.Requests
{
    public record TicketsRequest
    (
        string? Title,

        string? Description,

        long IdAuthor,

        Dictionary<long, int> approvingInQueue
    );
}
