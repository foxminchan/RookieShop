import DuendeIDS6Provider from "next-auth/providers/duende-identity-server6";

const authOptions = {
  providers: [
    DuendeIDS6Provider({
      clientId: process.env.DUENDE_IDS6_ID ?? "",
      clientSecret: process.env.DUENDE_IDS6_SECRET ?? "",
      issuer: process.env.DUENDE_IDS6_ISSUER,
    }),
  ],
  secret: process.env.AUTH_SECRET,
};

export default authOptions;
