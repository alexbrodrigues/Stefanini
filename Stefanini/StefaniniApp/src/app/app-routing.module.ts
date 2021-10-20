import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { PersonComponent } from './person/person.component';

const routes: Routes = [
{path: 'person', component: PersonComponent, canActivate: [AuthGuard] },
{path: '', redirectTo: 'dashboard', pathMatch: 'full' },
{path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
