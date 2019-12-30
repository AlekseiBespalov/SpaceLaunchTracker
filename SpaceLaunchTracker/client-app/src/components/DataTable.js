import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { LAUNCH_API_URL } from '../constants';
class DataTable extends Component {
    deleteItem = id => {
        let confirmDeletion = window.confirm('Do you really wish to delete it?');
        if (confirmDeletion) {
            fetch(`${LAUNCH_API_URL}/${id}`, {
                method: 'delete',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(res => {
                    this.props.deleteItemFromState(id);
                })
                .catch(err => console.log(err));
        }
    }
    render() {
        const items = this.props.items;
        return <Table striped>
            <thead className="thead-dark">
                <tr>
                    <th>Mission Name</th>
                    <th>Launch Number</th>
                    <th>Launch Date</th>
                    <th>Launch Site</th>
                    <th>Rocket Name</th>
                    <th>Mission Details</th>
                    <th>Changed Time</th>
                </tr>
            </thead>
            <tbody>
                {!items || items.length <= 0 ?
                    <tr>
                        <td colSpan="7" align="center"><b>No upcoming launches</b></td>
                    </tr>
                    : items.map(item => (
                        <tr key={item.id}>
                            <td>
                                {item.missionName}
                            </td>
                            <td>
                                {item.launchNumber}
                            </td>
                            <td>
                                {item.launchDate}
                            </td>
                            <td>
                                {item.launchSite}
                            </td>
                            <td>
                                {item.rocketName}
                            </td>
                            <td>
                                {item.missionDetails}
                            </td>
                            <td>
                                {item.changedTime}
                            </td>
                        </tr>
                    ))}
            </tbody>
        </Table>;
    }
}
export default DataTable;