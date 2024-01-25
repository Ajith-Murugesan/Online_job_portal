import { Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
import { JobSeekerService } from '../services/job-seeker.service';
import { IInterviewInvite } from '../../employeer/jobpost/models/IInterviewInvite';

@Component({
  selector: 'app-interview-invites',
  templateUrl: './interview-invites.component.html',
  styleUrl: './interview-invites.component.css'
})
export class InterviewInvitesComponent implements OnInit {
  DeclinedInterviewInvites!:IInterviewInvite[]
  InterviewInvites!:IInterviewInvite[]
  AcceptedInterviewInvites!:IInterviewInvite[]
  constructor( private toast:NgToastService,private service: JobSeekerService) {}
  ngOnInit(): void {
   
    this.getAll()
  }
  onAccept(id:number):void{
    this.service.acceptInvite(id).subscribe(
      data => {
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Invite Accepted!',
          duration: 2000,
        });
      },
      error => {
        this.toast.error({
          detail: 'SORRY',
          summary: 'Unable to accept!',
          duration: 2000,
        });
      }
    );
    this.getAll
  }
  onDecline(id:number):void{
   if(confirm('Do you want to decline the invite ?'))
   {
    this.service.declineInvite(id).subscribe(
      data => {
        this.toast.success({
          detail: 'SUCCESS',
          summary: 'Invite Declined!',
          duration: 2000,
        });
      },
      error => {
        this.toast.error({
          detail: 'SORRY',
          summary: 'Unable to decline!',
          duration: 2000,
        });
      }
    );
   }
   this.getAll()
  }
  getAll()
  {
    if (typeof localStorage !== 'undefined')
    {
      this.service.getInterviewInviteById(localStorage.getItem('id:')).subscribe((data) => {
        this.DeclinedInterviewInvites = data.filter(dt=>dt.IsDeclined===true);
        this.AcceptedInterviewInvites = data.filter(dt=>dt.IsAccepetd===true && dt.IsDeclined===false);
        this.InterviewInvites= data.filter(dt=>dt.IsAccepetd===false && dt.IsDeclined===false);
      });
    }
  }
}
