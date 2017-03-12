import React, {PropTypes} from 'react';
import AppNavigationBar from './AppNavigationBar';

class AppLayoutView extends React.Component {

    function render() {
        return(
            <div className="container-fluid">
                
                <AppNavigationBar />

                {this.props.children}
            </div>
);
    }
}

AppLayoutView.propTypes = {
    children: PropTypes.object.isRequired
};

export default AppLayoutView;

