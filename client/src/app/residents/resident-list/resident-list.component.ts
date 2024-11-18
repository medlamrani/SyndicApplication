import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-resident-list',
  standalone: true,
  imports: [],
  templateUrl: './resident-list.component.html',
  styleUrl: './resident-list.component.css'
})
export class ResidentListComponent {
  http = inject(HttpClient);
  users: any;

  ngOnInit(): void {
    this.http.get('https://localhost:6001/api/users').subscribe({
      next: res => this.users = res,
      error: error => console.log(error),
      complete: () => console.log("Complete")
    })
  }
}
