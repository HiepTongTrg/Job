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
          <v-form class="pa-4 pt-6">
              <v-text-field
                  label="Enter your name"
                  name="name"
                  prepend-inner-icon="mdi-account"
                  type="text"
                  class="rounded-0"
                  outlined
              ></v-text-field>
              <v-text-field
                  label="Enter your address"
                  name="email"
                  prepend-inner-icon="mdi-map-marker"
                  type="text"
                  class="rounded-0"
                  outlined
              ></v-text-field>
              <v-text-field
                  label="Enter your phone"
                  name="email"
                  prepend-inner-icon="mdi-phone"
                  type="text"
                  class="rounded-0"
                  outlined
              ></v-text-field>
              <v-text-field
                  label="Enter your email"
                  name="email"
                  prepend-inner-icon="mdi-email"
                  type="email"
                  class="rounded-0"
                  outlined
              ></v-text-field>
              <v-text-field
                  label="Enter your password"
                  name="password"
                  prepend-inner-icon="mdi-lock"
                  type="password"
                  class="rounded-0"
                  outlined
              ></v-text-field>
              <v-file-input
                accept="image/png, image/jpeg, image/bmp"
                placeholder="Pick an avatar"
                prepend-icon="mdi-camera"
                label="Avatar"
              ></v-file-input>
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
              <v-btn class="rounded-0" color="#000000" x-large block dark>Register</v-btn>
              <v-card-actions class="text--secondary">
                  <v-spacer></v-spacer>
                  <!-- <router-link :to="{ name: 'SignUp' }">Sign Up</router-link> -->
                  Already have an account?
                  <a href="#" class="pl-2" style="color: #000000">Sign In</a>
              </v-card-actions>
          </v-form>
      </v-card-text>
  </v-card>
  <Footer/>
  </div>
</template>

<script>
import Header from '@/components/Header.vue'
import Footer from '@/components/Footer.vue'
export default {
components: { Header, Footer },
data: () => ({
    dialogLogin: false,
})
}
</script>

<style>

</style>