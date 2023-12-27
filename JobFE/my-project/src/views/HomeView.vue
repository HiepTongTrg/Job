<template>
  <v-app>
    <Header/>
    <v-card>
      <v-carousel 
        hide-delimiters
        show-arrows="hover"
        cycle
      >
        <v-carousel-item
          v-for="(item,i) in items"
          :key="i"
          :src="item.src"
          reverse-transition="fade-transition"
          transition="fade-transition"
          cover
        >
          <v-row class="d-flex fill-height justify-center align-center">
            <div class="text-h2">{{ item.title }}</div>
          </v-row>
        </v-carousel-item>
      </v-carousel>
    </v-card>
    <v-container>
      <v-card>
        <v-data-iterator
          :items="jobs"
          :items-per-page="itemsPerPage"
          :search="search"
        >
          <template v-slot:header>
            <v-toolbar class="px-2">
              <v-toolbar-title>
                <h3>Các công việc phổ biến</h3>
              </v-toolbar-title>
              <v-spacer></v-spacer>
              <v-text-field
                v-model="search"
                :loading="loading"
                clearable
                density="comfortable"
                hide-details
                placeholder="Search"
                prepend-inner-icon="mdi-magnify"
                style="max-width: 500px;"
                variant="solo"
              ></v-text-field>
            </v-toolbar>
          </template>
          <template v-slot:default="{}">
            <v-container class="pa-2" fluid>
              <v-row dense>
                <v-col
                  v-for="job in searchJob"
                  :key="job.id"
                  cols="auto"
                  md="4"
                >
                  <v-card class="pb-3" border flat>
                    <v-img :src="job.avatar"></v-img>

                    <v-list-item class="mb-2" :subtitle="job.moTa">
                      <template v-slot:title>
                        <strong class="text-h6 mb-2">{{ job.tenCongViec }}</strong>
                      </template>
                    </v-list-item>

                    <div class="d-flex justify-space-between px-4">
                      <div class="d-flex align-center text-caption text-medium-emphasis me-1">
                        <v-icon icon="mdi-clock" start></v-icon>

                        <div class="text-truncate">{{ job.loaiCV }}</div>
                      </div>

                      <v-btn
                        border
                        flat
                        size="small"
                        class="text-none"
                        text="Apply"
                        :to="'/detail-job/' + job.id"
                      >
                      </v-btn>
                    </div>
                  </v-card>
                </v-col>
              </v-row>
            </v-container>
            <v-pagination 
              v-model="page"
              :length="pageCount">
            </v-pagination>
          </template>
        </v-data-iterator>
      </v-card>
    </v-container>
    <Footer/>
  </v-app>
</template>

<script>
  import Header from '@/components/Header.vue'
  import Footer from '@/components/Footer.vue'
  import { mapGetters } from 'vuex';
  export default {
    components: { Header, Footer },
    name: "Home",
    data: () => ({
      page: 1,
      search: '',
      itemsPerPage: 5,
      items: [
        {
          src: require("../assets/01.jpg"),
          title: "We are creative"
        },
        {
          src: require("../assets/02.jpg"),
          title: "We are hard worker"
        },
        {
          src: require("../assets/03.jpg"),
          title: "We are professional"
        },
      ],
    }),
    created(){
      this.$store.dispatch('loadJobs')
    },
    computed:{
      pageCount () {
            return Math.ceil(this.jobs.length / this.itemsPerPage)
        },
      ...mapGetters(["jobs"]),
      searchJob(){
        return this.jobs.filter((job) =>
          job.tenCongViec.toLowerCase().includes(this.search.toLowerCase()) ||
          job.loaiCV.toLowerCase().includes(this.search.toLowerCase())
        );
      }
    }
  }
</script>
