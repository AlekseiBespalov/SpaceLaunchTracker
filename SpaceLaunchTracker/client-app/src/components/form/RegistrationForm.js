import React from 'react';
import { Button, Form, FormGroup, Input, Label } from 'reactstrap';
import { LAUNCH_API_URL } from '../../constants';
class RegistrationForm extends React.Component {
    state = {
        id: 0,
        missionName: '',
        launchNumber: '',
        launchDate: '',
        launchSite: '',
        rocketName: '',
        missionDetails: '',
        infoUrl: '',
        changedTime: ''
    }
    componentDidMount() {
        if (this.props.launch) {
            const { id, missionName, launchNumber, launchDate, launchSite, rocketName, missionDetails, infoUrl, changedTime } = this.props.launch
            this.setState({ id, missionName, launchNumber, launchDate, launchSite, rocketName, missionDetails, infoUrl, changedTime });
        }
    }
    onChange = e => {
        this.setState({ [e.target.name]: e.target.value })
    }

    submitNew = e => {
        e.preventDefault();
        fetch(`${LAUNCH_API_URL}`, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                missionName: this.state.missionName,
                launchNumber: this.state.launchNumber,
                launchDate: this.state.launchDate,
                launchSite: this.state.launchSite,
                rocketName: this.state.rocketName,
                missionDetails: this.state.missionDetails,
                infoUrl: this.state.infoUrl,
                changedTime: this.state.changedTime
            })
        })
            .then(res => res.json())
            .then(launch => {
                this.props.addLaunchToState(launch);
                this.props.toggle();
            })
            .catch(err => console.log(err));
    }
    submitEdit = e => {
        e.preventDefault();
        fetch(`${LAUNCH_API_URL}/${this.state.id}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                missionName: this.state.missionName,
                launchNumber: this.state.launchNumber,
                launchDate: this.state.launchDate,
                launchSite: this.state.launchSite,
                rocketName: this.state.rocketName,
                missionDetails: this.state.missionDetails,
                infoUrl: this.state.infoUrl,
                changedTime: this.state.changedTime
            })
        })
            .then(() => {
                this.props.toggle();
                this.props.updateLaunchIntoState(this.state.id);
            })
            .catch(err => console.log(err));
    }
    render() {
        return <Form onSubmit={this.props.launch ? this.submitEdit : this.submitNew}>
            <FormGroup>
                <Label for="missionNamme">Mission Name:</Label>
                <Input type="text" name="missionName" onChange={this.onChange} value={this.state.missionName === '' ? '' : this.state.missionName} />
            </FormGroup>
            <FormGroup>
                <Label for="launchNumber">Launch Number:</Label>
                <Input type="text" name="launchNumber" onChange={this.onChange} value={this.state.launchNumber === null ? '' : this.state.launchNumber} />
            </FormGroup>
            <FormGroup>
                <Label for="launchDate">Launch Date:</Label>
                <Input type="datetime" name="launchDate" onChange={this.onChange} value={this.state.launchDate === null ? '' : this.state.launchDate} />
            </FormGroup>
            <FormGroup>
                <Label for="launchSite">Launch Site:</Label>
                <Input type="text" name="launchSite" onChange={this.onChange} value={this.state.launchSite === null ? '' : this.state.launchSite} />
            </FormGroup>
            <FormGroup>
                <Label for="rocketName">Rocket Name:</Label>
                <Input type="text" name="rocketName" onChange={this.onChange} value={this.state.rocketName === null ? '' : this.state.rocketName} />
            </FormGroup>
            <FormGroup>
                <Label for="missionDetails">Mission Details:</Label>
                <Input type="text" name="missionDetails" onChange={this.onChange} value={this.state.missionDetails === null ? '' : this.state.missionDetails} />
            </FormGroup>
            <FormGroup>
                <Label for="infoUrl">Info URL:</Label>
                <Input type="text" name="infoUrl" onChange={this.onChange} value={this.state.infoUrl === null ? '' : this.state.infoUrl} />
            </FormGroup>
            <FormGroup>
                <Label for="changedTime">Changed Time:</Label>
                <Input type="datetime" name="changedTime" onChange={this.onChange} value={this.state.changedTime === null ? '' : this.state.changedTime} />
            </FormGroup>
            <Button>Send</Button>
        </Form>;
    }
}
export default RegistrationForm;