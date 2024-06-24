using Virtable.Core.Exceptions;
using Virtable.Core.GridAggregate.Columns;
using Virtable.Core.GridAggregate.Records;
using Virtable.Core.SharedKernel;

namespace Virtable.Core.GridAggregate;

public sealed class Grid : BaseEntity, IAggregateRoot
{
    public List<Record> Records { get; set; } = [];

    public void AddRecord()
    {
        if (Records.Count == 0)
        {
            throw new DomainException($"Grid with {Id} should contain at least one record");
        }
        if (Records[0].Fields.Count == 0)
        {
            long recordId = Records[0].Id;
            throw new DomainException($"Record with id = {recordId} should contain at least one field");
        }
        Record sample = Records[0];

        Record newRecord = new();

        foreach (var field in sample.Fields)
        {
            Field copy = field.makeCopyWithDefaultValue();
            copy.ColumnId = field.ColumnId;
            copy.Column = field.Column;
            newRecord.AddField(copy);
        }

        Records.Add(newRecord);
    }

    public void AddColumn(ColumnType columnType)
    {
        if (Records.Count == 0)
        {
            throw new DomainException($"Grid (id = {Id}) should contain at least 1 Record");
        }
        if (Records[0].Fields.Count == 0)
        {
            long recordId = Records[0].Id;
            throw new DomainException($"Record with id = {recordId} should contain at least one field");
        }

        Column column = columnType.makeColumn();

        foreach (var record in Records)
        {
            Field field = columnType.makeField();
            field.Column = column;
            record.AddField(field);
        }
    }
}
