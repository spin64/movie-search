<template>
  <div class="d-flex justify-center bg-red-lighten-4 rounded-lg" >
    <v-img :src="movie.Poster" :width="250" :height="400" class="rounded-lg">
      <router-link 
        class="bg-red-lighten-4 pa-4 text-center"
        style="position: absolute; bottom: 0; left: 0; right: 0;"
        :to="'/' + movie.imdbID"
      >
        {{ movie.Title }}
      </router-link>
    </v-img>
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
  .posterImage {
    width: 250px;
    height: 375px;
  }
</style>
