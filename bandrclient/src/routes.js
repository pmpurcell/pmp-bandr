import React from 'react';
import { Routes, Route } from 'react-router-dom';
import UserView from './views/UserView';
import MessagesView from './views/MessagesView';
import EditView from './views/EditView';
import DirectMessageView from './views/DirectMessageView';
import SettingsView from './views/SettingsView';
import SwipeView from './views/SwipeView';

export default function Routing() {
  return (
    <>
    <Routes>
        <Route path="/" element={<SwipeView />} />
        <Route path="/user/:id" element={<UserView />} />
        <Route path="/user/edit/:id" element={<EditView />} />
        <Route path="/messages" element={<MessagesView />} />
        <Route path="/messages/:convoId" element={<DirectMessageView />} />
        <Route path="/settings" element={<SettingsView />} />
    </Routes>
    </>
  )
}
