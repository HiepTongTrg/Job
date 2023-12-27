<template>
    <v-container>
        <v-dialog
            v-model="dialog"
            max-width="800px"
        >
            <v-card>
                <v-card-title align="center">
                    <span>Xem danh sach ung vien</span>
                </v-card-title>
                <v-card-text>
                <v-table
                    fixed-header
                    height="300px"
                >
                    <thead>
                    <tr>
                        <th class="text-left">
                        TenUV
                        </th>
                        <th class="text-left">
                        Dia Chi
                        </th>
                        <th class="text-left">
                        Dien Thoai
                        </th>
                        <th class="text-left">
                        Email
                        </th>
                        <th class="text-left">
                        CV
                        </th>
                        <th class="text-left">
                        Chuc nang
                        </th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr
                        v-for="item in desserts"
                        :key="item.name"
                    >
                        <td>{{ item.name }}</td>
                        <td>{{ item.address }}</td>
                        <td>{{ item.phone }}</td>
                        <td>{{ item.email }}</td>
                        <td>{{ item.cv }}</td>
                        <td>
                          <v-icon
                              class="mr-3"
                              size="large"
                            >
                              mdi-check-bold
                          </v-icon>
                          <v-icon
                              size="large"
                              @click="dialogDelete = true"
                            >
                              mdi-delete
                            </v-icon>
                        </td>
                    </tr>
                    </tbody>
                </v-table>
                </v-card-text>
            </v-card>
        </v-dialog>
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
</template>

<script>

export default {
    dialogDelete: false,
    props: ['dialogView'],
    computed:{
        dialog:{
            get(){
                return this.dialogView;
            },
            set(value){
                if(!value){
                    this.$emit('close');
                }
            }
        }
    },
    data () {
      return {
        desserts: [
          {
            name: 'Frozen Yogurt',
            address: 'ngu',
            phone: 1591321,
            email: 'ngu@gmail.com',
            cv: '',
          },
          {
            name: 'Frozen Yogurt',
            address: 'ngu',
            phone: 1591321,
            email: 'ngu@gmail.com',
            cv: '',
          },
          {
            name: 'Frozen Yogurt',
            address: 'ngu',
            phone: 1591321,
            email: 'ngu@gmail.com',
            cv: '',
          },
          {
            name: 'Frozen Yogurt',
            address: 'ngu',
            phone: 1591321,
            email: 'ngu@gmail.com',
            cv: '',
          },
        ],
      }
    },
}
</script>

<style>

</style>