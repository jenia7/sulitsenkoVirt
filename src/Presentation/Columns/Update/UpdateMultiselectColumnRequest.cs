namespace Presentation.Columns.Update;

public record UpdateMultiselectColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    List<string> Variants);
