import React, { useEffect, useState } from 'react';
import Titulo from '../../components/Titulo/Titulo';
import './TiposEvento.css'
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container';
import ImageIlustrator from '../../components/ImageIlustrator/ImageIlustrator';

import tipoEventoImage from '../../assets/images/tipo-evento.svg'
import { Input, Button } from '../../components/FormComponents/FormComponents'
import api, { eventsTypeResource } from '../../Services/Service'
import Table from './TableTP/Table';
import Notification from '../../components/Notification/Notification';

const TiposEvento = () => {
    const [frmEdit, setFrmEdit] = useState(false)//Estado que vai determinar qual formulário vai aparecer: false = Cadastrar, true = Atualizar
    const [titulo, setTitulo] = useState("") // Estado que armazena e altera os dados que o usuario digitar e submitar
    const [tipoEventos, setTipoEventos] = useState([]) // Estado que guarda a lista de tipos de eventos vinda da API
    const [objTipoEvento, setObjTipoEvento] = useState({})// Estado que pega o objeto buscado da API

    const [notifyUser, setNotifyUser] = useState()// estado que muda o tipo de notificação

    async function loadEventsType() {
        try {
            const retorno = await api.get(eventsTypeResource)
            setTipoEventos(retorno.data)
        } catch (error) {
            notifyFunction(
                "Erro no carregamento!",
                "Não foi possível carregar os tipos de eventos",
                "danger",
                "Imagem de danger"
            )
            console.log(error)
        }
    }

    useEffect(() => {
        loadEventsType()
    })

    function notifyFunction(titulo = "", texto = "", icon = "", alt = "") {
        setNotifyUser({
            titleNote: titulo,
            textNote: texto,
            imgIcon: icon,
            imgAlt: alt,
            showMessage: true
        })
    }

    async function handleSubmit(e) {
        e.preventDefault()

        if (titulo.trim().length < 3) {
            notifyFunction(
                "Alerta", 
                `O titulo precisa ter mais de três caracteres`, 
                "warning", 
                "Icone da ilustração")
            return;
        }

        try {
            await api.post(eventsTypeResource, {
                titulo: titulo
            })
            setTitulo('')
            loadEventsType()
            notifyFunction(
                "Cadastrado com sucesso", 
                `O tipo de evento ${titulo} foi cadastrado com sucesso!`, 
                "success", 
                "Icone da ilustração")
            window.scrollTo({ left: 0, top: document.body.scrollHeight, behavior: "smooth" });
        } catch (error) {
            alert("Deu ruim no submit" + error)
        }


    }

    async function showUpdateForm(idElemento) {
        setFrmEdit(true)

        const tipoEvento = await (await api.get(`${eventsTypeResource}/${idElemento}`)).data

        setObjTipoEvento(tipoEvento)
        setTitulo(tipoEvento.titulo)
        window.scrollTo({ top: 0, behavior: 'smooth' });
    }

    async function handleUpdate(e) {
        e.preventDefault()

        if (titulo.trim().length < 3) {
            notifyFunction(
                "Alerta", 
                `O titulo precisa ter mais de três caracteres`, 
                "warning", 
                "Icone da ilustração")
            return;
        }

        try {
            objTipoEvento.titulo = titulo
            await api.put(`${eventsTypeResource}/${objTipoEvento.idTipoEvento}`, objTipoEvento)
            setTitulo('')
            loadEventsType()
            notifyFunction(
                "Atualizado com sucesso",
                `O tipo de evento ${titulo} foi Atualizado com sucesso!`,
                "success",
                "Icone da ilustração"
            )
            window.scrollTo({ left: 0, top: document.body.scrollHeight, behavior: "smooth" });
        } catch (error) {
            console.log(error)
        }

    }

    async function handleDelete(idElemento) {
        if (window.confirm("Confirma a exclusao?")) {

            try {
                await api.delete(`${eventsTypeResource}/${idElemento}`)
                loadEventsType()
                notifyFunction(
                    "Deletado com sucesso",
                    `O tipo de evento foi deletado com sucesso!`,
                    "danger",
                    "Icone da ilustração"
                )

            } catch (error) {
                alert("Erro ao apagar o tipo de evento!")
                console.log(error)
            }

        }
    }

    return (
        <>
            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}
            <MainContent>

                <section className='cadastro-evento-section'>
                    <Container>
                        <div className='cadastro-evento__box'>
                            {frmEdit ? <Titulo titleText="Atualizar evento"/> : <Titulo titleText={"Cadastro Tipos de Evento"} />}

                            <ImageIlustrator imageResource={tipoEventoImage} />

                            <form
                                className='ftipo-evento'
                                onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >

                                {
                                    !frmEdit ?
                                        (
                                            <>
                                                <Input
                                                    id="Titulo"
                                                    placeholder="Titulo"
                                                    name="titulo"
                                                    type="text"
                                                    required="required"
                                                    value={titulo}
                                                    manipulationFunction={(e) => {
                                                        setTitulo(e.target.value)
                                                    }}
                                                />
                                                <Button
                                                    textButton={"Cadastrar"}
                                                    id="cadastrar"
                                                    name="cadastrar"
                                                    type="submit"
                                                />
                                            </>

                                        )

                                        :

                                        (

                                            <>
                                                <Input
                                                    id="Titulo"
                                                    placeholder="Titulo"
                                                    name="titulo"
                                                    type="text"
                                                    required="required"
                                                    value={titulo}
                                                    manipulationFunction={(e) => {
                                                        setTitulo(e.target.value)
                                                    }}
                                                />
                                                <Button
                                                    textButton={"Atualizar"}
                                                    id="atualizar"
                                                    name="atualizar"
                                                    type="submit"/>
                                                <Button
                                                    textButton={"Voltar"}
                                                    id="voltar"
                                                    name="voltar"
                                                    manipulationFunction={() => {
                                                        setFrmEdit(false)
                                                        setTitulo('')
                                                    }}
                                                />
                                            </>

                                        )
                                }

                            </form>


                        </div>
                    </Container>
                </section>

                <section className="lista-eventos-section">
                    <Container>
                        <Titulo titleText={"Lista Tipo de Eventos"} color='white' />


                        <Table
                            fnUpdate={showUpdateForm}
                            fnDelete={handleDelete}

                            dados={tipoEventos}
                        />
                    </Container>

                </section>

            </MainContent>
        </>
    );
};

export default TiposEvento;