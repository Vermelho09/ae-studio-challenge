<template>
  <ProfileSearch />
</template>

<script>
import ProfileSearch from './components/ProfileSearch.vue'

export default {
  name: 'App',
  components: {
    ProfileSearch
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
