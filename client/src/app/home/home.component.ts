import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { AccountService } from '../_services/account.service';
import { DefaultComponent } from "../default/default.component";
import { ManagerComponent } from "../manager/manager.component";
import { AdminComponent } from "../admin/admin.component";
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent, DefaultComponent, ManagerComponent, AdminComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  http = inject(HttpClient);
  accountService = inject(AccountService);
  registerMode = false;
  url = environment.apiUrl;
  users: any;
  

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode= event;
  }

  getUsers() {
    this.http.get(this.url + 'users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })  
  }
}
