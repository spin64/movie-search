<template>
  <div>
    <SearchBar @search-for-movies="getMoviesOnPage"/>
    <v-container>
      <v-row class="d-flex justify-center">
        <v-col v-for="movie in moviesList" :key="movie.imdbID" cols="12" sm="6" md="4" lg="2" bg-black-lighten-5>
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
        color="black"
        next-icon="mdi-menu-right"
        prev-icon="mdi-menu-left"
        first-icon="mdi-page-first"
        last-icon="mdi-page-last"
      />
    </div>
  </div>
</template>

<script>
import { ref, watch } from 'vue';
import axios from 'axios';
import SearchBar from '../components/SearchCard.vue';
import MovieCard from '../components/MovieCard.vue';
import movieService from '@/services/movieService.js'
import logService from '@/services/logService.js'

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
    const searchQuery = ref('');

    const getMoviesOnPage = async (query, sendLog) => {
      searchQuery.value = query || searchQuery.value;
      const temp = await movieService.getMovies(searchQuery.value, currentPage.value);
      moviesList.value = temp.Search;
      totalResults.value = temp.totalResults;

      totalPages.value = Math.ceil(totalResults.value / 10);

      // dont want to send a log when we change pages
      if (sendLog){
        createLog()
      }
    };

    const createLog = async () => {
      const dataToLog = {
        id: 0,
        movieTitle: searchQuery.value,
        numOfResults: totalResults.value,
        queryDate: new Date().toISOString().toLocaleString(),
      };

      logService.addLogs(dataToLog);
    };

    // want to fetch a differnt pages' movie when pagination changes page number
    watch(currentPage, () => {
      getMoviesOnPage(searchQuery.value, false); 
    });

    return {
      currentPage,
      totalPages,
      moviesList,
      getMoviesOnPage,
      searchQuery,
    };
  },
};
</script>

<style scoped>
</style>
