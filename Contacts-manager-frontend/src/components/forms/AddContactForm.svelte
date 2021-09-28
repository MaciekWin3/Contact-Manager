<script>

    import { createEventDispatcher } from "svelte";

    let dispatch = createEventDispatcher();

    let firstName;
	  let lastName;
    let email;
    let phone;
    let birthDate;
    let contactType;

    const handleSubmit = () => {
            
      const product = {
            firstName: firstName,
            lastName: lastName,
            email: email,
            phone: phone,
            birthDate: birthDate,
            contactType: contactType
        }

        dispatch('addContact', contact);        
    };
</script>

<form on:submit={handleSubmit}>


    <div class="field">
        <label class="name" for="name">Name</label>
        <div class="control">
            <input class="input is-primary is-fullwidth" type="text" bind:value={firstName}>
        </div>
      </div>
    
      <div class="field">
        <label class="name" for="name">Last name</label>
        <div class="control">
            <input class="input is-primary is-fullwidth" type="text" bind:value={lastName}>
        </div>
      </div>
      <div class="field">
        <label class="name" for="name">Name</label>
        <div class="control">
            <input class="input is-primary is-fullwidth" type="text" bind:value={email}>
        </div>
      </div>
      <div class="field">
        <label class="name" for="name">Name</label>
        <div class="control">
            <input class="input is-primary is-fullwidth" type="text" bind:value={phone}>
        </div>
      </div>
      <div class="field">
        <label class="name" for="name">Name</label>
        <div class="control">
            <input class="input is-primary is-fullwidth" type="text" bind:value={birthDate}>
        </div>
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
 
