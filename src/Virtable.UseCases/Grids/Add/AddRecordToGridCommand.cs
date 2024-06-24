namespace Virtable.UseCases.Grids.Add;

public record AddRecordToGridCommand(long GridId) : IRequest<Result>;
