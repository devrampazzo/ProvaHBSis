import React, { Component } from 'react';

import Header from './components/Header';
import LivroBox from './components/Livros';

class App extends Component {
    render() {
        return (
            <div className="container">
                <Header title="HBSIS Livraria - Listagem de livros" />
                <br />
                <LivroBox />
            </div>
        );
    } 
}

export default App;
