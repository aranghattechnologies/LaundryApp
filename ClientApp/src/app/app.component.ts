import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, JsonpInterceptor } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,ReactiveFormsModule,CommonModule,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ClientApp';
  photo:any;
  form: FormGroup;

  constructor(private http:HttpClient)
  {
    this.form = new FormGroup({
      'Name': new FormControl(''),
      'Password': new FormControl(''),
      'Email': new FormControl(''),
      'Phone': new FormControl(''),
      'Address': new FormControl('')
    });
  }

  updateFile(event:any){
    console.log(event);
      if(event.target.files.length > 0)
      {
         this.photo = event.target.files[0];
         console.log("File Updatd");
      }
      else
        console.log("No file was selected");
  }

  onSubmit(){
    console.log(this.form.value);
    var formData = new FormData();
    formData.append("data",JSON.stringify(this.form.value));
    formData.append("photo",this.photo);

     this.http.post("http://localhost:5077/api/customer/signup"
     ,formData)
     .subscribe(o => console.log(o));
  }
}
