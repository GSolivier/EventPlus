import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Titulo/Titulo";
import TableEvA from "./TableEvA/TableEvA";
import Container from "../../components/Container/Container";
import { Select } from "../../components/FormComponents/FormComponents";
import Modal from "../../components/Modal/Modal";
import api, { commentsResource, eventsResource, presencasEvento } from "../../Services/Service";

import "./EventosAluno.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  const [comentario, setComentario] = useState("")
  const [novoComentario, setNovoComentario] = useState("")
  const [idComentario, setIdComentario] = useState("")

  async function loadEvents() {
    try {
        if(tipoEvento === "1"){

          const todosEventos = await api.get(eventsResource)
          const meusEventos = await api.get(`${presencasEvento}/${userData.id}`)

          const eventosMarcados = verificaPresenca(todosEventos.data, meusEventos.data)
          setEventos(eventosMarcados)

        }else{

          const retorno = await api.get(`${presencasEvento}/${userData.id}`)

          const arrEventos = []

          retorno.data.map( pr => {
              arrEventos.push({...pr.evento, situacao: true, idPresencaEvento: pr.idPresencaEvento})
          })

          setEventos(arrEventos)
        }
    } catch (error) {
        console.log(error);
    }
}

  useEffect(() => {
    loadEvents();
  }, [tipoEvento, userData.id]);

  const verificaPresenca = (arrEvents, eventsUser) => {
    for (let x = 0; x < arrEvents.length; x++) {//para cada evento principal

      for (let i = 0; i < eventsUser.length; i++) {//procurar a correspondencia em minhas presencas
        
        if (arrEvents[x].idEvento === eventsUser[i].idEvento) {
          arrEvents[x].situacao = true;
          arrEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento
          break; //para de procurar para o evento principal
        }
        
      }
            
    }
    return arrEvents
  }

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function postMyComentary(){
      const retorno = await api.post(commentsResource, {
        descricao: novoComentario,
        exibe: true,
        idUsuario: userData.id,
        idEvento: userData.idEvento
      })

      setNovoComentario('');
  }

  async function loadMyComentary(idUsuario, idEvento) {
    const retorno = await api.get(`${commentsResource}/Usuario?idUsuario=${idUsuario}&idEvento=${idEvento}`)

    setIdComentario(retorno.data.idComentarioEvento)
    console.log(retorno.data.idComentarioEvento);
    setComentario(retorno.data.descricao)
  }

  const showHideModal = (idEvent) => {
    setShowModal(showModal ? false : true);
    setUserData({...userData, idEvento: idEvent})
  };

  async function commentaryRemove(){
    const retorno = await api.delete(`${commentsResource}/${idComentario}`)

    setComentario('Comentario deletado!')
  };

  async function handleConnect(idE, whatTheFunction, presencaId = null) {
    if (whatTheFunction === "connect") {
      try {
        const obj = {
          situacao: true,
          idUsuario: userData.id,
          idEvento: idE
        }
  
        const retorno = await api.post(presencasEvento, obj)

        if (retorno.status === 201) {
          loadEvents()
        }
      } catch (error) {
          console.log(error)
      }

    } else {
      try {
        const unconnected = await api.delete(`${presencasEvento}/${presencaId}`);
  
        if (unconnected.status === 200) {
            loadEvents()
        }
      } catch (error) {
        
      }
    }
  }


  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            options={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <TableEvA
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={showHideModal}
          />
        </Container>
      </MainContent>

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
          fnGet={loadMyComentary}
          fnPost={postMyComentary}
          comentaryText={comentario}
          novoComentario={novoComentario}
          setNovoComentario={setNovoComentario}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
