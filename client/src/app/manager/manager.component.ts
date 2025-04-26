import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-manager',
  standalone: true,
  imports: [],
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.css'
})
export class ManagerComponent implements OnInit {
  accountService = inject(AccountService);
  http = inject(HttpClient);
  dashboard: any;


  ngOnInit(): void {
    this.getDashboard();
  }


  getDashboard() {
    this.http.get('https://localhost:6001/api/residence/dashboard').subscribe({
        next: response => this.dashboard = response,
        error: error => console.log(error),
        complete: () => console.log('Request has completed')
    })
  }

}
