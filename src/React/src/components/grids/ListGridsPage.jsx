import { useGetGridsQuery } from "../../features/api/apiSlice";
import GridExcerpt from "./GridExcerpt";

export default function ListGridsPage() {
  const {
    data: grids,
    isLoading,
    isError,
    isSuccess,
    error,
  } = useGetGridsQuery();
  let content;

  if (isLoading) {
    content = <div>Loading... Please, wait a bit</div>;
  } else if (isSuccess) {
    content = grids.map((g) => <GridExcerpt key={g.id} grid={g} />);
  } else if (isError) {
    content = <div>{error.message}</div>;
  }

  return (
    <section>
      <h2>Grids</h2>
      {content}
    </section>
  );
}
