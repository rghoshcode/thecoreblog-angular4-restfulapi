import { Component, OnInit } from '@angular/core';
import {BlogService} from '../shared/blog.service';
import { NgForm } from '@angular/forms'





@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  constructor(private blogService : BlogService) 
  { 

  }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    
  }

  onSubmit(form: NgForm) {
    if (form.value.BlogId == null) 
    {
      this.blogService.postBlog(form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.blogService.getBlogList();
        
      }
      )
    
    }
    else {
      this.blogService.putBlog(form.value.BlogId, form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.blogService.getBlogList();
        
      });
    }
  }
  

}

