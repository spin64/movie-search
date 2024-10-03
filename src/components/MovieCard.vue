<template>
  <v-card elevation="2" outlined max-width="250px">
    <v-img :src="movie.Poster" class="posterImage">
      <router-link 
        class="red lighten-5 pa-4 text-center"
        style="position: absolute; bottom: 0; left: 0; right: 0;"
        :to="'/' + movie.imdbID"
      >
        {{ movie.Title }}
      </router-link>
    </v-img>
  </v-card>
</template>

<script>
export default {
  props: {
    movie: Object,
  }
};
</script>

<style scoped>
  .posterImage {
    width: 250px;
    height: 450px;
  }
</style>
