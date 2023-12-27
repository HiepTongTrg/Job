<template>
    <div>
        <v-app-bar>
        <v-app-bar-nav-icon></v-app-bar-nav-icon>
        <v-toolbar-title>Tìm kiếm việc làm một cách nhanh chóng</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items>
            <v-btn to="/" text>
            <v-icon left>mdi-home</v-icon>
            Home
            </v-btn>
            <v-btn to="/job-list" text>
            <v-icon left>mdi-format-list-text</v-icon>
            List
            </v-btn>
            <v-btn to="/job" text>
            <v-icon left>mdi-view-list</v-icon>
            JOB
            </v-btn>
            <v-btn 
            text
            @click="dialogLogin=true"
            v-if="!isLoggedIn"
            >
            <v-icon small left>mdi-login</v-icon>
            Login
            </v-btn>
            <v-menu
                transition="scale-transition"
                v-else
            >
                <template v-slot:activator="{ props }">
                    <v-btn v-bind="props">
                        <v-avatar color="info">
                            <v-icon icon="mdi-account-circle"></v-icon>
                        </v-avatar>
                    </v-btn>
                </template>
                <v-card>
                    <v-card-text>
                        <div class="mx-auto text-center">
                        <v-btn
                            rounded
                            variant="text"
                            @click="logout"
                        >
                            <v-icon>mdi-logout</v-icon>
                            Logout
                        </v-btn>
                        </div>
                    </v-card-text>
                    </v-card>
            </v-menu>
        </v-toolbar-items>
        </v-app-bar>
        <login 
        :dialogLogin="dialogLogin"
        @close="dialogLogin=false"
        />
    </div>
</template>

<script>
import Login from '@/views/Login.vue';
import { mapGetters } from 'vuex';
export default {
    components: { Login },
    name: "Header",
    data:()=>({
        dialogLogin: false,
    }),
    computed:{
        ...mapGetters(["isLoggedIn"])
    },
    methods:{
        logout(){
            this.$store.dispatch('logout');
        }
    }
}
</script>

<style>

</style>