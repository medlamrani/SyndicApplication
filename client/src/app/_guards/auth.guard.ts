import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';

import { inject } from '@angular/core';

export const authGuard: CanActivateFn = () => {
  const accountService = inject(AccountService);
  if(accountService.currentUser()) {
    toastr.success('You are logged in');
    return true;
  } else {
    //toastr.error('You shall not pass !');
    return false;
  } 
};
