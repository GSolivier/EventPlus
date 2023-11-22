import React from 'react';
import './ImageIlustrator.css'

import imageDefault from '../../assets/images/default-image.jpeg'

const ImageIlustrator = ({altText, additionalClass, imageResource}) => {
    return (




        <figure className='ilustrator-box'>
            <img src={imageResource === undefined ? imageDefault : imageResource } alt={altText} className={`ilustrator-box__image ${additionalClass}`} />
        </figure>
    );
};

export default ImageIlustrator;