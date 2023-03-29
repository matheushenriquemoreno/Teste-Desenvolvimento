import { Modal } from 'bootstrap';


export function ValidaFormularioVazio(): boolean {
    let result: boolean = false;
    var form: any = document.querySelector('form.needs-validation');
  
    form!.classList.add('was-validated');
  
    if (form!.checkValidity()) {
      form!.classList.remove('was-validated');
      result = true
    }
  
    return result
  }
  
  export function MostrarModal(idModal: string, mostrar: boolean = true) {
    const elemento: any = document.querySelector(`#${idModal}`)
    const modal = Modal.getOrCreateInstance(elemento);
    if (mostrar) {
      modal.show()
    } else {
      modal.hide()
    }
  }