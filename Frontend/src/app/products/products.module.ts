import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductsHomeComponent } from './products-home/products-home.component';
import {MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './home/home.component';
import {MatCardModule} from '@angular/material/card';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { MatRippleModule } from '@angular/material/core';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { SearchResultComponent } from './search-result/search-result.component';
import { HotelsComponent } from './hotels/hotels.component';
import { RentalComponent } from './rental/rental.component';
import { FlightsComponent } from './flights/flights.component';
import { DiscoverComponent } from './discover/discover.component';
import { ProfileComponent } from './profile/profile.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ProductsHomeComponent,
    HomeComponent,
    SearchResultComponent,
    HotelsComponent,
    RentalComponent,
    FlightsComponent,
    DiscoverComponent,
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    MatTableModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule, MatSelectModule, MatInputModule, FormsModule,
    MatIconModule,
    MatGridListModule,
    MatDatepickerModule, MatNativeDateModule,
    MatRippleModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    ReactiveFormsModule
  ]
})
export class ProductsModule { }
