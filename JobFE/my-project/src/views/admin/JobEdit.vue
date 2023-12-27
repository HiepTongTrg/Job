<template>
    <v-container>
        <v-dialog
            v-model="dialog"
            max-width="640px"
        >
            <v-card>
                <v-card-title>
                    <span>Cap nhat cong viec</span>
                </v-card-title>
                <v-card-text>
                    <v-form>
                        <v-container>
                            <v-row>
                                <v-col>
                                    <v-text-field
                                        variant="outlined"
                                        label="Ten cong viec"
                                        v-model="job.tenCongViec"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-text-field
                                        variant="outlined"
                                        label="Luong"
                                        v-model="job.luong"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-text-field
                                        variant="outlined"
                                        label="Ngay Dang"
                                        v-model="job.ngayDang"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-text-field
                                        variant="outlined"
                                        label="Loai cong viec"
                                        v-model="job.loaiCV"
                                    ></v-text-field>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-file-input
                                        variant="outlined"
                                        accept="image/png, image/jpeg, image/bmp"
                                        placeholder="Pick an avatar"
                                        prepend-icon="mdi-camera"
                                        label="Avatar"
                                        v-model="file"
                                    ></v-file-input>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col>
                                    <v-textarea
                                        label="Mo ta"
                                        auto-grow
                                        variant="outlined"
                                        rows="3"
                                        row-height="25"
                                        shaped
                                        prepend-icon="mdi-comment"
                                        v-model="job.moTa"
                                    ></v-textarea>
                                </v-col>
                            </v-row>
                        </v-container>
                    </v-form>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                        class="mr-2"
                        color="grey darken-3"
                        @click="this.$emit('close')"
                    >Huy</v-btn>
                    <v-btn
                        color="primary"
                        @click="editJob"
                    >Luu</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script>
import axios from 'axios';
import { mapGetters } from 'vuex';
export default {
    name:'JobEdit',
    props: ['dialogEdit','currentItem'],
    data: () => ({
        job:{
            id:0,
            ngayDang:'',
            nhaTuyenDungID: 1,
            tenCongViec:'',
            luong:null,
            moTa:'',
            loaiCV:'',
            avatar: ''
        },
        file:''
    }),
    created(){
        this.$store.dispatch('getJob')
    },
    computed:{
        ...mapGetters(['job', 'token']),
        dialog:{
            get(){
                return this.dialogEdit;
            },
            set(value){
                if(!value){
                    this.$emit('close');
                }
            }
        }
    },
    methods:{
        editJob(){
            const token = this.$store.state.token;
            if(this.file==''){
                axios.put('https://localhost:7247/api/CongViec/' + this.job.id, this.job ,{headers: {'Authorization':'Bearer ' + token }})
                .then(response=>{
                    console.log(response.data);
                    this.$emit('close');
                    this.$emit('updateData');
                })
                .catch(e=>{
                    console.log(e)
                })
            }
            else{
                let formData = new FormData();
                console.log(this.file);
                formData.append('formFile',this.file[0]);
                axios.post('https://localhost:7247/api/CongViec/UploadImage?jobcode=' + this.job.id, formData)
                .then(response =>{
                    this.job.avatar = response.data[0];
                    console.log(this.job);
                    axios.put('https://localhost:7247/api/CongViec' + '/' + this.job.id, this.job ,{headers: {'Authorization':'Bearer ' + token }})
                    .then(response =>{
                        console.log(response.status);
                        this.$emit('close');
                        this.$emit('updateData');
                    }).catch(e =>{
                        console.log(e);
                    })
                }).catch(e =>{
                    console.log(e);
                })
            }
        }
    },
    watch:{
        currentItem:function(){
            this.job.id = this.currentItem.id;
            this.job.tenCongViec = this.currentItem.tenCongViec;
            this.job.luong = this.currentItem.luong;
            this.job.ngayDang = this.currentItem.ngayDang;
            this.job.loaiCV = this.currentItem.loaiCV;
            this.job.moTa = this.currentItem.moTa;
            this.job.avatar = this.currentItem.avatar;
        }
    }
}
</script>

<style>

</style>