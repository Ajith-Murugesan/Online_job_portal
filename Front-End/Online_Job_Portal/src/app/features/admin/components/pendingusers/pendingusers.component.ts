import { Component, OnInit } from '@angular/core';
import { UserAccountService } from '../../Services/user-account.service';
import { IUpdatestatus } from '../../Services/Models/IUpdatestatus';
import { IFeedback } from '../../Services/Models/IFeedback';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-pendingusers',
  templateUrl: './pendingusers.component.html',
  styleUrl: './pendingusers.component.css'
})
export class PendingusersComponent implements OnInit {
  constructor(private service: UserAccountService,private toast:NgToastService) {}
  UserDetails!: any;
  info!:IUpdatestatus
  feedbackmsg:any
  feedInfo!:IFeedback
  ngOnInit(): void {
    this.getAll()
  }
  UpdateStatus(id: number, emailid: string): void {
    this.info = {
      UserAccountId: id,
      Email: emailid
    };
  
    this.service.updateUserStatus(this.info).subscribe(
      (response) => {
        this.toast.success({detail:"SUUESS",summary:"User application approved",duration:2000});
        this.getAll();
      },
      (error) => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Unable to approve the application',
          duration: 3000
        });
      }
    );
  }
  deleteUser(id: number, emailid: string): void
  {
    this.feedbackmsg=prompt("Enter your feedback")
    console.log(this.feedbackmsg)
    this.feedInfo = {
      UserAccountId: id,
      Email: emailid,
      Feedback:this.feedbackmsg
    };
  
    this.service.deleteUserStatus(this.feedInfo).subscribe(
      (response) => {
        this.toast.success({detail:"SUUESS",summary:"User application rejected",duration:2000});
        this.getAll();
      },
      (error) => {
        this.toast.error({
          detail: "SORRY",
          summary: 'Unable to decline the application',
          duration: 3000
        });
      }
    );
    
  }

 getAll()
 {
  this.service.getUsers().subscribe((data) => {
    (this.UserDetails = data.filter(usr=>usr.IsActive===false));
  });
 }
}
