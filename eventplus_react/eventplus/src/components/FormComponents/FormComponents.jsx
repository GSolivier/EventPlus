import React from 'react';
import './FormComponents.css'

export const Input = ({
    type,
    id,
    value,
    required,
    name,
    placeholder,
    manipulationFunction,
    additionalClass = ""
}) => {
    return (
        <input  
            type={type}
            id={id} 
            name={name}
            value={value}
            required={required ? "required" : ""}
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoComplete='off' />
    );
}

export const Label = ({htmlFor, labelText}) => {
    return <label htmlFor={htmlFor}>{labelText}</label>
}

export const Button = ({
    name,
    id,
    textButton,
    type,
    additionalClass,
    manipulationFunction
}) => {
    return (
        <button
            id={id}
            name={name}
            type={type}
            className={`button-component ${additionalClass}`}
            onClick={manipulationFunction}
        >
            {textButton}
        </button>
    )
}


export const Select = ({
    required,
    id,
    name,
    options,
    manipulationFunction,
    additionalClass,
    defaultValue

}) => {
    return(
    <select
        name={name}
        id={id}
        required={required ? "required" : ""}
        className={`input-component ${additionalClass}`}
        onChange={manipulationFunction}
        value={defaultValue}
        >

            <option disabled defaultValue value={""}>Selecione</option>
            {options.map((o) => {
                return (
                    <option key={o.value} value={o.value}>{o.text}</option>
                )
            })}

    </select>)
}