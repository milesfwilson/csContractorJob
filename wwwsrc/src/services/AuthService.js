import { initialize } from '@bcwdev/auth0provider-client'
import { AppState } from '../AppState'
import { audience, clientId, domain } from '../AuthConfig'
import router from '../router'
import { setBearer } from './AxiosService'
import { profileService } from './ProfileService'
import { contractorService } from '../services/ContractorService'
import { jobService } from '../services/JobService'
import { contractorJobService } from './ContractorJobService'
export const AuthService = initialize({
  domain,
  clientId,
  audience,
  onRedirectCallback: appState => {
    router.push(
      appState && appState.targetUrl
        ? appState.targetUrl
        : window.location.pathname
    )
  }
})

AuthService.on(AuthService.AUTH_EVENTS.AUTHENTICATED, async function() {
  setBearer(AuthService.bearer)
  await profileService.getProfile()
  await contractorService.get()
  await jobService.get()
  await contractorJobService.get()
  AppState.user = AuthService.user
  // NOTE if there is something you want to do once the user is authenticated, place that here
})
