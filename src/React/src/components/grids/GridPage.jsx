import { useLoaderData } from "react-router-dom";
import { useGetGridQuery } from "../../features/api/apiSlice";
import Record from "./Record";

export default function GridPage() {
  const { id } = useLoaderData();
  const {
    data: grid,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetGridQuery(id);

  let content;

  if (isLoading) {
    content = <div>Loading... Please, wait a bit</div>;
  } else if (isSuccess) {
    const rows = grid.rows.map((r) => <Record key={r.id} row={r} />);
    content = (
      <article>
        <h2>{grid.name}</h2>
        {rows}
      </article>
    );
  } else if (isError) {
    content = <div>{error.status}</div>;
  }

  return <>{content}</>;
}
