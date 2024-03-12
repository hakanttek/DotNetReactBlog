import React, { Component } from 'react';
import { GameCard } from '../components/GameCard.js';

export class Games extends Component {
  static displayName = Games.name;

  constructor(props) {
    super(props);
    this.state = {
      gamesData: [],
      isLoading: true,
      error: null,
    };
  }

  componentDidMount() {
    fetch('/api/game/') // Replace with your actual API endpoint
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then(data => this.setState({ gamesData: data, isLoading: false }))
      .catch(error => this.setState({ error, isLoading: false }));
  }

  renderGameCards() {
    const { gamesData, isLoading, error } = this.state;

    if (isLoading) {
      return <p>Loading games...</p>;
    }

    if (error) {
      return <p>Error loading games: {error.message}</p>;
    }

    return gamesData.map((game, index) => (
      <div key={index} className="col-md-3">
        <GameCard 
          imageSource={game.imageSource} 
          name={game.name} 
          description={game.description}
          url={`games/${game.id}/`} 
        />
      </div>
    ));
  }

  render() {
    return (
      <div className='row'>
        {this.renderGameCards()}
      </div>
    );
  }
}
