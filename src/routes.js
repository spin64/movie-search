import HomePage from './components/HomePage'
import MovieDetails from './components/MovieDetails'

export default [
    { path: "/", component: HomePage },
    { path: "/:id", component: MovieDetails }
]
