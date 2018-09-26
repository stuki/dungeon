import React, { Component } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import {
  FormGroup,
  FormControl,
  Button,
  Form,
  InputGroup,
  Glyphicon
} from "react-bootstrap";
import Api from "../../../Common/Api";
import "./CreateLog.css";

class CreateLog extends Component {
  constructor(props) {
    super(props);
    this.state = {
      tag: "",
      message: "",
      sessionId: props.sessionId,
      playerId: props.user.id
    };
  }

  handleSubmit = e => {
    const { updateLogs } = this.props;

    e.preventDefault();
    Api.createLog(this.state);
    setTimeout(() => updateLogs(), 500);
    this.setState({ label: "", text: "" });
  };

  handleChange(property) {
    return e => {
      this.setState({
        [property]: e.target.value
      });
    };
  }

  render() {
    const { text } = this.state;

    return (
      <div>
        <div className="createLog">
          <Form inline onSubmit={this.handleSubmit}>
            <FormGroup controlId="formInlineLogText">
              <InputGroup>
                <FormControl
                  id="newLogText"
                  type="text"
                  value={text}
                  autoComplete="off"
                  placeholder="Write a log text"
                  onChange={this.handleChange("text")}
                />
                <InputGroup.Button>
                  <Button type="submit">
                    <Glyphicon glyph="send" />
                  </Button>
                </InputGroup.Button>
              </InputGroup>
            </FormGroup>
          </Form>
        </div>
      </div>
    );
  }
}

CreateLog.propTypes = {
  sessionId: PropTypes.string.isRequired,
  user: PropTypes.shape({
    id: PropTypes.number,
    name: PropTypes.string
  }).isRequired,
  updateLogs: PropTypes.func.isRequired
};

const mapStateToProps = state => ({
  user: state.user
});

// mapStateToProps basically receives the state of the store
export default connect(mapStateToProps)(CreateLog);
