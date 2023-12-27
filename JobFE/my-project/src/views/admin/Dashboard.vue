<template>
    <v-app>
        <side-bar :drawer="drawer"/>
        <top-bar @handleDrawer="drawer = !drawer"/>
        <v-main>
            <v-container>
                <v-layout>
                    <v-row class="clickibale">
                        <v-col cols="12" md="12">
                            <v-card class="ml-5 mr-5">
                                <v-toolbar color="teal" flat>
                                    <v-icon class="ml-3 mr-3">mdi-home</v-icon>
                                    <v-toolbar-title>Dashboard</v-toolbar-title>
                                    <v-divider
                                        class="mx-4"
                                        inset
                                        vertical
                                    ></v-divider>
                                </v-toolbar>
                                <v-container>
                                    <v-row>
                                        <v-col cols="12" sm="4" v-for="(item,index) in activities" :key="index">
                                            <v-row>
                                                <v-col>
                                                    <v-card elevation="2" class="rounded-lg">
                                                        <v-card-text class="d-flex justify-space-between align-center">
                                                            <div class="">
                                                                <strong>{{item.title}}</strong><br>
                                                                <small>Last 2 weeks</small>
                                                            </div>
                                                            <v-avatar :color="item.color" size="60">
                                                                <span class="white--text">{{item.amounts}}</span>
                                                            </v-avatar>
                                                        </v-card-text>
                                                    </v-card>
                                                </v-col>
                                            </v-row>
                                            <v-row>
                                                <v-col>
                                                    <v-card elevation="2" class="rounded-lg">
                                                        <v-card-text class="d-flex justify-space-between align-center">
                                                            <div class="">
                                                                <strong>{{item.title}}</strong><br>
                                                                <small>Last 2 weeks</small>
                                                            </div>
                                                            <v-avatar :color="item.color" size="60">
                                                                <span class="white--text">{{item.amounts}}</span>
                                                            </v-avatar>
                                                        </v-card-text>
                                                    </v-card>
                                                </v-col>
                                            </v-row>
                                        </v-col>
                                        <v-col lg="4" cols="md" class="pb-2">
                                            <v-card
                                                class="mx-auto"
                                                max-width="450"
                                            >
                                                <v-img
                                                src="https://cdn.vuetifyjs.com/images/cards/house.jpg"
                                                cover
                                                :aspect-ratio="16/9"
                                                >
                                                </v-img>
                                                <v-card-title class="flex-column align-start">
                                                <div class="text-h4 mb-2">
                                                    Welcome Home...
                                                </div>
                                                </v-card-title>
                                            </v-card>
                                        </v-col>
                                    </v-row>
                                    <v-row>
                                    <v-col>
                                        <v-card class="mx-auto">
                                            <v-card-title class="primary--text text-center">
                                                Jobs
                                            </v-card-title>
                                            <v-card>
                                                <v-table :items="jobs">
                                                    <thead>
                                                        <tr>
                                                            <th>STT</th>
                                                            <th>Ten Cong Viec</th>
                                                            <th>Image</th>
                                                            <th>Luong</th>
                                                            <th>Ngay</th>
                                                            <th>LoaiCV</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr v-for="(job,index) in jobs" :key="index">
                                                            <td>{{index+1}}</td>
                                                            <td>{{job.tenCongViec}}</td>
                                                            <td>
                                                                <v-card class="my-2" elevation="2" rounded>
                                                                    <v-img
                                                                        :src="job.avatar"
                                                                        cover
                                                                    ></v-img>
                                                                </v-card>
                                                            </td>
                                                            <td>{{job.luong}}</td>
                                                            <td>{{job.ngayDang.slice(0,10)}}</td>
                                                            <td>{{job.loaiCV}}</td>
                                                        </tr>
                                                    </tbody>
                                                </v-table>
                                        </v-card>
                                        </v-card>
                                    </v-col>
                                    </v-row>
                                </v-container>
                            </v-card>
                        </v-col>
                    </v-row>
                </v-layout>
            </v-container>
        </v-main>
    </v-app>
</template>
  
<script>
import { mapGetters } from 'vuex'
import SideBar from '../../components/SideBar.vue'
import TopBar from '../../components/TopBar.vue'
export default {
    components: { SideBar, TopBar },
    data(){
        return{
            drawer: true,
            activities:[
                {title:'Total Products', color:'red', amounts:2012},
                {title:'Total Category', color:'purple', amounts:2012},
            ],
        }
    },
    created(){
        this.$store.dispatch('loadJobs')
    },
    computed:{
        ...mapGetters(["jobs"])
    }
}
</script>