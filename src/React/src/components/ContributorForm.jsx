import { useState } from "react";
import { useAddContributorMutation } from "../features/api/apiSlice";

export default function AddContributorForm() {
  const [name, setName] = useState("");
  const [addContributor, { isLoading }] = useAddContributorMutation();
  async function onSaveClicked(e) {
    e.preventDefault();
    if (isLoading) {
      return;
    }
    try {
      await addContributor({ name }).unwrap();
      setName("");
    } catch (err) {
      console.error(`Error status: ${err.status}`);
    }
  }
  return (
    <section>
      <h2>Create contributor</h2>
      <form onSubmit={onSaveClicked}>
        <div>
          <label htmlFor="name">Name:</label>
          <input
            id="name"
            name="name"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <button type="submit">Save</button>
      </form>
    </section>
  );
}
