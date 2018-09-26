import { LOGIN_USER, LOGOUT_USER, LOGIN_ERROR } from "../Actions/userActions";

export default function authReducer(state = "", { type, payload }) {
  switch (type) {
    case LOGIN_USER:
      return payload.user;
    case LOGOUT_USER:
      return payload.user;
    case LOGIN_ERROR:
      return payload.error;
    default:
      return state;
  }
}
