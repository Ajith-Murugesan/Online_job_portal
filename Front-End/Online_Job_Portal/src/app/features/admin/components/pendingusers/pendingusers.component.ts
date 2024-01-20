import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '../../Services/user-account.service';

@Component({
  selector: 'app-pendingusers',
  templateUrl: './pendingusers.component.html',
  styleUrl: './pendingusers.component.css'
})
export class PendingusersComponent implements OnInit {
  constructor(private service: UserAccountService) {}
  UserDetails!: any;

  ngOnInit(): void {
    this.service.getUsers().subscribe((data) => {
      (this.UserDetails = data.filter(usr=>usr.IsActive===false)), console.log(data);
    });
  }
  UpdateStatus(id:number)
  {
   const response= this.service.updateUserStatus(id).subscribe(usr =>{
    alert("Updated successfully")
   });
 }
}
