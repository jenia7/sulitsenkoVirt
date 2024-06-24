import { createBrowserRouter } from "react-router-dom";
import ErrorPage from "./components/ErrorPage";
import MainPage from "./components/MainPage";
import ListGridsPage from "./components/grids/ListGridsPage";
import GridPage from "./components/grids/GridPage";
import Grid from "./components/grids/Grid";
import RComponent from "./components/RComponent";

function gridLoader({ params }) {
  const id = parseInt(params.id);
  return { id };
}

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainPage />,
    errorElement: <ErrorPage />,

    children: [
      { path: "/grids", element: <ListGridsPage /> },
      {
        path: "/grids/:id",
        element: <GridPage />,
        loader: gridLoader,
      },
      {
        path: "/custom-grid",
        element: <Grid />,
      },
      {
        path: "/react",
        element: <RComponent />,
        errorElement: <ErrorPage />,
      },
    ],
  },
]);

export default router;
