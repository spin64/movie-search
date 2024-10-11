import axios from "axios";

const getUrl = import.meta.env.VITE_DB_GET_API;
const postUrl = import.meta.env.VITE_DB_POST_API;

const apiClient = axios.create();

export default {
  async getLogs() {
    return apiClient.get(getUrl)
    .then((response) => {
      if (response.data) {
        return response.data; 
      } else {
        console.error('No logs found');
        return null
      }
    })
    .catch((error) => {
      console.error('Error fetching data:', error.message);
    });
  },
  async addLogs(logData) { 
    return apiClient.post(postUrl, logData)
    .then(function (response) {
      console.log(response);
    })
    .catch(function (error) {
      console.log(error);
    });
  },
};
