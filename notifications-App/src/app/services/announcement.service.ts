import { Injectable } from '@angular/core';
import { Announcement } from '../announcement';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { AnnouncementComponent } from '../announcement/announcement.component';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  private baseURL="https://localhost:7066"
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

  
  serviceCall() {
    console.log("Service was called");
   }
   
   constructor(private httpClient:HttpClient) {     
    this.getAnnouncements().subscribe(announcements => {this.announcements = announcements});
  }
   
   private announcements: Announcement[];

  getAnnouncements(): Observable<Announcement[]>
  {
    return this.httpClient.get<Announcement[]>(this.baseURL + "/Announcement");
  }

  addAnouncement(announcement:Announcement): Observable<Announcement>
  {
    return this.httpClient.post<Announcement>(this.baseURL + "/Announcement", announcement);
  }

  deleteAnnouncement(id:string)
  {
    return this.httpClient.delete<Announcement>(this.baseURL + "/Announcement/" + id);
  }

  selectedAnnouncement:Announcement;
  setAnnouncementToEdit(id:string)
  {
    this.selectedAnnouncement = this.announcements.find(item => item.id === id);
  }

  getAnnouncementToEdit() : Observable<Announcement>
  {
    return of(this.selectedAnnouncement);
  }

  putEditedAnnouncement()
  {
    return this.httpClient.put(this.baseURL + "/Announcement/"+ this.selectedAnnouncement.id, this.selectedAnnouncement)
  }
}
