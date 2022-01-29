import { Component, Input, OnInit } from '@angular/core';
import { Comment } from 'src/app/models/shop-models/comment.model';
import { CommentService } from 'src/app/services/shop/comment.service';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss']
})
export class CommentsComponent implements OnInit {
  @Input() commentsList: Comment[] = [];
  @Input() productId!: number;
  newComment: Comment = {} as Comment;
  isLogged = false;
  constructor(
    private readonly _commentService: CommentService
  ) { }

  ngOnInit(): void {
    if (JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token)
      this.isLogged = true;
  }

  async onCommentSubmit() {
    if (this.newComment.content.length === 0)
      return;
    const userId = JSON.parse(sessionStorage.getItem(environment._shopStorageKey)!).token.userId;
    this.newComment.productId = this.productId;
    this.newComment.customerId = userId;
    this.commentsList.push(await this._commentService.add(this.newComment));
    this.newComment.content = '';

  }

}
