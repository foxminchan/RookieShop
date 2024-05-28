import Link from "next/link"
import Image from "next/image"
import { UserNav } from "./user-nav"
import { ModeToggle } from "../custom/mode-toggle"

export default function Header() {
  return (
    <div className="supports-backdrop-blur:bg-background/60 fixed left-0 right-0 top-0 z-20 border-b bg-background/95 backdrop-blur">
      <nav className="flex h-14 items-center justify-between px-4">
        <div className="hidden lg:block">
          <Link
            href={"https://github.com/foxminchan/RookieShop"}
            target="_blank"
          >
            <Image src="/logo.png" alt="Logo" height={30} width={30} />
          </Link>
        </div>
        <div className="flex items-center gap-2">
          <UserNav />
          <ModeToggle />
        </div>
      </nav>
    </div>
  )
}
