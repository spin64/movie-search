<template>
  <div class="container">
    <div class="movie-card">
      <img class="posterImage" :src="movie.Poster"/>
      <router-link style="overflow-wrap: break-word;" v-bind:to="'/' + movie.imdbID">
        {{ movie.Title }}
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    movie: Object,
  }
};
</script>

<style scoped>
  .container {
    display: flex;
    align-items: center; 
    justify-content: center; 
    flex-wrap: wrap;
  }

  .movie-card {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    border-radius: 1.625rem;
    width: 250px;
    height: 350px;
    background-color: white;
    box-shadow: 4px 4px 2px 1px;
    padding: 10px;
  }

  .posterImage {
    width: 200px;
    height: 300px;
  }
</style>
