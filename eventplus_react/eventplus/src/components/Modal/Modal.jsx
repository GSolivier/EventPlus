import React, { useContext, useEffect } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../../components/FormComponents/FormComponents"
import "./Modal.css";
import { UserContext } from "../../context/AuthContext";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Não informado.",
  userId = null,
  showHideModal = false,
  fnDelete = null,
  fnPost = null,
  fnGet = null,
  novoComentario,
  setNovoComentario
}) => {

  const {userData} = useContext(UserContext)

  useEffect(() => {

    async function pegarDados(){
    await fnGet(userData.id, userData.idEvento)
    }

    pegarDados();
  }, [novoComentario])

  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={() => showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={() => {fnDelete()}}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          additionalClass="comentary__entry"
          value={novoComentario}
          manipulationFunction={(e) => {
            setNovoComentario(e.target.value)
          }}
        />

        <Button
          textButton="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={() => {fnPost()}}
        />
      </article>
    </div>
  );
};

export default Modal;
