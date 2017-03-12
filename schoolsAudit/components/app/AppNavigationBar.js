import React from 'react';
import {Link, IndexLink} from 'react-router';

const AppNavigationBar = () => return(
    <nav>
        
        <IndexLink to="/" activeClassName="active">School List</IndexLink>

        {" | "}
        
        <Link to="/documents" activeClassName="active">Document List</Link>

    </nav>
);

export default AppNavigationBar;

