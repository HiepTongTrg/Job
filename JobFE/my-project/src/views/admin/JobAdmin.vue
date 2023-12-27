<template>
    <v-app>
        <side-bar :drawer="drawer"/>
        <top-bar @handleDrawer="drawer = !drawer"/>
        <v-main>
            <v-container>
                <v-layout>
                    <v-row class="clickibale">
                        <v-col cols="12" md="12">
                            <v-card class="ml-5 mr-5" flat color="primary">
                                <v-toolbar color="teal" flat>
                                    <v-icon class="ml-3">mdi-briefcase</v-icon>
                                    <v-toolbar-title>Job Data</v-toolbar-title>
                                    <v-divider
                                        class="mx-4"
                                        inset
                                        vertical
                                    ></v-divider>
                                    <v-text-field
                                        prepend-inner-icon="mdi-magnify"
                                        density="compact"
                                        label="Search"
                                        single-line
                                        flat
                                        hide-details
                                        variant="solo-filled"
                                        class="mr-5"
                                        v-model="search"
                                        :loading="loading"
                                    ></v-text-field>
                                    <v-btn 
                                        icon="mdi-plus" 
                                        color="yellow"
                                        dark
                                        @click="dialogAdd=true"
                                    ></v-btn>
                                </v-toolbar>  
                                <v-data-table 
                                    :items="jobs" 
                                    :items-per-page="itemsPerPage" 
                                >
                                    <thead>
                                        <tr>
                                            <th>STT</th>
                                            <th>Tên Công Việc</th>
                                            <th>Image</th>
                                            <th>Lương</th>
                                            <th>Ngày</th>
                                            <th>Thời gian</th>
                                            <th>Chức năng</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(job,index) in searchJob" :key="index">
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
                                            <td>
                                                <v-btn
                                                    icon
                                                    color="blue"
                                                    class="mr-3"
                                                    size="small"
                                                    @click="dialogEdit=true,
                                                            currentItem=job"
                                                >
                                                    <v-icon>mdi-pencil</v-icon>
                                                </v-btn>
                                                <v-btn
                                                    icon
                                                    color="red"
                                                    class="mr-3"
                                                    size="small"
                                                    @click="deleteJobId(job.id)"
                                                >
                                                    <v-icon>mdi-delete</v-icon>
                                                </v-btn>
                                                <v-btn
                                                    icon
                                                    color="yellow"
                                                    size="small"
                                                    @click="dialogView=true"
                                                >
                                                    <v-icon>mdi-eye-outline</v-icon>
                                                </v-btn>
                                            </td>
                                        </tr>
                                    </tbody>
                                    <template v-slot:bottom>
                                        <div class="text-center pt-2">
                                            <v-pagination
                                                v-model="page"
                                                :length="pageCount"
                                            ></v-pagination>
                                        </div>
                                    </template>
                                </v-data-table>
                            </v-card>
                        </v-col>
                    </v-row>
                </v-layout>
                <job-add
                    :dialogAdd="dialogAdd"
                    @close="dialogAdd=false"
                    @updateData="loadJobs"
                />
                <job-edit
                    :dialogEdit="dialogEdit"
                    :currentItem="currentItem"
                    @close="dialogEdit=false"
                    @updateData="loadJobs"
                />
                <job-view
                    :dialogView="dialogView"
                    @close="dialogView=false"
                />
                <v-dialog
                    maxWidth="450px"
                    v-model="dialogDelete"
                >
                    <v-card>
                        <v-alert type="error">
                            <v-row align="center">
                                <v-col cols="11" class="text-center">
                                    Ban co dong y xoa khong?
                                </v-col>
                            </v-row>
                            <v-row align="center">
                                <v-spacer></v-spacer>
                                <v-col cols="5">
                                    <v-btn 
                                        variant="text"
                                        @click="deleteJob(jobId).then(()=>{
                                            this.$store.dispatch('loadJobs');
                                        }),
                                        dialogDelete = false"
                                    >Dong y</v-btn>
                                </v-col>
                                <v-col cols="6">
                                    <v-btn 
                                        variant="text"
                                        @click="dialogDelete=false"
                                    >Huy bo</v-btn>
                                </v-col>
                            </v-row>
                        </v-alert>
                    </v-card>
                </v-dialog>
            </v-container>
        </v-main>
    </v-app>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import SideBar from '../../components/SideBar.vue'
import TopBar from '../../components/TopBar.vue'
import JobAdd from './JobAdd.vue'
import JobEdit from './JobEdit.vue'
import JobView from './JobView.vue'
export default {
    components: { SideBar, TopBar, JobAdd, JobEdit, JobView },
    data(){
        return{
            dialogAdd: false,
            dialogEdit: false,
            dialogDelete: false,
            dialogView: false,
            drawer: true,
            search: '',
            page: 1,
            itemsPerPage: 5,
            jobId:''
        }
    },
    created(){
        this.$store.dispatch('loadJobs')
    },
    computed:{
        pageCount () {
            return Math.ceil(this.jobs.length / this.itemsPerPage)
        },
        ...mapGetters(["jobs","token"]),
        searchJob(){
        return this.jobs.filter((job) =>
          job.tenCongViec.toLowerCase().includes(this.search.toLowerCase()) ||
          job.ngayDang.toLowerCase().includes(this.search.toLowerCase()) ||
          job.loaiCV.toLowerCase().includes(this.search.toLowerCase())
        );
      }
    },
    methods:{
        ...mapActions(["loadJobs", "deleteJob"]),
        deleteJobId(id){
            this.jobId = id;
            this.dialogDelete = true;
        }
    }
}
</script>

<style>

</style>