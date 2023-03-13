import { Component } from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.scss']
})
export class EditItemComponent {

  constructor(private formBuilder: FormBuilder, private router: Router,
              private http: HttpClient) {
  }

  public formGroup = this.formBuilder.group({
    name: '',
    price: 0
  })

  public onSubmit(): void {
    debugger;
    this.http.post("https://localhost:7287/api/item", this.formGroup.getRawValue()).subscribe(value => {
      this.router.navigateByUrl('/item');
    })
  }
}
