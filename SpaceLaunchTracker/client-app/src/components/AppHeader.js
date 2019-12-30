import React, { Component } from 'react'; // 1
import {
    Navbar,
    NavbarBrand,
    NavbarToggler,
    Collapse,
    Nav,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem
} from 'reactstrap'; // 2
class AppHeader extends Component { // 3
    state = { // 4
        isOpen: false
    };
    toggle = this.toggle.bind(this); // 5
    toggle() { // 6
        this.setState({
            isOpen: !this.state.isOpen
        })
    }
    render() { // 7
        return <Navbar color="dark" dark expand="md">
            <NavbarBrand href="/">
                <img src="https://img.pngio.com/filespacex-logosvg-wikimedia-commons-spacex-png-1280_158.png" width="240" className="d-inline-block align-top" alt="" />
            </NavbarBrand>
            <NavbarToggler onClick={this.toggle} />
            <Collapse isOpen={this.state.isOpen} navbar>
                <Nav className="ml-auto" navbar>
                    <NavItem>
                        <NavLink href="/">Launches</NavLink>
                    </NavItem>
                    <UncontrolledDropdown nav inNavbar>
                        <DropdownToggle nav caret>
                            Dropdown
                        </DropdownToggle>
                        <DropdownMenu right>
                            <DropdownItem href="/">Test 1</DropdownItem>
                            <DropdownItem>Test 2</DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </Nav>
            </Collapse>
        </Navbar>;
    }
}
export default AppHeader; // 8