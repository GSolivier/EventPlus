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

    const [notifyUser, setNotifyUser] = useState({})// estado que muda o tipo de notificação

    const [tipoEventos, setTipoEventos] = useState([]) // Estado que guarda a lista de tipos de eventos vinda da API

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

    function transformType(){

        const newArray = []

        tipoEventos.map((tp) => {
            
            const obj = {
                text: tp.titulo,
                value: tp.idTipoEvento
            }
            
            newArray.push(obj)
        })

        return newArray
    }

    async function loadEventsType() {
        try {
            const retorno = await api.get(eventsTypeResource)
            setTipoEventos(retorno.data)
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: "Não foi possível carregar os tipos de eventos",
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })
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
            await api.post(eventsResource, frmData)


            // document.getElementById('tipo-evento').value = 0
            loadEvents()

            setNotifyUser({
                titleNote: "Cadastrado com sucesso!",
                textNote: `O evento ${frmData.nome} foi cadastrado com sucesso`,
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })

            window.scrollTo({ left: 0, top: document.body.scrollHeight, behavior: "smooth" });

            setFrmData({
                nome: "",
                descricao: "",
                idTipoEvento: "",
                dataEvento: "",
                idInstituicao: "AFD0BD83-9773-4062-A85C-00DD26842CF1"
            })
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: "Não foi cadastrar um novo evento, tente novamente mais tarde!",
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })
            console.log(error)
        }
    }

    async function handleUpdate(e) {
        e.preventDefault()

        try {


            await api.put(`${eventsResource}/${frmData.idEvento}`, frmData)

            setNotifyUser({
                titleNote: "Atualizado com Sucesso!",
                textNote: `O evento ${frmData.nome} foi atualizado com sucesso`,
                imgIcon: "success",
                imgAlt: "imagem de sucesso",
                showMessage: true
            })

            setFrmData({
                nome: "",
                descricao: "",
                idTipoEvento: "",
                dataEvento: "",
                idInstituicao: "AFD0BD83-9773-4062-A85C-00DD26842CF1"
            })
            
            loadEvents()
            window.scrollTo({ left: 0, top: document.body.scrollHeight, behavior: "smooth" });
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: "Não foi possível atualizar o evento",
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })
            console.log(error);
        }
    }

    async function showUpdateForm(idEvento) {
        try {
            setFrmEdit(true)

            const retorno = await api.get(`${eventsResource}/${idEvento}`)

            setFrmData(retorno.data)
            window.scrollTo({ top: 0, behavior: 'smooth' });
        } catch (error) {
            setNotifyUser({
                titleNote: "Erro!",
                textNote: "Não foi possível encontrar o evento",
                imgIcon: "danger",
                imgAlt: "imagem de erro",
                showMessage: true
            })
        }
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
                <section className='cadastro-evento-section'>
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
                                                    options={transformType()}
                                                    defaultValue={frmData.idTipoEvento}
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
                                                    options={transformType()}
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


                                                <div className='button-box'>
                                                <Button
                                                    textButton={"Atualizar"}
                                                    id="atualizar"
                                                    name="atualizar"
                                                    type="submit"
                                                    additionalClass={"button-component--middle"} />
                                                <Button
                                                    textButton={"Voltar"}
                                                    id="voltar"
                                                    name="voltar"
                                                    additionalClass={"button-component--middle"}
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

                                                </div>

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