import { Component, Input, OnInit } from '@angular/core';
import { AnnouncementService } from '../services/announcement.service';

@Component({
  selector: 'app-announcement',
  templateUrl: './announcement.component.html',
  template:`<h1>{{title}}</h1>
   <div>{{author}}</div>
   <div>{{message}}</div>`,
  styleUrls: ['./announcement.component.scss']
})
export class AnnouncementComponent implements  OnInit{
  @Input() message:string | undefined;
  @Input() title:string | undefined;
  @Input() author:string | undefined;
  @Input() imageUrl:string | undefined;
  

  constructor(private announcementService: AnnouncementService){}
  ngOnInit(): void {
  }
  getImageUrl(){
    return "url("+ this.imageUrl+")" 
  }
}
