<template>
    <v-dialog v-model="dialog" max-width="600px">
      <v-card>
        <v-card-title class="text-h5">Apply Job</v-card-title>
    
        <v-card-text>
          <v-form>
            <v-row class="form-group">
              <v-col cols="12" class="mb-3 mb-md-0">
                <v-text-field>{{ item.tenCongViec }}</v-text-field>
              </v-col>
            </v-row>
    
            <v-row class="form-group mb-4">
              <v-col cols="12" class="mb-3 mb-md-0">
                <v-file-input 
                    label="File input" 
                    show-size
                    prepend-icon="mdi-account-file-text"
                    v-model="file"
                ></v-file-input>
              </v-col>
            </v-row>
            
            <v-row class="form-group mb-4">
              <v-col cols="12" class="mb-3 mb-md-0">
                <label class="text-black">Mo ta</label>
                <v-textarea placeholder="Mo ta cua ban" v-model="apply.moTa"></v-textarea>
              </v-col>
            </v-row>
    
            <v-row class="form-group">
              <v-col cols="12">
                <v-btn
                    class="mr-2"
                    color="grey darken-3"
                    @click="this.$emit('close')"
                >Huy</v-btn>
                <v-btn
                    color="primary"
                    @click="addApply"
                >Cap nhat</v-btn>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
</template>
  
<script>
import { mapGetters } from 'vuex';
import axios from 'axios';
export default {
    props: ['dialogApply','item'],
    data:()=>({
      apply:{
        id:0,
        ungVienId:null,
        congViecId:null,
        cv:'',
        trangThai:0,
        moTa:'',
      },
      file:null,
    }),
    created(){
      this.jobster = this.$store.getters.jobster;
    },
    computed:{
      ...mapGetters(["token"]),
      dialog:{
        get(){
          return this.dialogApply;
        },
        set(value){
          if(!value){
            this.$emit('close');
          }
        }
      }
    },
    methods:{
      addApply(){
        this.jobster = this.$store.getters.jobster;
        this.apply.congViecId = this.item.id
        this.apply.ungVienId = this.jobster.id
        const token = this.$store.state.token;
        axios.post('https://localhost:7247/api/XinViec', this.apply ,{headers: {'Authorization':'Bearer ' + token }})
        .then(response=>{
          console.log(response.status);
          axios.get('https://localhost:7247/api/XinViec/GetLastApply')
          .then(response=>{
            this.apply.id = response.data.id;
            let formData = new FormData();
            formData.append('formFile',this.file[0]);
            axios.post('https://localhost:7247/api/XinViec/UploadFile?cvcode=' + this.apply.id, formData)
            .then(response=>{
              this.apply.cv = response.data[0];
              console.log(this.apply);
              axios.put('https://localhost:7247/api/XinViec' + '/' + this.apply.id, this.apply, {headers: {'Authorization':'Bearer ' + token }})
              .then(response=>{
                console.log(response.status);
                this.$emit('close');
                this.resetForm();
                this.$router.push('/')
              }).catch(e=>{
                console.log(e);
              })
            }).catch(e=>{
              console.log(e);
            })
          }).catch(e=>{
            console.log(e);
          })
        }).catch(e=>{
          console.log(e);
        })
      },
      resetForm(){
        this.apply = {
          id:0,
          ungVienId:null,
          congViecId:null,
          cv:'',
          trangThai:null,
          moTa:'',
        };
        this.file = null;
      }
    }
};
</script>

<style>

</style>