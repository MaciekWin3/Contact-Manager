<script>

    import { createEventDispatcher } from "svelte";

    export let product;

    let dispatch = createEventDispatcher();
    

    let firstName;
	  let lastName;
    let email;
    let phone;
    let birthDate;
    let contactType;
    let id = product.id;

    const handleSubmit = () => {

        const product = {
            firstName: firstName,
            lastName: lastName,
            email: email,
            phone: phone,
            birthDate: birthDate,
            contactType: contactType
        }

        dispatch('editContact', product, id);
               
    };
</script>

<form on:submit={handleSubmit}>
    <div class="field">
        <label class="name" for="name">Name</label>
        <div class="control">
            <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={firstName} placeholder={contact.firstName}>
        </div>  
        <div class="control">
          <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={lastName} placeholder={product.name}>
      </div>  
      <div class="control">
        <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={email} placeholder={product.name}>
    </div>  
    <div class="control">
      <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={phone} placeholder={product.name}>
  </div>  
  <div class="control">
    <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={birthDate} placeholder={product.name}>
  </div>      
  <div class="control">
    <input name="name" class="input is-primary is-fullwidth" type="text" bind:value={birthDate} placeholder={product.name}>
  </div>  

      

      <div class="field is-grouped">
        <p class="control">
          <button class="button is-primary">
            Submit
          </button>
        </p>
        <p class="control">
          <!-- svelte-ignore a11y-missing-attribute -->
          <a on:click class="button is-light">
            Cancel
          </a>
        </p>
      </div>
</form>
 