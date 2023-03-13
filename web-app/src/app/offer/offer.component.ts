import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";

interface Offer {
  id: string;
  description: string;
  percentage: number;
  itemId: string;
  requiredAmount: number;
  discountItemId: string;
}

const OFFERS: Offer[] = [
  {
    id: '317f6f8f-b0df-44a7-b07d-05c8f2fcf02b',
    description: 'Apples have 10% off their normal price this week',
    percentage: 0.10,
    requiredAmount: 1,
    itemId: '9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4',
    discountItemId: ''
  },
  {
    id: '9faae3b7-2e49-4b7e-9fa3-74e8a259afe0',
    description: 'Buy 2 tins of soup and get a loaf of bread for half price',
    percentage: 0.50,
    requiredAmount: 1,
    itemId: '5a164522-55fe-406d-8c0d-fe2907154b82',
    discountItemId: '3c27db6e-7a6b-4f72-b542-2d2353ecc2e5'
  }
];


@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.scss']
})
export class OfferComponent {
  public offers: any;

  constructor(private http: HttpClient) {
    this.http.get("https://localhost:7287/api/specialOffer").subscribe(value => {
      this.offers = value;
    });
  }
}
