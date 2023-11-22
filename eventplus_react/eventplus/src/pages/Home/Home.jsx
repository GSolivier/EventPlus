import React, { useEffect, useState } from 'react';
import Banner from '../../components/Banner/Banner';
import MainContent from '../../components/MainContent/MainContent';
import VisionSection from '../../components/VisionSection/VisionSection';
import ContactSection from '../../components/ContactSection/ContactSection'
import Titulo from '../../components/Titulo/Titulo';
import NextEvent from '../../components/NextEvent/NextEvent';
import Container from '../../components/Container/Container';
import {  dateFormatDbToViewSimple } from '../../Utils/stringFunctions';

import './Home.css'
import api, { nextEventsResource } from '../../Services/Service';

const Home = () => {

    const [nextEvents, setNextEvents] = useState([])

    useEffect(() => {
        async function getNextEvents(){
            try{

                const promise = await api.get(nextEventsResource);
                const dados = await promise.data

                setNextEvents(dados);
            } catch(error) {
                alert("Deu Ruim")
            }
        }

        getNextEvents();
    }, []);

    return (
        <div>
            
            <MainContent>
                <Banner/>

                <section className='proximos-eventos'>

                    <Container>

                    <Titulo titleText={"Próximos Eventos"}/>

                    <div className='events-box'>
                        
                        {
                            nextEvents.map( e => {
                                return ( 
                                <NextEvent
                                    key={e.idEvento}
                                    title={e.nome}
                                    description={e.descricao}
                                    eventDate={dateFormatDbToViewSimple(e.dataEvento)}
                                    idEvent={e.idEvento}
                                />)
                            })
                        }
  
                    </div>

                    </Container>

                </section>

            <VisionSection/>
            <ContactSection/>
            </MainContent>
            
        
        </div>

        
    );
};

export default Home;