<template>
  <div style="display: flex; justify-content: center;">
    <input v-model="searchQuery" class="searchQueryInput" placeholder="Search for movies..." />
    <button class="searchButton" @click="search">Search</button>
  </div>
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
.searchQueryInput {
  width: 25%;
  height: 2.8rem;
  background: #f5f5f5;
  outline: none;
  border: none;
  border-radius: 1.625rem;
  padding: 0 3.5rem 0 1.5rem;
  font-size: 1rem;
}

.searchButton {
  height: 2.8rem;
  background: #ffffff;
  border-radius: 1.625rem;
  padding: 0 1.5rem 0 1.5rem;
  font-size: 1rem;
}

.searchButton:active {
  background: #A9A9A9
}
</style>
