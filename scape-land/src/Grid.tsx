import GridRow, { GridRowProps } from "./GridRow";

export interface GridProps {
    rows: GridRowProps[]
}

export default function Grid({rows} : GridProps) {
    const rowElements = rows.map((r, i) => {
        return <GridRow key={i} tiles={r.tiles} />
    });
    
    return <div style={{border: '1px solid red'}}>
        {rowElements}
    </div>
}