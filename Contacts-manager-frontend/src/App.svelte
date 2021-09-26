<script>
	import { onMount } from "svelte";
	import Footer from "./components/Footer.svelte";
	import CreateModal from "./components/modals/AddModal.svelte";
	import AddContactForm from "./components/forms/AddContactForm.svelte";
	import EditModal from "./components/modals/EditModal.svelte";
	import EditContactForm from "./components/forms/EditContactForm.svelte";
	import ContactDetails from "./components/modals/ContactDetails.svelte";

	let contacts = [];
	onMount( async () => {
		const res = await fetch(`https://localhost:44375/api/contacts`);
		contacts = await res.json();
  	});

	let showCreateModal = false;
	let showEditModal = false;
	let showDetailsModal = false;
	let editedContact;
	let detailsContact;

	const switchCreateModal = () => {
		showCreateModal = !showCreateModal;
	}

	const switchEditModal = () => {
		showEditModal = !showEditModal;
	}

	const switchDetailsModal = () => {
		showDetailsModal = !showDetailsModal;
	}

	const handleDetailsModal = (contact) => {
		detailsContact = contact;
		switchDetailsModal();
	}


	const handleCreateModal = () => {		
		switchCreateModal();
	}

	const handleEditModal = (contact) => {
		editedContact = contact;
		switchEditModal();
	}

	const addContact = (e) => {
		let data = e.detail;
		fetch("https://localhost:44375/api/contacts", {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(data),
		})
		.then((response) => response.json())
		.then((data) => {
			console.log("Success:", data);
		})
		.catch((error) => {
			console.error("Error:", error);
		});
  	};

	const editContact = (e) =>{
		let data = e.detail;
		console.log(data);
		fetch("https://localhost:44375/api/contacts/" + data.d, {
			method: "PUT",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(data),
		})
		.then((data) => {
			console.log("Success:", data);
		})
		.catch((error) => {
			console.error("Error:", error);
		});
		
  	};

	const handleDelete = (id) => {		
		fetch("https://localhost:44375/api/contacts/" + id, {
			method: "DELETE",
			headers: {
				"Content-Type": "application/json",
			},
		})
		.catch((error) => {
			console.error("Error:", error);
		});
		contacts = contacts.filter((contact) => contact.Id != id);
	}	

</script>

<ContactDetails contact={detailsContact} showDetailsModal={showDetailsModal} on:click={switchDetailsModal} />
<EditModal contact={editedContact} showEditModal={showEditModal} on:click={switchEditModal}>
	<slot>
		<EditContactForm contact={editedContact} on:click={switchEditModal} on:editProduct={editContact} />
	</slot>
</EditModal>
<CreateModal showCreateModal={showCreateModal} on:click={switchCreateModal}>
	<slot>
		<AddContactForm on:click={switchCreateModal} on:addContact={addContact} />
	</slot>
</CreateModal>
<main>
	<section class="hero is-info is-small mb-4">
		<div class="hero-body">
		  <p class="title">
			List of Contacts
		  </p>
		  <button on:click={() => {handleCreateModal()}} class="button is-success is-medium mx-2">Create</button>
		</div>
	  </section>
	<div class="columns">
		<div class="is-three-quarters">
			
		</div>
	</div>
	<div class="table-container mx-4">
		<table class="table is-bordered is-striped is-fullwidth is-hoverable ">
			<thead>
				<tr>
					<th>First Name</th>
					<th>Last Name</th>
					<th>Email</th>
					<th>Phone</th>
					<th>Birth Date</th>
					<th>Contact type</th>
					<th>Info</th>
					<th>Edit</th>
					<th>Delete</th>
				</tr>
			</thead>
			{#each contacts as contact (contact.Id)} 
				<tbody>
					<tr>
						<th>{contact.firstName}</th>
						<th>{contact.lastName}</th>
						<th>{contact.email}</th>
						<th>{contact.phone}</th>
						<th>{contact.birthDate}</th>
						<th>{contact.contactType}</th>
						<th>
							<button on:click={() => {handleDetailsModal(contact)}} class="button is-info mx-2">Details</button>						
						</th>
						<th>
							<button on:click={() => {handleEditModal(contact)}} class="button is-warning mx-2">Edit</button>						
						</th>
						<th>
							<button on:click={() => {handleDelete(contact.id)}} class="button is-danger mx-2">Delete</button>
						</th>
					</tr>
				</tbody>					
			{:else}
				<em>Loading...</em>
			{/each}
		</table>
	</div>
</main>
<Footer />

<style>
	main {
		text-align: center;
		max-width: 240px;
		margin: 0 auto;
		display: flex;
		min-height: 100vh;
		flex-direction: column;
	}


	@media (min-width: 340px) {
		main {
			max-width: none;
		}
	}
</style>