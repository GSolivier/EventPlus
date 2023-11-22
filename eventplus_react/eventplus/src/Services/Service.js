import axios from "axios";

export const eventsResource = '/Evento'
export const nextEventsResource = '/Evento/ListarProximos'

export const eventsTypeResource = '/TiposEvento'

const apiPort = '7225';
const localApiUrl = `https://localhost:${apiPort}/api`

const api = axios.create({
    baseURL: localApiUrl
});

export default api