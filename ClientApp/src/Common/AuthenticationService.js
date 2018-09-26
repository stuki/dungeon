import { WebAuth } from "auth0-js";

const Authentication = new WebAuth({
  domain: "dungeon.eu.auth0.com",
  clientID: 'XwWlfFY1kpgSi8e14bZKIDI18rIVXLRT',
  redirectUri: "https://localhost:5001/",
  responseType: 'token'
});

export default Authentication;