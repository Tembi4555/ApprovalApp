namespace ApprovalApp.API.Contracts.Requests
{
    /// <summary>
    /// Моедль запроса
    /// </summary>
    public record TicketsRequest
    (
        string? Title,

        string? Description,

        long IdAuthor,

        Dictionary<long, int> approvingInQueue
    );
}
