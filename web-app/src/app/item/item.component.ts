import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

interface Item {
  id: string;
  name: string;
  price: number;
  hasOffer: boolean;
}

const ITEMS: Item[] = [
  {
    id: '5a164522-55fe-406d-8c0d-fe2907154b82',
    name: 'Soup',
    price: 0.80,
    hasOffer: false
  },
  {
    id: '3c27db6e-7a6b-4f72-b542-2d2353ecc2e5',
    name: 'Bread',
    price: 0.65,
    hasOffer: true
  },
  {
    id: '9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4',
    name: 'Apples',
    price: 1.00,
    hasOffer: true
  },
  {
    id: 'd7aeb3c3-8467-4e60-bec1-12ba88e59380',
    name: 'Milk',
    price: 1.30,
    hasOffer: false
  },
];


@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent{
  public items: any;

  constructor(private http: HttpClient) {

    this.http.get("https://localhost:7287/api/item").subscribe(value => {
      this.items = value;
    });
  }

}
