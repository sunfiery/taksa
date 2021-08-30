import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './pupils.component.html',
})
export class PupilsComponent {
  baseUrl;
  active = 1;
  public filiations: Filiation[];
  closeResult = '';
  filiationForm = this.fb.group({
    name: '',
    address: ''
  });

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private modalService: NgbModal,
    private fb: FormBuilder,
  ) {

    this.baseUrl = baseUrl;

    http.get<Filiation[]>(baseUrl + 'api/filiation').subscribe(result => {
      this.filiations = result;
    }, error => console.error(error));
  }

  close(event: MouseEvent, toRemove: number) {

  }

  add(event: MouseEvent) {
    event.preventDefault();
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

    event.preventDefault();
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  onSubmit(): void {
    //var formData: any = new FormData();
    //formData.append("name", this.filiationForm.get('name').value);
    //formData.append("address", this.filiationForm.get('address').value);

    var data = {
      name: this.filiationForm.get('name').value,
      address: this.filiationForm.get('address').value
    };

    this.http.post<Filiation>(this.baseUrl + 'api/filiation', data).subscribe(
      (response) => console.log(response),
      (error) => console.log(error)
    );

    console.warn('Your order has been submitted', this.filiationForm.value);
    this.filiationForm.reset();
  }
}

interface Filiation {
  id: number;
  name: string;
  address: string;
}
