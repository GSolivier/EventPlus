import React from 'react';
import { Route, BrowserRouter, Routes } from 'react-router-dom';

import Home from './pages/Home/Home';
import Eventos from './pages/Eventos/Eventos';
import TiposEvento from './pages/TiposEvento/TiposEvento';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';

const Rotas = () => {
    return (
        <BrowserRouter>

            <Header/>

            <Routes>
                <Route element={<Home/>} path='/' exact/>
                <Route element={<Eventos/>} path='/eventos' exact/>
                <Route element={<TiposEvento/>} path='/tipos-evento' exact/>
            </Routes>

            <Footer/>
            
        </BrowserRouter>
    );
};

export default Rotas;