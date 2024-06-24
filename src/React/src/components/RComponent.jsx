import { Alert, Button, DatePicker, Form, Input, Space } from "antd";
import FormItem from "antd/es/form/FormItem";
import { useState } from "react";

export default function RComponent() {
  const [values, setValues] = useState(new Set());
  function onAddValueClicked() {
    const newSet = new Set(values);
    newSet.add(Math.random());

    setValues(newSet);
  }
  return (
    <section>
      <button onClick={onAddValueClicked}>Ann one Item to Set</button>
      <h2>Choose from</h2>
      <Form>
        <FormItem
          label="Username"
          name="username"
          rules={[
            {
              required: true,
              message: "Please input your username!",
            },
          ]}
        >
          <Input />
        </FormItem>
        <FormItem
          label="Password"
          name={"password"}
          rules={[{ required: true, message: "Please enter your password" }]}
        >
          <Input.Password />
        </FormItem>
        <FormItem>
          <Button type="primary" htmlType="submit">
            Submit
          </Button>
        </FormItem>
      </Form>
    </section>
  );
}
