import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { VisitService } from '../../services/visit.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-visits-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './visits-list.component.html',
  styleUrl: './visits-list.component.css'
})
export class VisitsListComponent implements OnInit {
  visits: any[] = [];
  newVisit: any = { country: '', city: '', yearVisited: null };

  constructor(private visitService: VisitService) {}

  ngOnInit(): void {
      this.visitService.getVisits().subscribe(data => {
        this.visits = data;
      });
  }

  onSubmit(): void {
    this.visitService.addVisit(this.newVisit).subscribe(addedVisit => {
      this.visits.push(addedVisit);
      this.newVisit = { country: '', city: '', yearVisited: null };
    });
  }

  onDelete(id: number): void {
    this.visitService.deleteVisit(id).subscribe(() => {
      this.visits = this.visits.filter(v => v.id !== id);
    })
  }
}
