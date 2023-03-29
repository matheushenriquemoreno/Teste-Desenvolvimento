import { notification } from 'antd';

const openNotification = (type: "success" | "error",  titulo: string, descricao: string, aoFechar?: () => void) => {
    notification.open({
        type:type,
        message: titulo,
        description: descricao,
        placement: type === "success" ? "top" : "topRight" ,
        onClose: () => {
            if(aoFechar){
                aoFechar()
            }
        }
    });
};
export default openNotification 