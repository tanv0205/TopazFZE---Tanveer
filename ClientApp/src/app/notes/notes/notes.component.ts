import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Note } from 'src/app/home/home.component';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  public loadComponent:any[] = [];
  public notes:string[] = [];
  public noteList:Note[] = [];
  @Output() pushNotes = new EventEmitter<Note[]>();

  constructor() { }

  ngOnInit(): void {
  }

  // load component
  public addfield(e: Event) {
    e.preventDefault();
    this.loadComponent.push((this.loadComponent.length)+1);
  }

  public push(): void {

    this.noteList = this.notes
    .map(n=> ({
      noteDescription: n
    })as Note)
    .filter(n=>n.noteDescription!=null);

    this.pushNotes.emit(this.noteList);
    this.notes=[];
  }

}
