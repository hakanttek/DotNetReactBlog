import React, { Component } from 'react';
import { DeveloperMan } from '../components/SplineViewers/CustomSplines';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        {/* Shorter Coming Soon Message */}
        <div className="introductory-post" style={{ textAlign: 'center', padding: '20px', backgroundColor: '#343a40', borderRadius: '10px', boxShadow: '0 4px 8px rgba(0, 0, 0, 0.2)' }}>
          <h2 style={{ fontSize: '2.5rem', color: '#007bff', marginBottom: '10px' }}>Welcome to My Blog!</h2>
          <p style={{ fontSize: '1.2rem', color: '#fff', lineHeight: '1.5' }}>
            Explore the world of software development with me. I share insights, updates, and my passion for open-source games designed with Spline Design.
            <br /><br />
            Stay tuned for exciting updates and game development progress. Your feedback is welcome through the <a href="/contact" style={{ color: '#28a745', textDecoration: 'none', fontWeight: 'bold' }}>contact page</a>.
          </p>
        </div>
        <DeveloperMan />
      </div>
    );
  }
}