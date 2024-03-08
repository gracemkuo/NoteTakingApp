<template>
  <div id="app">
    <NotesApp/>
  </div>
</template>

<script>
import NotesApp from './components/NotesApp.vue';
import './assets/style.css';

export default {
  name: 'App',
  components: {
    NotesApp
  }
};
</script>
