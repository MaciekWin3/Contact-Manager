<script>

    export let showEditModal = false;
    export let contact;

</script>
  
{#if showEditModal}
    <div class="modal is-active">
        <div class="modal-background" on:click|self></div>
        <div class="modal-card">
        <header class="modal-card-head has-text-centered">
            <p class="modal-card-title">Edit contact : {contact.id}</p>
            <button on:click class="delete" aria-label="close"></button>
        </header>
        <section class="modal-card-body">
            <slot></slot>
        </section>
        </div>
    </div>
{/if}
