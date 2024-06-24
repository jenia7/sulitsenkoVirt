import { NavLink, useRouteError } from "react-router-dom";

export default function ErrorPage() {
  const error = useRouteError();
  return (
    <div>
      <h2>Oops...</h2>
      <p>An unexpected error has occured :/</p>
      <p>
        <strong>{error.message}</strong>
      </p>
      <NavLink to="/">to Main page</NavLink>
    </div>
  );
}
