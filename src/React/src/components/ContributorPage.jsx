import { Link, useLoaderData } from "react-router-dom";
import { useGetContributorQuery } from "../features/api/apiSlice";

export default function ContributorPage() {
  const { id } = useLoaderData();
  let {
    data: contributor,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetContributorQuery(id);

  let content;
  if (isLoading) {
    content = <div>Loading... Please, wait a bit</div>;
  } else if (isSuccess) {
    content = (
      <article>
        <h3>{contributor.name}</h3>
        <div>
          <Link to={`/contributors`}>Contributors</Link>
        </div>
      </article>
    );
  } else if (isError) {
    content = <div>{error.message}</div>;
  }

  return <>{content}</>;
}
