import './App.css';
import Game from './Game';
import { GameStateProvider } from './GameState';

function App() {
    return (
        <GameStateProvider>
            <Game />
        </GameStateProvider>
    );
}

export default App
