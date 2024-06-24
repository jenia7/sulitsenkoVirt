using Virtable.Core.GridAggregate;
using Virtable.Core.GridAggregate.Columns;
using Virtable.Core.GridAggregate.Records;

namespace Virtable.Core.Factory;

public static class Factory
{
    public static Grid makeGridWithOneRecordAndOneStringField()
    {
        StringField field = new();
        StringColumn column = new();
        field.Column = column;

        Record initialRecord = new();
        initialRecord.AddField(field);

        Grid grid = new();
        grid.Records.Add(initialRecord);

        return grid;
    }
}
