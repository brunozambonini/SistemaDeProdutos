import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Produto } from '../models/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  baseUrl = `${environment.mainUrl}/api/produto`

  constructor(private http: HttpClient) { }

  getAll(): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Produto> {
    return this.http.get<Produto>(`${this.baseUrl}/${id}`);
  }

  post(produto: Produto) {
    return this.http.post(`${this.baseUrl}`, produto);
  }

  delete(id: Number) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

}
