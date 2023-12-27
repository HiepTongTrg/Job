<template>
    <v-app-bar
        color="teal"
        elevate-on-srcoll
        elevation="4"
    >
        <v-app-bar-nav-icon @click="$emit('handleDrawer')"></v-app-bar-nav-icon>  

        <v-toolbar-title>Title</v-toolbar-title>

        <v-spacer></v-spacer>

        <v-toolbar-items>
            <v-btn>Hire me</v-btn>
            <v-btn>Blog</v-btn>
            <v-btn class="text-none" stacked to="/">
                <v-badge dot color="success">
                    <v-icon>mdi-home-outline</v-icon>
                </v-badge>
            </v-btn>
            <v-btn class="text-none" stacked>
                <v-badge content="2" color="error">
                    <v-icon>mdi-bell-outline</v-icon>
                </v-badge>
            </v-btn>
            <v-menu
                transition="scale-transition"
            >
                <template v-slot:activator="{ props }">
                    <v-btn v-bind="props">
                        <v-avatar>
                            <v-img
                                src="https://cf.shopee.vn/file/3a4bb534fca96af651202d482000fda6"
                                alt="Ken"
                            ></v-img>
                        </v-avatar>
                    </v-btn>
                </template>
                <v-list>
                    <v-list-item
                        prepend-avatar="https://cf.shopee.vn/file/3a4bb534fca96af651202d482000fda6"
                        title="Lelouch Ken"
                        subtitle="Logged In"
                    ></v-list-item>
                    <v-divider class="mt-3"></v-divider>
                    <v-list-item
                        v-for="([title, icon], i) in menus"
                        :key="i"
                        :title="title"
                        :prepend-icon="icon"
                        :value="title"
                        @click="handleMenuClick(title)"
                    ></v-list-item>
                </v-list>
            </v-menu>
        </v-toolbar-items>
    </v-app-bar>
</template>

<script>
import router from '@/router';
import { mapActions } from 'vuex';
export default {
    name: "TopBar",
    data(){
        return{
            menus: [
                ['Profile', 'mdi-account'],
                ['Change Password', 'mdi-key'],
                ['Setting', 'mdi-cog'],
                ['Logout', 'mdi-logout'],
            ],
        }
    },
    methods:{
        ...mapActions(['logout']),
        handleMenuClick(title) {
            if (title === 'Logout') {
                this.logout();
                this.$router.push('/');
            }
        }
    }
}
</script>

<style>

</style>