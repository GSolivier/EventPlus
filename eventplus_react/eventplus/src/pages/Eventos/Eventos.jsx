import React, { useEffect, useState } from 'react';
import Titulo from '../../components/Titulo/Titulo';
import Notification from '../../components/Notification/Notification';
import MainContent from '../../components/MainContent/MainContent';
import Container from '../../components/Container/Container';
import ImageIlustrator from '../../components/ImageIlustrator/ImageIlustrator';

import eventoImage from '../../assets/images/evento.svg'
import { Button, Input, Select } from '../../components/FormComponents/FormComponents';
import TableEv from './TableEv/TableEv';
import api, { eventsResource, eventsTypeResource } from '../../Services/Service';

import './Eventos.css'
import { dateFormatDbToViewBack } from '../../Utils/stringFunctions';

const Eventos = () => {
    const [eventos, setEventos] = useState([])
    const [frmEdit, setFrmEdit] = useState(false)//Estado que vai determinar qual formulário vai aparecer: false = Cadastrar, true = Atualizar
    const [frmData, setFrmData] = useState({
        nome: "",
        descricao: "",
        idTipoEvento: "",
        dataEvento: "",
        idInstituicao: "AFD0BD83-9773-4062-A85C-00DD26842CF1"
    })

    const [objEvento, setObjEvento] = useState({})
    const [notifyUser, setNotifyUser] = useState()// estado que muda o tipo de notificação

    const [tipoEventos, setTipoEventos] = useState([]) // Estado que guarda a lista de tipos de eventos vinda da API

    async function loadEvents() {
        try {
            const retorno = await api.get(eventsResource)

            setEventos(retorno.data)
            console.log(retorno.data)

        } catch (error) {
            console.log(error)
        }
    }

    async function loadEventsType() {
        try {
            const retorno = await api.get(eventsTypeResource)
            setTipoEventos(retorno.data)
        } catch (error) {
            console.log(error)
        }
    }

    useEffect(() => {
        loadEvents()
        loadEventsType()
    }, [])

    async function handleSubmit(e) {
        e.preventDefault()

        try {
            console.log(frmData)
            await api.post(eventsResource, frmData)
            setFrmData({})
            loadEvents()
        } catch (error) {
            console.log(error)
        }
    }

    async function handleUpdate(e) {
        e.preventDefault()

        try {
            objEvento.nome = frmData.nome
            objEvento.descricao = frmData.descricao
            objEvento.idTipoEvento = frmData.idTipoEvento
            objEvento.dataEvento = frmData.dataEvento
            objEvento.idInstituicao = "AFD0BD83-9773-4062-A85C-00DD26842CF1"

            await api.put(`${eventsResource}/${objEvento.idEvento}`, objEvento)
            setFrmData({
                nome: "",
                descricao: "",
                idTipoEvento: "",
                dataEvento: "",
                idInstituicao: "AFD0BD83-9773-4062-A85C-00DD26842CF1"
            })
            loadEvents()
        } catch (error) {
            
        }
    }

    async function showUpdateForm(idEvento) {
        setFrmEdit(true)

        const retorno = await api.get(`${eventsResource}/${idEvento}`)

        setFrmData(retorno.data)
        setObjEvento(retorno.data)
    }

    async function handleDelete(idEvento) {
        try {
            await api.delete(`${eventsResource}/${idEvento}`)
            loadEvents()
        } catch (error) {
            
        }
    }

    return (
        <>
            {<Notification {...notifyUser} setNotifyUser={setNotifyUser} />}

            <MainContent>
                <section>
                    <Container>
                        <div className='cadastro-evento__box'>
                            {frmEdit ? <Titulo titleText="Atualizar evento" /> : <Titulo titleText={"Cadastrar Evento"} />}

                            <ImageIlustrator imageResource={eventoImage} />

                            <form
                                className='ftipo-evento'
                                onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >

                                {
                                    !frmEdit ?
                                        (
                                            <>
                                                <Input
                                                    id="Nome"
                                                    placeholder="Nome"
                                                    name="Nome"
                                                    type="text"
                                                    required="required"
                                                    value={frmData.nome}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            nome: e.target.value
                                                        })
                                                    }}
                                                />

                                                <Input
                                                    id="Descricao"
                                                    placeholder="Descrição"
                                                    name="descricao"
                                                    type="text"
                                                    required="required"
                                                    value={frmData.descricao}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            descricao: e.target.value
                                                        })
                                                    }}
                                                />

                                                <Select
                                                    id="tipo-evento"
                                                    name="tipo-evento"
                                                    required="required"
                                                    options={tipoEventos}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            idTipoEvento: e.target.value
                                                        })
                                                    }}
                                                
                                                />

                                                <Input
                                                    id="dataEvento"
                                                    placeholder="dd/mm/aaaa"
                                                    name="dataEvento"
                                                    type="date"
                                                    required="required"
                                                    value={frmData.dataEvento}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            dataEvento: e.target.value
                                                        })
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
                                                    id="Nome"
                                                    placeholder="Nome"
                                                    name="Nome"
                                                    type="text"
                                                    required="required"
                                                    value={frmData.nome}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            nome: e.target.value
                                                        })
                                                    }}
                                                />

                                                <Input
                                                    id="Descricao"
                                                    placeholder="Descrição"
                                                    name="descricao"
                                                    type="text"
                                                    required="required"
                                                    value={frmData.descricao}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            descricao: e.target.value
                                                        })
                                                    }}
                                                />

                                                <Select
                                                    id="tipo-evento"
                                                    name="tipo-evento"
                                                    required="required"
                                                    options={tipoEventos}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            idTipoEvento: e.target.value
                                                        })
                                                    }}
                                                    defaultValue={frmData.idTipoEvento}
                                                />

                                                <Input
                                                    id="dataEvento"
                                                    placeholder="dd/mm/aaaa"
                                                    name="dataEvento"
                                                    type="date"
                                                    required="required"
                                                    value={dateFormatDbToViewBack(frmData.dataEvento)}
                                                    manipulationFunction={(e) => {
                                                        setFrmData({
                                                            ...frmData,
                                                            dataEvento: e.target.value
                                                        })
                                                    }}
                                                />
                                                <Button
                                                    textButton={"Atualizar"}
                                                    id="atualizar"
                                                    name="atualizar"
                                                    type="submit" />
                                                <Button
                                                    textButton={"Voltar"}
                                                    id="voltar"
                                                    name="voltar"
                                                    manipulationFunction={() => {
                                                        setFrmEdit(false)
                                                        setFrmData({
                                                            nome: "",
                                                            descricao: "",
                                                            idTipoEvento: "",
                                                            dataEvento: "",
                                                            idInstituicao: "AFD0BD83-9773-4062-A85C-00DD26842CF1"
                                                        })
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
                        <Titulo titleText={"Lista de Eventos"} color='white' />


                        <TableEv
                            fnUpdate={showUpdateForm}
                            fnDelete={handleDelete}

                            dados={eventos}
                            dadostp={tipoEventos}
                        />
                    </Container>

                </section>
            </MainContent>
        </>
    );
};

export default Eventos;