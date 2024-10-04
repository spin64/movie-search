<template>
  <div v-if="movie">
    <div style="display: flex; justify-content: center;" >
        <img :src="movie.Poster"/>
        <div class="details-box red lighten-4">
            <h1>{{movie.Title}}</h1>
            <div style="display: flex; align-items: center; gap:3px">
                <p>{{movie.Year}}</p>
                <p>•</p>
                <p>{{durationInHoursAndMinutes}}</p>
            </div>
            <p>Rated: {{movie.Rated}}</p>
            <p>Genres: {{movie.Genre}}</p>
            <p>Director: {{movie.Director}}</p>
            <p>Actors: {{movie.Actors}}</p>
            <details>
                <summary>Summary</summary>
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

export default {
  setup() {
    const route = useRoute();
    const movie = ref(null);

    const fetchMovie = async (movieId) => {
      fetch(`http://www.omdbapi.com/?i=${movieId}&apikey=${import.meta.env.VITE_API_KEY}`)
      .then(response => {
          if (!response.ok)throw new Error('Network response was not ok');
          return response.json();
      })
      .then(data => {
          if (data) movie.value = data;
          else {
            console.error('No Movie Found');
          }
      })
      .catch(error => {
          console.error('Error fetching data:', error);
      });
    }

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