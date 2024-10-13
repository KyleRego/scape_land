import Tile, { TileProps } from "./Tile"


export interface GridRowProps {
    tiles: TileProps[]
}

export default function GridRow({tiles} : GridRowProps) {
    const tileElements = tiles.map((t, i) => {
        return <Tile key={i} empty={t.empty} name={t.name} />
    });

    return <div style={{border: '1px solid blue'}}>
        {tileElements}
    </div>
}
