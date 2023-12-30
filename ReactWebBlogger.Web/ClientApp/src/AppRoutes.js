import { Home } from "./pages/Home";
import { Games } from "./pages/Games";
import { PinballGame, PlatformerGame, TownVespaGame } from './components/Splines/CustomSplines.js';
const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/games',
    element: <Games />
  },
  {
    path: '/blogs',
    element: <div />
  },
  {
    path: '/games/ToonPinball',
    element: <PinballGame />
  },
  {
    path: '/games/Platformer',
    element: <PlatformerGame />
  },
  {
    path: '/games/TownVespa',
    element: <TownVespaGame />
  }
];

export default AppRoutes;
