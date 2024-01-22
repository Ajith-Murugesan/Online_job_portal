import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  usertypeid: number | null = null;

  ngOnInit() {
    const userTypeFromLocalStorage = localStorage.getItem('Type:');
    this.usertypeid = userTypeFromLocalStorage ? +userTypeFromLocalStorage : null;
  }
}
