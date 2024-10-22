import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { Member } from "../_models/member";

@Injectable({
  providedIn: "root",
})
export class MembersService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;

  getMembers() {
    // return this.http.get<Member[]>(this.baseUrl + "appusers", this.getHttpOptions());
    return this.http.get<Member[]>(this.baseUrl + "appusers");
  }

  getMember(username: string) {
    // return this.http.get<Member>(this.baseUrl + "appusers/" + username, this.getHttpOptions());
    return this.http.get<Member>(this.baseUrl + "appusers/" + username);
  }

  // Not needed when we use jwt interceptor
  // getHttpOptions() {
  //   return {
  //     headers: new HttpHeaders({
  //       Authorization: `Bearer ${this.accountService.currentUser()?.token}`,
  //     }),
  //   };
  // }
}
