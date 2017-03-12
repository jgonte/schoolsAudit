import  from 'babel-polyfill';
import React from 'react';
import {render} from 'react-dom';
import {Route, browserHistory} from 'react-router';
import routes from './routes';

export default render(
    <Router history={browserHistory} routes={routes} />
, document.getElementById('app'));

