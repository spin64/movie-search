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
        <th class="text-left">
          Search Results
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
        <td>{{ log.numOfResults }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script>
import logService from '@/services/logService.js'
import { ref, onMounted } from 'vue';

export default {
  setup() {
    const logs = ref([]);
      
    const fetchLogs = async () => {
      const tempLogs = await logService.getLogs()
      logs.value = tempLogs
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
