import React, { useContext, useEffect, useState } from 'react';
import api, { commentsResource, eventsResource, onlyTrue } from '../../Services/Service';
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
    const [tipoEvento, setTipoEvento] = useState("")
    const [comentarios, setComentarios] = useState([])

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

        try {
            
            setEventoSelecionado({})
            setTipoEvento("")
            

            const retorno = await api.get(`${eventsResource}/${idEvento}`)
            const comentarios = await api.get(`${commentsResource}${onlyTrue}/${idEvento}`)
            const comentariosData = comentarios.data
            const dados = retorno.data

            console.log(comentariosData);
    
            setEventoSelecionado(dados)
            setComentarios(comentariosData)
            setTipoEvento(dados.tiposEvento.titulo)
            setIdEvento(idEvento)
        } catch (error) {
            
        }
    }

    return (
        <>
            <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

            
                
                    {idEvento === ""
                        ? <>
                        <section className="lista-eventos-section">
                        <Container>
                            <Titulo titleText={"Lista de Eventos"} color='white' />
                            <TableDet
                                dados={eventos}
                                fnDetails={openDetails}
                            />
                        </Container>
                        </section>
                        </>
                        :

                        <div>
                            <section className="lista-eventos-section">
                            <Container>
                            <Titulo titleText={eventoSelecionado.nome} color='white'/>
                            <button onClick={() => setIdEvento("")}>voltar</button>
                            
                            <h1>Descrição</h1>
                            <p>{eventoSelecionado.descricao}</p>

                            <h1>Tipo do evento</h1>
                                <p>{tipoEvento}</p>

                            <h1>Data</h1>
                            <p>{dateFormatDbToViewSimple(eventoSelecionado.dataEvento)}</p>
                            </Container>
                            </section>
                                    
                        </div>
                        

                    }

                

            
        </>
    );
};

export default DetalhesEvento;