<template>
  <div id="input-container">
      <input
      class="form-control"
      type="text"
      id="input-text1"
      v-model="customer.name" placeholder="Name:" @keyup.enter="onCapture"
      >
      <input
      class="form-control"
      type="text"
      id="input-text2"
      v-model="customer.address" placeholder="Address:" @keyup.enter="onCapture"
      >
      <input
      class="form-control"
      type="text"
      id="input-text3"
      v-model="customer.phone" placeholder="Phone:" @keyup.enter="onCapture"
      >
      <input
      class="form-control"
      type="text"
      id="input-text4"
      v-model="customer.email" placeholder="Email:" @keyup.enter="onCapture"
      >
       <input
      class="form-control"
      type="text"
      id="input-text5"
      v-model="customer.age" placeholder="Age:" @keyup.enter="onCapture"
      >
       <button type="button" :disabled="!customer.hasAllInfo" :class=" customer.hasAllInfo ? 'btn btn-primary' : 'btn btn-secondary'" id="add-customer" @click="onAdd" >Add</button>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data(){

    return {
      customer:{
        name:"",
        address:"",
        phone:"",
        email:"",
        age:"",
        hasAllInfo: false
        }
    }
  },
  methods :{
    onCapture(){
      if (this.customer.name.replace(/\s/g,'') && this.customer.address.replace(/\s/g,'') 
       && this.customer.phone.replace(/\s/g,'') && this.customer.email.replace(/\s/g,'')
       && this.customer.age.replace(/\s/g,'')) {
              this.customer.hasAllInfo = true;
      }
      else
      {
        this.customer.hasAllInfo = false;
      }
    },
    onAdd(){
       axios.post('http://ximenacustomerapp.azurewebsites.net/api/saver',{ customer: { name: this.customer.name, address: this.customer.address, phone: this.customer.phone, email:this.customer.email, age: this.customer.age }})
              .then(response => this.responseData = response.data)
              .catch(error => {alert(error)});
    }
  }
}
</script>

<style>
.form-control {
  width: 100%;
  padding: 8px 10px;
  display: block;
  border: 1px solid #007bff;
}
#input-container{
  display: block;
	margin-bottom: 40px;
}
#add-customer{
    width: 100%;
    height: 100%;
    flex:1;
}

</style>