export function showIfNull(obj: any) {
    return {display: (obj === null ? 'block' : 'none')};
}

export function hideIfNull(obj: any) {
    return {display: (obj === null ? 'none' : 'block')};
}

export const styleFlexRow = {display: 'flex',
                            justifyContent: 'center',
                            columnGap: '1rem'}

export const styleFlexCol = {display: 'flex',
                            justifyContent: 'start',
                            // https://github.com/cssinjs/jss/issues/1344
                            flexDirection: 'column' as 'column',
                            rowGap: '1rem'}
