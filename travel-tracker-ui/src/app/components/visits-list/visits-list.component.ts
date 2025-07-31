import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { VisitService } from '../../services/visit.service';

@Component({
  selector: 'app-visits-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './visits-list.component.html',
  styleUrl: './visits-list.component.css'
})
export class VisitsListComponent implements OnInit {
  visits: any[] = [];

  constructor(private visitService: VisitService) {}

  ngOnInit(): void {
      this.visitService.getVisits().subscribe(data => {
        this.visits = data;
      });
  }
}
