import React, { Component } from 'react';

export class Contact extends Component {
  static displayName = Contact.name;

  constructor(props) {
    super(props);
    const num1 = Math.floor(Math.random() * 10);
    const num2 = Math.floor(Math.random() * 10);
    this.state = {
      name: "",
      emailAddress: "",
      messageContent: "",
      captchaQuestion: `${num1} + ${num2} = ?`,
      captchaAnswer: num1 + num2,
      userCaptchaInput: ''
    };
  }

  handleChange = (event) => {
    this.setState({ [event.target.name]: event.target.value });
  }

  handleSubmit = async (event) => {
    event.preventDefault();

    if (parseInt(this.state.userCaptchaInput) !== this.state.captchaAnswer) {
      this.setState({ responseMessage: "Incorrect answer, please solve the math question." })
      return;
    }

    // Define the API endpoint
    const apiUrl = 'api/message/';
    const { name, emailAddress, messageContent } = this.state;

    try {
      const response = await fetch(apiUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, emailAddress, messageContent })
      });

      if (response.status === 400) {
        var resMsg = await response.json();
    
        // Extract the errors object
        const errors = resMsg.errors;
    
        // Create an array to hold all error messages
        let errorMessages = [];
    
        // Iterate over each key in the errors object
        for (let field in errors) {
            if (errors.hasOwnProperty(field)) {
                // For each field, get its error messages and add them to the errorMessages array
                errors[field].forEach(error => {
                    errorMessages.push(`${error}`);
                });
            }
        }
    
        // Convert the array of error messages into a string
        const errorMessageString = errorMessages.join('\n');
    
        // Update the component's state with the error messages
        this.setState({
            responseMessage: `Incomplete or incorrect information: ${errorMessageString}` 
        });
    }
    
      else if (!response.ok) {
        var resMsg = await response.text()
        this.setState({
          responseMessage: `${resMsg}` // Update response message
        });
      } else {
        var resMsg = await response.text()
        this.setState({
          responseMessage: resMsg
        });

        const num1 = Math.floor(Math.random() * 100);
        const num2 = Math.floor(Math.random() * 10);
        // Clear the form fields
        this.setState({
          name: '',
          emailAddress: '',
          messageContent: '',
          captchaQuestion: `${num1} + ${num2} = ?`,
          captchaAnswer: num1 + num2,
          userCaptchaInput: ''
        });

        // Set a timeout to clear the message after 3 seconds
        setTimeout(() => {
          this.setState({ responseMessage: '' });
        }, 3000);
      }
    } catch (error) {
      console.error('Error sending message:', error);
      this.setState({
        responseMessage: 'An unexpected error occurred. You can contact me directly via my e-mail address (hakanttek@gmail.com).' // Update response message
      });
    }
  }

  render() {
    return (
      <div className="container mt-4">
        <h2>Contact Us</h2>
        <p>If you prefer, you can also contact me directly at <a href="mailto:hakanttek@gmail.com">hakanttek@gmail.com</a>.</p>
        {this.state.responseMessage && <div className="alert alert-info">{this.state.responseMessage}</div>}
        <form onSubmit={this.handleSubmit}>
          <div className="form-group mb-3">
            <label>Name</label>
            <input type="text" className="form-control" name="name" value={this.state.name} onChange={this.handleChange} />
          </div>
          <div className="form-group mb-3">
            <label>Email address</label>
            <input type="email" className="form-control" name="emailAddress" value={this.state.emailAddress} onChange={this.handleChange} />
          </div>
          <div className="form-group mb-3">
            <label>Message</label>
            <textarea className="form-control" name="messageContent" rows="3" value={this.state.messageContent} onChange={this.handleChange}></textarea>
          </div>
          <div className="form-group mb-3 d-flex align-items-center">
            <button type='submit' className="btn btn-primary ml-2">Submit</button>
            <input style={{ width: '240px', marginLeft:'10px'}}  type="text" className="form-control" placeholder={`Security question: ${this.state.captchaQuestion}`} name="userCaptchaInput" value={this.state.userCaptchaInput} onChange={this.handleChange} />
          </div>
        </form>
      </div>

    );
  }
}
