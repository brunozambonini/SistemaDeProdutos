import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  public buscaForm: FormGroup;

  procurarSubmit(){
      this.buscaForm.get.name;
      console.log(this.buscaForm.get.name);
  }
  criarForm(){
    this.buscaForm = this.fb.group({
      nome: [''],
    });
  }

  constructor(private fb: FormBuilder, 
    private modalService: BsModalService) {
    this.criarForm();
   }

  ngOnInit() {
  }

}
