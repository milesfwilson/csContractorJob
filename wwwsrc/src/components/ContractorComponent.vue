<template>
  <div class="contractor-component col-4" v-if="contractor.name">
    <div class="shadow-lg text-center p-2 m-3 rounded">
      <h3>
        {{ contractor.name }}
      </h3>
      <h6>
        ${{ contractor.rate }}
      </h6>
      <form @submit.prevent="createContractorJob(contractor.id, state.jobId)">
        <select v-model="state.jobId" name="" id="">
          <option v-for="job in jobs" :key="job.id" :value="job.id">
            {{ job.title }}
          </option>
        </select>
        <button class="btn btn-block btn-primary">
          Hire
        </button>
      </form>

      <button @click="deleteContractor(contractor.id)" class="btn btn-block btn-danger">
        Delete
      </button>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { contractorService } from '../services/ContractorService'
import { contractorJobService } from '../services/ContractorJobService'
import { AppState } from '../AppState'
export default {
  name: 'ContractorComponent',
  props: ['contractorProps'],
  setup(props) {
    const state = reactive({
      jobId: null
    })
    return {
      state,
      contractor: computed(() => props.contractorProps),
      jobs: computed(() => AppState.jobs),
      deleteContractor(id) {
        contractorService.delete(id)
      },
      createContractorJob(id, job) {
        const newContractorJob = { contractorId: id, jobId: job }
        contractorJobService.create(newContractorJob)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
