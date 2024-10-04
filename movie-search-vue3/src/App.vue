<script setup>
</script>

<template>
  <v-app>
    <v-app-bar class="bg-red" app>
      <v-btn to="/" text>
        Home
      </v-btn>
    </v-app-bar>
    <v-main class="bg-red-lighten-5">
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<style scoped>
</style>
