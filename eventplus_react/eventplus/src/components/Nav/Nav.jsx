import React, { useContext } from 'react';
import './Nav.css'

import logMobile from '../../assets/images/logo-white.svg'
import logDesktop from '../../assets/images/logo-pink.svg'
import { Link } from 'react-router-dom';
import { UserContext } from '../../context/AuthContext';

const Nav = ({ exibeNavbar, setExibeNavbar }) => {

    const { userData } = useContext(UserContext)

    return (
        <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
            <span onClick={() => { setExibeNavbar(false) }}
                className='navbar__close'>x</span>

            <Link to={"/"} className='eventlogo'>
                <img className='eventlogo__logo-image'
                    src={window.innerWidth >= 992 ? logDesktop : logMobile}
                    alt="" />
            </Link>

            <div className='navbar__items-box'>

                <Link className='navbar__item' to={"/"}>Home</Link>
                <Link className='navbar__item' to={"/detalhes-evento"}>Detalhes do evento</Link>

                {
                    userData.name && userData.role === 'Administrador' ? (
                        <>
                            <Link className='navbar__item' to={"/tipos-evento"}>Tipos de Evento</Link>
                            <Link className='navbar__item' to={"/eventos"}>Eventos</Link>
                        </>
                    ) : (

                        userData.name && userData.role === 'Aluno' ?
                        (
                        <>
                        <Link className='navbar__item' to={"/eventos-aluno"}>Eventos</Link>
                        </>
                        )
                        :
                        (null)
                    )
                }



            </div>



        </nav>
    );
};

export default Nav;