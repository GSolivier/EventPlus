import React from 'react';
import Titulo from '../Titulo/Titulo';
import './VisionSection.css'

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Titulo 
                    titleText={"Visão"}
                    color='white'
                    aditionalClass='vision__title'

                    />
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Pariatur eos magnam deleniti vero, natus molestiae earum facere assumenda sint voluptatum quos repellat nemo repellendus praesentium recusandae sunt est laudantium explicabo!</p>
            </div>
        </section>
    );
};

export default VisionSection;