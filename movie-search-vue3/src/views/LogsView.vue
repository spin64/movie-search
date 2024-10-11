<template>
  <v-table v-if="logs" density="compact">
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
  <div v-else class="loading-container">
    <v-progress-circular 
      color="black"
      indeterminate
      model-value="128">
    </v-progress-circular>
  </div>
</template>

<script>
import logService from '@/services/logService.js'
import { ref, onMounted } from 'vue';

export default {
  setup() {
    const logs = ref([]);
      
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

    onMounted(async () => {
      logs.value = await logService.getLogs()
    });

    return {
      logs,
      formatDate
    };
  }
}
</script>
