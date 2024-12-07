namespace ApprovalApp.API.Contracts.Responses
{
    /// <summary>
    /// Ответ
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="FullName"></param>
    /// <param name="BirthDate"></param>
    public record PersonsResponse
    (
        long Id,
        string? FullName,
        DateTime BirthDate
    );
        
}
