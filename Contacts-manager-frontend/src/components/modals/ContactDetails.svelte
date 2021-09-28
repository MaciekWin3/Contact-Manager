<script>

    export let showDetailsModal = false;
    export let contact;

</script>
  
{#if showDetailsModal}
    <div class="modal is-active">
        <div class="modal-background" on:click|self></div>
        <div class="modal-card">
        <header class="modal-card-head has-text-centered">
            <p class="modal-card-title">Product Details</p>
            <button on:click class="delete" aria-label="close"></button>
        </header>
        <section class="modal-card-body">
            <p class="is-size-2">Name: {contact.firstName}</p>
            <p class="is-size-2">Surname: {contact.lastname}</p>
            <p class="is-size-2">Email: {contact.email}</p>
            <p class="is-size-2">Phone: {contact.phone}</p>
            <p class="is-size-2">Name: {contact.firstName}</p>
        </section>
            <footer class="modal-card-foot has-text-centered">
                <div class="content has-text-centered">
                    <button class="button is-danger" on:click>Cancel</button>
                </div>                
            </footer>
        </div>
    </div>
{/if}

