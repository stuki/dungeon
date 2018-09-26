import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import MDSpinner from "react-md-spinner";
import {
  FormGroup,
  FormControl,
  Form,
  ControlLabel,
  HelpBlock,
  Button
} from "react-bootstrap";
import { WebAuth } from "auth0-js";
import { updateUser } from "../../Common/Actions/userActions";
import Api from "../../Common/Api";
import "./Login.css";

const auth0 = new WebAuth({
  domain: "dungeon.eu.auth0.com",
  clientID: 'XwWlfFY1kpgSi8e14bZKIDI18rIVXLRT',
  redirectUri: "https://localhost:5001/",
  responseType: 'token'
});

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      name: "",
      email: "",
      register: false,
      isLoading: false
    };
    this.onUpdateUser = this.onUpdateUser.bind(this);
  }

  onUpdateUser(user) {
    const { onUpdateUser } = this.props;

    onUpdateUser(user);
  }

  handleChange = e => {
    this.setState({ email: e.target.value });
  };

  login = async e => {
    e.preventDefault();

    const { email } = this.state;

    auth0.passwordlessStart({
      connection: 'email',
      email: email,
      redirectUri: 'https://localhost:5001/account/',
      send: 'link'
    }, (err, res) => console.log(err, res));

    // const { handleLogin } = this.props;

    // if (name) {
    //   const player = await Api.getPlayer(name);
    //   if (player !== undefined) {
    //     this.onUpdateUser(player);
    //     setTimeout(() => handleLogin(), 500);
    //   } else {
    //     this.setState({ register: true });
    //   }
    // }
  };

  register = async e => {
    e.preventDefault();
    const player = this.state;
    delete player.register;
    if (player.name) {
      Api.createPlayer(player);
      this.setState({ isLoading: true });
      setTimeout(() => this.login(e), 500);
    }
  };

  render() {
    const { register, email, name } = this.state;
    const { isLoading } = this.state;

    if (isLoading) {
      return (
        <MDSpinner
          color1="#e91e63"
          color2="#673ab7"
          color3="#009688"
          color4="#ff5722"
          className="spinner"
        />
      );
    }
    return (
      <div id="login">
        {!register && (
          <Form onSubmit={this.login}>
            <h1 id="title">Dungeon</h1>
            <FieldGroup
              id="name"
              type="text"
              label="Username"
              value={email}
              onChange={this.handleChange}
              bsSize="large"
            />
            <Button type="submit">Login</Button>
          </Form>
        )}
        {register && (
          <Form onSubmit={this.register}>
            <FieldGroup
              id="name"
              type="text"
              label="Username"
              value={name}
              onChange={this.handleChange}
            />
            <Button type="submit">Register</Button>
          </Form>
        )}
      </div>
    );
  }
}

function FieldGroup({ id, label, help, ...props }) {
  return (
    <FormGroup controlId={id}>
      <ControlLabel>{label}</ControlLabel>
      <FormControl {...props} />
      {help && <HelpBlock>{help}</HelpBlock>}
    </FormGroup>
  );
}

Login.propTypes = {
  user: PropTypes.shape({
    id: PropTypes.number,
    name: PropTypes.string
  }).isRequired,
  onUpdateUser: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
  user: state.user
});

const mapActionsToProps = {
  onUpdateUser: updateUser
};

export default connect(
  mapStateToProps,
  mapActionsToProps
)(Login);
