namespace Presentation.Columns.Update;

public record UpdateSelectColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    string Variant);
