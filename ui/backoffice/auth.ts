import NextAuth from "next-auth"
import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6"

export const { handlers, auth, signIn, signOut } = NextAuth({
  providers: [
    DuendeIDS6Provider({
      clientId: "interactive.confidential",
      clientSecret: "secret",
      issuer: "https://demo.duendesoftware.com",
    }),
  ],
})
