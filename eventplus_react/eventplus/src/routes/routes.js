import React from 'react';
import { Route, BrowserRouter, Routes } from 'react-router-dom';

import Home from '../pages/Home/Home';
import Eventos from '../pages/Eventos/Eventos';
import TiposEvento from '../pages/TiposEvento/TiposEvento';


import Header from '../components/Header/Header';
import Footer from '../components/Footer/Footer';
import LoginPage from '../pages/Login/Login';
import { PrivateRoute } from './PrivateRoute';
import EventosAlunoPage from '../pages/EventosAluno/EventosAluno';
import DetalhesEvento from '../pages/DetalhesEvento/DetalhesEvento';

const Rotas = () => {
    return (
        <BrowserRouter>

            <Header />

            <Routes>
                <Route element={<Home />} path='/' exact />

                <Route
                    element={
                        <PrivateRoute redirectTo='/'>
                            <Eventos />
                        </PrivateRoute>
                    }
                    path='/eventos'
                    exact />
                <Route
                    element={
                        <PrivateRoute redirectTo='/'>
                            <EventosAlunoPage/>
                        </PrivateRoute>
                    }
                    path='/eventos-aluno'
                    exact />

                <Route
                    path='/tipos-evento'
                    element={
                        <PrivateRoute redirectTo='/'>
                            <TiposEvento />
                        </PrivateRoute>
                    }
                    exact />
                <Route element={<LoginPage />} path='/login' exact />
                <Route element={<DetalhesEvento />} path='/detalhes-evento'/>
            </Routes>

            <Footer />

        </BrowserRouter>
    );
};

export default Rotas;