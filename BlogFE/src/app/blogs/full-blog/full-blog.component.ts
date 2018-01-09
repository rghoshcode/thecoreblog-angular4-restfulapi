import { Component, OnInit } from '@angular/core';
import {BlogService} from '../shared/blog.service';
import { NgForm } from '@angular/forms'
import {Blog} from '../shared/blog.model'

@Component({
  selector: 'app-full-blog',
  templateUrl: './full-blog.component.html',
  styleUrls: ['./full-blog.component.css']
})
export class FullBlogComponent implements OnInit {

  constructor(private blogService : BlogService) { }

  ngOnInit() {
    
  }

}
