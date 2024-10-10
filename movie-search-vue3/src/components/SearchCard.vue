<template>
  <v-card width="400" class="pa-4 ma-5 bg-black mx-auto">
    <v-form @submit.prevent="search">
      <v-text-field 
        v-model="searchQuery" 
        color="white" 
        :label="$t('searchFor')"  
        @keydown.enter="search"/>
    </v-form>
    <v-btn rounded white class="w-100 mr-2" @click="search">
      {{ $t('search') }}
    </v-btn>
  </v-card>
</template>

<script>
import { ref } from 'vue';

export default {
  setup(props, { emit }) {
    const searchQuery = ref('');

    const search = () => {
      emit('search-for-movies', searchQuery.value, true);
    };

    return { 
      searchQuery, 
      search 
    };
  }
};
</script>

<style scoped>
</style>
