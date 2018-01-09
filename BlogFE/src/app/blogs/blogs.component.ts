import { Component, OnInit } from '@angular/core';
import {BlogService} from './shared/blog.service'

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css'],
  providers: [BlogService]
})
export class BlogsComponent implements OnInit {

  showNew : boolean;
  constructor( private blogService : BlogService) {  this.showNew = false;}

  ngOnInit() { }

  showNewBlog(){  this.showNew = true; }
  hideNewBlog(){  this.showNew = false; }
  displayAllBlogs(){   this.blogService.showSelected = false; }
}
