<template>
  <v-card width="400" class="pa-4 ma-5 red mx-auto">
    <v-form @submit.prevent="handleSubmit">
      <v-text-field v-model="searchQuery" color="white" label="Search For Movies..."></v-text-field>
    </v-form>
    <v-btn rounded white class="w-100 mr-2" @click="search">
      Search
    </v-btn>
  </v-card>
</template>


<script>
export default {
  data() {
    return {
      searchQuery: ''
    };
  },
  methods: {
    search() {
      this.$emit('search-for-movies', this.searchQuery);
    }
  }
};
</script>

<style scoped>

</style>
