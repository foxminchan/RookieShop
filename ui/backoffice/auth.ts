import NextAuth from "next-auth";
import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6";

export const { handlers, auth, signIn, signOut } = NextAuth({
  providers: [
    DuendeIDS6Provider({
      issuer: process.env.AUTH_DUENDE_IDENTITY_SERVER6_ISSUER,
      clientId: process.env.AUTH_DUENDE_IDENTITY_SERVER6_ID,
      clientSecret: process.env.AUTH_DUENDE_IDENTITY_SERVER6_SECRET,
      authorization: { params: { scope: "openid All" } },
    }),
  ],
});
