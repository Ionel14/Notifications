import { outputAst } from '@angular/compiler';
import { EventEmitter, Output } from '@angular/core';
import { Component } from '@angular/core';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent {
  @Output()
  public selectedCategory = new EventEmitter<Category>();
  @Output()
  public signal = new EventEmitter<boolean>();

  
  constructor (private announcementService: AnnouncementService, private categoryService:CategoryService){
    this.categoryService.getCategories().subscribe(categories => this.categories = categories)
  }

  categories:Category[]
  
  
  public emitCategory(category)
  {
    this.selectedCategory.emit(category);
  }

  public resetFilters()
  {
    this.signal.emit();
  }
}
