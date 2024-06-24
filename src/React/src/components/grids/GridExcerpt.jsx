import { NavLink } from "react-router-dom";

export default function GridExcerpt({ grid }) {
  return (
    <article>
      <h3>Id of the grid: {grid.id}</h3>
      <NavLink to={`/grids/${grid.id}`}>View details</NavLink>
    </article>
  );
}
