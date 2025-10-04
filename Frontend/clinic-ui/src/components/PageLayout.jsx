import React from 'react';
import { Menu } from 'antd';

const menuItems = [
  { key: 'Home', label: 'Home', },
  { key: 'Patients', label: 'Patients', },
  { key: 'Appointments', label: 'Appointments', },
  { key: 'Settings', label: 'Settings', },
];

export default function PageLayout({ children, activeMenu }) {
  return (
    <div className="page-layout">
      <Menu
        onClick={() => {

        }}
        selectedKeys={['Home']}
        mode="horizontal"
        items={menuItems}
      />
      <main className="content">
        {children}
      </main>
    </div>
  );
}