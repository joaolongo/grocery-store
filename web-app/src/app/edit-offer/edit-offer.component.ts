import { Component } from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-edit-offer',
  templateUrl: './edit-offer.component.html',
  styleUrls: ['./edit-offer.component.scss']
})
export class EditOfferComponent {
  constructor(private formBuilder: FormBuilder, private router: Router,
              private http: HttpClient) {
  }

  public formGroup = this.formBuilder.group({
    description: '',
    percentage: 0,
    requiredAmount: 1,
    itemId: '',
    discountItemId: ''
  })

  public onSubmit(): void {
    debugger;
    this.http.post("https://localhost:7287/api/specialOffer", this.formGroup.getRawValue()).subscribe(value => {
      this.router.navigateByUrl('/offer');
    })
  }
}
