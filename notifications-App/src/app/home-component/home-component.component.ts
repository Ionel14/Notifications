import { Component } from '@angular/core';
import { Announcement } from '../announcement';
import { Category } from '../category';
import { AnnouncementService } from '../services/announcement.service';
import { NotificationServiceService } from '../services/notification-service.service';

@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.scss']
})

export class HomeComponentComponent {

  constructor (private announcementService: AnnouncementService, private notificationService: NotificationServiceService){

    this.announcementService.getAnnouncements().subscribe(announcements => {
      this.announcements = announcements;
      this.filteredAnnouncements = this.announcements;  
    })    
 
  }


  notificationMessage:string;
  selectedCategory : Category;
  announcements:Announcement[];
  filteredAnnouncements: Announcement[];

  filterCategories(category: Category) {
    this.filteredAnnouncements = this.announcements.filter(announcement => announcement.categoryId === category.id);
  }

  resetCategories()
  {
    this.filteredAnnouncements = this.announcements;
  }

  ngOnInit()
  {
    this.announcementService.serviceCall();
    this.notificationService.initWebSocket();

    this.notificationService.notificationSubject.subscribe
    (hasNotifications => this.notificationMessage = hasNotifications ? "New notifications, please refresh the page" : "");
  }

  deleteAnnouncement(id:string)
  {
    this.announcementService.deleteAnnouncement(id).subscribe();
  }

  editAnnouncement(id:string)
  {
    this.announcementService.setAnnouncementToEdit(id);
  }
}
