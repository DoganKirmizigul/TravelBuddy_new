import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsHomeComponent } from './products-home/products-home.component';
import { HomeComponent } from './home/home.component';
import { SearchResultComponent } from './search-result/search-result.component';
import { HotelsComponent } from './hotels/hotels.component';
import { RentalComponent } from './rental/rental.component';
import { FlightsComponent } from './flights/flights.component';
import { DiscoverComponent } from './discover/discover.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [ {
  path:'',
  component: ProductsHomeComponent
},
{
  path: 'home', component: HomeComponent,
  title: 'Home',
},
{
  path: 'search-result', component: SearchResultComponent,
  title: 'Search results',
},
{
  path: 'hotels', component: HotelsComponent,
  title: 'Hotels',
},
{
  path: 'rental', component: RentalComponent,
  title: 'Rental',
},
{
  path: 'flights', component: FlightsComponent,
  title: 'Flights',
},
{
  path: 'discover', component: DiscoverComponent,
  title: 'Discover',
},
{
  path: 'profile', component: ProfileComponent,
  title: 'Profile',
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
