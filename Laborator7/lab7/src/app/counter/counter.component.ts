import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [],
  templateUrl: './counter.component.html',
  styleUrl: './counter.component.css'
})
export class CounterComponent {
  value : number = 0;

  increment() {
    this.value += 1;
  }

  decrement() {
    if (this.value >= 1) {
      this.value -= 1;
    }
  }

}
