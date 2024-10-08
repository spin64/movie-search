import { en, fr } from 'vuetify/locale';
import EN from './EN.json';
import FR from './FR.json';

export const languages = [
    { locale: 'EN', name: 'English', vuetify: en, translations: EN },
    { locale: 'FR', name: 'Français', vuetify: fr, translations: FR },
];

export const getMessages = () => {
    return languages.reduce((acc, { locale, translations, vuetify }) => {
        acc[locale] = { ...translations, ...vuetify };
        return acc;
    }, {});
};
