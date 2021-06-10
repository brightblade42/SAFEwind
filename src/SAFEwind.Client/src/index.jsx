import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

import { App } from './bin/App.js'; //fable land

function Root () {
    return (
        <div>
            <App />
        </div>
    );
}

ReactDOM.render( <Root />, document.getElementById('safer-app'));


/*
if (import.meta.hot) {
    import.meta.hot.accept();

}
*/
