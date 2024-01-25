import { Component, OnInit } from '@angular/core';
import { Router,NavigationEnd  } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  usertypeid: number | null = null;
  userid: number | null = null;

  constructor(private router: Router,private cdr: ChangeDetectorRef) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.updateUserTypeAndIdFromLocalStorage();
      }
    });
  }

  ngOnInit() {
    this.updateUserTypeAndIdFromLocalStorage();
    this.cdr.detectChanges();
  }

  private updateUserTypeAndIdFromLocalStorage() {
    if (typeof localStorage !== 'undefined') {
      const userTypeFromLocalStorage = localStorage.getItem('Type:');
      this.usertypeid = userTypeFromLocalStorage ? parseInt(userTypeFromLocalStorage, 10) : null;
  
      const useridFromLocalStorage = localStorage.getItem('id:');
      this.userid = useridFromLocalStorage ? parseInt(useridFromLocalStorage, 10) : null;
    }
  }
  onLogout(): void {
    localStorage.clear();
    this.router.navigate(['/landingpage']).then(() => {
      this.updateUserTypeAndIdFromLocalStorage();
    });
  }
}
