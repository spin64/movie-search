<template>
  <div>
    <search-bar @search-for-movies="getAllMovies"></search-bar>
    <v-container>
      <v-row class="ms-5 justify-center">
        <v-col v-for="movie in moviesOnPage(currentPage)" :key="movie.imdbID" cols="12" sm="6" md="4" lg="2">
          <movie-card :movie="movie"/>
        </v-col>
      </v-row>
    </v-container>
    <div v-if="moviesList.length > 0" class="text-center">
      <v-pagination
        v-model="currentPage"
        :length="totalPages"
        :total-visible="5"
        class="pa-4"  
        color="red"
      />
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
      currentPage: 1,
      totalResults: 0,
      totalPages: 0,
      moviesList: []
    };
  },
  methods: {
    async getAllMovies(searchQuery) {
      this.moviesList = [];
      this.currentPage = 1;

      const firstPageData = await this.getMoviesPerPage(searchQuery, this.currentPage);

      if (firstPageData){
        this.moviesList = firstPageData.Search;
        this.totalResults = firstPageData.totalResults;

        //this is for pageination
        this.totalPages = Math.ceil(this.totalResults / 12);
        //this is getting all of the movies
        this.tempPages = Math.ceil(this.totalResults / 10);

        for (let page = 2; page <= this.tempPages; page++) {
          const nextPageData = await this.getMoviesPerPage(searchQuery, page);
          if (nextPageData) {
            this.moviesList = [...this.moviesList, ...nextPageData.Search]
          }
        }
      }
    },
    async getMoviesPerPage(searchQuery, pageNum) {
      try {
        const response = await fetch(`http://www.omdbapi.com/?s=${searchQuery}&type=movie&apikey=${process.env.VUE_APP_API_KEY}&page=${pageNum}`);

        if (!response.ok) throw new Error('Network response was not ok');

        const data = await response.json();

        if (data) {
          return data;
        } else {
          console.error('No movies found');
          return [];
        }
      } catch (error) {
        console.error('Error fetching data:', error);
        return [];
      }
    },
    moviesOnPage(pageNum){
      const startIndex = (pageNum-1)*12;
      return this.moviesList.slice(startIndex, startIndex+12)
    }
  },
};
</script>

<style scoped>
</style>
