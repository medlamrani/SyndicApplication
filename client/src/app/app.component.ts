import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from "./home/home.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent, RegisterComponent, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  title = 'My Residence';
  users: any;
  registerMode: any;

  ngOnInit(): void {
    this.http.get('https://localhost:6001/api/users').subscribe({
      next: res => this.users = res,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    })
  }
}
