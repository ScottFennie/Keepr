import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keeps: [],
  currentKeep: null,
  currentVault: null,
  currentProfile: null,
  currentVaultKeep: null,
  profileKeeps: [],
  profileVaults: [],
  vaultKeeps: [],
  profPage: false
})
