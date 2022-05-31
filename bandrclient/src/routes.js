import React from 'react';
import { Routes, Route } from 'react-router-dom';

import React from 'react'
import UserView from './views/UserView';

export default function Routes() {
  return (
    <>
    <Routes>
        <Route path="/user/:id" element={UserView} />
        <Route path="/user/edit/:id" element={UserView} />
        <Route path="/messages" />
        <Route path="/messages/:convoId" />
        <Route path="/settings" />
    </Routes>
    </>
  )
}
