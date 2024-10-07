<template>
  <div>
    <SearchBar @search-for-movies="getAllMovies"/>
    <v-container>
      <v-row class="d-flex justify-center">
        <v-col v-for="movie in moviesOnPage(currentPage)" :key="movie.imdbID" cols="12" sm="6" md="4" lg="2" bg-red-lighten-5 >
          <MovieCard :movie="movie" />
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
        next-icon="mdi-menu-right"
        prev-icon="mdi-menu-left"
        first-icon="mdi-page-first"
        last-icon="mdi-page-last"
      />
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';
import SearchBar from '../components/SearchCard.vue';
import MovieCard from '../components/MovieCard.vue';
import movieService from '@/services/movieService.js'

export default {
  components: {
    SearchBar,
    MovieCard,
  },
  setup() {
    const currentPage = ref(1);
    const totalResults = ref(0);
    const totalPages = ref(0);
    const moviesList = ref([]);

    const getMoviesOnPage = async (searchQuery, pageNum) => {
      return movieService.getMovies(searchQuery, pageNum)
      .then((response) => {
        // response.data.Search is the array of movies
        if (response.data && response.data.Search) {
          return response.data; 
        } else {
          console.error('No movies found');
          return null;
        }
      })
      .catch((error) => {
        console.error('Error fetching data:', error.message);
        return null;
      });
    };


    const getAllMovies = async (searchQuery) => {
      moviesList.value = [];
      currentPage.value = 1;

      const firstPageData = await getMoviesOnPage(searchQuery, currentPage.value);
      if (firstPageData) {
        moviesList.value = firstPageData.Search;
        totalResults.value = firstPageData.totalResults;

        // Calculate total pages for pagination
        totalPages.value = Math.ceil(totalResults.value / 12);

        // Fetch additional pages
        const tempPages = Math.ceil(totalResults.value / 10);
        for (let page = 2; page <= tempPages; page++) {
          const nextPageData = await getMoviesOnPage(searchQuery, page);
          if (nextPageData) {
            moviesList.value = [...moviesList.value, ...nextPageData.Search];
          }
        }
      }
    };

    const moviesOnPage = (pageNum) => {
      const startIndex = (pageNum - 1) * 12;
      return moviesList.value.slice(startIndex, startIndex + 12);
    };

    return {
      currentPage,
      totalResults,
      totalPages,
      moviesList,
      getAllMovies,
      moviesOnPage,
    };
  },
};
</script>

<style scoped>
</style>
