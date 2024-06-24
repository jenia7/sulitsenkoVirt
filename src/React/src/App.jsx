import { useMemo, useState } from "react";
import "./App.css";
import { useGetContributorsQuery } from "./features/api/apiSlice";
import ContributorPage from "./components/ContributorPage";
import Navigation from "./components/Navigation";

function App() {
  const {
    data: contributors = [],
    isSuccess,
    isLoading,
    isError,
    error,
  } = useGetContributorsQuery();
  let content;
  let sortedContributors = useMemo(() => {
    let sorted = contributors.slice();
    sorted.sort((a, b) => a.name.localeCompare(b.name));
    return sorted;
  }, [contributors]);

  if (isLoading) {
    content = <div>Loading... Please, wait a bit...</div>;
  } else if (isSuccess) {
    content = sortedContributors.map((c) => (
      <ContributorPage key={c.id} contributor={c} />
    ));
  } else if (isError) {
    content = <div>{error.message}</div>;
  }

  return (
    <section>
      <Navigation />
      <h2>Contributors</h2>
      {content}
    </section>
  );
}

export default App;
