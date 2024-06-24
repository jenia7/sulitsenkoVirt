import { Link } from "react-router-dom";

export default function ContributorExcerpt({ contributor }) {
  return (
    <article>
      <h3>{contributor.name}</h3>
      <Link to={`/contributors/${contributor.id}`}>Details</Link>
    </article>
  );
}
