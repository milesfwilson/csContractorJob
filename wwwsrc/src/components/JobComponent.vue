<template>
  <div class="job-component col-4">
    <div class="shadow-lg p-2 m-3 rounded text-center">
      <h3>
        {{ job.title }}
      </h3>
      <h6>{{ job.location }}</h6>
      <h6>{{ job.budget }}</h6>
      <button class="btn btn-danger btn-block" @click="deleteJob(job.id)">
        Delete
      </button>
      <!-- Button trigger modal -->
      <button type="button" class="btn btn-primary btn-block" data-toggle="modal" :data-target="'#modal'+job.id" @click="getContractorsById(job.id)">
        See Contractors
      </button>

      <!-- Modal -->
      <div class="modal fade"
           :id="'modal'+job.id"
           tabindex="-1"
           role="dialog"
           aria-labelledby="modelTitleId"
           aria-hidden="true"
      >
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">
                {{ job.title }}
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <h6>
                ${{ job.budget }} in {{ job.location }}
              </h6>
              <contractor-job-component v-for="contractor in jobContractors" :key="contractor.id" :contractor-props="contractor" />
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="button" class="btn btn-primary">
                Save
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { jobService } from '../services/JobService'
import { AppState } from '../AppState'
export default {
  name: 'JobComponent',
  props: ['jobProps'],
  setup(props) {
    return {
      job: computed(() => props.jobProps),
      jobContractors: computed(() => AppState.jobContractors),
      deleteJob(id) {
        jobService.delete(id)
      },
      getContractorsById(id) {
        jobService.getContractorsById(id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
