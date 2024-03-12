import { Home } from "./pages/Home";
import { Games } from "./pages/Games";
import {Blogs} from "./pages/Blogs.js";
import {Contact} from "./pages/Contact.js";
import GameViewer from './pages/GameViewer.js';
import BlogViewer from "./pages/BlogViewer.js";
import { Login } from "./pages/Login.js";
import { MessageBox } from "./pages/MessageBox.js";
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
    element: <Blogs />
  },
  {
    path: '/games/:id',
    element: <GameViewer/>
  },
  {
    path: '/blogs/:id',
    element: <BlogViewer/>
  },
  {
    path: '/contact',
    element: <Contact/>
  },
  {
    path: '/login',
    element: <Login/>
  },
  {
    path: '/messagebox',
    element: <MessageBox/>
  }
];

export default AppRoutes;
