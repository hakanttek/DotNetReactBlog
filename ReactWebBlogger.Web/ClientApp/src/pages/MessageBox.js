import React, { Component } from 'react';

export class MessageBox extends Component {
  static displayName = "Messages";

  constructor(props) {
    super(props);
    this.state = {
      messages: [], // Store messages retrieved from the API
    };
  }

  componentDidMount() {
    // Fetch messages from the API when the component mounts
    this.fetchMessages();
  }

  fetchMessages = () => {
    fetch('/api/Message')
      .then(response => response.json())
      .then(data => this.setState({ messages: data }))
      .catch(error => console.error('Error fetching messages:', error));
  }

  handleDelete = (id) => {
    // Send a DELETE request to delete the message by ID
    fetch(`/api/Message/${id}`, {
      method: 'DELETE',
    })
      .then(response => {
        if (response.ok) {
          // If the deletion is successful, fetch messages again to update the table
          this.fetchMessages();
        } else {
          console.error('Error deleting message:', response.statusText);
        }
      })
      .catch(error => console.error('Error deleting message:', error));
  }

  render() {
    const { messages } = this.state;

    return (
      <div className="container">
        <h1>Messages</h1>
        <table className="table table-striped">
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
              <th>Message</th>
              <th>Date Sent</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {messages.map((message, index) => (
              <tr key={index}>
                <td>{message.name}</td>
                <td>{message.emailAddress}</td>
                <td>{message.messageContent}</td>
                <td>{new Date(message.dateSent).toLocaleString()}</td>
                <td>
                  <button
                    className="btn btn-danger"
                    onClick={() => this.handleDelete(message.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}
