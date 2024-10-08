<template>
  <div v-if="movie">
    <div class="ma-4" style="display: flex; justify-content: center;" >
      <img :src="movie.Poster"/>
      <div class="details-box red lighten-4">
        <h1>{{movie.Title}}</h1>
        <div style="display: flex; align-items: center; gap:3px">
          <p>{{movie.Year}}</p>
          <p>•</p>
          <p>{{durationInHoursAndMinutes}}</p>
        </div>
        <p>{{$t('details.rated')}}: {{movie.Rated}}</p>
        <p>{{$t('details.genres')}}: {{movie.Genre}}</p>
        <p>{{$t('details.director')}}: {{movie.Director}}</p>
        <p>{{$t('details.actors')}}: {{movie.Actors}}</p>
        <details>
          <summary>{{$t('details.summary')}}</summary>
          <p>{{movie.Plot}}</p>
        </details>
      </div>
    </div>     
  </div>
  <div v-else class="loading-container">
    <v-progress-circular 
      color="red"
      indeterminate
      model-value="128">
    </v-progress-circular>
  </div>
</template>

<script>
import { ref, onMounted, computed  } from 'vue';
import { useRoute } from 'vue-router';
import movieService from '@/services/movieService.js'

export default {
  setup() {
    const route = useRoute();
    const movie = ref(null);

    const fetchMovie = async (movieId) => {
      movieService.getMoviesById(movieId)
      .then((response) => {
        movie.value = response.data;
      })
      .catch((error) => {
        console.error('Error fetching data:', error.message);
      });
    };

    onMounted(async () => {
      fetchMovie(route.params.id)
    });
   
    const durationInHoursAndMinutes = computed(() => {
      let res = '';
      if (movie.value) {
        let mins = parseInt(movie.value.Runtime.split(' ')[0]);
        if (Math.floor(mins / 60) > 0) res += Math.floor(mins / 60) + 'h ';
        res += (mins % 60) + 'm';
      }
      return res
    });
  
    return {
      movie,
      durationInHoursAndMinutes
    }
  },

}
</script>

<style scope>
  .details-box{
    background: #f5f5f5;
    padding: 10px;
    width: 30%;
    border-top-right-radius:1.625rem;
    border-bottom-right-radius:1.625rem;
  }
  .loading-container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    width: 100vw;
  }
</style>