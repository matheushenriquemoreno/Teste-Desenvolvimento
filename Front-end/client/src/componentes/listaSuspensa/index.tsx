
import React, { useEffect, useState } from 'react'

export type item = {
    id: number,
    value: string
}

interface propsLista {
    label: string,
    itens: item[],
    valor: number,
    aoAlterado(id:number): void 
}

const ListaSuspensa = (props :propsLista) => {
    return (
        <div className='col-12'>
            <label className='form-label'>{props.label}</label>
            <select className='form-select' onChange={(e) => props.aoAlterado(Boolean(parseInt(e.target.value)) ?parseInt(e.target.value) : 0 )} required={true} value={props.valor}>
               <option value="">Selecione</option>
                {props.itens.map(item => <option key={item.id} value={item.id}>{item.value}</option>)}
            </select>
            <div className="invalid-feedback">Campo Obrigatorio</div>
        </div>
    )
}

export default ListaSuspensa