import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ItemComponent} from "./item/item.component";
import {EditItemComponent} from "./edit-item/edit-item.component";
import {OfferComponent} from "./offer/offer.component";
import {EditOfferComponent} from "./edit-offer/edit-offer.component";

const routes: Routes = [
  { path: 'item', component: ItemComponent },
  { path: 'item/edit/:id', component: EditItemComponent },
  { path: 'item/create', component: EditItemComponent },
  { path: 'item/details/:id', component: EditItemComponent },
  { path: 'offer', component: OfferComponent },
  { path: 'offer/edit/:id', component: EditOfferComponent },
  { path: 'offer/create', component: EditOfferComponent },
  { path: 'offer/details/:id', component: EditOfferComponent },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
