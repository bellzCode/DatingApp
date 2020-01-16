import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';


// Manually adding the heades has been over ridden by adding JWT token getter, so below code not necessary.

// const httpOptions = {
//   headers: new HttpHeaders({
//     Authorization: 'Bearer ' + localStorage.getItem('token')
//   })
// };

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;


constructor(private http: HttpClient) { }

// getUsers(): Observable<User[]> {
//   return this.http.get<User[]>(this.baseUrl + 'users', httpOptions);
// }
getUsers(): Observable<User[]> {
  return this.http.get<User[]>(this.baseUrl + 'users');
}

// getUser(id): Observable<User> {
//   return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);
// }

getUser(id): Observable<User> {
  return this.http.get<User>(this.baseUrl + 'users/' + id);
}

}


