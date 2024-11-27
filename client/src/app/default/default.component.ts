import { Component, inject } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-default',
  standalone: true,
  imports: [],
  templateUrl: './default.component.html',
  styleUrl: './default.component.css'
})
export class DefaultComponent {
accountService = inject(AccountService);

}
