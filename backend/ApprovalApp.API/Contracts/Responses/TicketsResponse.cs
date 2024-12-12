namespace ApprovalApp.API.Contracts.Responses
{
    /// <summary>
    /// Ответ 
    /// </summary>
    public record TicketsResponse
    (
        long Id,
        string? Title,
        string? Description,
        long IdAuthor, 
        string? status
    );
}
