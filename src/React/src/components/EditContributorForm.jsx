import {
  useEditContributorMutation,
  useGetContributorQuery,
} from "../features/api/apiSlice";

export default function EditContributorForm() {
  const { data: contributor } = useGetContributorQuery(1);
  const [updatedEntity, { isLoading }] = useEditContributorMutation();

  function onSaveClicked(e) {
    e.preventDefault();
  }

  return (
    <section>
      <h2>Edit contributor</h2>
      <form onSubmit={onSaveClicked}>
        <button type="submit">Save</button>
      </form>
    </section>
  );
}
