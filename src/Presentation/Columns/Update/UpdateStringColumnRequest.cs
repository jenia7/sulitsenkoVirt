namespace Presentation.Columns.Update;

public record UpdateStringColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    string Value);
