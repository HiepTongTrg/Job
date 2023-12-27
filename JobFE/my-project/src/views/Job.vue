<template>
    <div>
      <Header/>
      <v-container>
        <br>
        <v-breadcrumbs :items="links">
          <template v-slot:prepend>
            <v-icon size="small" icon="$vuetify"></v-icon>
          </template>
        </v-breadcrumbs>
        <br>
            <v-toolbar color="primary" flat>
                <v-icon class="ml-3">mdi-briefcase</v-icon>
                <v-toolbar-title>Job</v-toolbar-title>
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
                ></v-text-field>
            </v-toolbar>
            <v-data-table 
              :items="items" 
              :page="page"
              :headers="headers"
              :items-per-page="itemsPerPage"
            >
              <template v-slot:item.actions="{ items }">
                <v-icon
                  size="large"
                  @click="dialogDelete = true"
                >
                  mdi-delete
                </v-icon>
              </template>
              <template v-slot:bottom>
                <div class="text-center pt-2">
                  <v-pagination
                    v-model="page"
                    :length="pageCount"
                  ></v-pagination>
                </div>
              </template>
          </v-data-table>
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
                      @click="deleteCategory"
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
        <Footer/>
    </div>
  </template>
  
  <script>
  import Header from '@/components/Header.vue'
  import Footer from '@/components/Footer.vue'
  export default {
      components: { Header, Footer },
      data: () => ({
        dialogDelete: false,
        page: 1,
        itemsPerPage: 3,
        headers: [
          { sortable: false, title: 'TenCV', key: 'name' },
          { sortable: false, title: 'TenCT', key: 'company' },
          { sortable: false, title: 'DC', key: 'address' },
          { sortable: false, title: 'DT', key: 'phone' },
          { sortable: false, title: 'Email', key: 'email' },
          { sortable: false, title: 'LoaiCV', key: 'time' },
          { sortable: false, title: 'Trang thai', key: 'status' },
          { sortable: false, title: 'Chuc nang', key: 'actions' },
        ],
        links: [
            {
            title: 'Home',
            disabled: false,
            href: 'breadcrumbs_dashboard',
            },
            {
            title: 'Job',
            disabled: false,
            href: 'breadcrumbs_link_1',
            },
        ],
        items: [
          {
            name: 'TenCV',
            company: 'FPT',
            address: 'London',
            phone: '012345',
            email: 'h@gmail.com',
            time: 'Full',
            status: 'OK'
          },
          {
            name: 'TenCV',
            company: 'FPT',
            address: 'London',
            phone: '0123456',
            email: 'h@gmail.com',
            time: 'Full',
            status: 'OK'
          },
          {
            name: 'TenCV',
            company: 'FPT',
            address: 'London',
            phone: '0123457',
            email: 'h@gmail.com',
            time: 'Full',
            status: 'OK'
          },
          {
            name: 'TenCV',
            company: 'FPT',
            address: 'London',
            phone: '0123458',
            email: 'h@gmail.com',
            time: 'Full',
            status: 'OK'
          },
          {
            name: 'TenCV',
            company: 'FPT',
            address: 'London',
            phone: '0123459',
            email: 'h@gmail.com',
            time: 'Full',
            status: 'OK'
          },
        ],
      }),
      computed: {
        pageCount () {
          return Math.ceil(this.items.length / this.itemsPerPage)
        },
      },
    }
  </script>
  