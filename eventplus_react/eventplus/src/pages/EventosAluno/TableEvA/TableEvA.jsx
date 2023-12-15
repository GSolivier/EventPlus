import React from "react";
import comentaryIcon from "../../../assets/images/comentary-icon.svg";
import {dateFormatDbToView} from "../../../Utils/stringFunctions";
import "react-tooltip/dist/react-tooltip.css";

import "./TableEvA.css";
import Toggle from "../../../components/Toggle/Toggle";

const Table = ({ dados, fnConnect = null, fnShowModal = null }) => {
  return (
    <table className="tbal-data">
      <thead className="tbal-data__head">
        <tr className="tbal-data__head-row tbal-data__head-row--red-color">
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Evento
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Data
          </th>
          <th className="tbal-data__head-title tbal-data__head-title--big">
            Ações
          </th>
        </tr>
      </thead>
      <tbody>
        {dados.map((e) => {
          return (
            <tr className="tbal-data__head-row" key={Math.random()}>
              <td className="tbal-data__data tbal-data__data--big">
                {e.nome}
              </td>
              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                {dateFormatDbToView(e.dataEvento)}
              </td>

              <td className="tbal-data__data tbal-data__data--big tbal-data__btn-actions">
                <img
                  className="tbal-data__icon"
                  src={comentaryIcon}
                  alt=""
                  onClick={() => {fnShowModal(e.idEvento)}}
                />

                <Toggle toggleActive={e.situacao} manipulationFunction={() => {
                  fnConnect(
                    e.idEvento,
                   e.situacao ? "disconnect" : "connect",
                    e.idPresencaEvento)}} />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default Table;
