<template>
  <div class="contractor-job-component row">
    <div class="col-8">
      {{ contractor.name }}
    </div>
    <div class="col-4">
      ${{ contractor.rate }}
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ContractorJobComponent',
  props: ['contractorProps'],
  setup(props) {
    return {
      contractor: computed(() => props.contractorProps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
