import React from 'react';
import {Provider} from 'react-redux';
import Routes from '../routes';
import store from '../store';
import userManager from '../utils/userManager';
import {OidcProvider} from 'redux-oidc';

export default function App(props) {
    return(
    <Provider store={store}>
        <OidcProvider store={store} userManager={userManager}>
            <div>
                <Routes />
            </div>
        </OidcProvider>
    </Provider>
);
};

