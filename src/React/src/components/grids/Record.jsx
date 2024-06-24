import Field from "./Field";

export default function Record({ record }) {
  const content = record.fields.map((f) => <Field key={f.id} field={f} />);

  return (
    <section>
      <h3>Record: {record.id}</h3>
      {content}
    </section>
  );
}
