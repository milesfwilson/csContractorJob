<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row">
      <contractor-component v-for="contractor in contractors" :key="contractor.id" :contractor-props="contractor" />
    </div>
    <div class="row">
      <form @submit.prevent="create(state.newContractor)">
        <input type="text" v-model="state.newContractor.name" placeholder="Contractor Name" required>
        <input type="number" v-model="state.newContractor.rate" placeholder="Contractor Rate" required>
        <button class="btn btn-primary btn-block">
          Submit
        </button>
      </form>
    </div>
    <div class="row">
      <job-component v-for="job in jobs" :key="job.id" :job-props="job" />
    </div>
    <form @submit.prevent="createJob(state.newJob)">
      <input type="text" v-model="state.newJob.title" placeholder="Job Title" required>
      <input type="text" v-model="state.newJob.location" placeholder="Job Location" required>
      <input type="number" v-model="state.newJob.budget" placeholder="Budget" required>
      <button class="btn btn-primary btn-block">
        Submit
      </button>
    </form>
  </div>
</template>

<script>
import { onMounted, computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { contractorService } from '../services/ContractorService'
import ContractorComponent from '../components/ContractorComponent.vue'
import JobComponent from '../components/JobComponent.vue'
import { jobService } from '../services/JobService'
export default {
  name: 'Home',
  components: { ContractorComponent, JobComponent },
  setup() {
    onMounted({

    })
    const state = reactive({
      newContractor: {
        name: '',
        rate: null
      },
      newJob: {
        title: '',
        budget: null,
        location: ''
      }
    })
    return {
      contractors: computed(() => AppState.contractors),
      jobs: computed(() => AppState.jobs),
      state,
      create(newContractor) {
        contractorService.create(newContractor)
      },
      createJob(newJob) {
        jobService.create(newJob)
      }
    }
  }
}
</script>

<style scoped lang="scss">

</style>
