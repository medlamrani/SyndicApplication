import { Component } from '@angular/core';
import { AppComponent } from '../app.component';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [AppComponent, RegisterComponent],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  registerMode = false;

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
