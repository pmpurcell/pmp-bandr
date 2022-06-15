import React from "react";
import {
    AiOutlineUser,
    AiOutlineSearch,
    AiOutlineMessage,
    AiOutlineSetting,
  } from "react-icons/ai";

export default function FooterNavbar() {
  return (
    <footer id="FooterNavbar">
      <AiOutlineUser className="nav-item" style={{ fontSize: "50px" }}
      onClick={() => {console.warn("User Profile")}}/>
      <AiOutlineSearch className="nav-item"  style={{ fontSize: "50px" }}
      onClick={() => {console.warn("Swipe View")}} />
      <AiOutlineMessage className="nav-item"  style={{ fontSize: "50px" }}
      onClick={() => {console.warn("Messages")}} />
      <AiOutlineSetting className="nav-item"  style={{ fontSize: "50px" }}
      onClick={() => {console.warn("Settings")}} />
    </footer>
  );
}
