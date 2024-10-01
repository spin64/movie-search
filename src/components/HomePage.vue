<template>
  <div>
    <search-bar @search-for-movies="findMovies"></search-bar>
      <div class="movie-cards-container">
        <movie-card class="movie-cards" v-for="movie in moviesList" :key="movie.imdbID" v-bind:movie="movie"></movie-card>
      </div>
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
      fetch(`http://www.omdbapi.com/?s=${searchQuery}&type=movie&apikey=a5f91eae`)
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
.movie-cards-container {
  display: flex;
  align-items: flex-start; 
  justify-content: center;
  flex-wrap: wrap; 
  gap: 10px;
}
</style>
