namespace Virtable.Core.GridAggregate.Records;

public sealed class Record
{
    public long Id { get; set; }

    public List<Field> Fields { get; set; } = [];

    public void AddField(Field field)
    {
        Fields.Add(field);
    }
}
