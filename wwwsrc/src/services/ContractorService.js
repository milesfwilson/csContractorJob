import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ContractorService {
  async get() {
    try {
      const res = await api.get('/api/contractor')
      AppState.contractors = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newContractor) {
    try {
      await api.post('/api/contractor', newContractor)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async delete(contractorId) {
    try {
      await api.delete('/api/contractor/' + contractorId)
      logger.log(contractorId)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(contractorId, newContractor) {
    try {
      await api.put('/api/contractor/' + contractorId, newContractor)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const contractorService = new ContractorService()
