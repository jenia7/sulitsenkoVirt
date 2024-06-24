import { useGetContributorsQuery } from "../features/api/apiSlice";
import ContributorExcerpt from "./ContributorExcerpt";

export default function ContributorsPage() {
  const {
    data: contributors,
    isLoading,
    isError,
    isSuccess,
    error,
  } = useGetContributorsQuery();
  let content;

  if (isLoading) {
    content = <div>Loading... Please, wait a bit</div>;
  } else if (isSuccess) {
    content = contributors.map((c) => (
      <ContributorExcerpt key={c.id} contributor={c} />
    ));
  } else if (isError) {
    content = <div>{error.message}</div>;
  }

  return (
    <section>
      <h2>Contributors</h2>
      {content}
    </section>
  );
}
