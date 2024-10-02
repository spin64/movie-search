<template>
  <div>
    <search-bar @search-for-movies="findMovies"></search-bar>
    <v-container fluid class="ms-5">
      <v-row>
        <v-col v-for="movie in moviesList" :key="movie.imdbID" cols="12" sm="6" md="4" lg="2">
          <movie-card v-bind:movie="movie"></movie-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import SearchBar from './SearchBar.vue';
import MovieCard from './MovieCard.vue';

export default {
  components: {
    SearchBar,
    MovieCard
  },
  data() {
    return {
      moviesList: []
    };
  },
  methods: {
    async findMovies(searchQuery) {
      fetch(`http://www.omdbapi.com/?s=${searchQuery}&type=movie&apikey=${process.env.VUE_APP_API_KEY}`)
      .then(response => {
        if (!response.ok) throw new Error('Network response was not ok');
        return response.json();
      })
      .then(data => {
        if (data.Search) this.moviesList = data.Search;
        else {
          console.error('No movies found');
          this.moviesList = [];
        }
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
    }
  }
};
</script>

<style scoped>
</style>
