import React from "react";

export default function EditUserForm() {
  const handleChange = (e) => {
    setFormInput((prevState) => ({
      ...prevState,
      [e.target.id]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (item.firebaseKey) {
      updateChart({
        ...formInput,
        // chartFile: fileObj,
      }).then(() => history.push("/charts"));
    } else {
      uploadFile(fileState).then((fileObj) => {
        createChart({
          ...formInput,
          uid: user.uid,
          userName: user.fullName,
          chartFile: fileObj,
        }).then(() => history.push("/charts"));
      });
    }
  };
  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="chartName" className="form-label">
            Chart Name
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.chartName || ""}
              id="chartName"
            />
          </label>
        </div>
        <div className="mb-3">
          <label htmlFor="chartDescription" className="form-label">
            Chart Description
            <input
              type="text"
              className="form-control"
              onChange={handleChange}
              value={formInput.chartDescription || ""}
              id="chartDescription"
            />
          </label>
        </div>
        <button type="submit" className="btn btn-primary">
          Submit
        </button>
      </form>
    </div>
  );
}
