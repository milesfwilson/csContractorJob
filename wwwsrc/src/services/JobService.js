import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class JobService {
  async get() {
    try {
      const res = await api.get('/api/job')
      AppState.jobs = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async getContractorsById(id) {
    try {
      const res = await api.get('/api/job/' + id + '/contractorjob')
      AppState.jobContractors = res.data
      logger.log(AppState.jobContractors)
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newJob) {
    try {
      await api.post('/api/job', newJob)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async delete(jobId) {
    try {
      await api.delete('/api/job/' + jobId)
      logger.log(jobId)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(jobId, newJob) {
    try {
      await api.put('/api/job/' + jobId, newJob)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const jobService = new JobService()
