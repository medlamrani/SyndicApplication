import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { authGuard } from './_guards/auth.guard';
import { ResidentListComponent } from './residents/resident-list/resident-list.component';
import { ProjectListComponent } from './projects/project-list/project-list.component';
import { ProjectDetailComponent } from './projects/project-detail/project-detail.component';
import { ResidentDetailComponent } from './residents/resident-detail/resident-detail.component';
import { MessagesComponent } from './messages/messages.component';

export const routes: Routes = [
    {path: '',component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            {path: 'projects' ,component: ProjectListComponent},
            {path: 'projects/:id' ,component: ProjectDetailComponent},            
            {path: 'residents',component: ResidentListComponent},
            {path: 'residents/:id' ,component: ResidentDetailComponent},
            {path: 'messages' ,component: MessagesComponent}
        ]
    },
    {path: '**', component: HomeComponent, pathMatch: 'full'}
];
