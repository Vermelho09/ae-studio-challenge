<template>
  <div class="profile">
    <img class="logo" alt="github logo" src="../assets/github-icon.png">
    <div class="header"><b>Github Profiler</b></div>

    <div class="search-panel">
      <div>github.com/<input v-model="username" /></div>
      <div><button v-on:click="searchUser">GO</button></div>
    </div>

    <div v-if="userSearch" class="user-info">
      <div>
        <img :src=user.profilePicUrl>
      </div>
      <div>Stars: {{this.user.starsCount}}</div>
      </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'ProfileSearch',
  data () {
    return {
      username: '',
      userSearch: false,
      user: {},
      axios
    }
  },
  methods: {
    searchUser () {
      axios
        .get('https://localhost:7230/User/' + this.username)
        .then((res) => {
          this.user = res.data
          console.log(res)
          this.userSearch = true
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }
}
</script>

<style scoped>
.profile {
  width: 80%;
  margin: auto;
  background: #f3f3f3;
}

.logo {
  width: 5%;
}

.header {
  margin-top: 1%;
}

.search-panel {
  margin: 5% 0 5% 0;
  justify-content: center;
  display: inline-flex;
}

.user-info {
  padding-bottom: 5%;
}
</style>
