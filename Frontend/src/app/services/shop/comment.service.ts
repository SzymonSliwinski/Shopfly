import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Comment } from 'src/app/models/shop-models/comment.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CommentService {
    constructor(private _http: HttpClient) { }

    public async add(comment: Comment): Promise<Comment> {
        return this._http.post<Comment>(environment._shopApiUrl + 'shop/comment', comment).toPromise()
    }
}
