import React, { Component } from "react";
import PropTypes from "prop-types";
import { Grid } from "react-bootstrap";
import { connect } from "react-redux";
import { loginUser } from "../../Common/Actions/userActions";
import SessionList from "./SessionList";
import NavigationBar from "../Common/NavigationBar";
import Login from "../Common/Login";

class Profile extends Component {
  constructor(props) {
    super(props);
    this.state = {
      player: props.user
    };
  }

  handleLogin = () => {
    const { user } = this.props;
    this.setState({ player: user });
  };

  handleLogout = () => {
    const { onUpdateUser } = this.props;
    onUpdateUser(null);
    this.setState({ player: null });
  };

  render() {
    const { player } = this.state;
    console.log(player);

    if (!player) {
      return <Login handleLogin={this.handleLogin} />;
    }
    return (
      <div>
        <NavigationBar handleLogout={this.handleLogout} />
        <Grid>
          <SessionList />
        </Grid>
      </div>
    );
  }
}

Profile.propTypes = {
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
)(Profile);
