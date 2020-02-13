import React, { Fragment } from 'react';
class AppFooter extends React.Component {
    render() {
        return <Fragment>
            <hr className="featurette-divider" />
            <footer style={{ padding: "0 50px" }} className="navbar fixed-bottom">
                <p className="float-right"><a href="/">Back to the Top</a></p>
                <p>© 2020 Space Launch Tracker, Inc. · <a href="/">Term and Conditions</a></p>
            </footer>
        </Fragment>;
    }
}
export default AppFooter;