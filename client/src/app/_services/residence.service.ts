import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { AccountService } from './account.service';
import { Residence } from '../_models/residence';

@Injectable({
  providedIn: 'root'
})
export class ResidenceService {
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  baseUrl = 'https://localhost:6001/api/';
  user = this.accountService.currentUser();

  getResidence(residence: number) {
    return this.http.get<Residence>(this.baseUrl + 'residence/' + residence);
  }

  getDashboard() {
    return this.http.get(this.baseUrl + 'residence/dashboard');
  }
  
}
