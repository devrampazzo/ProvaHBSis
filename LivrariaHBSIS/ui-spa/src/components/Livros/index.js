import React, { Component } from 'react';
import {Table, Button, Form, FormGroup, Label, Input, Alert} from 'reactstrap';
import PubSub from 'pubsub-js';

class FormCadastroLivros extends Component {
    
    state ={
        model: {
            livroId: 0,
            isbn: 0,
            nomeLivro: '',
            nomeAutor: '',
            editora: '',
            anoLancamento: 0,
            edicao: 0,
            dataCadastro: '',
            categoriaId: 0,
            descricaoCategoria: ''
        }
    }

    setValues = (e, property) => {
        const {model} = this.state;
        model[property] = e.target.value;
        this.setState({model});
    }

    create = () => {
        this.setState({
            model: {
                livroId: 0,
                isbn: 0,
                nomeLivro: '',
                nomeAutor: '',
                editora: '',
                anoLancamento: 0,
                edicao: 0,
                dataCadastro: '',
                categoriaId: 0,
                descricaoCategoria: ''
            }
        });
        this.props.livroCreate(this.state.model);
    }

    componentWillMount(){
        PubSub.subscribe('edit-livro', (topic, livro) => {
            this.setState({model: livro});
        });
    }
    
    render() {
        const {categorias} = this.props;
        return (
            <Form>
                <FormGroup>
                    <Label for="nomeLivro">Título:</Label>
                    <Input id="nomeLivro" value={this.state.model.nomeLivro} type="text" placeholder="Nome do Livro..."
                            onChange={e => this.setValues(e, 'nomeLivro')}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="nomeAutor">Nome do Autor:</Label>
                    <Input id="nomeAutor" value={this.state.model.nomeAutor} type="text" placeholder="Nome do Autor..."
                            onChange={e => this.setValues(e, 'nomeAutor')}></Input>
                </FormGroup>
                <FormGroup>
                    <div className="form-row">
                        <div className="col-md-6">
                            <Label for="anoLancamento">Ano de Publicação:</Label>
                            <Input id="anoLancamento" value={this.state.model.anoLancamento} type="text"
                                    onChange={e => this.setValues(e, 'anoLancamento')}></Input>
                        </div>
                        <div className="col-md-6">
                            <Label for="edicao">Edição:</Label>
                            <Input id="edicao" value={this.state.model.edicao} type="text"
                                    onChange={e => this.setValues(e, 'edicao')}></Input>
                        </div>
                    </div>
                </FormGroup>
                <FormGroup>
                    <Label for="editora">Editora:</Label>
                    <Input id="editora" value={this.state.model.editora} type="text" placeholder="Editora..."
                            onChange={e => this.setValues(e, 'editora')}></Input>
                </FormGroup>
                <FormGroup>
                    <Label for="descricaoCategoria">Categoria:</Label>
                    <select value={this.state.model.categoriaId} onChange={e => this.setValues(e, 'categoriaId')}>
                        <option key="" value="">Selecione...</option>
                        {categorias.map(categoria => (
                            <option key={categoria.categoriaId} 
                                    value={categoria.categoriaId}>
                                {categoria.descricao}
                            </option>
                        ))}
                    </select>
                </FormGroup>
                <Button block color="primary" onClick={this.create}>Salvar</Button>
            </Form>
            );
    }
}

class ListLivros extends Component {

    delete = (id) => {
        this.props.deleteLivro(id);
    }

    onEdit = (livro) => {
        PubSub.publish('edit-livro', livro);
    }

