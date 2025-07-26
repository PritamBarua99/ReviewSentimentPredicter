import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrls: ['./app.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule]
})
export class AppComponent {
  comment = '';
  prediction: any;

  constructor(private http: HttpClient) {}

  getSentiment() {
    this.http.post('https://localhost:5070/Sentiment/PredictCustomerSentiment', { sentimentText: this.comment })
      .subscribe(result => {
        this.prediction = result;
      });
  }
}