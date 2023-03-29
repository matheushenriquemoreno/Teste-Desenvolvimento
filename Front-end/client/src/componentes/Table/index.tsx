import React from "react";

export interface PropsTable{
    colunas: string[],
    childrem: React.ReactNode,
    classeTR: string 
}

const Table = (props: PropsTable) => {
    return(
        <div className="mb-3 ">
        <table className="table table-striped align-items-center mb-0">
            <thead>
                <tr className={props.classeTR}>
                    {
                        props.colunas.map( item => {
                            return (
                            <>
                                <th className="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">
                                {item} 
                                </th>
                            </>)
                        })
                    }
                </tr>
            </thead>
            <tbody>
                {props.childrem}
            </tbody>
        </table>
    </div>
    )
}


export default Table;


