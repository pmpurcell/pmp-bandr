import { Modal, Button } from 'reactstrap';
import { React, useState } from 'react';
import PropTypes from "prop-types";

export default function ModalDetails({user, match}) {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Launch demo modal
      </Button>
      <Modal animation={false} isOpen={show}>
        <div className="modal-details">
          <div className="col-auto">
          </div>
          <h1 className="card-title">It's a match!!!</h1>
          <p className="card-text">{user.name}</p>
          <p className="card-text">{match.userName}</p>
          <Button onClick={handleClose}> Keep Swiping </Button>
        </div>
      </Modal>
    </>
  );
}

ModalDetails.propTypes = {
  user: PropTypes.shape({}).isRequired,
  match: PropTypes.shape({}).isRequired,
};