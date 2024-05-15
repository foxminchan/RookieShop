import { AuthOptions } from "next-auth";
import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6";

const authOptions: AuthOptions = {
  providers: [
    DuendeIDS6Provider({
      clientId: process.env.DUENDE_IDS6_ID ?? "",
      clientSecret: process.env.DUENDE_IDS6_SECRET ?? "",
      issuer: process.env.DUENDE_IDS6_ISSUER,
      authorization: { params: { scope: "openid All" } },
    }),
  ],
  secret: process.env.AUTH_SECRET,
  callbacks: {},
};

export default authOptions;
