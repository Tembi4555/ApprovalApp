namespace ApprovalApp.API.Contracts.Requests
{
    /// <summary>
    /// Запрос 
    /// </summary>
    /// <param name="FullName"></param>
    /// <param name="BirthDate"></param>
    public record PersonsRequest
    (
        string? FullName,
        DateTime BirthDate
    );
}
