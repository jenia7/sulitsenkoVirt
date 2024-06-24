import { Outlet } from "react-router-dom";
import Navigation from "./Navigation";
import { Layout } from "antd";
import { Content, Footer, Header } from "antd/es/layout/layout";
import Sider from "antd/es/layout/Sider";

const layoutStyle = {
  borderRadius: 8,
  overflow: "hidden",
  width: "calc(100% - 8px)",
  maxWidth: "calc(100% - 8px)",
  minHeight: "100%",
};
const headerStyle = {
  textAlign: "center",

  height: 64,
  paddingInline: 48,
  lineHeight: "64px",
  backgroundColor: "#4096ff",
};
const contentStyle = {
  textAlign: "center",
  minHeight: 120,
  lineHeight: "120px",
  color: "#000000",
  backgroundColor: "#e1e1e1",
};
const siderStyle = {
  textAlign: "center",
  lineHeight: "120px",
  color: "#fff",
  backgroundColor: "#d4d4d4",
};
const footerStyle = {
  textAlign: "center",
  color: "#fff",
  backgroundColor: "#4096ff",
};

export default function MainPage() {
  return (
    <Layout style={layoutStyle}>
      <Header style={headerStyle}>Header</Header>
      <Layout>
        <Sider style={siderStyle} width={"25%"}>
          <Navigation />
        </Sider>
        <Content style={contentStyle}>
          <Outlet />
        </Content>
      </Layout>

      <Footer style={footerStyle}>Footer</Footer>
    </Layout>
  );
}
