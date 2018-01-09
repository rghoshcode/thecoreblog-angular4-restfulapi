import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import {Blog} from './blog.model'

@Injectable()
export class BlogService {

  //adding a new property for the service
  selectedBlog : Blog;
  draftBlog : Blog;
  blogList : Blog[];
  showSelected: boolean;
  constructor(private http : Http) {
    this.showSelected = false;
    this.draftBlog =  {
      BlogId: Math.floor(Math.random() * 1000),
      BlogName: '',
      BlogAuthor: '',
      BlogContent: ''
      
    }
   }

  postBlog(blog : Blog){
    blog.BlogId = Math.floor(Math.random() * 1000);
    var body = JSON.stringify(blog);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('https://localhost:44337/api/Blog1',body,requestOptions).map(x => x.json());
    
      
  }

  putBlog(id, blog) {
    var body = JSON.stringify(blog);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('https://localhost:44337/api/blog1/' + id,
      body,
      requestOptions).map(res => res.json());
  }
  getBlogList(){
    this.http.get('https://localhost:44337/api/blog1')
    .map((data : Response) =>{
      return data.json() as Blog[];
    }).toPromise().then(x => {
      this.blogList = x;
    })
  }

  deleteBlog(id: number) {
    return this.http.delete('https://localhost:44337/api/blog1' + id).map(res => res.json());
  }

}
