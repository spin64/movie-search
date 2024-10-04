<template>
  <v-app>
    <v-app-bar class="red" app>
      <v-btn to="/" color="white" text>
        Home
      </v-btn>
    </v-app-bar>
    <v-main class="red lighten-5">
      <router-view></router-view>
    </v-main>
  </v-app>  
</template>
