import { Menu } from "antd";
import { useState } from "react";
import { NavLink } from "react-router-dom";
import {
  AppstoreOutlined,
  MailOutlined,
  SettingOutlined,
} from "@ant-design/icons";
import { element } from "prop-types";

const items = [
  {
    label: "Navigation One",
    key: "mail",
    icon: <MailOutlined />,
  },
  {
    label: "Navigation Two",
    key: "app",
    icon: <AppstoreOutlined />,
  },
];

export default function Navigation() {
  const [current, setCurrent] = useState("mail");
  const onClick = (e) => {
    console.log("click ", e);
    setCurrent(e.key);
  };

  const elem = (
    <nav>
      <ul>
        <li>
          <NavLink to="/">Main page</NavLink>
        </li>
        <li>
          <NavLink to="/grids">Grids</NavLink>
        </li>
        <li>
          <NavLink to="/custom-grid">GRID</NavLink>
        </li>
        <li>
          <NavLink to="/react">React</NavLink>
        </li>
      </ul>
    </nav>
  );

  return (
    <Menu
      onClick={onClick}
      selectedKeys={[current]}
      mode="vertical"
      items={items}
    />
  );
}
