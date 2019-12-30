import React, { Component, Fragment } from 'react';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';
import RegistrationForm from './RegistrationForm';
class RegistrationModal extends Component {
    state = {
        modal: false
    }
    toggle = () => {
        this.setState(previous => ({
            modal: !previous.modal
        }));
    }
    render() {
        const isNew = this.props.isNew;
        let title = 'Edit Launch';
        let button = '';
        if (isNew) {
            title = 'Add Launch';
            button = <Button
                color="success"
                onClick={this.toggle}
                style={{ minWidth: "200px" }}>Add</Button>;
        } else {
            button = <Button
                color="warning"
                onClick={this.toggle}>Edit</Button>;
        }
        return <Fragment>
            {button}
            <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                <ModalHeader toggle={this.toggle}>{title}</ModalHeader>
                <ModalBody>
                    <RegistrationForm
                        addLaunchToState={this.props.addLaunchToState}
                        updateLaunchIntoState={this.props.updateLaunchIntoState}
                        toggle={this.toggle}
                        launch={this.props.launch} />
                </ModalBody>
            </Modal>
        </Fragment>;
    }
}
export default RegistrationModal;