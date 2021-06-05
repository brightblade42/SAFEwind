import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App.jsx';
import { AppView } from "./bin/View.js";

ReactDOM.render( <AppView />, document.getElementById('safer-app'));

/*
if (import.meta.hot) {
    import.meta.hot.accept();

}
*/
