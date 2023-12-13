import React, { useContext, useEffect, useState } from 'react';
import api, { eventsResource } from '../../Services/Service';
import Notification from '../../components/Notification/Notification';
import Container from '../../components/Container/Container';
import Titulo from '../../components/Titulo/Titulo';
import TableDet from './TableDet/TableDet';
import { dateFormatDbToViewSimple } from '../../Utils/stringFunctions';
import { UserContext } from '../../context/AuthContext';

const DetalhesEvento = () => {
    const [eventos, setEventos] = useState([])
    const [notifyUser, setNotifyUser] = useState({})

    const [idEvento, setIdEvento] = useState("")
    const [eventoSelecionado, setEventoSelecionado] = useState({})

    const { userData, setUserData } = useContext(UserContext);

    async function loadEvents() {
        try {
            const retorno = await api.get(eventsResource)

            setEventos(retorno.data)

        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: "Não foi possível carregar os eventos",
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })
        }
    }

    async function loadComentary(){
        try {
            if (userData != null) {
                
            }


        } catch (error) {
            
        }
    }

    useEffect(() => {
        loadEvents()
    }, [])

    async function openDetails(idEvento) {

        setIdEvento(idEvento)

        const retorno = await api.get(`${eventsResource}/${idEvento}`)
        const dados = retorno.data

        setEventoSelecionado(dados)

        console.log(eventoSelecionado);
    }

    return (
        <>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

            <section className="lista-eventos-section">
                <Container>
                    {idEvento === ""
                        ? <>
                            <Titulo titleText={"Lista de Eventos"} color='white' />
                            <TableDet
                                dados={eventos}
                                fnDetails={openDetails}
                            />
                        </>
                        :

                        <div>
                            <Titulo titleText={eventoSelecionado.nome} color='white'/>
                            <button onClick={() => setIdEvento("")}>voltar</button>
                            
                            <h1>Descrição</h1>
                            <p>{eventoSelecionado.descricao}</p>

                            <h1>Tipo do evento</h1>
                                {/* <p>{eventoSelecionado.tiposEvento.titulo}</p> */}

                            <h1>Data</h1>
                            <p>{dateFormatDbToViewSimple(eventoSelecionado.dataEvento)}</p>
                            
                        </div>

                    }

                </Container>

            </section>
        </>
    );
};

export default DetalhesEvento;