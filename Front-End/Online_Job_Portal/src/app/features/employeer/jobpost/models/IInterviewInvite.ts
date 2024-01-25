export interface IInterviewInvite {
  UserAccountId: number;
  JobPostId: number;
  InterviewId: number;
  LocationId: number;
  CompanyId: number;
  UserName: string;
  JobPosition: string;
  CompanyName: string;
  JobDescription: string;
  InterviewDate: any;
  InterviewTime: any;
  LocationName: string;
  Address: string;
  City: string;
  IsAccepetd: boolean;
  IsDeclined: boolean;
}
