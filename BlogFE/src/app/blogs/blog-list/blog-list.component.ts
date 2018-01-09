import { Component, OnInit } from '@angular/core';
import {BlogService} from '../shared/blog.service';
import { NgForm } from '@angular/forms'
import {Blog} from '../shared/blog.model'
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-blog-list',
  templateUrl: './blog-list.component.html',
  styleUrls: ['./blog-list.component.css']
})
export class BlogListComponent implements OnInit {

  constructor(private blogService : BlogService) {
    
   }

  ngOnInit() {
         this.blogService.getBlogList();    
  }
  displayFullBlog(b: Blog) {
    this.blogService.selectedBlog = Object.assign({}, b);
    this.blogService.showSelected = true;
  }
  
}
