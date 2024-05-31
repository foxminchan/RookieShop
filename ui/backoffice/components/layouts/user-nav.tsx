"use client"

import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "../ui/dropdown-menu"
import { useAtom } from "jotai"
import { Button } from "../ui/button"
import { userAtom } from "@/lib/jotai/userAtom"
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar"

export function UserNav() {
  const [user, setUser] = useAtom(userAtom)

  if (user) {
    return (
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant="ghost" className="relative h-8 w-8 rounded-full">
            <Avatar className="h-8 w-8">
              <AvatarImage
                src="https://github.com/foxminchan.png"
                alt="admin"
              />
              <AvatarFallback>NT</AvatarFallback>
            </Avatar>
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent className="w-56" align="end" forceMount>
          <DropdownMenuItem onClick={() => setUser(null)}>
            Log out
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
    )
  }
}
