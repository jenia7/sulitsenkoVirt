namespace Presentation.Columns.Update;

public record UpdateValidatedColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    string Value);
