import { Component, OnInit } from '@angular/core';
import { HttpLoadingService } from '../core/services/data/http-loading.service';

@Component({
  selector: 'ai-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit {

  isLoading = this.loadingService.loading$;

  constructor(private loadingService: HttpLoadingService) { }

  ngOnInit(): void {
  }

}
