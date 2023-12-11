import React, { useContext, useEffect, useState } from "react";
import ImageIlustrator from "../../components/ImageIlustrator/ImageIlustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import loginImage from '../../assets/images/login.svg'
import api, { loginResource } from "../../Services/Service";

import "./Login.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  
    const [user, setUser] = useState({email: "adm@adm.com.br", senha: "admadmadm"})
    const {userData, setUserData} = useContext(UserContext)
    const navigate = useNavigate()

    useEffect(() => {
      if(userData.name) navigate("/")
    }, [userData])

  
    async function handleSubmit(e){
        e.preventDefault()

        try {
            const retorno = await api.post(loginResource, user)
            const token = retorno.data.token

            const payload = userDecodeToken(token)
            setUserData(payload)
            localStorage.setItem("token", JSON.stringify(payload))

            console.log(payload);
            console.log(userData);
          navigate("/")
        } catch (error) {
            alert("email ou senha incorretos")
        }
    }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIlustrator
            imageResource={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                 setUser({
                    ...user,
                    email: e.target.value.trim()
                 })
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({
                    ...user,
                    senha: e.target.value.trim()
                 })
              }}
              placeholder="****"
            />

            {/* <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a> */}

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
