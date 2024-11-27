import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { AccountService } from '../_services/account.service';
import { DefaultComponent } from "../default/default.component";
import { ManagerComponent } from "../manager/manager.component";
import { AdminComponent } from "../admin/admin.component";
import { AppComponent } from "../app.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent, DefaultComponent, ManagerComponent, AdminComponent, AppComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  http = inject(HttpClient);
  accountService = inject(AccountService);
  registerMode = false;
  users: any;
  
  
  ngOnInit(): void {
    this.accountService.currentUser();
    console.log(this.accountService.currentUser());
  }

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode= event;
  }

  getUsers() {
    this.http.get('https://localhost:6001/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })  
  }
}
