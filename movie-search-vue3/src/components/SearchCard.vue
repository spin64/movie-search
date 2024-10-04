<template>
  <v-card width="400" class="pa-4 ma-5 bg-red mx-auto">
    <v-form>
      <v-text-field v-model="searchQuery" color="white" label="Search For Movies..." />
    </v-form>
    <v-btn rounded white class="w-100 mr-2" @click="search">
      Search
    </v-btn>
  </v-card>
</template>

<script>
import { ref } from 'vue';

export default {
  setup(props, { emit }) {
    const searchQuery = ref('');

    const search = () => {
      emit('search-for-movies', searchQuery.value);
    };

    return { searchQuery, search };
  }
};
</script>

<style scoped>
</style>
