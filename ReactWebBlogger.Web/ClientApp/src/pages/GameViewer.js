import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import SplineViewer from '../components/SplineViewers/SplineViewer'; // Assuming you have a SplineViewer component

const GameViewer = ({ gameId }) => {
  const [game, setGame] = useState(null);
  const { id: routeGameId } = useParams(); // Extract gameId from URL if available
  const effectiveGameId = gameId || routeGameId; // Use the prop if available, otherwise use the route parameter

  useEffect(() => {
    const fetchGame = async () => {
      try {
        const res = await fetch(`api/game/${effectiveGameId}/`); // Use effectiveGameId to fetch game data
        const data = await res.json();
        setGame(data);
      } catch (error) {
        console.error('Failed to fetch game:', error);
      }
    };

    if (effectiveGameId) {
      fetchGame();
    }
  }, [effectiveGameId]);

  if (!game) {
    return <div>Loading...</div>;
  }

  return (
    <SplineViewer url={game.url} />
  );
};

export default GameViewer;