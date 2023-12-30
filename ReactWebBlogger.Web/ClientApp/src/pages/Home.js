import React, { Component } from 'react';
import { DeveloperMan } from '../components/Splines/CustomSplines';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        {/* Shorter Coming Soon Message */}
        <div className="coming-soon" style={{ textAlign: 'center', padding: '20px' }}>
          <h2 style={{ fontSize: '2.5rem', color: '#007bff' }}>Coming soon!</h2>
          <p style={{ fontSize: '1.2rem' }}>
            Thank you for visiting! Exciting updates are on the way.  While you're here,
            feel free to check out the <a href='/games' style={{ color: '#28a745', textDecoration: 'none' }}>games</a>.
          </p>
        </div>
        <DeveloperMan />
      </div>
    );
  }
}
