import React, { Component } from 'react';

export class Login extends Component {
  static displayName = "Blogs";

  constructor(props) {
    super(props);
    this.state = {
      username: '',
      password: '',
      isLoggedIn: false,
      errorMessage: ''
    };
  }

  handleInputChange = (event) => {
    const { name, value } = event.target;
    this.setState({ [name]: value });
  }

  handleLogin = async (event) => {
    event.preventDefault();
    const { username, password } = this.state;
    console.log(`${JSON.stringify({ username, password })}`)
    try {
      const response = await fetch('/api/Login/in', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, password })
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.text();

      this.setState({ isLoggedIn: true, errorMessage: '' });
      // Handle success (e.g., store the logged-in user's info, redirect, etc.)
    } catch (error) {
      console.error('Login failed:', error);
      this.setState({ errorMessage: 'Login failed. Please try again.' });
      // Handle error (e.g., show error message)
    }
  }

  handleLogout = async () => {
    try {
      const response = await fetch('/api/Login/out', { method: 'POST' });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.text();
      console.log(data);
      this.setState({ isLoggedIn: false });
      // Handle success (e.g., remove the user's info, redirect, etc.)
    } catch (error) {
      console.error('Logout failed:', error);
      // Handle error
    }
  }

  render() {
    const { username, password, isLoggedIn, errorMessage } = this.state;

    return (
      <div className="container mt-5">
        {!isLoggedIn ? (
          <form onSubmit={this.handleLogin}>
            <div className="mb-3">
              <label htmlFor="username" className="form-label">Username</label>
              <input
                type="text"
                className="form-control"
                id="username"
                name="username"
                value={username}
                onChange={this.handleInputChange}
                required
              />
            </div>
            <div className="mb-3">
              <label htmlFor="password" className="form-label">Password</label>
              <input
                type="password"
                className="form-control"
                id="password"
                name="password"
                value={password}
                onChange={this.handleInputChange}
                required
              />
            </div>
            {errorMessage && <div className="alert alert-danger">{errorMessage}</div>}
            <button type="submit" className="btn btn-primary">Login</button>
          </form>
        ) : (
          <div>
            <p>You are logged in!</p>
            <button onClick={this.handleLogout} className="btn btn-danger">Logout</button>
          </div>
        )}
      </div>
    );
  }
}
