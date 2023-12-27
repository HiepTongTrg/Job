<template>
    <v-container>
        <v-dialog
            v-model="dialog"
            max-width="640px"
        >
            <v-card flat outlined>
                <v-tabs
                    fixed-tabs
                    bg-color="indigo-darken-2"
                    v-model="tab"
                >
                    <v-tab value="job">
                    Job
                    </v-tab>
                    <v-tab value="admin">
                    Admin
                    </v-tab>
                </v-tabs>
                <v-card-text>
                    <v-window v-model="tab">
                        <v-window-item value="job">
                            <v-card
                                class="mx-auto pa-12 pb-8"
                                elevation="8"
                                max-width="448"
                                rounded="lg"
                            >
                            <div class="text-subtitle-1 text-medium-emphasis">Account</div>

                            <v-text-field
                                v-model="jobster.userName"
                                density="compact"
                                placeholder="Enter your username"
                                prepend-inner-icon="mdi-email-outline"
                                variant="outlined"
                            ></v-text-field>

                            <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">Password</div>

                            <v-text-field
                                v-model="jobster.passWord"
                                :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
                                :type="visible ? 'text' : 'password'"
                                density="compact"
                                placeholder="Enter your password"
                                prepend-inner-icon="mdi-lock-outline"
                                variant="outlined"
                                @click:append-inner="visible = !visible"
                            ></v-text-field>
                            <v-btn
                                block
                                class="mb-5"
                                color="blue"
                                size="large"
                                variant="tonal"
                                @click="loginJob"
                            >
                                Đăng nhập
                            </v-btn>
                            <v-btn
                                block
                                class="mb-5"
                                color="blue"
                                size="large"
                                variant="tonal"
                                @click="this.$emit('close')"
                            >
                                Hủy
                            </v-btn>

                            <v-card-text class="text-center">
                                <a
                                class="text-blue text-decoration-none"
                                href="http://localhost:8080/sign-up"
                                rel="noopener noreferrer"
                                target="_blank"
                                >
                                Sign up now <v-icon icon="mdi-chevron-right"></v-icon>
                                </a>
                            </v-card-text>
                            </v-card>
                        </v-window-item>
                        <v-window-item value="admin">
                            <v-card
                                class="mx-auto pa-12 pb-8"
                                elevation="8"
                                max-width="448"
                                rounded="lg"
                            >
                            <div class="text-subtitle-1 text-medium-emphasis">Account</div>

                            <v-text-field
                                v-model="company.userName"
                                density="compact"
                                placeholder="Enter your username"
                                prepend-inner-icon="mdi-email-outline"
                                variant="outlined"
                            ></v-text-field>

                            <div class="text-subtitle-1 text-medium-emphasis d-flex align-center justify-space-between">
                                Password
                            </div>

                            <v-text-field
                                v-model="company.passWord"
                                :append-inner-icon="visible ? 'mdi-eye-off' : 'mdi-eye'"
                                :type="visible ? 'text' : 'password'"
                                density="compact"
                                placeholder="Enter your password"
                                prepend-inner-icon="mdi-lock-outline"
                                variant="outlined"
                                @click:append-inner="visible = !visible"
                            ></v-text-field>

                            <v-btn
                                block
                                class="mb-5"
                                color="blue"
                                size="large"
                                variant="tonal"
                                @click="loginCompany"
                            >
                                Đăng nhập
                            </v-btn>
                            <v-btn
                                block
                                color="blue"
                                size="large"
                                variant="tonal"
                                @click="this.$emit('close')"
                            >
                                Hủy
                            </v-btn>
                            </v-card>
                        </v-window-item>
                    </v-window>
                </v-card-text>
            </v-card>
        </v-dialog>
    </v-container>
</template>

<script>
import router from '@/router';
import axios from 'axios';
import { mapGetters } from 'vuex';
export default {
    data: () => ({
        tab: null,
        visible: false,
        company:{
            userName:'',
            passWord:''
        },
        jobster:{
            userName:'',
            passWord:''
        }
    }),
    props: ['dialogLogin'],
    computed:{
        ...mapGetters(["setJobster", "setCompany"]),
        dialog:{
            get(){
                return this.dialogLogin;
            },
            set(value){
                if(!value){
                    this.$emit('close');
                }
            }
        }
    },
    methods:{
        loginJob(){
            axios.post('https://localhost:7247/api/UngVien/login?account=' + this.jobster.userName + '&password=' + this.jobster.passWord)
            .then(response=>{
                this.$store.dispatch('login', response.data.token);
                this.$store.dispatch('getJobster', response.data.user.id)
                this.$emit('close');
                console.log(response.data.user)
            })
            .catch(e=>{
                console.log(e);
            })
        },
        loginCompany(){
            axios.post('https://localhost:7247/api/NhaTuyenDung/login?account=' + this.company.userName + '&password=' + this.company.passWord)
            .then(response=>{
                this.$store.dispatch('login', response.data.token);
                this.$store.dispatch('getCompany', response.data.user.id)
                this.$emit('close');
                this.$router.push('/admin')
                console.log(response.data.user)

            })
            .catch(e=>{
                console.log(e);
            })
        }
    }
}
</script>

<style>

</style>