import React from 'react';
import './TableEv.css'

import editPen from '../../../assets/images/edit-pen.svg'

import trashDelete from '../../../assets/images/trash-delete.svg'
import { dateFormatDbToViewSimple } from '../../../Utils/stringFunctions';

const TableEv = ({
  dados,
  dadostp,
  fnDelete = null,
  fnUpdate = null
}) => {

    return (
        <table className='table-data'>

             <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Nome</th>
                    <th className="table-data__head-title table-data__head-title--big">Descrição</th>
                    <th className="table-data__head-title table-data__head-title--big">Tipo de Evento</th>
                    <th className="table-data__head-title table-data__head-title--big">Data</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>

            <tbody>

      {
        dados.map((ev) => {
          return (
            <tr key={ev.idEvento} className="table-data__head-row">
            <td 
            className="table-data__data table-data__data--big">
              {ev.nome}
            </td>

            <td 
            className="table-data__data table-data__data--big"
            >
              {ev.descricao}
            </td>

            <td 
            className="table-data__data table-data__data--big"
            >
              
              {ev.tiposEvento.titulo}
              
            </td>

            <td 
            className="table-data__data table-data__data--big"
            >
              {dateFormatDbToViewSimple(ev.dataEvento)}
            </td>
  
            <td className="table-data__data table-data__data--little">
              <img className="table-data__icon" src={editPen} alt="" onClick={() => {fnUpdate(ev.idEvento)}} />
            </td>
  
            <td className="table-data__data table-data__data--little">
              <img
              idtipoevento={ev.idEvento}
              onClick={() => {
                fnDelete(ev.idEvento)
              }}
              className="table-data__icon" 
              src={trashDelete} 
              alt="" />
            </td>
          </tr>
          )
        })
      }

      </tbody>

        </table>
    );
};

export default TableEv;