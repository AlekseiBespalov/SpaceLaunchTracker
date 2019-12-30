import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import DataTable from './DataTable';
import RegistrationModal from './form/RegistrationModal';
import { LAUNCH_API_URL } from '../constants';
class Home extends Component {
    state = {
        items: []
    }
    componentDidMount() {
        this.getItens();
    }
    getItens = () => {
        fetch(LAUNCH_API_URL)
            .then(res => res.json())
            .then(res => this.setState({ items: res }))
            .catch(err => console.log(err));
    }
    addLaunchToState = launch => {
        this.setState(previous => ({
            items: [...previous.items, launch]
        }));
    }
    updateState = (id) => {
        this.getItens();
    }
    deleteItemFromState = id => {
        const updated = this.state.items.filter(item => item.id !== id);
        this.setState({ items: updated })
    }
    render() {
        return <Container style={{ paddingTop: "50px" }}>
            <Row>
                <Col>
                    <h3>Space Launch Tracker ASP.NET Core + React</h3>
                </Col>
            </Row>
            <Row>
                <Col>
                    <DataTable
                        items={this.state.items}
                        updateState={this.updateState}
                        deleteItemFromState={this.deleteItemFromState} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <RegistrationModal isNew={true} addLaunchToState={this.addLaunchToState} />
                </Col>
            </Row>
        </Container>;
    }
}
export default Home;