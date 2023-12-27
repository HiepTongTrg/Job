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
                                    <v-icon class="ml-3">mdi-account</v-icon>
                                    <v-toolbar-title>Account</v-toolbar-title>
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
                                </v-toolbar>  
                                <v-data-table 
                                    :items="jobsters" 
                                    :items-per-page="itemsPerPage" 
                                >
                                    <thead>
                                        <tr>
                                            <th>STT</th>
                                            <th>Ten Ung Vien</th>
                                            <th>Dia Chi</th>
                                            <th>Dien Thoai</th>
                                            <th>Email</th>
                                            <th>Chuc nang</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for="(jobster,index) in searchJob" :key="index">
                                            <td>{{index+1}}</td>
                                            <td>{{jobster.tenUngVien}}</td>
                                            <td>{{jobster.diaChi}}</td>
                                            <td>{{jobster.dienThoai}}</td>
                                            <td>{{jobster.email}}</td>
                                            <td>
                                                <v-btn
                                                    color="red"
                                                    size="large"
                                                    @click="dialogDelete=true"
                                                >
                                                    <v-icon>mdi-delete</v-icon>
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
                                        @click="deleteAccount"
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
import { mapGetters } from 'vuex'
import SideBar from '../../components/SideBar.vue'
import TopBar from '../../components/TopBar.vue'
export default {
    components: { SideBar, TopBar},
    data(){
        return{
            dialogDelete: false,
            drawer: true,
            search: '',
            page: 1,
            itemsPerPage: 3,
        }
    },
    created(){
        this.$store.dispatch('loadJobsters')
    },
    computed:{
        pageCount () {
            return Math.ceil(this.jobsters.length / this.itemsPerPage)
        },
        ...mapGetters(["jobsters"]),
        searchJob(){
        return this.jobsters.filter((jobster) =>
          jobster.tenUngVien.toLowerCase().includes(this.search.toLowerCase()) ||
          jobster.diaChi.toLowerCase().includes(this.search.toLowerCase()) ||
          jobster.dienThoai.toLowerCase().includes(this.search.toLowerCase()) ||
          jobster.email.toLowerCase().includes(this.search.toLowerCase()) 
        );
      }
    }
}
</script>

<style>

</style>