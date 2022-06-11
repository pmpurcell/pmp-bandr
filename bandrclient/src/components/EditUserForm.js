import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { updateUserInfo } from "../data/userData";

const initialState = {
    userName: "",
    firebaseUid: "",
    photo: "",
    userBio: "",
    userAge: "",
    skillLevel: "",
    location: ""
  };

export default function EditUserForm({user}) {
    const [formInput, setFormInput] = useState(initialState);

    const navigate = useNavigate();

  const handleChange = (e) => {
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  useEffect(() => {
    if (user.id) {
      setFormInput({
        id: user.id,
        userName: user.userName,
        firebaseUid: user.firebaseUid,
        photo: user.photo,
        userBio: user.userBio,
        userAge: user.userAge,
        location: user.location,
        skillLevel: user.skillLevel
      });
    }
  }, [user]);

  const handleSubmit = (e) => {
    e.preventDefault();
    console.warn(user.id);
    console.warn(formInput);
    updateUserInfo(user.id, formInput).then(() => navigate("/swipe"));
  };
  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="userName" className="form-label">
            User Name
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.userName || ""}
              id="userName"
            />
          </label>
        </div>
        <div className="mb-3">
          <label htmlFor="photo" className="form-label">
            Profile Photo
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.photo || ""}
              id="photo"
            />
          </label>
        </div>
        <div className="mb-3">
          <label htmlFor="userBio" className="form-label">
            User Bio
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.userBio || ""}
              id="userBio"
            />
          </label>
        </div>
        <div className="mb-3">
          <label htmlFor="location" className="form-label">
            Location
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.location || ""}
              id="location"
            />
          </label>
        </div>
        <div>
        <label>
          Skill Level:
          <select id="skillLevel" value={formInput.skillLevel || ""} onChange={handleChange}>
            <option value="Beginner">Beginner</option>
            <option value="Intermediate">Intermediate</option>
            <option value="Advanced">Advanced</option>
          </select>
        </label>
        </div>
        <button type="submit" className="btn btn-primary">
          Submit
        </button>
      </form>
    </div>
  );
}
