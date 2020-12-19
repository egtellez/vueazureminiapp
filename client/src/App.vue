<template>
	<div>
		<H1 id="H1"/>
		<CustomerInputControls id="CustomerInputControls"/>
	</div>
</template>

<script>
import H1 from './components/H1.vue'
import CustomerInputControls from './components/CustomerInputControls.vue'

export default {
	components: {
		CustomerInputControls, H1
	}
}
</script>

<style>

*, *::before, *::after {
	box-sizing: border-box;
}

#H1 {
	text-align: center;
}


#CustomerInputControls{
  position: relative;
  margin: 50px auto;
  overflow: auto;
  width: 500px;
  min-height: 350px;
  background-color: rgb(255, 255, 255);
  box-shadow: 5px 5px 15px #00000047;
  border-radius: 10px;
  padding: 40px 25px 40px 25px;
}

@media screen and (max-width: 600px){
	#CustomerInput{
		margin: 0 0;
		overflow: auto;
		width: 85%;
		margin: auto;
	}
}


</style>