<template>
  <v-app>
    <v-app-bar class="red" app>
      <v-btn color="white" text>
        <router-link to="/" class="white--text">Home</router-link>
      </v-btn>
    </v-app-bar>
    <v-main class="red lighten-5">
      <router-view></router-view>
    </v-main>
  </v-app>
</template>
