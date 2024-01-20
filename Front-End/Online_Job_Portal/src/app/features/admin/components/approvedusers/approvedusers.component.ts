import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '../../Services/user-account.service';

@Component({
  selector: 'app-approvedusers',
  templateUrl: './approvedusers.component.html',
  styleUrl: './approvedusers.component.css'
})
export class ApprovedusersComponent implements OnInit {
  constructor(private service: UserAccountService) {}
  UserDetails!: any;

  ngOnInit(): void {
    this.service.getUsers().subscribe((data) => {
      (this.UserDetails = data.filter(usr=>usr.IsActive===true)), console.log(data);
    });
  }
  UpdateStatus(id:number)
  {
   const response= this.service.updateUserStatus(id).subscribe(usr =>alert(usr.toString()));
 }
}
