import { useState } from "react";
import { hideIfNull,
        showIfNull,
        styleFlexRow,
        styleFlexCol } from "./CssHelpers";

import { GameState, useGameState } from "./GameState";
import { TileProps } from "./Tile";

interface MainMenuOption {
    text: string,
    warning: string,
    confirm: string | null,
    cancel: string,
    submitHandler: () => void
} 

export default function MainMenu() {
    const { setGameState } = useGameState();

    const [selectedOption, setSelectedOption] = useState<MainMenuOption | null>(null);

    const options: MainMenuOption[] = [
        {text: "New game", warning: "Are you ready to begin?", confirm: "Start", cancel: "Cancel",
            submitHandler: () => {
                const emptyTile: TileProps = {empty: true, name: "empty tile"}

                const initialGameState: GameState = {
                    grid: { rows:  Array(5)
                                    .fill(null)
                                    .map(() => ({
                                        tiles: Array(5).fill({ ...emptyTile })
                                    }))
                    }
                }

                setGameState(initialGameState);
            }
        }
    ];

    return (
        <>
            <h1 style={showIfNull(selectedOption)}>
                Welcome to Scape Land
            </h1>
            <div>
                <div style={showIfNull(selectedOption)}>
                    <div style={styleFlexCol}>
                        {options.map((option, index) => (
                            <button type="button" key={index} 
                                    onClick={_ => setSelectedOption(option)}
                            >
                                {option.text}
                            </button>
                        ))}
                    </div>
                </div>

                <div style={hideIfNull(selectedOption)}>
                    <p>
                        {selectedOption?.warning}
                    </p>
                    <div style={styleFlexRow}>
                        <button type="button" onClick={selectedOption?.submitHandler}>Continue</button>
                        <button type="button" onClick={() => setSelectedOption(null)}>Go back</button>
                    </div>
                </div>

            </div>
        </>
    );
}
