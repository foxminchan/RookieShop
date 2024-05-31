import { User } from "oidc-client-ts"
import { authService } from "../services/auth.service"
import { oidcStorageName } from "../configs/oicd.config"
import { atomWithStorage, createJSONStorage } from "jotai/utils"

const storage = createJSONStorage<User | null>(() => window.localStorage, {
  reviver: User.fromStorageString,
  replacer: (_key, value) =>
    value instanceof User ? value.toStorageString() : (value as string),
})

export const userAtom = atomWithStorage<User | null>(
  oidcStorageName,
  authService.getUser(),
  storage
)