    render() {
        const {livros} = this.props;
        return ( 
            <Table className="table-bordered text-center">
                <thead className="thead-dark">
                    <tr>
                        <th>Título</th>
                        <th>Autor</th>
                        <th>Ano</th>
                        <th>Edição</th>
                        <th>Editora</th>
                        <th>Categoria</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {livros.map(livro => (
                        <tr key={livro.livroId}>
                            <td>{livro.nomeLivro}</td>
                            <td>{livro.nomeAutor}</td>
                            <td>{livro.anoLancamento}</td>
                            <td>{livro.edicao}</td>
                            <td>{livro.editora}</td>
                            <td>{livro.descricaoCategoria}</td>
                            <td>
                                <Button color="info" size="sm" onClick={e => this.onEdit(livro)}>Editar</Button>
                                <Button color="danger" size="sm" onClick={e => this.delete(livro.livroId)}>Deletar</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            );
    }
}

export default class LivroBox extends Component{

    ApiUrl = 'https://localhost:44344/api/livraria/';

    state ={
        livros: [],
        categorias: [],
        message:{
            text: '',
            alert: ''
        }
    }

    componentDidMount(){
        fetch(this.ApiUrl)
        .then(response => response.json())
        .then(livros => this.setState({livros}))
        .catch(e => console.log(e));

        fetch(this.ApiUrl + 'ObterTodasAsCategorias/')
        .then(response => response.json())
        .then(categorias => this.setState({categorias}))
        .catch(e => console.log(e));
    }

    save = (livro) => {
        let data = {
            livroId: parseInt(livro.livroId),
            isbn: parseInt(livro.isbn),
            nomeLivro: livro.nomeLivro,
            nomeAutor: livro.nomeAutor,
            editora: livro.editora,
            anoLancamento: parseInt(livro.anoLancamento),
            edicao: parseInt(livro.edicao),
            dataCadastro: livro.dataCadastro,
            categoriaId: parseInt(livro.categoriaId),
            descricaoCategoria: livro.descricaoCategoria
        };
        console.log(data);
        const requestInfo ={
            method: 'POST',
            body: JSON.stringify(data),
            headers: new Headers({
                'Content-type': 'application/json'
            })
        };

        if (data.livroId === 0){
            // INSERIR
            fetch(this.ApiUrl + 'CadastrarLivro', requestInfo)
            .then(response => response.json())
            .then(novoLivro => {
                this.state.livros.push(novoLivro);
                let lista = this.state.livros;
                this.setState({livros: lista, message: {text: 'Livro cadastrado!', alert: 'success'}});
            })
            .catch(e => console.log(e));
        } else {
            // EDITAR
            fetch(this.ApiUrl + 'AlterarLivro', requestInfo)
            .then(response => response.json())
            .then(livroAlterado => {
                let posicao = this.state.livros.findIndex(livro => livro.livroId === data.livroId);
                let lista = this.state.livros;
                lista[posicao] = livroAlterado;
                this.setState({livros: lista, message: {text: 'Livro atualizado!', alert: 'info'}});
            })
            .catch(e => console.log(e));
        }
        
    }

    delete = (id) => {
        fetch(`${this.ApiUrl}RemoverLivro/${id}`, {method: 'DELETE'})
        .then(response => console.log(response))
        .then(rows => {
            let livros = this.state.livros.filter(livro => livro.livroId != id);
            this.setState({livros, message: {text: 'Livro apagado!', alert: 'danger'}});
        })
        .catch(e => console.log(e));
    }

    render(){
        return (
            <div>
                {
                    this.state.message.text !== '' ? (
                        <Alert color={this.state.message.alert} className="text-center">{this.state.message.text}</Alert>
                    ) : ''
                }
                <div className="row">
                    <div className="col-lg-4">
                        <div>
                            <h2 className="font-weight-bold text-center">Cadastro de Livros</h2>
                        </div>
                        <FormCadastroLivros 
                            categorias={this.state.categorias}
                            livroCreate={this.save} />
                    </div>
                    <div className="col-lg-8">
                        <div>
                            <h2 className="font-weight-bold text-center">Lista de Livros</h2>
                        </div>
                        <ListLivros livros={this.state.livros} deleteLivro={this.delete} />
                    </div>
                </div>
                <br />
                <div>
                    Felipe Rampazzo Farias
                </div>
            </div>
            
        );
    }
} 