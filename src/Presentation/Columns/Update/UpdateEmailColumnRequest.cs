namespace Presentation.Columns.Update;

public record UpdateEmailColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    string Email);
