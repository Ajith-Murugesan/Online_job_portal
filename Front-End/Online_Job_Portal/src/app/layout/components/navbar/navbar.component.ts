import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  usertypeid: number | null = null;
  userid: number | null = null;
  constructor(  private router: Router) {}
  ngOnInit() {
    const userTypeFromLocalStorage = localStorage.getItem('Type:');
    this.usertypeid = userTypeFromLocalStorage ? +userTypeFromLocalStorage : null;
    const useridFromLocalStorage = localStorage.getItem('id:');
    this.userid = useridFromLocalStorage ? +useridFromLocalStorage : null;
  }
  onLogout():void{
    localStorage.clear()
    // window.location.reload()
    this.router.navigate(['/landingpage']);
  }
}
