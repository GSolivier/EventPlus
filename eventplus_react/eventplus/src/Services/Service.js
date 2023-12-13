import axios from "axios";

export const eventsResource = '/Evento'
export const nextEventsResource = '/Evento/ListarProximos'

export const eventsTypeResource = '/TiposEvento'

export const loginResource = '/Login'

export const presencasEvento = '/PresencasEvento'

export const commentsResource = '/ComentarioEvento'

const webApiUrl = `https://eventpluswebapi-guilherme.azurewebsites.net/api`

const api = axios.create({
    baseURL: webApiUrl
});

export default api