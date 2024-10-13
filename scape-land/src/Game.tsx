import { useGameState } from "./GameState";
import Grid from "./Grid";
import MainMenu from "./MainMenu";

export default function Game() {
    const { gameState } = useGameState();

    if (gameState === null) {
        return (
            <>
                <MainMenu />
            </>
        );
    } else {
        return (
            <Grid rows={gameState.grid.rows} />
        );
    }
}
