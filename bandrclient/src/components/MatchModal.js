// import React from 'react'
// import PropTypes from "prop-types";
// import { Modal, Button } from 'reactstrap';

// export default function MatchModal({show, onHide, user, match}) {
//   return (
//     <Modal.Dialog show>
//   <Modal.Header closeButton>
//     <Modal.Title> It's A Match!</Modal.Title>
//   </Modal.Header>

//   <Modal.Body>
//     <p>{user.name}</p>
//     <p>{match.userName}</p>
//   </Modal.Body>

//   <Modal.Footer>
//     <Button variant="secondary">Keep Swiping</Button>
//     <Button variant="primary">Go To Messages</Button>
//   </Modal.Footer>
// </Modal.Dialog>
//   )
// }

// MatchModal.propTypes = {
//     user: PropTypes.shape({
//     }).isRequired,
//     match: PropTypes.shape({
//     }).isRequired,
//     show: PropTypes.bool.isRequired,
//     onHide: PropTypes.func.isRequired
//   };