import { Category } from "./category"

export interface Announcement {
  message:string;
  title:string; 
  author:string;
  categoryId:string;
  imageUrl:string;
  id:string;
}
