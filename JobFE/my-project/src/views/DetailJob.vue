<template>
  <v-app>
    <Header/>
    <v-container>
        <br><br>
        <v-breadcrumbs :items="items">
          <template v-slot:prepend>
            <v-icon size="small" icon="$vuetify"></v-icon>
          </template>
        </v-breadcrumbs>
        <br>
      <v-row class="mb-5">
        <v-col cols="12" md="8" class="mb-4 mb-lg-0">
          <div class="d-flex align-center">
            <div class="border p-2 d-inline-block mr-3 rounded">
              <v-avatar size="150" rounded="0">
                <v-img :src="job.avatar" alt="Image"></v-img>
              </v-avatar>
            </div>
            <div>
              <h1 class="headline">{{ job.tenCongViec }}</h1>
              <div class="mt-3">
                <span class="mr-3 mb-2"><v-icon class="mr-1">mdi-briefcase-variant</v-icon>Sky</span>
                <span class="mr-4 mb-2"><v-icon class="mr-1">mdi-map-marker</v-icon>Ha Noi</span>
                <span class="mb-2"><v-icon class="mr-2">mdi-card-account-phone</v-icon>081309131</span>
              </div>
            </div>
          </div>
        </v-col>
        <v-col cols="12" md="4">
          <v-row>
            <v-col cols="6">
              <v-btn class="mt-13" size="x-large" color="#2196F3" @click="dialogApply=true, item = job">Apply Now</v-btn>
            </v-col>
          </v-row>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" md="8">
          <div class="mb-5">
            <h3 class="h5 d-flex align-center mb-4 text-primary"><v-icon class="mr-2">mdi-format-align-left</v-icon>Job Description</h3>
            <p>{{ job.moTa }}</p>
          </div>
        </v-col>
        <v-col cols="12" md="4">
          <v-card class="bg-light p-3 border rounded mb-4">
            <h3 class="text-primary mt-6 h5 pl-3 mb-3 ml-5">Job Summary</h3>
            <ul class="list-unstyled pl-3 mb-0">
              <li class="mb-2 ml-5"><strong class="text-black">Published on:</strong> {{ job.ngayDang }}</li>
              <li class="mb-2 ml-5"><strong class="text-black">Employment Status:</strong> {{ job.loaiCV }}</li>
              <li class="mb-2 ml-5"><strong class="text-black">Experience:</strong> No exp</li>
              <li class="mb-2 ml-5"><strong class="text-black">Job Location:</strong> Ha Noi</li>
              <li class="mb-2 ml-5"><strong class="text-black">Salary:</strong> {{ job.luong }}</li>
              <li class="mb-8 ml-5"><strong class="text-black">Gender:</strong> Any</li>
            </ul>
          </v-card>
        </v-col>
      </v-row>
      <apply-job 
        :dialogApply="dialogApply"
        @close="dialogApply=false"
        :item="item"
      />
    </v-container>
    <Footer/>
  </v-app>
  </template>
  
  <script>
  import Header from '@/components/Header.vue'
  import Footer from '@/components/Footer.vue'
  import ApplyJob from './ApplyJob.vue'
  import { mapGetters } from 'vuex';
  export default {
    components: { Header, Footer, ApplyJob },
    data: () => ({
      dialogApply: false,
      items: [
        {
          title: 'Home',
          disabled: false,
          href: 'breadcrumbs_dashboard',
        },
        {
          title: 'Detail',
          disabled: false,
          href: 'breadcrumbs_link_1',
        },
      ],
      item:''
    }),
    created(){
      this.$store.dispatch('getJob', this.$route.params.id)  
    },
    computed:{
      ...mapGetters(['job']),
    },
    methods:{

    }
  }
  </script>