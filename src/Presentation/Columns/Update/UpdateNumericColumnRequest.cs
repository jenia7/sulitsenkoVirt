namespace Presentation.Columns.Update;

public record UpdateNumericColumnRequest(
    long GridId,
    long ColumnId,
    int Index,
    decimal Value);
