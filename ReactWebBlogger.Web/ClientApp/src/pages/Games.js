import React, { Component } from 'react';
import { GameCard } from '../components/GameCard.js';

export class Games extends Component {
  static displayName = Games.name;

  render() {
    return (
      <div className='row'>
        <div className="col-md-3">
          <GameCard 
            imageSource={'img/ToonPinball_icon.png'} 
            name={'Pinball'} 
            description={'An exciting pinball adventure with a cartoon twist.'}
            gameLink={'/games/ToonPinball'} 
          />
        </div>
        <div className="col-md-3">
          <GameCard 
            imageSource={'img/Platformer_icon.png'} 
            name={'Platformer'} 
            description={'Jump and run through challenging platforms.'}
            gameLink={'/games/Platformer'} 
          />
        </div>
        <div className="col-md-3">
          <GameCard 
            imageSource={'img/TownVespa_icon.png'} 
            name={'Town Vespa'} 
            description={'Explore the town in this fun Vespa ride.'}
            gameLink={'/games/TownVespa'} 
          />
        </div>
      </div>
    );
  }
}
