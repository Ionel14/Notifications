import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { AddAnnouncementFormComponent } from './add-announcement-form/add-announcement-form.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { EditAnnouncementFormComponent } from './edit-announcement-form/edit-announcement-form.component';


const routes:Routes = [{ path:'add', component:AddAnnouncementFormComponent}, 
{path:'', component:HomeComponentComponent, pathMatch:"full"}, 
{ path:'edit', component:EditAnnouncementFormComponent},
{path:'**',  component:HomeComponentComponent}]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)  
  ]
})

export class AppRoutingModule {
}
