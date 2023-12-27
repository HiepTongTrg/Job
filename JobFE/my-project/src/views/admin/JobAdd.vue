<template>
    <v-container>
        <v-dialog
            v-model="dialog"
            max-width="640px"
        >
            <v-card>
                <v-card-title>
                    <span class="text-h4">Them moi cong viec</span>
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
                                    <v-select
                                        variant="outlined"
                                        :items="items"
                                        label="Loai cong viec"
                                        v-model="job.loaiCV"
                                    ></v-select>
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
                        @click="addJob"
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
    name: 'JobAdd',
    props: ['dialogAdd'],
    data: () => ({
        items: ['Full-time', 'Part-time'],
        job:{
            id:0,
            nhaTuyenDungID: null,
            tenCongViec:'',
            luong:null,
            moTa:'',
            loaiCV:'',
            avatar: ''
        },
        file:'',
    }),
    created(){
        this.company = this.$store.getters.company;
    },
    computed:{
        ...mapGetters(["token"])
    },
    methods:{
        addJob(){
            this.job.nhaTuyenDungID = this.company.id
            const token = this.$store.state.token;
            axios.post('https://localhost:7247/api/CongViec',this.job ,{headers: {'Authorization':'Bearer ' + token }})
            .then(response => {
                console.log(response.status);
                axios.get('https://localhost:7247/api/CongViec/GetLastJob')
                .then(response =>{
                    this.job.id = response.data.id;
                    let formData = new FormData();
                    console.log(this.file);
                    formData.append('formFile',this.file[0]);
                    axios.post('https://localhost:7247/api/CongViec/UploadImage?jobcode=' + this.job.id, formData)
                    .then(response =>{
                        this.job.avatar = response.data[0];
                        console.log(this.job);
                        axios.put('https://localhost:7247/api/CongViec' + '/' + this.job.id, this.job, {headers: {'Authorization':'Bearer ' + token }})
                        .then(response =>{
                            console.log(response.status);
                            this.$emit('close');
                            this.$emit('updateData');
                            this.resetForm();
                        }).catch(e =>{
                            console.log(e);
                        })
                    }).catch(e =>{
                        console.log(e);
                    })
                }).catch(e =>{
                    console.log(e);
                })
            }).catch(e => {
                console.log(e);
            })
        },
        resetForm(){
            this.job = {
                id: 0,
                nhaTuyenDungID: 1,
                tenCongViec: '',
                luong: null,
                moTa: '',
                loaiCV: '',
                avatar: ''
            };
            this.file = '';
        }
    },
    computed:{
        dialog:{
            get(){
                return this.dialogAdd;
            },
            set(value){
                if(!value){
                    this.$emit('close');
                }
            }
        },
    }
}
</script>

<style>

</style>