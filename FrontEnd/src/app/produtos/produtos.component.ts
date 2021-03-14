import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Produto } from '../models/produto';
import { ProdutoService } from './produto.service';
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {

  public title = 'Produtos';
  public produtoForm: FormGroup;
  public produtoSelecionado: Produto;
  public modalRef: BsModalRef;
  public produtos: Produto[];
  public filterPost = '';
  public page: number = 1;
  public pageSize: number = 10;

  produtoSelect(produto : Produto){
    this.produtoSelecionado = produto;
    this.produtoForm.patchValue(produto);
  }

  produtoNovo(){
    this.produtoSelecionado = new Produto();
    this.produtoForm.patchValue(this.produtoSelecionado);
  }

  salvarProduto(produto: Produto) {
    console.log(produto);
    this.produtoService.post(produto).subscribe(
      (retorno: Produto) => {
        console.log(retorno);
        this.carregarProdutos();
      },
      (erro: any) => {
        console.log(erro) ;
      }
    );
  }
  produtoSubmit(){
    this.salvarProduto(this.produtoForm.value);
  }

  deletar(id: Number){
    this.produtoService.delete(id).subscribe(
      (model) => {
        console.log(model)
        this.carregarProdutos();
      },
      (erro: any) => {
        console.error(erro)
      }
    )
  }

  voltar(){
    this.produtoSelecionado = null;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit(){
    this.carregarProdutos();
  }
  
  carregarProdutos(){
    this.produtoService.getAll().subscribe(
      (produtos: Produto[]) => { // Se der certo
        this.produtos = produtos;
      },
      (erro: any) => { // Caso dê algum erro
        console.error(erro);
      }
      )
    }

    constructor(private fb: FormBuilder, 
      private modalService: BsModalService,
      private produtoService: ProdutoService) {
      this.criarForm();
     }
    
  criarForm(){
    this.produtoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      preco: ['', Validators.required]
    });
  }

}
