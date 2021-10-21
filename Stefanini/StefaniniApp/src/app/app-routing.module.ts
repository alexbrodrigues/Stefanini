import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { PersonComponent } from './person/person.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { PersonphoneComponent } from './personphone/personphone.component';
import { PhonenumbertypeComponent } from './phonenumbertype/phonenumbertype.component';

const routes: Routes = [
  {path: 'user', component: UserComponent,
  children: [
    {path: 'login', component: LoginComponent },
    {path: 'registration', component: RegistrationComponent }
  ]
},
{path: 'person', component: PersonComponent, canActivate: [AuthGuard] },
{path: 'personphone', component: PersonphoneComponent, canActivate: [AuthGuard]},
{path: 'phonenumbertype', component: PhonenumbertypeComponent, canActivate: [AuthGuard]},
{path: 'dashboard', component: DashboardComponent },
{path: '', redirectTo: 'dashboard', pathMatch: 'full' },
{path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
