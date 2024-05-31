import { atomWithStorage, createJSONStorage } from "jotai/utils"
import { User } from "oidc-client-ts"

import { oidcStorageName } from "../configs/oicd.config"
import { authService } from "../services/auth.service"

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
