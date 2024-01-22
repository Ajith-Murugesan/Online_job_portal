import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  isOpen:boolean=false
  constructor(  private router: Router) {}
  toggleVisibility() {
    this.isOpen = !this.isOpen;
  }
  onLogout():void{
    localStorage.clear()
    this.router.navigate(['/landingpage']);
  }
}
