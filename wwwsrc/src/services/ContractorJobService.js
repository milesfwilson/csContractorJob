import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ContractorJobService {
  async get() {
    try {
      const res = await api.get('/api/contractorjob')
      AppState.allJobContractors = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newContractorJob) {
    try {
      await api.post('/api/contractorjob', newContractorJob)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const contractorJobService = new ContractorJobService()
