import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Profile from "./Components/Profile";
import Session from "./Components/Session";
import "./Include/bootstrap";

const App = () => (
  <Router>
    <Switch>
      <Route exact path="/" component={Profile} />
      <Route path="/session/:sessionId" component={Session} />
    </Switch>
  </Router>
);

export default App;
