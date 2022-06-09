import { Modal, Button } from 'reactstrap';
import { React, useState } from 'react';

function ModalDetails() {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Launch demo modal
      </Button>
      <Modal isOpen={show}>
        <div className="modal-details">
          <div className="col-auto">
          </div>
          <h1 className="card-title">Modal</h1>
          <p className="card-text">Modal</p>
          <Button onClick={handleClose}> Close Window </Button>
        </div>
      </Modal>
    </>
  );
}

export default ModalDetails;