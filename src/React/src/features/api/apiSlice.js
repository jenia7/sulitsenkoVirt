import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const apiSlice = createApi({
  // The cache reducer expects to be added at `state.api` (already default - this is optional)
  reducerPath: "api",
  // All of our requests will have URLs starting with '/fakeApi'
  baseQuery: fetchBaseQuery({ baseUrl: "/api" }),
  tagTypes: ["Grids"],
  // The "endpoints" represent operations and requests for this server
  endpoints: (builder) => ({
    // The `getPosts` endpoint is a "query" operation that returns data
    getGrids: builder.query({
      // The URL for the request is '/fakeApi/posts'
      query: () => "/grids",
      providesTags: ["Grids"],
    }),
    getGrid: builder.query({
      query: (id) => `/grids/${id}`,
    }),
    addGrid: builder.mutation({
      query: (grid) => ({
        url: "/grids",
        method: "POST",
        body: grid,
      }),
      invalidatesTags: ["Grids"],
    }),
    editGrid: builder.mutation({
      query: (grid) => ({
        url: "/grids",
        method: "PUT",
        body: grid,
      }),
      invalidatesTags: ["Grids"],
    }),
  }),
});

// Export the auto-generated hooks
export const {
  useGetGridsQuery,
  useGetGridQuery,
  useAddGridMutation,
  useEditGridMutation,
} = apiSlice;
