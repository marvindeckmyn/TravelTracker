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

  editingVisitId: number | null = null;
  visitToEdit: any = {};

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

  onEdit(visit: any): void {
    this.editingVisitId = visit.id;
    this.visitToEdit = { ...visit };
  }

  onSave(visit: any): void {
    this.visitService.updateVisit(visit.id, this.visitToEdit).subscribe(() => {
      const index = this.visits.findIndex(v => v.id === visit.id);
      if (index !== -1) {
        this.visits[index] = this.visitToEdit;
      }
      this.onCancel();
    });
  }

  onCancel(): void {
    this.editingVisitId = null;
    this.visitToEdit = {};
  }
}
