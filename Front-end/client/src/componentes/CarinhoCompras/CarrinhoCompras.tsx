import React, { useEffect, useState } from 'react';
import { MinusOutlined, CloseOutlined, PlusCircleOutlined } from '@ant-design/icons';
import { Avatar, Card, Space } from 'antd';
import { Button, Drawer } from 'antd';
import "./style.css"
import { ItemCarrinho } from "../../Interfaces/Produto";
import { formatarPreco } from '../../Helpers/Utilitarios';

interface propsCarrinhoCompra {
    classCarrinho?: string,
    itensCarrinho: ItemCarrinho[],
    aumentarQuantidadeItem(idProduto: number): void,
    excluirProduto(idProduto: number): void,
    diminuirQuantidade(idProduto: number): void,
    aoFinalizarCompra(): void
}

const { Meta } = Card;


const CarrinhoCompras = ({ classCarrinho, itensCarrinho, aumentarQuantidadeItem, excluirProduto, diminuirQuantidade, aoFinalizarCompra }: propsCarrinhoCompra) => {
    const [valorTotal, setValorTotal] = useState<number>(0);
    const [open, setOpen] = useState(false);
    const [isLoading, setIsloading] = useState(false);

    const showDrawer = () => {
        setOpen(true);
    };

    const onClose = () => {
        setOpen(false);
    };


    function finalizarCompra() {
        onClose()
        aoFinalizarCompra()
    }

    useEffect(() => {
        setIsloading(true)

        const total = itensCarrinho.reduce((sum, item) => {
            const valorPedido = item.Produto.valor * item.quantidadeItens;
            return sum += valorPedido
        }, 0)
        setValorTotal(total);

        setTimeout(() => {
            setIsloading(false)
        }, 500);


    }, [itensCarrinho])

    return (
        <div className={classCarrinho}>
            <Button loading={isLoading} type="primary" onClick={showDrawer} className=' align-content-end'>
                <i className="bi bi-cart-check"> Carrinho {itensCarrinho.length}</i>
            </Button>

            <Drawer className='teste' title="Carrinho" placement="right" onClose={onClose} open={open} size='large'
                extra={
                    <Space>
                        <Button onClick={finalizarCompra} type="primary">
                            Finalizar compra
                        </Button>
                    </Space>
                }
            >
                <div>
                    <span className='mb-0 text-sm text-dark'>Sub Total: </span> <b>{formatarPreco(valorTotal)}</b>
                </div>
                <hr />

                <div className='row row-cols-2 justify-content-center'>
                    {itensCarrinho.map(item => {
                        return (

                            <Card className='col m-1 shadow' key={item.idProduto} style={{ width: 300, marginTop: 16 }}
                                actions={[
                                    <PlusCircleOutlined key={"Aumentar"} onClick={() => aumentarQuantidadeItem(item.idProduto)} />,
                                    <MinusOutlined key={"Diminuir"} onClick={() => diminuirQuantidade(item.idProduto)} />,
                                    <CloseOutlined key={"Excluir"} onClick={() => excluirProduto(item.idProduto)} />,
                                ]}
                            >
                                <Meta
                                    avatar={<Avatar src="https://www.freepnglogos.com/uploads/box-png/closed-square-cardboard-box-transparent-png-svg-vector-35.png" />}
                                    title={item.Produto.nomeProduto}
                                    description={<>
                                        <div>
                                            <small className='text-sm'>Quantidade: <b>{item.quantidadeItens}</b></small>
                                            <br></br>
                                            <small className='text-sm'>valor unitario: <b>{formatarPreco(item.Produto.valor)}</b></small>
                                        </div>
                                    </>}
                                />
                            </Card>
                        )
                    })}
                </div>

            </Drawer>

        </div>
    )
}



export default CarrinhoCompras;
