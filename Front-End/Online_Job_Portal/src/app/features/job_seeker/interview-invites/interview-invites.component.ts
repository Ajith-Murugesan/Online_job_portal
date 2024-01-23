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
  InterviewInvites!:IInterviewInvite[]
  constructor( private toast:NgToastService,private service: JobSeekerService) {}
  ngOnInit(): void {
   
    this.service.getInterviewInviteById(localStorage.getItem('id:')).subscribe((data) => {
      this.InterviewInvites = data;
      console.log(data)
    });
  }
}
