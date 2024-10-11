import { createApp } from 'vue';
import { createVuetify } from 'vuetify';
import { createVueI18nAdapter } from 'vuetify/locale/adapters/vue-i18n';
import { createI18n, useI18n } from 'vue-i18n';
import App from './App.vue';
import router from './router';
import 'vuetify/styles';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';
import '@mdi/font/css/materialdesignicons.css';

import { getMessages } from './locales/languages.js'; 

const messages = getMessages();

const app = createApp(App);

const i18n = createI18n({
    legacy: false,
    locale: 'EN',
    fallbackLocale: 'EN',
    messages,
});

const vuetify = createVuetify({
    components,
    directives,
    icons: {
        iconfont: 'mdi',
    },
    locale: {
        adapter: createVueI18nAdapter({ i18n, useI18n }),
    },
});

app.use(router);
app.use(vuetify);
app.use(i18n);
app.mount('#app');
