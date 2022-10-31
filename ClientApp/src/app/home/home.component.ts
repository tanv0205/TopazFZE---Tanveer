import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

export interface Category {
  id: number;
  name: string;
}

export interface SubCategory {
  id: number;
  name: string;
  categoryId: number;
}

export interface TicketRequest {
  categoryId: number;
  subCategoryId: number;
  description: string;
  notes: Note[];
  createdOn: Date;
}

export interface SavedRequest {
	category: string;
	subCategory: string;
	description: string;
	notes: string;
	createdOn: Date;
}

export interface Note {
	noteId: number;
	noteDescription: string;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  form: FormGroup = new FormGroup({
    category: new FormControl(),
    subCategory: new FormControl(),
    description: new FormControl()
  });

  // public fields
  public show: boolean = false;
  public categories: Category[] = [];
  public subCategoriesList: SubCategory[] = [];
  public subCategoriesFiltered: SubCategory[] = [];
  public receivedNotes: Note[] = [];
  public readonly baseUrl = "http://localhost:5230/api/TicketRequests";
  public savedRequests: SavedRequest[] = [];

  /**
   * constructor
   */
  constructor(private formBuilder: FormBuilder,
        	private http: HttpClient) {

  }

  // ngOnInit
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      category: [],
      subCategory: [],
      description: [null, Validators.required]
    });

    this.categories = [
        {id:1, name:"Software"},
        {id:2, name:"Hardware"},
        {id:3, name:"Salary Issue"}];
    
    this.subCategoriesList = [
        {id:1, name: "Installation", categoryId:1},
        {id:2, name: "Uninstallation", categoryId:1},
        {id:3, name: "Audio Issue", categoryId:2},
        {id:4, name: "Video ISsue", categoryId:2},
        {id:5, name: "Less Salary", categoryId:3},
        {id:6, name: "No Salary", categoryId:3}
    ];

	this.savedRequests = [
		{
			category: "Software",
			subCategory: "Installation",
			description: "Need Installation",
			notes: "kindly help",
			createdOn: new Date()
		},
		{
			category: "Hardware",
			subCategory: "Audio Issue",
			description: "Need Repair",
			notes: "kindly help",
			createdOn: new Date()
		}];

    this.form.get('category')?.setValue(1);
    this.onChange();
  }

  // public functions
  public toggle(): void {
    this.show = !this.show;
  }

  // onSubmit
  public onSubmit(): void {
    if (this.form.invalid) {
		alert("Description is required")
      return;
    }
    let request = {
      categoryId: this.form.get('category')?.value,
      subCategoryId: this.form.get('subCategory')?.value,
      description: this.form.get('description')?.value,
      notes: this.receivedNotes,
      createdOn: new Date()
    } as TicketRequest;
	console.log(request)

	this.http.post(this.baseUrl, request).subscribe(result=> {
		this.form.get('description')?.setValue('');
		alert("Added Successfully");
	});
  }

  // onChange
  public onChange() {
    let categoryId = this.form.get('category')?.value;
    this.subCategoriesFiltered = this.subCategoriesList.filter(sc => sc.categoryId == categoryId);
    this.form.get('subCategory')?.setValue(categoryId == 1 ? 1 : categoryId == 2 ? 3 : 5);
  }

  // refresh - get saved requests
  public refresh(): void {
	this.http.get<TicketRequest[]>(this.baseUrl).toPromise().then(result=>{
		this.savedRequests = this.savedRequests;
	});
  }

  public receiveNotes(notes: Note[]): void {
    this.receivedNotes = notes;
	console.log(this.receivedNotes)
  }
}
