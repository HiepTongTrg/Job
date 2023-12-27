<template>
    <v-navigation-drawer v-model="drawer1">
        <v-img src="" class="pa-4">
            <div class="text-center mt-4">
                <v-avatar
                    class="mb-4"
                    color="grey-darken-1"
                    size="64"
                >
                    <v-img aspect-ratio="30" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSco2XERUzLlpvvlc2oxqQnc6UG1N5-YgsUPw&usqp=CAU"/>
                </v-avatar>
  
                <h2>Admin</h2>
            </div>
        </v-img>

        <v-divider></v-divider>
  
        <v-list>
            <v-list-item
                v-for="(item, i) in links"
                :key="i"
                :to="item.route"
                :value="item"
            >
                <template v-slot:prepend>
                    <v-icon :icon="item.icon"></v-icon>
                </template>

                <v-list-item-title>{{item.title}}</v-list-item-title>
            </v-list-item>
        </v-list>
      </v-navigation-drawer>
</template>

<script>
export default {
    name: "SideBar",
    props:['drawer'],
    data(){
        return{
            links: [
                {
                    icon: 'mdi-microsoft-windows',
                    title: 'Dashboard',
                    route: '/admin'
                },
                {
                    icon: 'mdi-account',
                    title: 'Account',
                    route: '/account'
                },
                {
                    icon: 'mdi-briefcase',
                    title: 'Job',
                    route: '/job-admin'
                }
            ],
        }
    },
    computed:{
        drawer1:{
            get(){
                return this.drawer
            }
        }
    }
}
</script>

<style>

</style>