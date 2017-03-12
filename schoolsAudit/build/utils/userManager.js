import {createUserManager} from 'redux-oidc';

const userManagerConfig = {
    authority: 'http://localhost:5000',
    client_id: 'schoolsAuditWebClient',
    redirect_uri: `${window.location.protocol}//${window.location.hostname}${window.location.port ? `:${window.location.port}` : ''}/callback`,
    response_type: 'id_token token',
    scope: 'openid profile schoolsAuditApi',
    post_logout_redirect_uri: `${window.location.protocol}//${window.location.hostname}${window.location.port ? `:${window.location.port}` : ''}/login`
};

const userManager = createUserManager(userManagerConfig);

export default userManager;

