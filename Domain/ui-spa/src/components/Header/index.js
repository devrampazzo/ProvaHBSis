import React from 'react';
import './styles.css';

const Header = ({ title }) => (
    <header>
        <img src={require('./logo.png')} alt="HBSIS logo" width="80px" height="80px" />
        <h1 className="font-weight-bold"> {title ? title : 'Livraria HBSIS'} </h1>
    </header>
);

export default Header;