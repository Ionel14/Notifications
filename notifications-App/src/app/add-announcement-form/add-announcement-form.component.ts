import { Component } from '@angular/core';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { Announcement } from '../announcement';
import { AnnouncementComponent } from '../announcement/announcement.component';
import { CategoryService } from '../services/category.service';
import { NotificationServiceService } from '../services/notification-service.service';

@Component({
  selector: 'app-add-announcement-form',
  templateUrl: './add-announcement-form.component.html',
  styleUrls: ['./add-announcement-form.component.scss']
})
export class AddAnnouncementFormComponent {
  title:string;
  author:string;
  imageUrl:string;
  message:string;

  constructor (private announcementService: AnnouncementService, private categoryService:CategoryService, private notificationService: NotificationServiceService){
    this.categoryService.getCategories().subscribe(categories => this.categories = categories)
  }
  ngOnInit()
  {
    this.announcementService.serviceCall();
    
  }

    categories:Category[];
    selectedCategory:Category;
    newAnnouncement :Announcement;
    addAnouncement()
    {
      console.log(this.title);
      console.log(this.author);
      console.log(this.imageUrl);
      console.log(this.message);
      console.log(this.selectedCategory.name);
      
      this.newAnnouncement = {
        title: this.title,
        author: this.author,
        categoryId: this.selectedCategory.id,
        imageUrl: this.imageUrl,
        message : this.message,
        id: "453"
      }
      this.announcementService.addAnouncement(this.newAnnouncement).subscribe(r => this.notificationService.sendMessage("BroadcastMessage", [r]));    }
}
