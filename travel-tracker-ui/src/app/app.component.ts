import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { VisitsListComponent } from "./components/visits-list/visits-list.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, VisitsListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'travel-tracker-ui';
}
