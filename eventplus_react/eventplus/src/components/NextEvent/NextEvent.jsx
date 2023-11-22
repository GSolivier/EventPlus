import React from 'react';
import './NextEvent.css'
import { Tooltip } from 'react-tooltip';

const NextEvent = ( {title, description, eventDate, idEvent} ) => {

    function conectar(idEvent){
        alert(`Chama o ${idEvent}`)
    }

    return (
        <article className='event-card'>

            <h2 className='event-card__title'>
                {title.substr(0,25)}
            </h2>

            <p  
                className='event-card__description'
                data-tooltip-id={idEvent}
                data-tooltip-content={description}
                data-tooltip-place="top"
            >

                <Tooltip id={idEvent} className="my-tooltip"/>
                {description.substr(0,15)}...
            </p>

            <p className='event-card__description'>
                {eventDate}
            </p>

            <a onClick={() => {conectar(idEvent)}} href="/" className='event-card__connect-link'>Conectar</a>

        </article>
    );
};

export default NextEvent;