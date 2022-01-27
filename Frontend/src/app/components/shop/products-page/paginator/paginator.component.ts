import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Params, Router } from "@angular/router";

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})

export class PaginatorComponent implements OnInit {
  @Input() pages!: number;
  @Input() actualPage!: number;
  startPage!: number;
  lastPage!: number;
  visiblePages: number[] = [];

  constructor(
    private readonly _router: Router,
    private _route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.setPagesRange();
    console.log(this.pages)

    for (let i = this.startPage; i <= this.lastPage; i++)
      this.visiblePages.push(i);
    this.actualPage = Number(this.actualPage);
  }

  redirectToPage(page: number): void {
    this._route.queryParams.subscribe(async (params: Params) => {
      if (params['category']) {
        this._router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
          this._router.navigate(
            [`/products/${page}`],
            { queryParams: { category: `${params['category']}` } }));
      }
    });
    window.scroll({
      top: 0,
      left: 0,
    });
  }

  private setPagesRange(): void {
    if (this.pages < 9) {
      this.lastPage = Number(this.pages);
      this.startPage = 1;
    }
    else {
      if (Number(this.actualPage) <= 5) {
        this.startPage = 1;
        this.lastPage = 9;
      }
      else if (Number(this.actualPage) + 4 >= Number(this.pages)) {
        this.startPage = Number(this.pages) - 8;
        this.lastPage = Number(this.pages);
      }
      else {
        this.startPage = Number(this.actualPage) - 4;
        this.lastPage = Number(this.actualPage) + 4;
      }
    }
  }
}