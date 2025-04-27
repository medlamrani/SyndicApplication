import { Component, inject, OnInit } from '@angular/core';
<<<<<<< HEAD
import { Residence } from '../_models/residence';
import { AccountService } from '../_services/account.service';
import { ResidenceService } from '../_services/residence.service';
import { HttpClient } from '@angular/common/http';
import { NgIf } from '@angular/common';
import { environment } from '../../environments/environment';
=======
import { AccountService } from '../_services/account.service';
import { HttpClient } from '@angular/common/http';
>>>>>>> aeacc977a8d55892f6d9f8bbb55a24101f1a38bb

@Component({
  selector: 'app-manager',
  standalone: true,
  imports: [NgIf],
  templateUrl: './manager.component.html',
  styleUrl: './manager.component.css'
})
<<<<<<< HEAD
export class ManagerComponent implements OnInit{
  http = inject(HttpClient);
  url = environment.apiUrl;
  accountService = inject(AccountService);
  residenceService = inject(ResidenceService);
  user = this.accountService.currentUser();
  residences: any;
  immeubles: any;
  dashboardData: any;

  ngOnInit(): void {
    this.getResidence();
    console.log(this.user);
  }

  getResidence(){
    this.http.get('https://localhost:6001/api/residence/dashboard').subscribe({
      next: response => this.dashboardData = response,
      error: error => console.log(error),
      complete: () => console.log('Request has completed')
    })  
=======
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
>>>>>>> aeacc977a8d55892f6d9f8bbb55a24101f1a38bb
  }

}
