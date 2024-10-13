export interface TileProps {
    empty: boolean,
    name: string
}

export default function Tile({empty, name} : TileProps) {
    const sideLength: string = '100px';

    return <div style={{border: '1px solid green',
                        display: 'inline-block',
                        width: sideLength,
                        height: sideLength}}>
        {name} - {empty}
    </div>
}
