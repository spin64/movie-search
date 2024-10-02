<template>
    <div v-if="movie">
        <div style="display: flex; justify-content: center;">
            <img :src="movie.Poster"/>
            <div class="details-box">
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
    <div v-else>
        <p>loading...</p>
    </div>
</template>

<script>
export default {
    data() {
        return {
            movieId: this.$route.params.id,
            movie: null,
        } 
    },
    created() {
        const apiKey = import.meta.env.VITE_API_KEY;
        fetch(`http://www.omdbapi.com/?i=${this.movieId}&$apikey=${apiKey}`)
        .then(response => {
            if (!response.ok)throw new Error('Network response was not ok');
            return response.json();
        })
        .then(data => {
            if (data) this.movie = data;
            else {
                console.error('No Movie Found');
                this.moviesList = [];
            }
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
    },
    computed: {
        durationInHoursAndMinutes(){
            let res = '';
            if (this.movie) {
                let mins = parseInt(this.movie.Runtime.split(' ')[0]);
                if (Math.floor(mins / 60) > 0) res += Math.floor(mins / 60) + 'h ';
                res += (mins % 60) + 'm';
            }
            return res
        }
    }
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
</style>