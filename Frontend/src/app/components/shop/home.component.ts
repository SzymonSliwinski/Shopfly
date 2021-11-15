import { AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { FlatTreeControl } from '@angular/cdk/tree';
import { Category } from 'src/app/models/shop-models/category.model';

interface Node {
  expandable: boolean;
  name: string;
  level: number;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLogged = true;
  showCategories = false;
  isLoaded = false;
  animateSidebar = false;
  treeControl = new FlatTreeControl<Node>(
    node => node.level,
    node => node.expandable,
  );
  hasChild = (_: number, node: Node) => node.expandable;

  private _transformer = (node: Category, level: number) => {
    return {
      expandable: !!node.childrensCategories && node.childrensCategories.length > 0,
      name: node.name,
      level: level,
    };
  };

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.childrensCategories,
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);
  @ViewChild('sidebar') sidebar!: SidebarComponent;

  constructor() {
    this.dataSource.data;
  }
  ngOnInit(): void {
    this.isLogged = this.checkIsLogged();
    this.dataSource.data = [
      {
        id: 1, name: 'kategoria 1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories:
          [
            {
              id: 2, name: 'kategoria 1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                { id: 6, name: 'kategoria 1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                {
                  id: 7, name: 'kategoria 1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                    {
                      id: 8, name: 'kategoria 1.1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: [
                        { id: 10, name: 'kategoria 1.1.1.1.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                        { id: 11, name: 'kategoria 1.1.1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                      ]
                    },
                    { id: 9, name: 'kategoria 1.1.1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
                  ]
                },
              ]
            },
            { id: 3, name: 'kategoria 1.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
          ]
      },
      {
        id: 3, name: 'kategoria 2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories:
          [
            { id: 4, name: 'kategoria 2.1', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
            { id: 5, name: 'kategoria 2.2', isRoot: true, parentCategoryId: null, position: 1, parentCategory: null, childrensCategories: null },
          ]
      }
    ]
    this.isLoaded = true;
  }

  checkIsLogged(): boolean {
    if (!sessionStorage.getItem(environment._shopStorageKey))
      return false;

    let storage =
      JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!) as { token: { expirationDate: Date; userId: number; value: string } };

    if (new Date().getTime() > new Date(storage.token.expirationDate).getTime())
      return false;

    return true;
  }

  toggleCategories() {
    this.showCategories = !this.showCategories;
    this.showCategories === true ? this.sidebar.toggle() : this.sidebar.hide();
  }

  onSidebarClose() {
    this.showCategories = false;
  }

  onSidebarInit() {
    this.sidebar.hide();
    this.animateSidebar = true;
  }
}
