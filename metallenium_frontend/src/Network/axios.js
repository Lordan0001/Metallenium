import axios from 'axios';
import Cookies from 'js-cookie'; // Импортируйте библиотеку для работы с куками

const instance = axios.create({
    baseURL: 'https://localhost:7007/api',
    // withCredentials: true,
    // crossDomain: true,
});
instance.interceptors.request.use((config) => {
    const token = Cookies.get('jwt'); // Получаем токен из куки

    if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
}, (error) => {
    return Promise.reject(error);
});

export default instance;
