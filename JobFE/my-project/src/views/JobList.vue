<template>
    <div>
      <Header/>
      <v-container>
      <br>
        <v-breadcrumbs :items="items">
          <template v-slot:prepend>
            <v-icon size="small" icon="$vuetify"></v-icon>
          </template>
        </v-breadcrumbs>
      <br>
        <v-row>
          <v-col cols="12" sm="3">
            <v-text-field
              prepend-inner-icon="mdi-magnify"
              density="compact"
              label="Search"
              single-line
              flat
              hide-details
              variant="solo-filled"
              v-model="searchQuery"
              @input="searchJobs"
            ></v-text-field>
            <v-card class="mt-5">
              <v-toolbar color="transparent" class="ml-3">Categoties
              <v-spacer></v-spacer>
              <v-btn icon="mdi-chevron-down"></v-btn>
              </v-toolbar>
              <v-divider></v-divider>
              <v-row>
                <v-col>
                  <v-checkbox
                    v-model="filters.name1"
                    label="Full-Stack"
                    hide-details
                    @change="updateFilter('name1', filters.name1)"
                  ></v-checkbox>
                  <v-checkbox
                    v-model="filters.name2"
                    label="Back-End"
                    hide-details
                    @change="updateFilter('name2', filters.name2)"
                  ></v-checkbox>
                  <v-checkbox
                    v-model="filters.name3"
                    label="Front-End"
                    hide-details
                    @change="updateFilter('name3', filters.name3)"
                  ></v-checkbox>
                </v-col>
              </v-row>
            </v-card>
            <v-card class="mt-5">
              <v-toolbar color="transparent" class="ml-3">Job Type
              <v-spacer></v-spacer>
              <v-btn icon="mdi-chevron-down"></v-btn>
              </v-toolbar>
              <v-divider></v-divider>
              <v-row>
                <v-col>
                  <v-checkbox
                    v-model="filters.type1"
                    label="Full time"
                    color="primary"
                    value="primary"
                    hide-details
                    @change="updateFilter('type1', filters.type1)"
                  ></v-checkbox>
                  <v-checkbox
                    v-model="filters.type2"
                    label="Part-Time"
                    color="orange"
                    value="orange"
                    hide-details
                    @change="updateFilter('type2', filters.type2)"
                  ></v-checkbox>
                </v-col>
              </v-row>
            </v-card>
            <v-card class="mt-5">
              <v-toolbar color="transparent" class="ml-3">Salary
              <v-spacer></v-spacer>
              <v-btn icon="mdi-chevron-down"></v-btn>
              </v-toolbar>
              <v-divider></v-divider>
              <v-row>
                <v-col>
                  <v-checkbox
                    v-model="filters.salary1"
                    label="10k - 20k"
                    hide-details
                    @change="updateFilter('salary1', filters.salary1)"
                  ></v-checkbox>
                  <v-checkbox
                    v-model="filters.salary2"
                    label="20k - 30k"
                    hide-details
                    @change="updateFilter('salary2', filters.salary2)"
                  ></v-checkbox>
                  <v-checkbox
                    v-model="filters.salary3"
                    label="40k - 50k"
                    hide-details
                    @change="updateFilter('salary3', filters.salary3)"
                  ></v-checkbox>
                </v-col>
              </v-row>
            </v-card>
          </v-col>
          <v-col cols="12" sm="9">
            <v-data-iterator
              :page="page"
              :items="filteredJobs"
              :items-per-page="itemsPerPage"
            >
              <v-row>
                <v-col cols="12" sm="4" v-for="(job,index) in filteredJobs" :key="index">
                  <v-card class="mx-auto" max-width="344">
                    <v-img :src="job.avatar" height="200px" cover></v-img>
                    <v-divider class="border-opacity-100" color="info"></v-divider>
                    <v-card-title>
                      {{ job.tenCongViec }}
                    </v-card-title>
                    <v-card-actions>
                      <v-btn prepend-icon="mdi-currency-usd">{{ job.luong }}</v-btn>
                      <v-spacer></v-spacer>
                      <v-btn size="small" color="surface-variant" variant="text" icon="mdi-briefcase-clock"></v-btn>
                      <span class="subheading">{{job.loaiCV}}</span>
                      <v-btn color="surface-variant" variant="text" icon="mdi-format-color-highlight" :to="'/detail-job/' + job.id"></v-btn>
                    </v-card-actions>
                  </v-card>
                </v-col>
              </v-row>
              <v-pagination 
                v-model="page"
                :length="pageCount">
              </v-pagination>
            </v-data-iterator>
          </v-col>
        </v-row>
      </v-container>
      <Footer/>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
import { mapActions, mapGetters, mapState } from 'vuex'
export default {
    components: { Header, Footer },
    data: () => ({
      page: 1,
      itemsPerPage: 6,
      items: [
        {
          title: 'Home',
          disabled: false,
          href: 'breadcrumbs_dashboard',
        },
        {
          title: 'List',
          disabled: false,
          href: 'breadcrumbs_link_1',
        },
      ],
      searchQuery:'',
    }),
    created(){
      this.$store.dispatch('loadJobs')
    },
    computed: {
      pageCount () {
        return Math.ceil(this.items.length / this.itemsPerPage)
      },
      ...mapState(['filters', 'filteredJobs']),
      ...mapGetters(['jobs'])
    },
    methods:{
      ...mapActions(['updateFilter']),
      searchJobs() {
        this.$store.commit('updateFilter', { filter: 'searchQuery', value: this.searchQuery });
        this.$store.commit('applyFilters');
      },
    }
}
</script>

<style>

</style>