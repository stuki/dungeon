import { WebAuth } from "auth0-js";

const auth0 = new WebAuth({
  domain: "dungeon.eu.auth0.com",
  clientID: "XwWlfFY1kpgSi8e14bZKIDI18rIVXLRT",
  redirectUri: "https://localhost:5001/",
  responseType: "token"
});

export const LOGIN_USER = "users:loginUser";
export const LOGOUT_USER = "users:logoutUser";
export const LOGIN_ERROR = "LOGIN_ERROR";

export function loginUser() {
  const hash = auth0.parseHash(window.location.hash);
  if (hash && hash.error) {
    return {
      type: LOGIN_ERROR,
      payload: {
        error: { title: hash.error, description: hash.error_description }
      }
    };
  }
  return {
    type: LOGIN_USER,
    payload: {
      id_token: hash.idToken
    }
  };
}

export function logoutUser(newUser) {
  return {
    type: LOGOUT_USER,
    payload: {
      id_token: null
    }
  };
}
