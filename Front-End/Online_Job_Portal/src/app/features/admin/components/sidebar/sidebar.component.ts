import { Component } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  isOpen:boolean=false

  toggleVisibility() {
    this.isOpen = !this.isOpen;
  }
}
