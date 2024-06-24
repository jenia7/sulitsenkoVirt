import Field from "./Field";

export default function Row(record) {
  const content = record.fields.map((f) => <Field key={f.id} field={f} />);
  return <div>{content}</div>;
}
