import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbModal, ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './pupils.component.html',
})
export class PupilsComponent {
  baseUrl;
  filationModalRef;
  groupModalRef;
  pupilModalRef;
  active = 1;
  public filiations: Filiation[];
  closeResult = '';
  filiationForm = this.fb.group({
    name: '',
    address: ''
  });

  groupForm = this.fb.group({
    name: '',
    description: ''
  });

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private modalService: NgbModal,
    private fb: FormBuilder
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

  openFilationModal(content) {
    this.filationModalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    this.filationModalRef.result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

    event.preventDefault();
  }

  openGroupModal(content, filationID) {
    this.groupModalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    this.groupModalRef.result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

    event.preventDefault();
  }

  openPupilModal(content) {
    this.pupilModalRef = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    this.pupilModalRef.result.then((result) => {
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

  onFilationSubmit(): void {

    var data = {
      name: this.filiationForm.get('name').value,
      address: this.filiationForm.get('address').value
    };

    this.http.post<Filiation>(this.baseUrl + 'api/filiation', data).subscribe(
      (response) => {
        console.log(response);
        this.filationModalRef.close();
      },
      (error) => {
        console.log(error);
      }
    );

    console.warn('Your order has been submitted', this.filiationForm.value);
    this.filiationForm.reset();
  }

  onGroupSubmit(): void {

    var data = {
      name: this.groupForm.get('name').value,
      description: this.groupForm.get('description').value
    };

    this.http.post<Group>(this.baseUrl + 'api/group', data).subscribe(
      (response) => {
        console.log(response);
        this.groupModalRef.close();
      },
      (error) => {
        console.log(error);
      }
    );

    console.warn('Your order has been submitted', this.groupForm.value);
    this.groupForm.reset();
  }
}

interface Filiation {
  id: number;
  name: string;
  address: string;
}

interface Group {
  id: number;
  name: string;
  description: string;
}
