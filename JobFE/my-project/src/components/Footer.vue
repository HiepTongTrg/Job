<template>
    <v-footer
      class="bg-indigo-lighten-1 text-center d-flex flex-column pa-4"
      absolute
    >
    <div>
      <v-btn
        v-for="icon in icons"
        :key="icon"
        class="mx-4"
        :icon="icon"
        variant="text"
      ></v-btn>
    </div>
    <v-divider></v-divider>
      <div>
        <v-spacer></v-spacer>
        &copy; {{ new Date().getFullYear() }} — <strong>Awesome Job</strong>
      </div>
    </v-footer>
</template>

<script>
export default {
    name: "Footer",
    data:()=>({
        icons: [
            'mdi-facebook',
            'mdi-twitter',
            'mdi-linkedin',
            'mdi-instagram',
        ],
    })
}
</script>

<style>

</style>