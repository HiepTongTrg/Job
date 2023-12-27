<template>
    <div>
    <Header/>
    <v-card 
        elevation="0"
        class="mx-auto"
        style="max-width: 500px;"
    >
        <div class="text-center">
            <h1 class="mt-10">Register</h1>
        </div>
        <v-card-text>
            <v-form class="pa-4 pt-6" @submit.prevent="onSubmit">
                <v-text-field
                    label="Enter your name"
                    prepend-inner-icon="mdi-account"
                    type="text"
                    class="rounded-0"
                    outlined
                    v-model="jobster.tenUngVien"
                ></v-text-field>
                <v-text-field
                    label="Enter your address"
                    prepend-inner-icon="mdi-map-marker"
                    type="text"
                    class="rounded-0"
                    outlined
                    v-model="jobster.diaChi"
                ></v-text-field>
                <v-text-field
                    label="Enter your phone"
                    prepend-inner-icon="mdi-phone"
                    type="text"
                    class="rounded-0"
                    outlined
                    v-model="jobster.dienThoai"
                ></v-text-field>
                <v-text-field
                    label="Enter your email"
                    prepend-inner-icon="mdi-email"
                    type="email"
                    class="rounded-0"
                    outlined
                    v-model="jobster.email"
                ></v-text-field>
                <v-text-field
                    label="Enter your username"
                    prepend-inner-icon="mdi-account-box"
                    type="text"
                    class="rounded-0"
                    outlined
                    v-model="jobster.userName"
                ></v-text-field>
                <v-text-field
                    label="Enter your password"
                    prepend-inner-icon="mdi-lock"
                    type="password"
                    class="rounded-0"
                    outlined
                    v-model="jobster.passWord"
                ></v-text-field>
                <v-checkbox>
                    <template v-slot:label>
                        I agree to the&nbsp;
                        <a
                            href="#"
                        >Terms of Service</a>
                        &nbsp;and&nbsp;
                        <a
                            href="#"
                        >Privacy Policy</a>*
                    </template>
                </v-checkbox>
                <v-btn class="rounded-0" color="#000000" x-large block dark type="submit">Register</v-btn>
            </v-form>
        </v-card-text>
    </v-card>
    <Footer/>
    </div>
</template>

<script>
import router from '@/router';
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
export default {
  components: { Header, Footer },
  data: () => ({
      jobster:{
        id:0,
        tenUngVien:'',
        diaChi:'',
        dienThoai:'',
        email:'',
        userName:'',
        passWord:''
    },
  }),
  methods:{
    onSubmit(){
        this.$store.dispatch('addJobster', this.jobster);
        this.$router.push('/');
    }
  }
}
</script>

<style>

</style>