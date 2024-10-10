<template>
  <v-app>
    <v-app-bar class="bg-black" app>
      <v-btn to="/" text>
        {{ $t('home') }}
      </v-btn>
      <v-btn to="/Logs" text>
        {{ $t('logs') }}
      </v-btn>
      <v-spacer></v-spacer>
      <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn
            color="white"
            v-bind="props"
          >
            {{ $t('abbreviation') }}
          </v-btn>
        </template>
        <v-list>
          <v-list-item
            v-for="(language, index) in languages"
            :key="index"
            :value="index"
          >
            <v-list-item-title @click="changeLocale(language.locale)">{{ language.name }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
    <v-main class="bg-black-lighten-5">
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script setup>
import { useI18n } from 'vue-i18n';
import { languages } from './locales/languages.js'; 
import { onMounted } from 'vue';

const { locale } = useI18n();

onMounted(() => {
    locale.value = 'EN'
  });

function changeLocale(newLocale) {
  locale.value = newLocale; 
}
</script>

<style scoped>
</style>
