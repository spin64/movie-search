<template>
    <v-table density="compact">
    <thead>
      <tr>
        <th class="text-left">
          id
        </th>
        <th class="text-left">
          Movie Title
        </th>
        <th class="text-left">
          Date Searched
        </th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="log in logs" :key="log.id"
      >
        <td>{{ log.id }}</td>
        <td>{{ log.movieTitle }}</td>
        <td>{{ formatDate(log.queryDate) }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script>
import axios from 'axios';
import { ref, onMounted } from 'vue';

export default {
    setup() {
        const logs = ref([]);
        
        const fetchLogs = async () => {
            try {
                const response = await axios.get(import.meta.env.VITE_DB_GET_API, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                });
                console.log('Response:', response.data);
                logs.value = [...logs.value, ...response.data];
            } catch (error) {
                console.error('Error:', error);
            }
        };

        const formatDate = (timestamp) => {
            const date = new Date(timestamp);
            const timeString = date.toLocaleTimeString('en-US', {
                hour: '2-digit',
                minute: '2-digit',
                second: '2-digit',
                hour12: true
            });
           
            return date.getUTCDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear()  + " " + timeString;
        };

        onMounted(() => {
            fetchLogs();
        });

        return {
            logs,
            formatDate
        };
    }
}
</script>
