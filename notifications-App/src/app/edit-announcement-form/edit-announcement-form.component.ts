import { Component } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-edit-announcement-form',
  templateUrl: './edit-announcement-form.component.html',
  styleUrls: ['./edit-announcement-form.component.scss']
})
export class EditAnnouncementFormComponent {
  title:string;
  author:string;
  imageUrl:string;
  message:string;
  announcement :Announcement;

  constructor (private announcementService: AnnouncementService,  private categoryService:CategoryService){
    categoryService.getCategories().subscribe(categories =>{ 
      this.categories = categories
      this.selectedCategory = this.categories.find(item => this.announcement.categoryId === item.id);
    })
    

    announcementService.getAnnouncementToEdit().subscribe(announcement => {this.announcement = announcement})
    this.title = this.announcement.title;
    this.author = this.announcement.author;
    this.imageUrl = this.announcement.imageUrl;
    this.message = this.announcement.message;

  }

  ngOnInit()
  {
    this.announcementService.serviceCall();
    
  }

  categories:Category[] = [];

    selectedCategory:Category = {
      id: "e",
      name:""
    };

    addAnouncement()
    {
      console.log(this.title);
      console.log(this.author);
      console.log(this.imageUrl);
      console.log(this.message);
      console.log(this.selectedCategory.name);

      this.announcement.title = this.title;
      this.announcement.author = this.author;
      this.announcement.categoryId = this.selectedCategory.id;
      this.announcement.imageUrl = this.imageUrl;
      this.announcement.message = this.message;
      this.announcementService.putEditedAnnouncement().subscribe();
    }
}
