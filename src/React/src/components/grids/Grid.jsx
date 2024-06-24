import "react-data-grid/lib/styles.css";

import DataGrid, { SelectColumn, textEditor } from "react-data-grid";
import { useMemo, useState } from "react";
import { useGetGridQuery, useGetGridsQuery } from "../../features/api/apiSlice";
import Record from "./Record";

const countries = ["China", "Rossia", "USA"];

function getComparator(sortColumn) {
  switch (sortColumn) {
    case "id":
      return (a, b) => a[sortColumn] - b[sortColumn];
    case "title":
    case "client":
      return (a, b) => a[sortColumn].localeCompare(b[sortColumn]);

    default:
      throw new Error(`unsupported column type: ${sortColumn}`);
  }
}

const rowsInit = [
  { id: 1, title: "str", client: "Ann" },
  { id: 2, title: "str2", client: "Bob" },
  { id: 3, title: "str3", client: "Mary" },
];

export default function Grid() {
  let [rows, setRows] = useState(rowsInit);
  const [selectedRows, setSelectedRows] = useState(new Set());
  const [sortColumns, setSortColumns] = useState([]);
  let columns;
  const {
    data: grid,
    isLoading,
    isError,
    isSuccess,
    error,
  } = useGetGridQuery(4);
  let content;
  if (isLoading) {
    content = <div>Loading... Please, wait a bit... ://</div>;
  } else if (isSuccess) {
    //content = grid.records.map((r) => <Record key={r.id} record={r} />);
    columns = grid.records[0].fields.map((f) => ({
      key: f.columnId,
      name: f.column.discriminator.name,
    }));

    rows = grid.records.map((r) => ({
      6: r.fields[0].value,
      7: r.fields[1].number,
    }));
  } else if (isError) {
    content = <div>{error.message}</div>;
  }

  function handleFill({ columnKey, sourceRow, targetRow }) {
    return { ...targetRow, [columnKey]: sourceRow[columnKey] };
  }

  const sortedRows = useMemo(() => {
    if (sortColumns.length === 0) return rows;

    return [...rows].sort((a, b) => {
      for (const sort of sortColumns) {
        const comparator = getComparator(sort.columnKey);
        const compResult = comparator(a, b);
        if (compResult !== 0) {
          return sort.direction === "ASC" ? compResult : -compResult;
        }
      }
      return 0;
    });
  }, [rows, sortColumns]);

  return (
    <>
      <DataGrid columns={columns} rows={rows} />
    </>
  );
}
