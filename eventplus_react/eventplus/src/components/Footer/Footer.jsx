import React from 'react';
import './Footer.css'

const Footer = ({textRights = "Escola Senai de Informática - 2023"}) => {
    return (
        <footer className='footerPage'>
            <p className='footerPage__rights'>
                {textRights}
            </p>
        </footer>
    );
};

export default Footer;