import fetchival from "fetchival";

class Api {
  getPlayer = async name => {
    fetchival(`/api/players/${name}`)
      .get()
      .catch(err => console.log(err));
  };

  createPlayer = player => {
    fetchival("/api/players")
      .post(player)
      .catch(err => console.log(err));
  };

  getSessions = async id =>
    fetchival(`/api/sessions/playerid/${id}`)
      .get()
      .catch(err => console.log(err));

  getSession = async id =>
    fetchival(`/api/sessions/id/${id}`)
      .get()
      .catch(err => console.log(err));

  updateSession = session => {
    fetchival(`/api/sessions/id/${session.id}`)
      .put(session)
      .catch(err => console.log(err));
  };

  createSession = session =>
    fetchival("/api/sessions")
      .post(session)
      .catch(err => console.log(err));

  deleteSession = async id => {
    fetchival(`/api/sessions/${id}/delete`)
      .delete()
      .catch(err => console.log(err));
  };

  joinSession = (id, player) => {
    fetchival(`/api/sessions/${id}/join`)
      .post(player)
      .catch(err => console.log(err));
  };

  getCharacter = async (sessionId, playerId) => {
    fetchival(`/api/sessions/${sessionId}/${playerId}`)
      .get()
      .catch(err => console.log(err));
  };

  updateCharacter = character => {
    fetchival(`/api/sessions/${character.sessionId}/${character.playerId}`)
      .put(character)
      .catch(err => console.log(err));
  };

  createCharacter = character => {
    fetchival(`/api/sessions/${character.sessionId}/characters/create`)
      .post(character)
      .catch(err => console.log(err));
  };

  deleteCharacter = character =>
    fetchival(
      `/api/sessions/${character.sessionId}/characters/${character.id}/delete`
    )
      .delete()
      .catch(err => console.log(err));

  getLogs = async id =>
    fetchival(`/api/sessions/${id}/logs`)
      .get()
      .catch(err => console.log(err));

  updateLog = log => {
    fetchival(`/api/sessions/${log.sessionId}/logs/${log.id}`)
      .put(log)
      .catch(err => console.log(err));
  };

  createLog = log => {
    fetchival(`/api/sessions/${log.sessionId}/logs/create`)
      .post(log)
      .catch(err => console.log(err));
  };
}

export default new Api();
