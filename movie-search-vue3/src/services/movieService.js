import axios from "axios";
const apiKey = import.meta.env.VITE_API_KEY;
const url = import.meta.env.VITE_BASE_URL;


const apiClient = axios.create({
    baseURL: url,
});

export default {
    getMoviesById(movieId) {
        return apiClient.get('', {
            params: {
                i: movieId,
                apikey: apiKey,
            },
        })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.error('Error fetching data:', error.message);
        });
    },
    getMovies(searchQuery,pageNum) {
        return apiClient.get('', {
            params: {
                s: searchQuery,
                type: 'movie',
                apikey: apiKey,
                page: pageNum
            },
        })
        .then((response) => {
            if (response.data && response.data.Search) {
                return response.data; 
            } else {
                console.error('No movies found');
                return null;
            }
        })
        .catch((error) => {
            console.error('Error fetching data:', error.message);
            return null;
        });
    },
}
